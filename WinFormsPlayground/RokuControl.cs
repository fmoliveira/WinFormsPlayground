using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsPlayground
{
    internal class RokuControl
    {
        private Socket? socket;

        internal void sendRokuMulticast()
        {
            var multicastIP = "239.255.255.250";
            var multicastPort = 1900;
            var searchTimeout = 5;
            var mSearch = "M-SEARCH * HTTP/1.1\nHost: 239.255.255.250:1900\nMan: \"ssdp:discover\"\nST: roku:ecp\n";
            var requestData = Encoding.UTF8.GetBytes(mSearch);

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.SendBufferSize = requestData.Length;

            var sendEvent = new SocketAsyncEventArgs();
            sendEvent.RemoteEndPoint = new IPEndPoint(IPAddress.Parse(multicastIP), multicastPort);
            sendEvent.SetBuffer(requestData, 0, requestData.Length);
            sendEvent.Completed += SendEvent_Completed;

            var timeout = new System.Timers.Timer(TimeSpan.FromSeconds(searchTimeout + 1).TotalMilliseconds);
            timeout.Elapsed += (e, s) =>
            {
                socket?.Dispose();
                socket = null;
            };

            socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastInterface, IPAddress.Parse(multicastIP).GetAddressBytes());
            socket.SendToAsync(sendEvent);
            timeout.Start();
        }

        private void SendEvent_Completed(object? sender, SocketAsyncEventArgs e)
        {
            if (e.SocketError != SocketError.Success)
            {
                Debug.WriteLine("SocketError: " + e.SocketError);
                return;
            }

            switch (e.LastOperation) {
                case SocketAsyncOperation.SendTo:
                    e.RemoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    var receiveBuffer = new byte[8096];
                    socket!.ReceiveBufferSize = receiveBuffer.Length;
                    e.SetBuffer(receiveBuffer, 0, receiveBuffer.Length);
                    socket.ReceiveFromAsync(e);
                    break;

                case SocketAsyncOperation.ReceiveFrom:
                    var result = Encoding.UTF8.GetString(e.Buffer!, 0, e.BytesTransferred);
                    if (result.StartsWith("HTTP/1.1 200 OK", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Debug.WriteLine(result);
                    }
                    if (socket != null)
                    {
                        socket.ReceiveFromAsync(e);
                    }
                    break;

                default:
                    Debug.WriteLine("Last operation: " + e.LastOperation);
                    break;
            }
        }
    }
}
