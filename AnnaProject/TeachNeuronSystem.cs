using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnnaProject
{
    public partial class TeachNeuronSystem : Form
    {

        private int indexImage = 0;

        public TeachNeuronSystem()
        {
            InitializeComponent();
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
            String str = Config.Instance.path + "\\image";
            Console.WriteLine(str);
            DirectoryInfo dir = new DirectoryInfo(str);
            var item = dir.GetFiles();
            if (item.Length > indexImage)
            {
                Console.WriteLine(item.ElementAt(indexImage).Name);
                pictureBox1.ImageLocation = (str + "\\" + item.ElementAt(indexImage)).ToString();
            }

            //pictureBox1.ImageLocation = str;

            //Bitmap bmp = new Bitmap(str);

            //SaveBin(txtDestDir.Text, txtAllFiles.Lines[num], Convert.ToString(numericUpDown2.Value), bmp);

            //str = txtDir.Text + "\\" + txtAllFiles.Lines[++num];
            //pictureBox1.ImageLocation = str;
        }

        private void NextImage_Click(object sender, EventArgs e)
        {
            indexImage++;
            btTeach_Click(null, null);
        }

        private void SaveBin(String path, String name, String digit, Bitmap bmp)
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

            File.WriteAllLines(path + "\\" + name + ".in.txt", mas);

            N = Convert.ToInt32("neuron на выходе");
            if (N > 0)
            {
                String[] mas2 = new string[N];

                for (int i = 0; i < N; i++)
                    mas2[i] = "ложь";

                int num2 = Convert.ToInt32("цифра у картинки" - 1);
                mas2[num2] = "истина";


                File.WriteAllLines(path + "\\" + name + ".out.txt", mas2);
            }
        }
    }
}
