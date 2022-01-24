using System;
using System.Text;

namespace Projekat____Grupa_7
{
    class proFeatures
    {
        public void Init()
        {
            Console.Title = "Projekat \"Aplikacija za Restoran\" - Grupa 7";
            Console.WriteLine(@"");
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            PokretanjeMenija();
        }
        private void PokretanjeMenija()
        {
            string[] opcije = new string[] { "Jelovnik", "Karta pića", "Narudžbine", "Rezervacija", "Naručivanje telefonom", "Knjiga utisaka", "Menadžer restorana - prijava na sistem", "Napusti program" };
            proMenu meni = new proMenu(opcije, @"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

Glavni meni:
");
            int IzabraniIndex = meni.PokreniMeni();

            if (IzabraniIndex == opcije.Length - 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.WriteLine(@"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

Da li ste sigurni da želite da napustite aplikaciju?
");
                Console.WriteLine("Pritisnite dugme ENTER ukoliko želite, u suprotnom pritisnite dugme ESC");
                ConsoleKeyInfo k = Console.ReadKey(true);
                while (k.Key != ConsoleKey.Enter && k.Key != ConsoleKey.Escape) k = Console.ReadKey(true);
                if (k.Key == ConsoleKey.Enter) Environment.Exit(0);
                else if (k.Key == ConsoleKey.Escape) Init();
            }
            else if (IzabraniIndex == 0)
            {
                proJelovnik p = new proJelovnik();
                p.Init();
            }
            else if (IzabraniIndex == 6)
            {
                proMenadzer m = new proMenadzer();
                m.Init();
            }
            else if (IzabraniIndex == 2)
            {
                proNarudzbine r = new proNarudzbine();
                r.Init();
            }
            else if (IzabraniIndex == 1)
            {
                proKartaPica k = new proKartaPica();
                k.Init();
            }
            else if (IzabraniIndex == 3)
            {
                proRezervacija j = new proRezervacija();
                j.Init();
            }
            else if (IzabraniIndex == 5)
            {
                proKnjigaUtisaka n = new proKnjigaUtisaka();
                n.Init();
            }
            else if (IzabraniIndex == 4)
            {
                proTelefon u = new proTelefon();
                u.Init();
            }

        }
    }
}
