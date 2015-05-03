﻿using NeuroSystem;
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
    public partial class MainProgram : Form
    {

        // Собственно сама нейросеть
        NeuronSystem NET;
        // Путь к сети
        String path = "";
        // 1 - идет обучение. 0 - нет
        bool run = false;
        Graphics graphics;// полотно
        Bitmap btm;//полотно

        public MainProgram()
        {
            InitializeComponent();
        }

        private void создать_Click(object sender, EventArgs e)
        {
            CreateNeuron neuron = new CreateNeuron();
            if (neuron.ShowDialog() == DialogResult.OK)
            {
                CreateNeuronSystem(neuron.getSizeX, neuron.getLayers);
            }
            TeachManager.Instance.sizeout = NET.GetY;
        }

        public void CreateNeuronSystem(int SizeX, int[] Layers)
        {
            NET = new NeuronSystem(SizeX, Layers);
            path = "";
            textlog.AppendText("Создана полносвязная сеть:\r\n");
            textlog.AppendText("Число входов: " + Convert.ToString(SizeX) + "\r\n");
            textlog.AppendText("Число выходов: " + Convert.ToString(Layers[Layers.Count() - 1]) + "\r\n");
            textlog.AppendText("Число скрытых слоёв: " + Convert.ToString(Layers.Count() - 1) + "\r\n");

            for (int i = 0; i < Layers.Count() - 1; i++)
            {
                textlog.AppendText("Нейронов в " + Convert.ToString(i + 1) + " скрытом слое: "
                                                    + Convert.ToString(Layers[i]) + "\r\n");

            }


        }

        private void clearText(object sender, EventArgs e)
        {
            textlog.Clear();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NET == null)
            {
                textlog.AppendText("Ошибка! Сеть не не создана!\r\n");
            }
            else
            {
                if (path == "")
                {
                    saveFileDialog1.ShowDialog();
                    path = saveFileDialog1.FileName;
                }
                try
                {
                    NET.SaveNW(path);
                }
                finally
                { }
                textlog.AppendText("Сеть сохранена:\r\n" + path + "\r\n");
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            path = openFileDialog1.FileName;
            if (File.Exists(path))
            {
                try
                {
                    NET = new NeuronSystem(path);
                }
                finally
                { }

                textlog.AppendText("Загружена сеть:\r\n" + path + "\r\n");

                textlog.AppendText("Число входов: " + Convert.ToString(NET.GetX) + "\r\n");
                textlog.AppendText("Число выходов: " + Convert.ToString(NET.GetY) + "\r\n");
                textlog.AppendText("Число скрытых слоёв: " + Convert.ToString(NET.CountLayers - 1) + "\r\n");

                for (int i = 0; i < NET.CountLayers - 1; i++)
                {
                    textlog.AppendText("Нейронов в " + Convert.ToString(i + 1) + " скрытом слое: "
                                                        + Convert.ToString(NET.Layer(i).countY) + "\r\n");
                }
            }
            else
            {
                if (path != "")
                {
                    textlog.AppendText("Ошибка! Файл не существует!\r\n" + path + "\r\n");
                    path = "";
                }
                return;
                
            }
            TeachManager.Instance.sizeout = NET.GetY;
        }

        private void обучениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NET == null)
            {
                textlog.AppendText("Создайте или откройте нейронную сеть");
                return;
            }
            TeachNeuronSystem teachNeuron = new TeachNeuronSystem(NET.GetY);
            if (teachNeuron.ShowDialog() == DialogResult.OK)
            {
            }       
        }

        private void function_close()
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtDir.Text = folderBrowserDialog1.SelectedPath;
        }

        private void btnLern_Click(object sender, EventArgs e)
        {
            if (NET == null)
            {
                textlog.AppendText("Не создана сеть!\r\n");
                return;
            }
            try
            {
                //if (Convert.ToDouble(txtKLern.Text) > 1 || Convert.ToDouble(txtKLern.Text) < 0.1)
                //{
                //    textlog.AppendText("Установите скорость обучения от 0.1 до 1!\r\n");
                //    return;
                //}

                //if (Convert.ToDouble(txtKErr.Text) > 1 || Convert.ToDouble(txtKErr.Text) < 0.1)
                //{
                //    textlog.AppendText("Установите Критерий ошибки от 0.1 до 1!\r\n");
                //    return;
                //}
            }
            catch (FormatException err)
            {
                textlog.AppendText("Не верный формат входных данных!\n");
                return;
            }



            textlog.AppendText("Запущен процесс обучения\r\n");

            String strFileIn, strFileOut, strFile;

            // Очищаем список в обучающей выборке
            txtLernFiles.Text = "";
            FileInfo[] fInfo = new DirectoryInfo(txtDir.Text).GetFiles("*.in.txt");
            foreach (FileInfo f in fInfo)
            {
                // Загружаем список файлов
                strFileIn = f.FullName;
                strFile = strFileIn.Remove(strFileIn.Length - 7);
                strFileOut = strFile + ".out.txt";

                if (File.Exists(strFileOut) && File.Exists(strFileIn))
                {
                    txtLernFiles.AppendText(strFile + "\r\n");
                }
            }
            if (txtLernFiles.Lines.Count() > 0)
                textlog.AppendText("Загружена обучающая выборка\r\n");
            else
            {
                textlog.AppendText("Обучающая выборка не найдена\r\n");
                return;
            }

            int currPos = 0;
            double kErr = 1E256;
            double kErrNorm = Convert.ToDouble(txtKErr.Text);
            double kLern = Convert.ToDouble(txtKLern.Text);

            double[] X = new double[NET.GetX];
            double[] Y = new double[NET.GetY];
            String[] currFile;

            btnLern.Enabled = false;
            btnStop.Enabled = true;
            run = true;
            while (kErr > kErrNorm)
            {
                kErr = 0;
                for (currPos = 0; currPos < txtLernFiles.Lines.Count() - 1; currPos++)
                {
                    // Загружаем обучающую пару
                    try
                    {
                        // Загружаем текущий входной файл
                        currFile = File.ReadAllLines(txtLernFiles.Lines[currPos] + ".in.txt");

                        for (int i = 0; i < NET.GetX; i++)
                            X[i] = Convert.ToDouble(currFile[i]);

                        // Загружаем текущий выходной файл
                        currFile = File.ReadAllLines(txtLernFiles.Lines[currPos] + ".out.txt");

                        for (int j = 0; j < NET.GetY; j++)
                            Y[j] = Convert.ToDouble(currFile[j]);
                    }
                    finally
                    { }

                    // Обучаем текущую пару
                    kErr += NET.LernNW(X, Y, kLern);

                    Application.DoEvents();

                    if (!run)
                        return;
                }
                textlog.AppendText("Текущая ошибка: " + Convert.ToString(kErr) + "\r\n");
            }
            textlog.AppendText("Обучение завершено!\r\n");

            btnLern.Enabled = true;
            btnStop.Enabled = false;
            run = false;
        }

        private void MainProgram_Load(object sender, EventArgs e)
        {
            openFileDialog1.FileName = ""; // Default file name
            openFileDialog1.DefaultExt = ".txt"; // Default file extension
            openFileDialog1.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            openFileDialog2.FileName = ""; // Default file name
            openFileDialog2.DefaultExt = ".txt"; // Default file extension
            openFileDialog2.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            btm = new Bitmap(100, 100);
            graphics = Graphics.FromImage(btm);//привязка изображения к полотну, чтобы мы ресовали как бы по верз битмапа
            graphics.Clear(Color.White);//очищаем белым цветом
            pictureBox1.Image = btm;

            TeachManager.Instance.createDictionary();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnLern.Enabled = true;
            btnStop.Enabled = false;
            run = false;
            textlog.AppendText("Обучение остановлено пользователем\r\n");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (NET == null)
            {
                textlog.AppendText("Не создана сеть!\r\n");
                return;
            }
            openFileDialog2.ShowDialog();   

            String strFile = openFileDialog2.FileName;

            if (!File.Exists(strFile))
                return;


            String[] currFile;

            textBox2.Text = "";

            // Загружаем текущий входной файл
            currFile = File.ReadAllLines(strFile);
            textlog.AppendText("Загружен файл:\r\n" + Convert.ToString(strFile) + "\r\n");
            recognize(currFile);
        }

        private void recognize(string[] strFile)
        {
            textBox2.Text = "";
            double[] X = new double[NET.GetX];
            double[] Y;

            for (int i = 0; i < NET.GetX; i++)
            {
                X[i] = Convert.ToDouble(strFile[i]);
            }

            NET.NetOUT(X, out Y);

            for (int i = 0; i < NET.GetY; i++)
            {
                textBox2.AppendText(string.Format("{0:F4}\r\n", Y[i]));
                //textBox2.AppendText(Convert.ToString(Y[i]) + "\r\n");
            }
            double y = 0, max = Y[0]; int id = 0;
            for (int i = 0; i < Y.Length; i++)
            {
                if (Y[i] > max)
                {
                    max = Y[i];
                    id = i;
                }

            }

            textoutput.Text = (id + 1).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (TeachManager.Instance.myList[nametestimage.Text] == null)
            {
                textlog.AppendText("Такого символа нет в каталоге");
                return;
            }
            TeachManager.Instance.SaveBin(TeachManager.Instance.myList[nametestimage.Text].ToString(), btm);
            String[] currFile = TeachManager.Instance.mas;
            recognize(currFile);       
        }

        private void txtKLern_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        #region рисование
        bool drawInBox = false;//разрешение на рисование

        /// <summary>
        /// Событие отмены рисования при отпускании мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drawInBox = false;
        }

        /// <summary>
        /// Событие начала рисования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            oldPoint = new Point(e.X, e.Y);
            drawInBox = true;

        }
        Point oldPoint;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawInBox)
            {
                graphics.DrawLine(new Pen(Color.Black, 3), oldPoint, new Point(e.X, e.Y));//рисуем на полотне
                pictureBox1.Image = btm;//отображаем на пикчербоксе
                oldPoint = new Point(e.X, e.Y);

            }
        }
        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            pictureBox1.Image = btm;
        }

    }
}
