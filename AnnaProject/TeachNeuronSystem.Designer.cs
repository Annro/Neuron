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
            this.button2 = new System.Windows.Forms.Button();
            this.txtDestDir = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btTeach = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(359, 93);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "..";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtDestDir
            // 
            this.txtDestDir.Location = new System.Drawing.Point(6, 95);
            this.txtDestDir.Name = "txtDestDir";
            this.txtDestDir.ReadOnly = true;
            this.txtDestDir.Size = new System.Drawing.Size(348, 20);
            this.txtDestDir.TabIndex = 10;
            this.txtDestDir.Text = "C:\\";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Путь для сохранения выборки:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(359, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "..";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(6, 54);
            this.txtDir.Name = "txtDir";
            this.txtDir.ReadOnly = true;
            this.txtDir.Size = new System.Drawing.Size(348, 20);
            this.txtDir.TabIndex = 7;
            this.txtDir.Text = "C:\\";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Путь к изображениям:";
            // 
            // btTeach
            // 
            this.btTeach.Location = new System.Drawing.Point(13, 12);
            this.btTeach.Name = "btTeach";
            this.btTeach.Size = new System.Drawing.Size(226, 23);
            this.btTeach.TabIndex = 1;
            this.btTeach.Text = "Подготовка файлов для обучения";
            this.btTeach.UseVisualStyleBackColor = true;
            this.btTeach.Click += new System.EventHandler(this.btTeach_Click);
            // 
            // TeachNeuronSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 123);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtDestDir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btTeach);
            this.Name = "TeachNeuronSystem";
            this.Text = "TeachNeuronSystem";
            this.Load += new System.EventHandler(this.TeachNeuronSystem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtDestDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btTeach;
    }
}