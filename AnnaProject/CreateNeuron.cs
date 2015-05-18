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
    public partial class CreateNeuron : Form
    {
        public CreateNeuron()
        {
            InitializeComponent();
        }
         // Счетчик для настройки нейронов в скрытых слоях
        NumericUpDown[] NLayers;
        // Метки скрытых слоев
        Label[] NLayerLabels;
        // Количество скрытых слоев
        int countLayers=0;

        int[] layers;

        int sizeX;
        /// <summary>
        /// Метод для создания скрытых слоев
        /// </summary>
        void CreateNumeric()
        {
            for (int i = 0; i < countLayers; i++)
            {
                this.groupBox1.Controls.Remove(this.NLayers[i]);
                this.groupBox1.Controls.Remove(this.NLayerLabels[i]);
            }

            countLayers = (int)numericUpDown3.Value;

            NLayers = new NumericUpDown[countLayers];
            NLayerLabels = new Label[countLayers];

            for (int i = 0; i < countLayers; i++)
            {
                // Создаем счетчик слоев
                NLayers[i] = new NumericUpDown();

                NLayers[i].Left = 6;
                NLayers[i].Top = 71 + 39 * i;

                NLayers[i].Maximum = 10000;
                NLayers[i].Minimum = 1;

                this.groupBox1.Controls.Add(this.NLayers[i]);

                // Создаем Метку i-го скрытого слоя
                NLayerLabels[i] = new Label();
                NLayerLabels[i].Top = 55 + 39 * i;
                NLayerLabels[i].Left = 6;
                NLayerLabels[i].Text = "Нейронов в " + Convert.ToString(i + 1) + " слое: ";
                NLayerLabels[i].AutoSize = true;

                this.groupBox1.Controls.Add(this.NLayerLabels[i]);
            }
            // Перемещаем настройки для выходов
            numericUpDown2.Top = 71 + 39 * countLayers;
            label2.Top = 55 + 39 * countLayers;
        }
        /// <summary>
        /// Геттер колличества выходных нейронов
        /// </summary>
        public int[] getLayers
        {
            get 
            {
                return layers;
            }
        }
        /// <summary>
        /// Геттер количества входных нейронов
        /// </summary>
        public int getSizeX
        {
            get 
            {
                return sizeX;
            }
        }
        /// <summary>
        /// Создание нейронной сети
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            layers = new int[countLayers + 1];

            sizeX = (int)numericUpDown1.Value;

            for (int i = 0; i < countLayers; i++)
                layers[i] = (int)NLayers[i].Value;

            layers[countLayers] = (int)numericUpDown2.Value;

            Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        
        }

        private void numericUpDown3_ValueChanged_1(object sender, EventArgs e)
        {
            try
            {
                CreateNumeric();
            }
            finally
            {}
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
        
        }
    }
}
