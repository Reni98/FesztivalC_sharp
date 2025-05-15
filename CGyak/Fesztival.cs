using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fesztival
{
    internal class Fesztival
    {
        public int sorszam;
        public string nev;
        public string hotel;
        public int szemelyek;
        public int napok;
        public double osszeg;
        public string kedvezmeny;

        public Fesztival(string sorszam, string nev, string hotel, string szemelyek, string napok, string osszeg, string kedvezmeny)
        {
            this.sorszam = int.Parse(sorszam);
            this.nev = nev;
            this.hotel = hotel;
            this.szemelyek = int.Parse(szemelyek);
            this.napok = int.Parse(napok);
            this.osszeg = double.Parse (osszeg);
            this.kedvezmeny = kedvezmeny;
        }
    }

    public class Befizetes {
        public string befnev;
        public double osszeg;

        public Befizetes(string befnev, double osszeg)
        {
            this.befnev = befnev;
            this.osszeg = osszeg;
        }
    }
}
