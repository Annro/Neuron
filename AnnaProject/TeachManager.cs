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
            myList.Add("1", 0);
            myList.Add("2", 1);
            myList.Add("3", 2);
            myList.Add("4", 3);
            myList.Add("5", 4);
            myList.Add("6", 5);
            myList.Add("7", 6);
            myList.Add("8", 7);
            myList.Add("9", 8);
            myList.Add("?", 9);
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

                int num2 = Convert.ToInt32(name);
                mas2[num2] = "0,99";

            }
        }

    }
}
