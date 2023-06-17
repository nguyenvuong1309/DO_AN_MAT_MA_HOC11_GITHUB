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
            this.choosefile = new System.Windows.Forms.Button();
            this.pdfViewer1 = new Spire.PdfViewer.Forms.PdfViewer();
            this.save = new System.Windows.Forms.Button();
            this.get = new System.Windows.Forms.Button();
            this.upload_to_db = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(357, 118);
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
            this.textBox1.Location = new System.Drawing.Point(357, 69);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 22);
            this.textBox1.TabIndex = 17;
            // 
            // send
            // 
            this.send.Location = new System.Drawing.Point(435, 26);
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
            // choosefile
            // 
            this.choosefile.Location = new System.Drawing.Point(781, 176);
            this.choosefile.Name = "choosefile";
            this.choosefile.Size = new System.Drawing.Size(117, 23);
            this.choosefile.TabIndex = 24;
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
            this.pdfViewer1.Location = new System.Drawing.Point(3, 146);
            this.pdfViewer1.MultiPagesThreshold = 60;
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.OnRenderPageExceptionEvent = null;
            this.pdfViewer1.Size = new System.Drawing.Size(763, 379);
            this.pdfViewer1.TabIndex = 23;
            this.pdfViewer1.Text = "pdfViewer1";
            this.pdfViewer1.Threshold = 60;
            this.pdfViewer1.ViewerBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(587, 117);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 25;
            this.save.Text = "save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // get
            // 
            this.get.Location = new System.Drawing.Point(587, 69);
            this.get.Name = "get";
            this.get.Size = new System.Drawing.Size(75, 23);
            this.get.TabIndex = 26;
            this.get.Text = "get";
            this.get.UseVisualStyleBackColor = true;
            this.get.Click += new System.EventHandler(this.get_Click);
            // 
            // upload_to_db
            // 
            this.upload_to_db.Location = new System.Drawing.Point(772, 477);
            this.upload_to_db.Name = "upload_to_db";
            this.upload_to_db.Size = new System.Drawing.Size(126, 23);
            this.upload_to_db.TabIndex = 27;
            this.upload_to_db.Text = "upload_to_db";
            this.upload_to_db.UseVisualStyleBackColor = true;
            this.upload_to_db.Click += new System.EventHandler(this.upload_to_db_Click);
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.upload_to_db);
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
            this.Size = new System.Drawing.Size(901, 534);
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
        private System.Windows.Forms.Button choosefile;
        private Spire.PdfViewer.Forms.PdfViewer pdfViewer1;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button get;
        private System.Windows.Forms.Button upload_to_db;
    }
}
