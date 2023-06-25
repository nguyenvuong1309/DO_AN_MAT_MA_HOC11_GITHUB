namespace BEN_VAN_CHUYEN
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
            this.pdfViewer1 = new Spire.PdfViewer.Forms.PdfViewer();
            this.Verify = new System.Windows.Forms.Button();
            this.Sign = new System.Windows.Forms.Button();
            this.uploadToDb = new System.Windows.Forms.Button();
            this.choosefile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(316, 92);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(190, 22);
            this.textBox2.TabIndex = 44;
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(152, 77);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 43;
            this.stop.Text = "stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(316, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 22);
            this.textBox1.TabIndex = 42;
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(395, 14);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(75, 23);
            this.send.TabIndex = 41;
            this.send.Text = "send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(152, 29);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 40;
            this.start.Text = "start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(33, 30);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(100, 22);
            this.port.TabIndex = 39;
            this.port.Text = "8080";
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.FindTextHighLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(153)))), ((int)(((byte)(193)))), ((int)(((byte)(218)))));
            this.pdfViewer1.FormFillEnabled = false;
            this.pdfViewer1.IgnoreCase = false;
            this.pdfViewer1.IsToolBarVisible = true;
            this.pdfViewer1.Location = new System.Drawing.Point(12, 120);
            this.pdfViewer1.MultiPagesThreshold = 60;
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.OnRenderPageExceptionEvent = null;
            this.pdfViewer1.Size = new System.Drawing.Size(838, 399);
            this.pdfViewer1.TabIndex = 64;
            this.pdfViewer1.Text = "pdfViewer1";
            this.pdfViewer1.Threshold = 60;
            this.pdfViewer1.ViewerBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            // 
            // Verify
            // 
            this.Verify.Location = new System.Drawing.Point(853, 358);
            this.Verify.Name = "Verify";
            this.Verify.Size = new System.Drawing.Size(116, 23);
            this.Verify.TabIndex = 63;
            this.Verify.Text = "Verify";
            this.Verify.UseVisualStyleBackColor = true;
            // 
            // Sign
            // 
            this.Sign.Location = new System.Drawing.Point(853, 320);
            this.Sign.Name = "Sign";
            this.Sign.Size = new System.Drawing.Size(116, 23);
            this.Sign.TabIndex = 62;
            this.Sign.Text = "Sign";
            this.Sign.UseVisualStyleBackColor = true;
            this.Sign.Click += new System.EventHandler(this.Sign_Click);
            // 
            // uploadToDb
            // 
            this.uploadToDb.Location = new System.Drawing.Point(856, 479);
            this.uploadToDb.Name = "uploadToDb";
            this.uploadToDb.Size = new System.Drawing.Size(116, 23);
            this.uploadToDb.TabIndex = 61;
            this.uploadToDb.Text = "upload_to_db";
            this.uploadToDb.UseVisualStyleBackColor = true;
            this.uploadToDb.Click += new System.EventHandler(this.uploadToDb_Click);
            // 
            // choosefile
            // 
            this.choosefile.Location = new System.Drawing.Point(853, 180);
            this.choosefile.Name = "choosefile";
            this.choosefile.Size = new System.Drawing.Size(104, 23);
            this.choosefile.TabIndex = 60;
            this.choosefile.Text = "choosefile";
            this.choosefile.UseVisualStyleBackColor = true;
            this.choosefile.Click += new System.EventHandler(this.choosefile_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pdfViewer1);
            this.Controls.Add(this.Verify);
            this.Controls.Add(this.Sign);
            this.Controls.Add(this.uploadToDb);
            this.Controls.Add(this.choosefile);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.stop);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.send);
            this.Controls.Add(this.start);
            this.Controls.Add(this.port);
            this.Name = "Server";
            this.Size = new System.Drawing.Size(987, 525);
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
        private Spire.PdfViewer.Forms.PdfViewer pdfViewer1;
        private System.Windows.Forms.Button Verify;
        private System.Windows.Forms.Button Sign;
        private System.Windows.Forms.Button uploadToDb;
        private System.Windows.Forms.Button choosefile;
    }
}
