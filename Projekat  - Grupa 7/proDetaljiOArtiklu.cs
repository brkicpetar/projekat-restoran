using System;
using System.IO;

namespace Projekat____Grupa_7
{
    class proDetaljiOArtiklu
    {
        public void PrikaziDetalje(string Artikal)
        {
            Console.Clear();
            string[] lines = File.ReadAllLines(Properties.Resources.LokacijaPomocnihFajlova + @"Detalji o artiklima\" + Artikal + ".pf");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

{0}:
", Artikal);
            Console.ResetColor();
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine(lines[i]);
            }

            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Povratak na meni jela i predjela");
            Console.ResetColor();
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
            proMeniJelaPredjela p = new proMeniJelaPredjela();
            p.Init();
        }
    }
}
