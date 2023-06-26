using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auticka
{
    internal class Tovarna
    {

        Stranka Web = new Stranka();
        public Dictionary<string, string> AdresyAutTelsa = new Dictionary<string, string>();
        public void Obraz()
        {
            AdresyAutTelsa.Add("Model S", "https://digitalassets.tesla.com/tesla-contents/image/upload/h_923,w_1640,c_fit,f_auto,q_auto:best/compare-model-s");
            AdresyAutTelsa.Add("Model Y", "https://digitalassets.tesla.com/tesla-contents/image/upload/h_923,w_1640,c_fit,f_auto,q_auto:best/compare-model-y-performance");
            AdresyAutTelsa.Add("Model X", "https://digitalassets.tesla.com/tesla-contents/image/upload/h_923,w_1640,c_fit,f_auto,q_auto:best/compare-model-x");
            AdresyAutTelsa.Add("Model 3", "https://digitalassets.tesla.com/tesla-contents/image/upload/h_923,w_1640,c_fit,f_auto,q_auto:best/compare-model-3-performance");
            AdresyAutTelsa.Add("Cybertruck", "https://ih0.redbubble.net/image.978502087.9736/flat,1000x1000,075,f.u6.jpg");
        }

        Auto VyrobeneAuta = new Auto();
        public Auto VytvorAuto()
        {
            Console.Clear();

            Console.WriteLine("Zadej model:   (Model S , Model 3,Model X,Model Y,Cybertruck)");
            VyrobeneAuta.Model = Console.ReadLine();
            foreach (var item in AdresyAutTelsa)
            {
                if (item.Key == VyrobeneAuta.Model)
                {
                    VyrobeneAuta.Obraz = item.Value;
                }
            }

            while (true)
            {
                Console.WriteLine("Zadej počet sedadel:   (2-5)");
                int Pocet_sedadel = Convert.ToInt32(Console.ReadLine());
                if (Pocet_sedadel >= 2 && Pocet_sedadel <= 5)
                {
                    VyrobeneAuta.sedadla = Pocet_sedadel;
                    break;
                }
                else
                {
                    Console.WriteLine("Špatně");
                }
            }

            Console.WriteLine("Vyber  druh pohonu:\n eletric/hybrid");
            string Pohon = Console.ReadLine();
            VyrobeneAuta.DruhPohonu = Pohon;

            Console.WriteLine("Zadej cenu:  ");
            double Cena = Convert.ToDouble(Console.ReadLine());
            VyrobeneAuta.Cena = Cena;
            return VyrobeneAuta;
        }
        public void AutoInfo(Auto VyrobeneAuto)
        {
            Console.WriteLine("***********");
            Console.WriteLine("Chceš zobrazit tvoje vytvořené auto? Y/N");
            string Volba = Console.ReadLine();
            if (Volba.ToUpper() == "Y")
            {
                Web.VytvorStranku(VyrobeneAuto);
                Web.ZobrazStranku("index.html");
            }
        }
        public void InteraktivniMenu()
        {
            Console.Clear();

            Console.WriteLine("Vítejte v továrně na Autíčka");
            Console.WriteLine("V menu: \n---------------------------------");


            foreach (var auto in AdresyAutTelsa)
            {
                Console.WriteLine(auto.Key);
            }
            Console.ResetColor();

            Console.WriteLine("-----------------------------");
            Console.WriteLine("1. zobrazit poslední vytvořené auto\n2. Vytvořit nové auto");
            string volba = Console.ReadLine().Trim();
            if (volba == "1" || volba == "1.")
            {
                if (File.Exists("index.html"))
                {
                    Web.ZobrazStranku("index.html");
                }
                else
                {
                    Console.WriteLine("špatně");
                }
            }
            else if (volba == "2" || volba == "2.")
            {
                Auto vyrobeno = VytvorAuto();
                AutoInfo(vyrobeno);
            }
        }
    }
}
