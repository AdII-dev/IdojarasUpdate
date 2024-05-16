using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idojaras
{
    internal class Varos
    {
        public string _nev;
        public int _homerseklet;
        public int _paratartalom;
        public int _szelsebesseg;

        public Varos(string nev, int homerselket, int paratartalom, int szelesebesseg)
        {
           
            _nev = nev;
            _homerseklet = homerselket;
            _paratartalom = paratartalom;
            _szelsebesseg = szelesebesseg;
        }
    }
}
