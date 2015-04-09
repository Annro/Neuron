using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaProject
{

    public class Config
    {

        public string path = Environment.CurrentDirectory;

        private static readonly Config instance = new Config();

        public static Config Instance
        {
            get { return instance; }
        }

        protected Config() { }  

    }
}
