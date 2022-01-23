﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projekat____Grupa_7
{
    class proRezervacija
    {
        public void Init()
        {
            List<string> opcije = new List<string>();
            List<int> maxi = new List<int>();
            for (int i = 0; i <= 4; i++)
            {
                if(File.ReadAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Stolovi\sto" + (i + 1).ToString() + ".pf") == "")
                {
                    opcije.Add("Sto " + (i + 1).ToString() + " je slobodan za rezervaciju.");
                    maxi.Add(i + 1);
                }
                

            }
            opcije.Add("Povratak na glavni meni.");
            proMenu rezervacija = new proMenu(opcije.ToArray(), @"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

Izaberite sto koji zelite da rezervisete:
");
            int izabraniIndex = rezervacija.PokreniMeni();

            if (izabraniIndex == opcije.Count -1)
            {
                proFeatures j = new proFeatures();
                j.Init();
            }
            else
            {
                Console.Write("Unesite ime na koje se rezervacija cuva: ");
                string ime = Console.ReadLine();
                while (ime == "" && ime.Contains("=")) 
                { 
                    Console.WriteLine("Ime nije uneto pravilno ili nije uneto uopste, pokusajte ponovo: ");
                    ime = Console.ReadLine();
                }
                File.WriteAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Stolovi\sto" + maxi [izabraniIndex] + ".pf", ime);
                Console.WriteLine("Sto {0} je rezervisan na ime {1}" , maxi[izabraniIndex], ime );
                System.Threading.Thread.Sleep(2597);
                proFeatures j = new proFeatures();
                j.Init();
            }

            

        }
    }
}