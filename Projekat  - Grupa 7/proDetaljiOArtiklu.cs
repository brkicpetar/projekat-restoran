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
        public void PrikaziDetalje(string Artikal)
        {
            Console.Clear();
            string[] lines = File.ReadAllLines(Properties.Resources.LokacijaPomocnihFajlova + @"Detalji o artiklima\" + Artikal + ".pf");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

{0} - cena: {1} RSD
", Artikal.Split('=')[0], Artikal.Split('=')[1]);
            Console.ResetColor();
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine(lines[i]);
            }

            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            if(meniKarta == 0) Console.WriteLine("Povratak na jelovnik");
            else Console.WriteLine("Povratak na kartu pića");
            Console.ResetColor();
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
            if(meniKarta == 0)
            {
                proJelovnik p = new proJelovnik();
                p.Init();
                return;
            }
            else
            {
                proKartaPica p = new proKartaPica();
                p.Init();
                return;
            }
        }
    }
}
