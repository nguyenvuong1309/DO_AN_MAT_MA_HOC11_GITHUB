namespace BEN_TRUNG_GIAN
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
            this.get = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.choosefile = new System.Windows.Forms.Button();
            this.pdfViewer1 = new Spire.PdfViewer.Forms.PdfViewer();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.stop = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.send = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.port = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // get
            // 
            this.get.Location = new System.Drawing.Point(557, 44);
            this.get.Name = "get";
            this.get.Size = new System.Drawing.Size(75, 23);
            this.get.TabIndex = 46;
            this.get.Text = "get";
            this.get.UseVisualStyleBackColor = true;
            this.get.Click += new System.EventHandler(this.get_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(557, 93);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 45;
            this.save.Text = "save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // choosefile
            // 
            this.choosefile.Location = new System.Drawing.Point(774, 151);
            this.choosefile.Name = "choosefile";
            this.choosefile.Size = new System.Drawing.Size(117, 23);
            this.choosefile.TabIndex = 44;
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
            this.pdfViewer1.Location = new System.Drawing.Point(9, 121);
            this.pdfViewer1.MultiPagesThreshold = 60;
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.OnRenderPageExceptionEvent = null;
            this.pdfViewer1.Size = new System.Drawing.Size(750, 358);
            this.pdfViewer1.TabIndex = 43;
            this.pdfViewer1.Text = "pdfViewer1";
            this.pdfViewer1.Threshold = 60;
            this.pdfViewer1.ViewerBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(350, 93);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(190, 22);
            this.textBox2.TabIndex = 42;
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(186, 78);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 41;
            this.stop.Text = "stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(350, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 22);
            this.textBox1.TabIndex = 40;
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(429, 15);
            this.send.Name = "send";
            this.send.Size = new System.Drawing.Size(75, 23);
            this.send.TabIndex = 39;
            this.send.Text = "send";
            this.send.UseVisualStyleBackColor = true;
            this.send.Click += new System.EventHandler(this.send_Click);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(186, 31);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 38;
            this.start.Text = "start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(67, 31);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(100, 22);
            this.port.TabIndex = 37;
            this.port.Text = "8080";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.get);
            this.Controls.Add(this.save);
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

        private System.Windows.Forms.Button get;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button choosefile;
        private Spire.PdfViewer.Forms.PdfViewer pdfViewer1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button send;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.TextBox port;
    }
}
