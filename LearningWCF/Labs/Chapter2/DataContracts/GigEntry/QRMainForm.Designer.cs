namespace GigEntry
{
    partial class QRMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.qTabControl1 = new Qios.DevSuite.Components.QTabControl();
            this.qTabPage1 = new Qios.DevSuite.Components.QTabPage();
            this.qTabPage2 = new Qios.DevSuite.Components.QTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.qTabControl1)).BeginInit();
            this.qTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // qTabControl1
            // 
            this.qTabControl1.ActiveTabPage = this.qTabPage1;
            this.qTabControl1.Controls.Add(this.qTabPage1);
            this.qTabControl1.Controls.Add(this.qTabPage2);
            this.qTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.qTabControl1.Location = new System.Drawing.Point(0, 0);
            this.qTabControl1.Name = "qTabControl1";
            this.qTabControl1.PersistGuid = new System.Guid("a1f87c33-78a9-4539-be29-b221a374621a");
            this.qTabControl1.Size = new System.Drawing.Size(551, 405);
            this.qTabControl1.TabIndex = 0;
            this.qTabControl1.Text = "qTabControl1";
            // 
            // qTabPage1
            // 
            this.qTabPage1.ButtonOrder = 0;
            this.qTabPage1.Location = new System.Drawing.Point(0, 30);
            this.qTabPage1.Name = "qTabPage1";
            this.qTabPage1.PersistGuid = new System.Guid("7aaa1b3d-e9b3-4bc2-a955-d512ffa01ca2");
            this.qTabPage1.Size = new System.Drawing.Size(549, 373);
            this.qTabPage1.Text = "qTabPage1";
            // 
            // qTabPage2
            // 
            this.qTabPage2.ButtonOrder = 1;
            this.qTabPage2.Location = new System.Drawing.Point(0, 30);
            this.qTabPage2.Name = "qTabPage2";
            this.qTabPage2.PersistGuid = new System.Guid("863a2b2d-1f5b-458c-834d-a8d6e1a1d3a0");
            this.qTabPage2.Size = new System.Drawing.Size(549, 373);
            this.qTabPage2.Text = "qTabPage2";
            // 
            // QRMainForm
            // 
            this.Appearance.BackgroundStyle = Qios.DevSuite.Components.QColorStyle.Metallic;
            this.ClientSize = new System.Drawing.Size(551, 405);
            this.Controls.Add(this.qTabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "QRMainForm";
            this.Text = "QRMainForm";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.qTabControl1)).EndInit();
            this.qTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Qios.DevSuite.Components.QTabControl qTabControl1;
        private Qios.DevSuite.Components.QTabPage qTabPage1;
        private Qios.DevSuite.Components.QTabPage qTabPage2;
    }
}