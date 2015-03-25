using NeuroSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

    }
}
