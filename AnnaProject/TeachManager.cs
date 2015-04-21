﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaProject
{
    public class TeachManager
    {

        public int sizeout;
        public String[] mas2;
        public String[] mas;

        private static readonly TeachManager instance = new TeachManager();
 
        public static TeachManager Instance
        {
        get { return instance; }
        }
 
        /// Защищенный конструктор нужен, чтобы предотвратить создание экземпляра класса Singleton
        protected TeachManager() { }

        public void SaveBin(String name, Bitmap bmp)
        {

            int W = bmp.Width;
            int H = bmp.Height;
            int N = W * H;
            double val = 0;

            mas = new String[N];

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

            N = sizeout;
            if (N > 0)
            {
                mas2 = new string[N];

                for (int i = 0; i < N; i++)
                    mas2[i] = "0,01";

                int num2 = Convert.ToInt32(name) - 1;
                mas2[num2] = "0,99";

            }
        }

    }
}