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

        private int sizeout;

        private int indexImage = 0;

        private string outname;

        public TeachNeuronSystem(int sizeOut)
        {
            InitializeComponent();
            sizeout = sizeOut;
        }

        private void TeachNeuronSystem_Load(object sender, EventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btTeach_Click(object sender, EventArgs e)
        {

            String str = txtDir.Text;
            if (str == "C:\\")
                return;

            DirectoryInfo dir = new DirectoryInfo(str);
            var item = dir.GetFiles();
            if (item.Length > indexImage)
            {

                string nameimage = item.ElementAt(indexImage).Name;
                Console.WriteLine(str + nameimage);
                string pattern = @"\d";

                Regex r = new Regex(pattern);
                Match m = r.Match(nameimage);
                while (m.Success)
                {
                    outname = m.ToString();            
                    m = m.NextMatch();
                }
                Bitmap bmp = new Bitmap(str + "\\" + item.ElementAt(indexImage));
                Console.WriteLine(outname);

                pictureBox1.Size = new System.Drawing.Size(100, 100);
                pictureBox1.BorderStyle = BorderStyle.Fixed3D;
                pictureBox1.Image = bmp;

                Bitmap bmp1 = new Bitmap(pictureBox1.Image, new System.Drawing.Size(100, 100));
                //Bitmap bmp = new Bitmap((str + "\\" + item.ElementAt(indexImage)));
                TeachManager.Instance.SaveBin(outname, bmp);
                File.WriteAllLines(txtDestDir.Text + "\\" + "teach" + outname + ".in.txt", TeachManager.Instance.mas);
                File.WriteAllLines(txtDestDir.Text + "\\" + "teach" + outname + ".out.txt", TeachManager.Instance.mas2);
                
            }

            //pictureBox1.ImageLocation = str;

            //

            //SaveBin(txtDestDir.Text, txtAllFiles.Lines[num], Convert.ToString(numericUpDown2.Value), bmp);

            //str = txtDir.Text + "\\" + txtAllFiles.Lines[++num];
            //pictureBox1.ImageLocation = str;
        }

        private void NextImage_Click(object sender, EventArgs e)
        {
            indexImage++;
            btTeach_Click(null, null);
        }

        private void SaveBin(String path, String name, Bitmap bmp)
        {

            int W = bmp.Width;
            int H = bmp.Height;
            int N = W * H;
            double val = 0;

            String[] mas = new String[N];

            for (int j = 0, k = 0; j < H; j++)
            {
                for (int i = 0; i < W; i++)
                {
                    val = 0.3 * bmp.GetPixel(i, j).R + 0.59 * bmp.GetPixel(i, j).G + 0.11 * bmp.GetPixel(i, j).B;

                    if (val > 127)
                    {
                        mas[k++] = "-0,5";
                    }
                    else
                    {
                        mas[k++] = "0,5";
                    }
                }
            }
            string pathWrite = txtDestDir.Text;
            File.WriteAllLines(pathWrite + "\\" + "teach" + name + ".in.txt", mas);

            N = sizeout;
            if (N > 0)
            {
                String[] mas2 = new string[N];

                for (int i = 0; i < N; i++)
                    mas2[i] = "0,01";

                int num2 = Convert.ToInt32(name) - 1;
                mas2[num2] = "0,99";


                File.WriteAllLines(pathWrite + "\\" + "teach" + name + ".out.txt", mas2);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtDir.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtDestDir.Text = folderBrowserDialog1.SelectedPath;
        }
    }
}
