using System;
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
        public Dictionary<string, int> myList = new Dictionary<string, int>();


        public Dictionary<int, int> myListOut = new Dictionary<int, int>();  

        private static readonly TeachManager instance = new TeachManager();
 
        public static TeachManager Instance
        {
        get { return instance; }
        }
 
        /// Защищенный конструктор нужен, чтобы предотвратить создание экземпляра класса Singleton
        protected TeachManager() 
        {
            
        }

        public void createDictionary(){
            myList.Add("!", 33);
            myList.Add("#", 35);
            myList.Add("$", 36);
            myList.Add("%", 37);
            myList.Add("?", 63);
            myList.Add("А", 192);
            myList.Add("Б", 193);
            myList.Add("В", 194);
            myList.Add("Г", 195);
            myList.Add("Д", 196);


            myListOut.Add(33, 0);
            myListOut.Add(35, 1);
            myListOut.Add(36, 2);
            myListOut.Add(37, 3);
            myListOut.Add(63, 4);
            myListOut.Add(192, 5);
            myListOut.Add(193, 6);
            myListOut.Add(194, 7);
            myListOut.Add(195, 8);
            myListOut.Add(196, 9);
        }

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
                    //val = 0.3 * bmp.GetPixel(i, j).R + 0.59 * bmp.GetPixel(i, j).G + 0.11 * bmp.GetPixel(i, j).B;

                    //if (val > 127)
                    //{
                    //    mas[k++] = "-0,5";
                    //}
                    //else
                    //{
                    //    mas[k++] = "0,5";
                    //}
                    mas[k++] = bmp.GetPixel(i, j).B == 0 ? 1.ToString() : 0.ToString();
                }
            }

            N = sizeout;
            if (N > 0)
            {
                mas2 = new string[N];

                for (int i = 0; i < N; i++)
                    mas2[i] = "0,01";

                int num2 = Convert.ToInt32(name);
                mas2[num2] = "0,99";

            }
        }

    }
}
