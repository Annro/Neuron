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

        /// <summary>
        /// Два словаря, со списком картинок, для обучения
        /// </summary>
        public Dictionary<string, int> myList = new Dictionary<string, int>();
        public Dictionary<int, int> myListOut = new Dictionary<int, int>();  

        /// <summary>
        /// Синглтон
        /// </summary>
        private static readonly TeachManager instance = new TeachManager();
 
        public static TeachManager Instance
        {
        get { return instance; }
        }
 
        /// <summary>
        /// Защищенный конструктор нужен, чтобы предотвратить создание экземпляра класса Singleton
        /// </summary>
        protected TeachManager() 
        {
            
        }
        /// <summary>
        /// Метод создания словаря
        /// </summary>
        public void createDictionary(){
          
            myList.Add("A", 65);
            myList.Add("B", 66);
            myList.Add("C", 67);
            myList.Add("D", 68);
            myList.Add("E", 69);
            myList.Add("F", 70);
            myList.Add("G", 71);
            myList.Add("H", 72);
            myList.Add("I", 73);
            myList.Add("J", 74);
            myList.Add("K", 75);
            myList.Add("L", 76);
            myList.Add("M", 77);
            myList.Add("N", 78);
            myList.Add("O", 79);
            myList.Add("P", 80);
            myList.Add("Q", 81);
            myList.Add("R", 82);
            myList.Add("S", 83);
            myList.Add("T", 84);
            myList.Add("U", 85);
            myList.Add("V", 86);
            myList.Add("W", 87);
            myList.Add("X", 88);
            myList.Add("Y", 89);
            myList.Add("Z", 90);

            myListOut.Add(65, 0);
            myListOut.Add(66, 1);
            myListOut.Add(67, 2);
            myListOut.Add(68, 3);
            myListOut.Add(69, 4);
            myListOut.Add(70, 5);
            myListOut.Add(71, 6);
            myListOut.Add(72, 7);
            myListOut.Add(73, 8);
            myListOut.Add(74, 9);
            myListOut.Add(75, 10);
            myListOut.Add(76, 11);
            myListOut.Add(77, 12);
            myListOut.Add(78, 13);
            myListOut.Add(79, 14);
            myListOut.Add(80, 15);
            myListOut.Add(81, 16);
            myListOut.Add(82, 17);
            myListOut.Add(83, 18);
            myListOut.Add(84, 19);
            myListOut.Add(85, 20);
            myListOut.Add(86, 21);
            myListOut.Add(87, 22);
            myListOut.Add(88, 23);
            myListOut.Add(89, 24);
            myListOut.Add(90, 25);
        }
        /// <summary>
        /// Генерация набора пикселей по картинки(битмапу)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="bmp"></param>
        public void SaveBin(String name, Bitmap bmp)
        {

            int W = bmp.Width;
            int H = bmp.Height;
            int N = W * H;

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
