using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auticka
{
    internal class Stranka
    {
        public void VytvorStranku(Auto VyrobeneAuto)
        {
            string html = $@"
            <html>
            <body style='background-Color: black;'>
            <h1 style='color: white;'>Továrna na auta</h1>
            <h2 style='color: blue;'>{VyrobeneAuto.Znacka}</h2>
            <h2 style='color: white;'>{VyrobeneAuto.Model}</h2>
            <h2 style='color: white;'>Počet sedaček: {VyrobeneAuto.sedadla}</h2>
            <h2 style='color: white;'>Druh pohonu: {VyrobeneAuto.DruhPohonu}</h2>
            <img src='{VyrobeneAuto.Obraz}'>
            <h3 style='color: white;'>Rok výroby: {VyrobeneAuto.RokVyroby}</h3>
            <hr>
            <div style='color: white;'>
                Cena: <h4 style='color: orange;'>{VyrobeneAuto.Cena}</h4>
            </div>
            </body>
            </html>";
            File.WriteAllText("index.html", html);
        }
        public void ZobrazStranku(string Adresa_souboru)
        {
            var process = new System.Diagnostics.ProcessStartInfo();
            process.UseShellExecute = true;
            process.FileName = Adresa_souboru;
            System.Diagnostics.Process.Start(process);
        }
    }
}
