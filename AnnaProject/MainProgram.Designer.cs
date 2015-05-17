namespace AnnaProject
{
    partial class MainProgram
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создать = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обучениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textlog = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtKErr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKLern = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLern = new System.Windows.Forms.Button();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.button4 = new System.Windows.Forms.Button();
            this.textoutput = new System.Windows.Forms.TextBox();
            this.nametestimage = new System.Windows.Forms.TextBox();
            this.txtLernFiles = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.clear = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(728, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создать,
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.обучениеToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // создать
            // 
            this.создать.Name = "создать";
            this.создать.Size = new System.Drawing.Size(207, 22);
            this.создать.Text = "Создать НС";
            this.создать.Click += new System.EventHandler(this.создать_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.открытьToolStripMenuItem.Text = "Открыть НС";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить НС";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // обучениеToolStripMenuItem
            // 
            this.обучениеToolStripMenuItem.Name = "обучениеToolStripMenuItem";
            this.обучениеToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.обучениеToolStripMenuItem.Text = "Подготовка к обучению";
            this.обучениеToolStripMenuItem.Click += new System.EventHandler(this.обучениеToolStripMenuItem_Click);
            // 
            // textlog
            // 
            this.textlog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textlog.Location = new System.Drawing.Point(12, 126);
            this.textlog.Multiline = true;
            this.textlog.Name = "textlog";
            this.textlog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textlog.Size = new System.Drawing.Size(393, 164);
            this.textlog.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(357, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 23);
            this.button2.TabIndex = 26;
            this.button2.Text = "..";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(325, 77);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(80, 46);
            this.btnStop.TabIndex = 25;
            this.btnStop.Text = "Остановить обучение";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtKErr
            // 
            this.txtKErr.Location = new System.Drawing.Point(125, 80);
            this.txtKErr.Name = "txtKErr";
            this.txtKErr.Size = new System.Drawing.Size(124, 20);
            this.txtKErr.TabIndex = 24;
            this.txtKErr.Text = "0,1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(125, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Критерий ошибки:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Темп обучения:";
            // 
            // txtKLern
            // 
            this.txtKLern.Location = new System.Drawing.Point(12, 80);
            this.txtKLern.Name = "txtKLern";
            this.txtKLern.Size = new System.Drawing.Size(107, 20);
            this.txtKLern.TabIndex = 21;
            this.txtKLern.Text = "0,1";
            this.txtKLern.TextChanged += new System.EventHandler(this.txtKLern_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Путь к обучающей выборке:";
            // 
            // btnLern
            // 
            this.btnLern.Location = new System.Drawing.Point(255, 77);
            this.btnLern.Name = "btnLern";
            this.btnLern.Size = new System.Drawing.Size(64, 46);
            this.btnLern.TabIndex = 19;
            this.btnLern.Text = "Начать обучение";
            this.btnLern.UseVisualStyleBackColor = true;
            this.btnLern.Click += new System.EventHandler(this.btnLern_Click);
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(12, 40);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(339, 20);
            this.txtDir.TabIndex = 18;
            this.txtDir.Text = "C:\\";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Текстовый интерфейс:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(416, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Вектор выхода:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(419, 99);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(83, 191);
            this.textBox2.TabIndex = 30;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(398, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(252, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "Открыть файл для тестирования";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(639, 243);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 36;
            this.button4.Text = "Распознать";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textoutput
            // 
            this.textoutput.Location = new System.Drawing.Point(508, 246);
            this.textoutput.Name = "textoutput";
            this.textoutput.Size = new System.Drawing.Size(100, 20);
            this.textoutput.TabIndex = 37;
            // 
            // nametestimage
            // 
            this.nametestimage.Location = new System.Drawing.Point(508, 214);
            this.nametestimage.Name = "nametestimage";
            this.nametestimage.Size = new System.Drawing.Size(100, 20);
            this.nametestimage.TabIndex = 38;
            // 
            // txtLernFiles
            // 
            this.txtLernFiles.Location = new System.Drawing.Point(125, 80);
            this.txtLernFiles.Multiline = true;
            this.txtLernFiles.Name = "txtLernFiles";
            this.txtLernFiles.Size = new System.Drawing.Size(121, 16);
            this.txtLernFiles.TabIndex = 28;
            this.txtLernFiles.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(639, 214);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 41;
            this.button3.Text = "Обучить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.FileName = "openFileDialog3";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Location = new System.Drawing.Point(664, 83);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.TabIndex = 42;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // button5
            // 
            this.button5.Image = global::AnnaProject.Properties.Resources.w256h2561339252558DeleteRed3;
            this.button5.Location = new System.Drawing.Point(633, 83);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(25, 26);
            this.button5.TabIndex = 40;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(508, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 125);
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // clear
            // 
            this.clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clear.Image = global::AnnaProject.Properties.Resources.w256h2561339252558DeleteRed2;
            this.clear.Location = new System.Drawing.Point(350, 129);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(32, 34);
            this.clear.TabIndex = 2;
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clearText);
            // 
            // button6
            // 
            this.button6.Image = global::AnnaProject.Properties.Resources.w256h2561339252558DeleteRed3;
            this.button6.Location = new System.Drawing.Point(611, 214);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(22, 20);
            this.button6.TabIndex = 43;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Image = global::AnnaProject.Properties.Resources.w256h2561339252558DeleteRed3;
            this.button7.Location = new System.Drawing.Point(611, 246);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(22, 20);
            this.button7.TabIndex = 44;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // MainProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 302);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.nametestimage);
            this.Controls.Add(this.textoutput);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.txtKErr);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtKLern);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLern);
            this.Controls.Add(this.txtDir);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.textlog);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtLernFiles);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainProgram";
            this.Text = "Система распознования символьных образов";
            this.Load += new System.EventHandler(this.MainProgram_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создать;
        private System.Windows.Forms.TextBox textlog;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem обучениеToolStripMenuItem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtKErr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKLern;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLern;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textoutput;
        private System.Windows.Forms.TextBox nametestimage;
        private System.Windows.Forms.TextBox txtLernFiles;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
    }
}

