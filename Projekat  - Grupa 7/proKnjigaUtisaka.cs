using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projekat____Grupa_7
{
    class proKnjigaUtisaka
    {


        public void Init()
        {
            string[] opcije = new string[] { "Pročitaj knjigu utisaka", "Unesite utiske", "Povratak na glavni meni" };


            proMenu Knjiga = new proMenu(opcije.ToArray(), @"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

Knjiga utisaka:
");

            int izabraniIndex = Knjiga.PokreniMeni();


            if (izabraniIndex == 0)
            {
                Console.Clear();
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

Knjiga utisaka
_______________________________________________________________________________________________________________
");
                if (File.ReadAllText(Properties.Resources.LokacijaPomocnihFajlova + "knjiga_utisaka.pf") == "")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Knjiga utisaka je prazna"); 
                }
                else
                {
                    Console.WriteLine(File.ReadAllText(Properties.Resources.LokacijaPomocnihFajlova + "knjiga_utisaka.pf"));
                }
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Povratak na prethodni meni");
                Console.ResetColor();
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
                proKnjigaUtisaka knj = new proKnjigaUtisaka();
                knj.Init();
                return;
            }
            else if (izabraniIndex == 1)
            {
                Console.Clear();
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

Unos utisaka:
"
);
                Console.WriteLine("Upisati utiske (pisati sve rečenice u jednom redu, biće prikazane svaka posebno):");
                Console.CursorVisible = true;
                Console.ForegroundColor = ConsoleColor.White;
                string[] ut = Console.ReadLine().Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                while (ut.Length == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Podaci nisu uneti! Molimo unesite utiske: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    ut = Console.ReadLine().Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                }
                string[] utisak = new string[ut.Length];
                for (int i = 0; i < ut.Length; i++) utisak[i] = ut[i].Trim();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Unesite Vaše ime: ");
                Console.ForegroundColor = ConsoleColor.White;
                string ime1 = Console.ReadLine();
                while (ime1 == "" )
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ime nije uneto pravilno ili nije uneto uopšte, pokušajte ponovo: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    ime1 = Console.ReadLine();
                }

                Console.CursorVisible = false; 

                if (File.ReadAllText(Properties.Resources.LokacijaPomocnihFajlova + "knjiga_utisaka.pf") == "")
                {
                    File.WriteAllLines(Properties.Resources.LokacijaPomocnihFajlova + "knjiga_utisaka.pf", utisak);
                    File.AppendAllText(Properties.Resources.LokacijaPomocnihFajlova + "knjiga_utisaka.pf", "\n\n" + ime1 + "\n_______________________________________________________________________________________________________________\n");
                   
                }
                else
                {
                    File.AppendAllLines(Properties.Resources.LokacijaPomocnihFajlova + "knjiga_utisaka.pf", utisak);
                    File.AppendAllText(Properties.Resources.LokacijaPomocnihFajlova + "knjiga_utisaka.pf", "\n\n" + ime1 + "\n_______________________________________________________________________________________________________________\n");
                }

            

                Console.WriteLine("Utisak uspešno unet");
                System.Threading.Thread.Sleep(1730);
                proKnjigaUtisaka knj = new proKnjigaUtisaka();
                knj.Init();
                return;

            }

            else if(izabraniIndex == 2)
            {
                proFeatures a = new proFeatures();
                a.Init();
                return;
            }
        }
    }
}
