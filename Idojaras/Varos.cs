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
        public double _homerseklet;
        public double _paratartalom;
        public double _szelsebesseg;

        public Varos(string nev, double homerselket, double paratartalom, double szelesebesseg)
        {
           
            _nev = nev;
            _homerseklet = homerselket;
            _paratartalom = paratartalom;
            _szelsebesseg = szelesebesseg;
        }
        public Varos(string sor)
        {
            var adatok = sor.Split(';').ToList();
            _nev = adatok[0];
            _homerseklet = double.Parse(adatok[1]);
            _paratartalom = double.Parse(adatok[2]);
            _szelsebesseg = double.Parse(adatok[3]);
        }

    }


}
