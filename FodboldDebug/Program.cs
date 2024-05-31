using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FodboldDebug
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var liga = new Liga();


        }

        public class Hold
        {
            public string Navn { get; set; }
            public int Point { get; set; }
            public int MaalScoret { get; set; }
            public int MaalKaseret { get; set; }

            public Hold(string navn)
            {
                Navn = navn;
                Point = 0;
                MaalScoret = 0;
                MaalKaseret = 0;
            }
        }

        public class Kamp
        {
            public Hold HjemmeHold { get; set; }
            public Hold UdeHold { get; set; }
            public int HjemmeMaal { get; set; }
            public int UdeMaal { get; set; }

            public Kamp(Hold hjemmeHold, Hold udeHold, int hjemmeMaal, int udeMaal)
            {
                HjemmeHold = hjemmeHold;
                UdeHold = udeHold;
                HjemmeMaal = hjemmeMaal;
                UdeMaal = udeMaal;
            }

            public void SpilKamp()
            {
                HjemmeHold.MaalScoret += HjemmeMaal;
                HjemmeHold.MaalKaseret += UdeMaal;
                UdeHold.MaalScoret += UdeMaal;
                UdeHold.MaalKaseret += HjemmeMaal;

                if (HjemmeMaal > UdeMaal)
                {
                    HjemmeHold.Point += 3;
                }
                else if (UdeMaal > HjemmeMaal)
                {
                    UdeHold.Point += 3;
                }
                else
                {
                    HjemmeHold.Point += 1;
                    UdeHold.Point += 1;
                }
            }
        }

        public class Liga
        {
            public List<Hold> HoldIFlertal { get; set; }
            public List<Kamp> Kampe { get; set; }

            public Liga()
            {
                HoldIFlertal = new List<Hold>();
                Kampe = new List<Kamp>();
            }

            public void AddHold(Hold hold)
            {
                HoldIFlertal.Add(hold);
            }
            
            public void AddKamp(Kamp kamp)
            {
                Kampe.Add(kamp);
                kamp.SpilKamp();
            }

            public void Stillinger()
            {
                var stillinger = HoldIFlertal.OrderByDescending(t => t.Point)
                                             .ThenByDescending(t => t.MaalScoret - t.MaalKaseret)
                                             .ThenByDescending(t => t.MaalScoret);
                Console.WriteLine("Liga Stillinger:");
                foreach(var hold in stillinger)
                {
                    Console.WriteLine($"{hold.Navn} Point - {hold.Point} Mål Scoret - {hold.MaalScoret} Mål Kaseret - {hold.MaalKaseret}");
                }
            }
        }
    }
}

