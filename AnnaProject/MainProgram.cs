using NeuroSystem;
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
    public partial class MainProgram : Form
    {

        // Нейронная сеть
        NeuronSystem NET;
        // Путь к сети
        String path = "";
        // 1 - идет обучение. 0 - нет
        bool run = false;
        Graphics graphics;// полотно
        Graphics graphicssmall;// полотно
        Bitmap btm;//полотно
        Bitmap btmsmall;//полотно
        private int sizeout;

        public MainProgram()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Создание НС, с указыванием количества входных нейронов, выходных нейронов, скрытых слоев, а так же количество нейронов в скрытых слоях
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void создать_Click(object sender, EventArgs e)
        {
            CreateNeuron neuron = new CreateNeuron();
            if (neuron.ShowDialog() == DialogResult.OK)
            {
                CreateNeuronSystem(neuron.getSizeX, neuron.getLayers);
            }
            if (NET == null)
            {
                textlog1.AppendText("Не создана сеть!\r\n");
                return;
            }
            TeachManager.Instance.sizeout = NET.GetY;
        }
        /// <summary>
        /// Генерация НС, с указанным количеством входных, выходных нейронов, скрытых слоев и нейронов в этих слоях
        /// </summary>
        /// <param name="SizeX"></param>
        /// <param name="Layers"></param>
        public void CreateNeuronSystem(int SizeX, int[] Layers)
        {
            NET = new NeuronSystem(SizeX, Layers);
            path = "";
            textlog1.AppendText("Создана полносвязная сеть:\r\n");
            textlog1.AppendText("Число входов: " + Convert.ToString(SizeX) + "\r\n");
            textlog1.AppendText("Число выходов: " + Convert.ToString(Layers[Layers.Count() - 1]) + "\r\n");
            textlog1.AppendText("Число скрытых слоёв: " + Convert.ToString(Layers.Count() - 1) + "\r\n");

            for (int i = 0; i < Layers.Count() - 1; i++)
            {
                textlog1.AppendText("Нейронов в " + Convert.ToString(i + 1) + " скрытом слое: "
                                                    + Convert.ToString(Layers[i]) + "\r\n");

            }


        }
        /// <summary>
        /// Очищение логов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearText(object sender, EventArgs e)
        {
            textlog1.Clear();
        }
        /// <summary>
        /// Сохранение НС
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NET == null)
            {
                textlog1.AppendText("Ошибка! Сеть не не создана!\r\n");
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
                textlog1.AppendText("Сеть сохранена:\r\n" + path + "\r\n");
            }
        }
        /// <summary>
        /// Открытие НС из файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                textlog1.AppendText("Загружена сеть:\r\n" + path + "\r\n");

                textlog1.AppendText("Число входов: " + Convert.ToString(NET.GetX) + "\r\n");
                textlog1.AppendText("Число выходов: " + Convert.ToString(NET.GetY) + "\r\n");
                textlog1.AppendText("Число скрытых слоёв: " + Convert.ToString(NET.CountLayers - 1) + "\r\n");

                for (int i = 0; i < NET.CountLayers - 1; i++)
                {
                    textlog1.AppendText("Нейронов в " + Convert.ToString(i + 1) + " скрытом слое: "
                                                        + Convert.ToString(NET.Layer(i).countY) + "\r\n");
                }
            }
            else
            {
                if (path != "")
                {
                    textlog1.AppendText("Ошибка! Файл не существует!\r\n" + path + "\r\n");
                    path = "";
                }
                return;
                
            }
            TeachManager.Instance.sizeout = NET.GetY;
        }
        /// <summary>
        /// Открытие окна для создания обучающей выборки, которая необходима для обучения НС
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void обучениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NET == null)
            {
                textlog1.AppendText("Создайте или откройте нейронную сеть");
                return;
            }
            TeachNeuronSystem teachNeuron = new TeachNeuronSystem(NET.GetY);
            if (teachNeuron.ShowDialog() == DialogResult.OK)
            {
            }       
        }
        /// <summary>
        /// Путь до обучающией выборки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtDir.Text = folderBrowserDialog1.SelectedPath;
        }

        /// <summary>
        ///  Обучение НС
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLern_Click(object sender, EventArgs e)
        {
            if (NET == null)
            {
                textlog1.AppendText("Не создана сеть!\r\n");
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
            catch
            {
                textlog1.AppendText("Не верный формат входных данных!\n");
                return;
            }
            textlog1.AppendText("Запущен процесс обучения\r\n");
            String strFileIn, strFileOut, strFile;
            // Очищаем список в обучающей выборке
            txtLernFiles.Text = "";
            FileInfo[] fInfo = new DirectoryInfo(txtDir.Text).GetFiles("*.in.txt");
            foreach (FileInfo f in fInfo)
            {
                // Загружаем список файлов in
                strFileIn = f.FullName;
                strFile = strFileIn.Remove(strFileIn.Length - 7);
                strFileOut = strFile + ".out.txt";

                if (File.Exists(strFileOut) && File.Exists(strFileIn))
                {
                    txtLernFiles.AppendText(strFile + "\r\n");
                }
            }
            if (txtLernFiles.Lines.Count() > 0)
                textlog1.AppendText("Загружена обучающая выборка\r\n");
            else
            {
                textlog1.AppendText("Обучающая выборка не найдена\r\n");
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
            //Проверяем критерий ошибки
            while (kErr > kErrNorm)
            {
                kErr = 0;
                for (currPos = 0; currPos < txtLernFiles.Lines.Count() - 1; currPos++)
                {
                    // Загружаем обучающую пару in и out
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
                textlog1.AppendText("Текущая ошибка: " + Convert.ToString(kErr) + "\r\n");
            }
            textlog1.AppendText("Обучение завершено!\r\n");

            btnLern.Enabled = true;
            btnStop.Enabled = false;
            run = false;
        }

        //Загрузка при старте программы
        private void MainProgram_Load(object sender, EventArgs e)
        {
            openFileDialog1.FileName = ""; // Default file name
            openFileDialog1.DefaultExt = ".txt"; // Default file extension
            openFileDialog1.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            openFileDialog2.FileName = ""; // Default file name
            openFileDialog2.DefaultExt = ".txt"; // Default file extension
            openFileDialog2.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            btm = new Bitmap(125, 125);
            graphics = Graphics.FromImage(btm);//привязка изображения к полотну
            graphics.Clear(Color.White);//очищаем белым цветом
            pictureBox1.Image = btm;

            btmsmall = new Bitmap(btm, 50, 50);
            graphicssmall = Graphics.FromImage(btmsmall);//привязка изображения к полотну
            graphicssmall.Clear(Color.White);//очищаем белым цветом
            pictureBox2.Image = btmsmall;

            TeachManager.Instance.createDictionary();

            пToolStripMenuItem_Click(null, null);
        }

        /// <summary>
        /// Остановка обучения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            btnLern.Enabled = true;
            btnStop.Enabled = false;
            run = false;
            textlog1.AppendText("Обучение остановлено пользователем\r\n");
        }
        /// <summary>
        /// Путь до изображения с символом, нарисованное в другом графическом редакторе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (NET == null)
            {
                textlog1.AppendText("Не создана сеть!\r\n");
                return;
            }
            //Открываем окно и загружаем картинку
            openFileDialog3.ShowDialog();   

            String strFile = openFileDialog3.FileName;

            if (!File.Exists(strFile))
                return;

            textBox2.Text = "";

            Bitmap bitmaptest = new Bitmap(strFile);
            graphics.DrawImage(bitmaptest, 0, 0, 125, 125);//рисуем на полотне
            pictureBox1.Image = btm;//отображаем на пикчербоксе
            //btm = new Bitmap(bitmaptest, 125, 125);
            pictureBox1.Image = btm;
            btmsmall = new Bitmap(btm, 50, 50);
            pictureBox2.Image = btmsmall;
        }
        /// <summary>
        /// Вывод результата из НС
        /// </summary>
        /// <param name="strFile"></param>
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
            //Array.Sort(Y);
            for (int i = 0; i < NET.GetY; i++)
            {
                var testint = TeachManager.Instance.myListOut.FirstOrDefault(yy => yy.Value == i).Key;
                textBox2.AppendText(string.Format("{0:F4} - {1}\r\n", Y[i], TeachManager.Instance.myList.FirstOrDefault(x => x.Value == testint).Key));
            }
            double max = Y[0]; int id = 0;
            for (int i = 0; i < Y.Length; i++)
            {
                if (Y[i] > max)
                {
                    max = Y[i];
                    id = i;
                }

            }
            var myValue = TeachManager.Instance.myListOut.FirstOrDefault(x => x.Value == (id)).Key;
            var outputValue = TeachManager.Instance.myList.FirstOrDefault(x => x.Value == myValue).Key;
            textoutput.Text = outputValue;
        }
        /// <summary>
        /// Распознование с картинки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (NET == null)
            {
                textlog1.AppendText("Не создана сеть!\r\n");
                return;
            }

            if (!TeachManager.Instance.myList.ContainsKey(nametestimage.Text))
            {
                Bitmap bmpnew = new Bitmap(btm, 50, 50);
                TeachManager.Instance.SaveBin(0.ToString(), bmpnew);
            }
            else
            {
                var t = TeachManager.Instance.myList[nametestimage.Text];
                Bitmap bmpnew = new Bitmap(btm, 50, 50);
                TeachManager.Instance.SaveBin(TeachManager.Instance.myListOut[t].ToString(), bmpnew);
            }

            String[] currFile = TeachManager.Instance.mas;
            for (int i = 0; i < NET.GetX; i++)
            {
                Console.Write(currFile[i]);
            }
            
            recognize(currFile);       
        }

        #region рисование
        Point prevLocMouse;
        bool paint = false;
        SolidBrush br1;
        /// <summary>
        /// Событие отмены рисования при отпускании мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;
        }

        /// <summary>
        /// Событие начала рисования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            prevLocMouse = new Point(e.X, e.Y);

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint)
            {
                br1 = new SolidBrush(Color.Black);
                graphics.FillEllipse(br1, e.X, e.Y, 6, 6);

                // вычисляем расстояние между соседними точками
                double sqrDist = (e.X - prevLocMouse.X) * (e.X - prevLocMouse.X) + (e.Y - prevLocMouse.Y) * (e.Y - prevLocMouse.Y);
                double dist = Math.Sqrt(sqrDist);
                //если оно больше (например) 2, то соединяем точки линией
                if (dist > 1)
                {
                    graphics.DrawLine(new Pen(Color.Black, 3), prevLocMouse.X + 2, prevLocMouse.Y + 2, e.X + 2, e.Y + 2);
                }
  
                pictureBox1.Image = btm;
                prevLocMouse = new Point(e.X, e.Y);
            }
            btmsmall = new Bitmap(btm, 50, 50);
            pictureBox2.Image = btmsmall;
        }
        #endregion
        private void button5_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            pictureBox1.Image = btm;
            btmsmall = new Bitmap(btm, 50, 50);
            pictureBox2.Image = btmsmall;
        }
        /// <summary>
        /// Обучение НС
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (NET == null)
            {
                textlog1.AppendText("Не создана сеть!\r\n");
                return;
            }
            try
            {
                /* Ограничение на обучение и критерий ошибки
                if (Convert.ToDouble(txtKLern.Text) > 1 || Convert.ToDouble(txtKLern.Text) < 0.1)
                {
                    textlog.AppendText("Установите скорость обучения от 0.1 до 1!\r\n");
                    return;
                }
                if (Convert.ToDouble(txtKErr.Text) > 1 || Convert.ToDouble(txtKErr.Text) < 0.1)
                {
                    textlog.AppendText("Установите Критерий ошибки от 0.1 до 1!\r\n");
                    return;
                }
                */
            }
            catch
            {
                textlog1.AppendText("Не верный формат входных данных!\n");
                return;
            }

            textlog1.AppendText("Запущен процесс обучения\r\n");
            double kErr = 1E256;
            //double kErrNorm = Convert.ToDouble(txtKErr.Text);
            //double kLern = Convert.ToDouble(txtKLern.Text);

            double[] X = new double[NET.GetX];
            double[] Y = new double[NET.GetY];
            String[] currFile;

            btnLern.Enabled = false;
            btnStop.Enabled = true;
            run = true;
            if (!TeachManager.Instance.myList.ContainsKey(nametestimage.Text))
            {
                textlog1.AppendText("Такого символа нет в каталоге\n");
                return;
            }
            var t = TeachManager.Instance.myList[nametestimage.Text];
            Bitmap bmpnew = new Bitmap(btm, 50, 50);
            TeachManager.Instance.SaveBin(TeachManager.Instance.myListOut[t].ToString(), bmpnew);
            currFile = TeachManager.Instance.mas;
            txtLernFiles.AppendText(currFile + "\r\n");
            while (kErr > 0.001)
            {
                kErr = 0;
                // Загружаем обучающую пару in и out
                try
                {

                    for (int i = 0; i < NET.GetX; i++)
                        X[i] = Convert.ToDouble(currFile[i]);


                    for (int j = 0; j < NET.GetY; j++)
                        if ((j) == TeachManager.Instance.myListOut[t])
                        {
                            Y[j] = 0.99;
                        }
                        else
                        {
                            Y[j] = 0.01;
                        }
                }
                finally
                {
                    textlog1.AppendText("Ошибка строки");
                }

                // Обучаем текущую пару
                kErr += NET.LernNW(X, Y, 0.3);
                textlog1.AppendText("Текущая ошибка: " + Convert.ToString(kErr) + "\r\n");
                Application.DoEvents();

                    if (!run)
                        return;
                    
            }

            textlog1.AppendText("Обучение завершено!\r\n");

            btnLern.Enabled = true;
            btnStop.Enabled = false;
            run = false;
        }
        /// <summary>
        /// Очищаем текстбокс
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            nametestimage.Text = "";
        }
        /// <summary>
        /// Очищаем текстбокс
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            textoutput.Text = "";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textlog_TextChanged(object sender, EventArgs e)
        {

        }

        private void btTeach_Click(object sender, EventArgs e)
        {
            if (NET == null)
            {
                textlog1.AppendText("Не создана сеть!\r\n");
                return;
            }
            sizeout = NET.GetY;
            SaveBin(true);
        }
        private void SaveBin(bool flag)
        {

            String str = textBox1.Text;
            if (str == "C:\\")
                return;

            DirectoryInfo dir = new DirectoryInfo(str);
            var item = dir.GetFiles();
            for (int i = 0; i < item.Length - 1; i++)
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

        private void button9_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox1.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            txtDestDir.Text = folderBrowserDialog1.SelectedPath;
        }

        private void пToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            groupBox3.Visible = false;
        }

        private void обучениеНСToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = true;
            groupBox1.Location = new Point(448, 37);
            label6.Visible = false;
            textBox2.Visible = false;
            button1.Text = "Открыть изображение для обучения";

            //Обучение
            nametestimage.Visible = true;
            button6.Visible = true;
            button3.Visible = true;

            //Распознование
            textoutput.Visible = false;
            button7.Visible = false;
            button4.Visible = false;

            groupBox1.Text = "";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void распознаваниеСимволовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox1.Location = new Point(21, 37);
            label6.Visible = true;
            textBox2.Visible = true;
            button1.Text = "Открыть изображение для распознавания";

            //Обучение
            nametestimage.Visible = false;
            button6.Visible = false;
            button3.Visible = false;

            //Распознование
            textoutput.Visible = true;
            button7.Visible = true;
            button4.Visible = true;

            groupBox1.Text = "";
        }

    }
}
