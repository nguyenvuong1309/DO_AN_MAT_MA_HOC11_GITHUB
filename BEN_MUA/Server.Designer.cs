namespace BEN_MUA
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
            this.Verify = new System.Windows.Forms.Button();
            this.Sign = new System.Windows.Forms.Button();
            this.uploadToDb = new System.Windows.Forms.Button();
            this.choosefile = new System.Windows.Forms.Button();
            this.pdfViewer1 = new Spire.PdfViewer.Forms.PdfViewer();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(321, 98);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(190, 22);
            this.textBox2.TabIndex = 38;
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(157, 83);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 37;
            this.stop.Text = "stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(321, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 22);
            this.textBox1.TabIndex = 36;
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(400, 20);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(75, 23);
            this.send.TabIndex = 35;
            this.send.Text = "send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(157, 35);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 34;
            this.start.Text = "start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(38, 36);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(100, 22);
            this.port.TabIndex = 33;
            this.port.Text = "8080";
            // 
            // Verify
            // 
            this.Verify.Location = new System.Drawing.Point(867, 365);
            this.Verify.Name = "Verify";
            this.Verify.Size = new System.Drawing.Size(116, 23);
            this.Verify.TabIndex = 78;
            this.Verify.Text = "Verify";
            this.Verify.UseVisualStyleBackColor = true;
            this.Verify.Click += new System.EventHandler(this.Verify_Click);
            // 
            // Sign
            // 
            this.Sign.Location = new System.Drawing.Point(867, 327);
            this.Sign.Name = "Sign";
            this.Sign.Size = new System.Drawing.Size(116, 23);
            this.Sign.TabIndex = 77;
            this.Sign.Text = "Sign";
            this.Sign.UseVisualStyleBackColor = true;
            this.Sign.Click += new System.EventHandler(this.Sign_Click);
            // 
            // uploadToDb
            // 
            this.uploadToDb.Location = new System.Drawing.Point(870, 486);
            this.uploadToDb.Name = "uploadToDb";
            this.uploadToDb.Size = new System.Drawing.Size(116, 23);
            this.uploadToDb.TabIndex = 76;
            this.uploadToDb.Text = "upload_to_db";
            this.uploadToDb.UseVisualStyleBackColor = true;
            this.uploadToDb.Click += new System.EventHandler(this.uploadToDb_Click);
            // 
            // choosefile
            // 
            this.choosefile.Location = new System.Drawing.Point(867, 187);
            this.choosefile.Name = "choosefile";
            this.choosefile.Size = new System.Drawing.Size(104, 23);
            this.choosefile.TabIndex = 75;
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
            this.pdfViewer1.Location = new System.Drawing.Point(19, 139);
            this.pdfViewer1.MultiPagesThreshold = 60;
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.OnRenderPageExceptionEvent = null;
            this.pdfViewer1.Size = new System.Drawing.Size(819, 370);
            this.pdfViewer1.TabIndex = 79;
            this.pdfViewer1.Text = "pdfViewer1";
            this.pdfViewer1.Threshold = 60;
            this.pdfViewer1.ViewerBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
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
            this.Size = new System.Drawing.Size(1000, 530);
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
        private System.Windows.Forms.Button Verify;
        private System.Windows.Forms.Button Sign;
        private System.Windows.Forms.Button uploadToDb;
        private System.Windows.Forms.Button choosefile;
        private Spire.PdfViewer.Forms.PdfViewer pdfViewer1;
    }
}
