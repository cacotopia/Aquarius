namespace WinClient
{
   partial class Form1
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
          this.button1 = new System.Windows.Forms.Button();
          this.groupBox1 = new System.Windows.Forms.GroupBox();
          this.radWSHttpSecureSession = new System.Windows.Forms.RadioButton();
          this.radWSHttpReliableSession = new System.Windows.Forms.RadioButton();
          this.radNetTcp = new System.Windows.Forms.RadioButton();
          this.radNetPipe = new System.Windows.Forms.RadioButton();
          this.radWSHttpNoSession = new System.Windows.Forms.RadioButton();
          this.radBasicHttp = new System.Windows.Forms.RadioButton();
          this.button2 = new System.Windows.Forms.Button();
          this.button3 = new System.Windows.Forms.Button();
          this.groupBox1.SuspendLayout();
          this.SuspendLayout();
          // 
          // button1
          // 
          this.button1.Location = new System.Drawing.Point(279, 29);
          this.button1.Name = "button1";
          this.button1.Size = new System.Drawing.Size(119, 23);
          this.button1.TabIndex = 0;
          this.button1.Text = "No Exception";
          this.button1.UseVisualStyleBackColor = true;
          this.button1.Click += new System.EventHandler(this.button1_Click);
          // 
          // groupBox1
          // 
          this.groupBox1.Controls.Add(this.radWSHttpSecureSession);
          this.groupBox1.Controls.Add(this.radWSHttpReliableSession);
          this.groupBox1.Controls.Add(this.radNetTcp);
          this.groupBox1.Controls.Add(this.radNetPipe);
          this.groupBox1.Controls.Add(this.radWSHttpNoSession);
          this.groupBox1.Controls.Add(this.radBasicHttp);
          this.groupBox1.Location = new System.Drawing.Point(13, 13);
          this.groupBox1.Name = "groupBox1";
          this.groupBox1.Size = new System.Drawing.Size(248, 174);
          this.groupBox1.TabIndex = 3;
          this.groupBox1.TabStop = false;
          this.groupBox1.Text = "Binding";
          // 
          // radWSHttpSecureSession
          // 
          this.radWSHttpSecureSession.AutoSize = true;
          this.radWSHttpSecureSession.Location = new System.Drawing.Point(17, 68);
          this.radWSHttpSecureSession.Name = "radWSHttpSecureSession";
          this.radWSHttpSecureSession.Size = new System.Drawing.Size(181, 17);
          this.radWSHttpSecureSession.TabIndex = 5;
          this.radWSHttpSecureSession.TabStop = true;
          this.radWSHttpSecureSession.Text = "WSHttpBinding (Secure Session)";
          this.radWSHttpSecureSession.UseVisualStyleBackColor = true;
          // 
          // radWSHttpReliableSession
          // 
          this.radWSHttpReliableSession.AutoSize = true;
          this.radWSHttpReliableSession.Location = new System.Drawing.Point(17, 91);
          this.radWSHttpReliableSession.Name = "radWSHttpReliableSession";
          this.radWSHttpReliableSession.Size = new System.Drawing.Size(185, 17);
          this.radWSHttpReliableSession.TabIndex = 4;
          this.radWSHttpReliableSession.TabStop = true;
          this.radWSHttpReliableSession.Text = "WSHttpBinding (Reliable Session)";
          this.radWSHttpReliableSession.UseVisualStyleBackColor = true;
          // 
          // radNetTcp
          // 
          this.radNetTcp.AutoSize = true;
          this.radNetTcp.Location = new System.Drawing.Point(17, 137);
          this.radNetTcp.Name = "radNetTcp";
          this.radNetTcp.Size = new System.Drawing.Size(96, 17);
          this.radNetTcp.TabIndex = 3;
          this.radNetTcp.TabStop = true;
          this.radNetTcp.Text = "NetTcpBinding";
          this.radNetTcp.UseVisualStyleBackColor = true;
          // 
          // radNetPipe
          // 
          this.radNetPipe.AutoSize = true;
          this.radNetPipe.Location = new System.Drawing.Point(17, 114);
          this.radNetPipe.Name = "radNetPipe";
          this.radNetPipe.Size = new System.Drawing.Size(132, 17);
          this.radNetPipe.TabIndex = 2;
          this.radNetPipe.TabStop = true;
          this.radNetPipe.Text = "NetNamedPipeBinding";
          this.radNetPipe.UseVisualStyleBackColor = true;
          // 
          // radWSHttpNoSession
          // 
          this.radWSHttpNoSession.AutoSize = true;
          this.radWSHttpNoSession.Location = new System.Drawing.Point(17, 45);
          this.radWSHttpNoSession.Name = "radWSHttpNoSession";
          this.radWSHttpNoSession.Size = new System.Drawing.Size(161, 17);
          this.radWSHttpNoSession.TabIndex = 1;
          this.radWSHttpNoSession.TabStop = true;
          this.radWSHttpNoSession.Text = "WSHttpBinding (No Session)";
          this.radWSHttpNoSession.UseVisualStyleBackColor = true;
          // 
          // radBasicHttp
          // 
          this.radBasicHttp.AutoSize = true;
          this.radBasicHttp.Location = new System.Drawing.Point(17, 22);
          this.radBasicHttp.Name = "radBasicHttp";
          this.radBasicHttp.Size = new System.Drawing.Size(106, 17);
          this.radBasicHttp.TabIndex = 0;
          this.radBasicHttp.TabStop = true;
          this.radBasicHttp.Text = "BasicHttpBinding";
          this.radBasicHttp.UseVisualStyleBackColor = true;
          // 
          // button2
          // 
          this.button2.Location = new System.Drawing.Point(279, 58);
          this.button2.Name = "button2";
          this.button2.Size = new System.Drawing.Size(119, 23);
          this.button2.TabIndex = 7;
          this.button2.Text = "Exception";
          this.button2.UseVisualStyleBackColor = true;
          this.button2.Click += new System.EventHandler(this.button2_Click);
          // 
          // button3
          // 
          this.button3.Location = new System.Drawing.Point(279, 87);
          this.button3.Name = "button3";
          this.button3.Size = new System.Drawing.Size(119, 23);
          this.button3.TabIndex = 10;
          this.button3.Text = "Fault";
          this.button3.UseVisualStyleBackColor = true;
          this.button3.Click += new System.EventHandler(this.button3_Click);
          // 
          // Form1
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(407, 197);
          this.Controls.Add(this.button3);
          this.Controls.Add(this.button2);
          this.Controls.Add(this.groupBox1);
          this.Controls.Add(this.button1);
          this.Name = "Form1";
          this.Text = "Instancing";
          this.groupBox1.ResumeLayout(false);
          this.groupBox1.PerformLayout();
          this.ResumeLayout(false);

      }

      #endregion

       private System.Windows.Forms.Button button1;
       private System.Windows.Forms.GroupBox groupBox1;
       private System.Windows.Forms.RadioButton radNetTcp;
       private System.Windows.Forms.RadioButton radNetPipe;
       private System.Windows.Forms.RadioButton radWSHttpNoSession;
       private System.Windows.Forms.RadioButton radBasicHttp;
       private System.Windows.Forms.RadioButton radWSHttpSecureSession;
       private System.Windows.Forms.RadioButton radWSHttpReliableSession;
       private System.Windows.Forms.Button button2;
       private System.Windows.Forms.Button button3;
   }
}

