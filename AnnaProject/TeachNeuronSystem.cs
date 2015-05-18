using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnnaProject
{
    public partial class TeachNeuronSystem : Form
    {
        
        public TeachNeuronSystem(int sizeOut)
        {
            InitializeComponent();
            
        }

        private void TeachNeuronSystem_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// Подготовка файла для последующего обучения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btTeach_Click(object sender, EventArgs e)
        {
            SaveBin(true);
            this.Close();
        }
        /// <summary>
        /// Подготовка файла для последующего обучения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBin(bool flag)
        {

            String str = txtDir.Text;
            if (str == "C:\\")
                return;

            DirectoryInfo dir = new DirectoryInfo(str);
            var item = dir.GetFiles();
            for (int i = 0; i < item.Length; i++)
            {

                string nameimage = item.ElementAt(i).Name;

                string pattern = @"\d";
                string outname = "";
                Regex r = new Regex(pattern);
                Match m = r.Match(nameimage);
                while (m.Success)
                {
                    outname += m.ToString();
                    m = m.NextMatch();
                }
                Bitmap bmp = new Bitmap(str + "\\" + item.ElementAt(i));
                var t = TeachManager.Instance.myListOut[Convert.ToInt32(outname)];
                TeachManager.Instance.SaveBin(t.ToString(), bmp);
                File.WriteAllLines(txtDestDir.Text + "\\" + t.ToString() + ".in.txt", TeachManager.Instance.mas);

                if (flag)
                {
                    File.WriteAllLines(txtDestDir.Text + "\\" + t.ToString() + ".out.txt", TeachManager.Instance.mas2);
                }
                
            }
        }
        /// <summary>
        /// Путь до папки с изображениями
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtDir.Text = folderBrowserDialog1.SelectedPath;
        }
        /// <summary>
        /// Путь до папки куда будет сгенерирована выборка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtDestDir.Text = folderBrowserDialog1.SelectedPath;
        }

        private void txtDestDir_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtDir_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
