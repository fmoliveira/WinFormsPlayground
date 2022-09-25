using System.Diagnostics;

namespace WinFormsPlayground
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnConnectRoku_Click(object sender, EventArgs e)
        {
            //var roku = new RokuControl();
            //roku.sendRokuMulticast();

            //var roku = new UpnPDevDiscovery();
            //roku.FindDevices();

            var roku = new RokuControlCopy();
            roku.sendRokuMulticast();
        }
    }
}