using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fesztival
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> osszegek = new List<double>();
            List<string> foglalok = new List<string>();
            
            List <Befizetes> befizetes = new List<Befizetes>();
            befizetes.Sort();
            List<Fesztival> foglalasok = new List<Fesztival>();
            string[] sorok = File.ReadAllLines("fesztival.txt");
            foreach (string s in sorok) { 
                string[] adatok = s.Split(',');
                Fesztival foglal = new Fesztival(adatok[0],adatok[1],adatok[2],adatok[3],adatok[4],adatok[5],adatok[6]);
                foglalasok.Add(foglal);
            }

            double legtobbet = 0;
            string legn = "";
            foreach (var fog in foglalasok) {
                Console.WriteLine($"{fog.sorszam},{fog.nev},{fog.hotel},{fog.szemelyek},{fog.napok},{fog.osszeg},{fog.kedvezmeny}");
                if (!foglalok.Contains(fog.nev)) { 
                    foglalok.Add(fog.nev);

                   
                }
            }
            double fizetettosszeg = 0;
          
            foreach ( string nev in foglalok)
            {
                foreach (var item in foglalasok)
                {
                    if (nev == item.nev) {
                       
                        if (item.kedvezmeny == "igen")                        {
                            
                                double kedvezmeny = item.osszeg - (item.osszeg * 0.25);

                                fizetettosszeg = (kedvezmeny * item.napok) * item.szemelyek;
                                    osszegek.Add(fizetettosszeg);
                            
                        }
                        else {
                            fizetettosszeg = (item.osszeg*item.napok)*item.szemelyek;
                            osszegek.Add(fizetettosszeg);
                        }                                              
                    }                    
                }  
                Befizetes b = new Befizetes(
                    nev,
                    fizetettosszeg);
                befizetes.Add(b);

               
                Console.WriteLine($"{nev}, {fizetettosszeg} FT");
            }
            
            foreach (var item in befizetes) {
                if (item.osszeg>legtobbet) {
                    legtobbet = item.osszeg;
                    legn = item.befnev;
                }
            }
            
            Console.WriteLine("7.feladat");
            Console.WriteLine($"A legtöbbet fizető nev: {legn}, {legtobbet}");

            Console.ReadKey();
        }

       
    }
}
