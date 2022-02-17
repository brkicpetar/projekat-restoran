using System;
using System.IO;

namespace Projekat____Grupa_7
{
    class proDetaljiOArtiklu
    {
        private int meniKarta = -1;
        public proDetaljiOArtiklu(int MeniIliKartaPica)
        {
            meniKarta = MeniIliKartaPica;
        }
        public void PrikaziDetalje(string Kategorija, string Artikal)
        {
            string glavno = Properties.Resources.LokacijaPomocnihFajlova + (meniKarta == 0 ? @"Jelovnik\" : @"Karta pica\") + Kategorija + @"\" + Artikal + @"\o_jelu.pf";
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             
 
_______________________________________________________________________________________________________________
 
{0} - cena (bez PDV-a): {1} RSD
", Artikal, int.Parse(File.ReadAllLines(glavno)[1]).ToString("0.00"));
            Console.ResetColor();
            string ispis = File.ReadAllLines(glavno)[0] == "<==>" ? "Očekivana cena sa PDV-om i uslugom: " + (int.Parse(File.ReadAllLines(glavno)[1]) * 1.11 * 1.2).ToString("0.00") + " RSD" :
                 (meniKarta == 0 ? "Sastojci: " : "Proizvođač: ") + File.ReadAllLines(glavno)[0] + "\n\nOčekivana cena sa PDV-om i uslugom: " + (int.Parse(File.ReadAllLines(glavno)[1]) * 1.11 * 1.2).ToString("0.00") + " RSD";
            Console.WriteLine(ispis);

            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            if (meniKarta == 0) Console.WriteLine("Povratak na kategorije jelovnika");
            else Console.WriteLine("Povratak na kategorije karte pića");
            Console.ResetColor();
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
            if (meniKarta == 0)
            {
                proJelovnik p = new proJelovnik();
                p.Init(Kategorija);
                return;
            }
            else
            {
                proKartaPica p = new proKartaPica();
                p.Init(Kategorija);
                return;
            }
        }
    }
}
