namespace AnnaProject
{
    partial class TeachNeuronSystem
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btTeach = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NextImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 63);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btTeach
            // 
            this.btTeach.Location = new System.Drawing.Point(12, 34);
            this.btTeach.Name = "btTeach";
            this.btTeach.Size = new System.Drawing.Size(75, 23);
            this.btTeach.TabIndex = 1;
            this.btTeach.Text = "Teach";
            this.btTeach.UseVisualStyleBackColor = true;
            this.btTeach.Click += new System.EventHandler(this.btTeach_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(93, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // NextImage
            // 
            this.NextImage.Location = new System.Drawing.Point(199, 34);
            this.NextImage.Name = "NextImage";
            this.NextImage.Size = new System.Drawing.Size(75, 23);
            this.NextImage.TabIndex = 3;
            this.NextImage.Text = "NextImage";
            this.NextImage.UseVisualStyleBackColor = true;
            this.NextImage.Click += new System.EventHandler(this.NextImage_Click);
            // 
            // TeachNeuronSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 278);
            this.Controls.Add(this.NextImage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btTeach);
            this.Controls.Add(this.btnClose);
            this.Name = "TeachNeuronSystem";
            this.Text = "TeachNeuronSystem";
            this.Load += new System.EventHandler(this.TeachNeuronSystem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btTeach;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button NextImage;
    }
}