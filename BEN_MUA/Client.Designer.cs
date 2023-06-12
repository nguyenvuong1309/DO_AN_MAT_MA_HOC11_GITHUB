namespace BEN_NGAN_HANG
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
            this.stop = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.connect = new System.Windows.Forms.Button();
            this.send = new System.Windows.Forms.Button();
            this.port = new System.Windows.Forms.TextBox();
            this.ip = new System.Windows.Forms.TextBox();
            this.send1 = new System.Windows.Forms.Button();
            this.signpdf = new System.Windows.Forms.Button();
            this.get_from_db = new System.Windows.Forms.Button();
            this.upload_to_db = new System.Windows.Forms.Button();
            this.choosefile = new System.Windows.Forms.Button();
            this.pdfViewer1 = new Spire.PdfViewer.Forms.PdfViewer();
            this.save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(439, 67);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 13;
            this.stop.Text = "stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(574, 137);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(148, 22);
            this.textBox2.TabIndex = 12;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(574, 93);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(148, 22);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "Nguyen duc vuong";
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(439, 20);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(75, 23);
            this.connect.TabIndex = 10;
            this.connect.Text = "connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(599, 21);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(75, 23);
            this.send.TabIndex = 9;
            this.send.Text = "send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(253, 21);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(100, 22);
            this.port.TabIndex = 8;
            this.port.Text = "8080";
            // 
            // ip
            // 
            this.ip.Location = new System.Drawing.Point(81, 21);
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(143, 22);
            this.ip.TabIndex = 7;
            this.ip.Text = "127.0.0.1";
            // 
            // send1
            // 
            this.send1.Location = new System.Drawing.Point(750, 287);
            this.send1.Name = "send1";
            this.send1.Size = new System.Drawing.Size(141, 31);
            this.send1.TabIndex = 32;
            this.send1.Text = "send";
            this.send1.UseVisualStyleBackColor = true;
            this.send1.Click += new System.EventHandler(this.send1_Click);
            // 
            // signpdf
            // 
            this.signpdf.Location = new System.Drawing.Point(750, 450);
            this.signpdf.Name = "signpdf";
            this.signpdf.Size = new System.Drawing.Size(141, 32);
            this.signpdf.TabIndex = 31;
            this.signpdf.Text = "Sign pdf";
            this.signpdf.UseVisualStyleBackColor = true;
            // 
            // get_from_db
            // 
            this.get_from_db.Location = new System.Drawing.Point(750, 385);
            this.get_from_db.Name = "get_from_db";
            this.get_from_db.Size = new System.Drawing.Size(141, 32);
            this.get_from_db.TabIndex = 30;
            this.get_from_db.Text = "get_from_db";
            this.get_from_db.UseVisualStyleBackColor = true;
            // 
            // upload_to_db
            // 
            this.upload_to_db.Location = new System.Drawing.Point(750, 336);
            this.upload_to_db.Name = "upload_to_db";
            this.upload_to_db.Size = new System.Drawing.Size(141, 34);
            this.upload_to_db.TabIndex = 29;
            this.upload_to_db.Text = "upload_to_db";
            this.upload_to_db.UseVisualStyleBackColor = true;
            // 
            // choosefile
            // 
            this.choosefile.Location = new System.Drawing.Point(750, 240);
            this.choosefile.Name = "choosefile";
            this.choosefile.Size = new System.Drawing.Size(141, 31);
            this.choosefile.TabIndex = 28;
            this.choosefile.Text = "choosefile";
            this.choosefile.UseVisualStyleBackColor = true;
            this.choosefile.Click += new System.EventHandler(this.choosefile_Click);
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.FindTextHighLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(153)))), ((int)(((byte)(193)))), ((int)(((byte)(218)))));
            this.pdfViewer1.FormFillEnabled = false;
            this.pdfViewer1.IgnoreCase = false;
            this.pdfViewer1.IsToolBarVisible = true;
            this.pdfViewer1.Location = new System.Drawing.Point(9, 160);
            this.pdfViewer1.MultiPagesThreshold = 60;
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.OnRenderPageExceptionEvent = null;
            this.pdfViewer1.Size = new System.Drawing.Size(735, 367);
            this.pdfViewer1.TabIndex = 27;
            this.pdfViewer1.Text = "pdfViewer1";
            this.pdfViewer1.Threshold = 60;
            this.pdfViewer1.ViewerBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(768, 136);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 33;
            this.save.Text = "save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.save);
            this.Controls.Add(this.send1);
            this.Controls.Add(this.signpdf);
            this.Controls.Add(this.get_from_db);
            this.Controls.Add(this.upload_to_db);
            this.Controls.Add(this.choosefile);
            this.Controls.Add(this.pdfViewer1);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.send);
            this.Controls.Add(this.port);
            this.Controls.Add(this.ip);
            this.Name = "Client";
            this.Size = new System.Drawing.Size(901, 536);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.TextBox ip;
        private System.Windows.Forms.Button send1;
        private System.Windows.Forms.Button signpdf;
        private System.Windows.Forms.Button get_from_db;
        private System.Windows.Forms.Button upload_to_db;
        private System.Windows.Forms.Button choosefile;
        private Spire.PdfViewer.Forms.PdfViewer pdfViewer1;
        private System.Windows.Forms.Button save;
    }
}
