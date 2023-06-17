namespace BEN_TRUNG_GIAN
{
    partial class Client
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.save = new System.Windows.Forms.Button();
            this.choosefile = new System.Windows.Forms.Button();
            this.get = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.connect = new System.Windows.Forms.Button();
            this.send = new System.Windows.Forms.Button();
            this.port = new System.Windows.Forms.TextBox();
            this.ip = new System.Windows.Forms.TextBox();
            this.pdfViewer1 = new Spire.PdfViewer.Forms.PdfViewer();
            this.Sign = new System.Windows.Forms.Button();
            this.upload_to_db = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(690, 91);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 48;
            this.save.Text = "save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // choosefile
            // 
            this.choosefile.Location = new System.Drawing.Point(774, 157);
            this.choosefile.Name = "choosefile";
            this.choosefile.Size = new System.Drawing.Size(104, 23);
            this.choosefile.TabIndex = 47;
            this.choosefile.Text = "choosefile";
            this.choosefile.UseVisualStyleBackColor = true;
            this.choosefile.Click += new System.EventHandler(this.choosefile_Click);
            // 
            // get
            // 
            this.get.Location = new System.Drawing.Point(690, 52);
            this.get.Name = "get";
            this.get.Size = new System.Drawing.Size(75, 23);
            this.get.TabIndex = 46;
            this.get.Text = "get";
            this.get.UseVisualStyleBackColor = true;
            this.get.Click += new System.EventHandler(this.get_Click);
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(393, 73);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 45;
            this.stop.Text = "stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(526, 91);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(148, 22);
            this.textBox2.TabIndex = 44;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(526, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(148, 22);
            this.textBox1.TabIndex = 43;
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(393, 26);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(75, 23);
            this.connect.TabIndex = 42;
            this.connect.Text = "connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(553, 9);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(75, 23);
            this.send.TabIndex = 41;
            this.send.Text = "send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(207, 27);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(100, 22);
            this.port.TabIndex = 40;
            this.port.Text = "8080";
            // 
            // ip
            // 
            this.ip.Location = new System.Drawing.Point(35, 27);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(143, 22);
            this.ip.TabIndex = 39;
            this.ip.Text = "127.0.0.1";
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.FindTextHighLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(153)))), ((int)(((byte)(193)))), ((int)(((byte)(218)))));
            this.pdfViewer1.FormFillEnabled = false;
            this.pdfViewer1.IgnoreCase = false;
            this.pdfViewer1.IsToolBarVisible = true;
            this.pdfViewer1.Location = new System.Drawing.Point(21, 132);
            this.pdfViewer1.MultiPagesThreshold = 60;
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.OnRenderPageExceptionEvent = null;
            this.pdfViewer1.Size = new System.Drawing.Size(744, 351);
            this.pdfViewer1.TabIndex = 49;
            this.pdfViewer1.Text = "pdfViewer1";
            this.pdfViewer1.Threshold = 60;
            this.pdfViewer1.ViewerBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            // 
            // Sign
            // 
            this.Sign.Location = new System.Drawing.Point(774, 261);
            this.Sign.Name = "Sign";
            this.Sign.Size = new System.Drawing.Size(104, 23);
            this.Sign.TabIndex = 50;
            this.Sign.Text = "Sign";
            this.Sign.UseVisualStyleBackColor = true;
            this.Sign.Click += new System.EventHandler(this.Sign_Click);
            // 
            // upload_to_db
            // 
            this.upload_to_db.Location = new System.Drawing.Point(774, 445);
            this.upload_to_db.Name = "upload_to_db";
            this.upload_to_db.Size = new System.Drawing.Size(124, 23);
            this.upload_to_db.TabIndex = 51;
            this.upload_to_db.Text = "upload_to_db";
            this.upload_to_db.UseVisualStyleBackColor = true;
            this.upload_to_db.Click += new System.EventHandler(this.upload_to_db_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.upload_to_db);
            this.Controls.Add(this.Sign);
            this.Controls.Add(this.pdfViewer1);
            this.Controls.Add(this.save);
            this.Controls.Add(this.choosefile);
            this.Controls.Add(this.get);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.send);
            this.Controls.Add(this.port);
            this.Controls.Add(this.ip);
            this.Name = "Client";
            this.Size = new System.Drawing.Size(901, 495);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button choosefile;
        private System.Windows.Forms.Button get;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.TextBox ip;
        private Spire.PdfViewer.Forms.PdfViewer pdfViewer1;
        private System.Windows.Forms.Button Sign;
        private System.Windows.Forms.Button upload_to_db;
    }
}
