namespace BEN_NGAN_HANG
{
    partial class Server
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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.stop = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.send = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.port = new System.Windows.Forms.TextBox();
            this.send1 = new System.Windows.Forms.Button();
            this.signpdf = new System.Windows.Forms.Button();
            this.get_from_db = new System.Windows.Forms.Button();
            this.upload_to_db = new System.Windows.Forms.Button();
            this.choosefile = new System.Windows.Forms.Button();
            this.pdfViewer1 = new Spire.PdfViewer.Forms.PdfViewer();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(357, 94);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(190, 22);
            this.textBox2.TabIndex = 19;
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(245, 55);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 18;
            this.stop.Text = "stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(357, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 22);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = "server: nguyen duc vuong";
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(589, 55);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(75, 23);
            this.send.TabIndex = 16;
            this.send.Text = "send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(245, 26);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 15;
            this.start.Text = "start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(88, 26);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(100, 22);
            this.port.TabIndex = 14;
            this.port.Text = "8080";
            // 
            // send1
            // 
            this.send1.Location = new System.Drawing.Point(744, 196);
            this.send1.Name = "send1";
            this.send1.Size = new System.Drawing.Size(141, 31);
            this.send1.TabIndex = 31;
            this.send1.Text = "send";
            this.send1.UseVisualStyleBackColor = true;
            this.send1.Click += new System.EventHandler(this.send1_Click);
            // 
            // signpdf
            // 
            this.signpdf.Location = new System.Drawing.Point(744, 349);
            this.signpdf.Name = "signpdf";
            this.signpdf.Size = new System.Drawing.Size(141, 32);
            this.signpdf.TabIndex = 30;
            this.signpdf.Text = "Sign pdf";
            this.signpdf.UseVisualStyleBackColor = true;
            // 
            // get_from_db
            // 
            this.get_from_db.Location = new System.Drawing.Point(744, 284);
            this.get_from_db.Name = "get_from_db";
            this.get_from_db.Size = new System.Drawing.Size(141, 32);
            this.get_from_db.TabIndex = 29;
            this.get_from_db.Text = "get_from_db";
            this.get_from_db.UseVisualStyleBackColor = true;
            // 
            // upload_to_db
            // 
            this.upload_to_db.Location = new System.Drawing.Point(744, 233);
            this.upload_to_db.Name = "upload_to_db";
            this.upload_to_db.Size = new System.Drawing.Size(141, 34);
            this.upload_to_db.TabIndex = 28;
            this.upload_to_db.Text = "upload_to_db";
            this.upload_to_db.UseVisualStyleBackColor = true;
            // 
            // choosefile
            // 
            this.choosefile.Location = new System.Drawing.Point(744, 139);
            this.choosefile.Name = "choosefile";
            this.choosefile.Size = new System.Drawing.Size(141, 31);
            this.choosefile.TabIndex = 27;
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
            this.pdfViewer1.Location = new System.Drawing.Point(3, 122);
            this.pdfViewer1.MultiPagesThreshold = 60;
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.OnRenderPageExceptionEvent = null;
            this.pdfViewer1.Size = new System.Drawing.Size(735, 367);
            this.pdfViewer1.TabIndex = 26;
            this.pdfViewer1.Text = "pdfViewer1";
            this.pdfViewer1.Threshold = 60;
            this.pdfViewer1.ViewerBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.send1);
            this.Controls.Add(this.signpdf);
            this.Controls.Add(this.get_from_db);
            this.Controls.Add(this.upload_to_db);
            this.Controls.Add(this.choosefile);
            this.Controls.Add(this.pdfViewer1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.send);
            this.Controls.Add(this.start);
            this.Controls.Add(this.port);
            this.Name = "Server";
            this.Size = new System.Drawing.Size(901, 495);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.Button send1;
        private System.Windows.Forms.Button signpdf;
        private System.Windows.Forms.Button get_from_db;
        private System.Windows.Forms.Button upload_to_db;
        private System.Windows.Forms.Button choosefile;
        private Spire.PdfViewer.Forms.PdfViewer pdfViewer1;
    }
}
