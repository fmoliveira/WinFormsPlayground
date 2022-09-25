namespace WinFormsPlayground
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConnectRoku = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConnectRoku
            // 
            this.btnConnectRoku.Location = new System.Drawing.Point(10, 9);
            this.btnConnectRoku.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConnectRoku.Name = "btnConnectRoku";
            this.btnConnectRoku.Size = new System.Drawing.Size(150, 40);
            this.btnConnectRoku.TabIndex = 0;
            this.btnConnectRoku.Text = "Connect to Roku";
            this.btnConnectRoku.UseVisualStyleBackColor = true;
            this.btnConnectRoku.Click += new System.EventHandler(this.btnConnectRoku_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 338);
            this.Controls.Add(this.btnConnectRoku);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnConnectRoku;
    }
}