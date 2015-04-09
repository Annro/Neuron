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
            }
        }

        private void обучениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeachNeuronSystem teachNeuron = new TeachNeuronSystem();
            if (teachNeuron.ShowDialog() == DialogResult.OK)
            {
                
            }
            Console.WriteLine(Environment.CurrentDirectory);
        }

    }
}
