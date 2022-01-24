using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projekat____Grupa_7
{
    class proNarudzbine
    {
        public void Init()
        {
            Console.Clear();
            proMenu OdabirStola = new proMenu(new string[] {"Prvi sto", "Drugi sto", "Treci sto", "Cetvrti sto", "Peti sto", "Povratak na glavni meni"}, @"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

Odaberite sto za koji je narudžbina:
");
            int IzabraniSto = OdabirStola.PokreniMeni();
            if (IzabraniSto == 5)
            {
                proFeatures f = new proFeatures();
                f.Init();
                return;
            }
            line34:
            proMenu OdabirOpcije = new proMenu(new string[] { "Jelovnik", "Karta pića", "Zakljuci racun", "Povratak na odabir stolova" }, @"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

Odaberite opciju:
");
            int IzabranaOpcija = OdabirOpcije.PokreniMeni();
            if (IzabranaOpcija == 0) //jelovnik
            {
                string[] menuContent = File.ReadAllLines(Properties.Resources.LokacijaPomocnihFajlova + "meni.pf");
                string[] opcije = new string[menuContent.Length + 1];
                for (int i = 0; i < menuContent.Length; i++)
                {
                    opcije[i] = menuContent[i].Split('=')[0];
                }
                opcije[menuContent.Length] = "Povratak na odabir opcija";
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                proMenu meni = new proMenu(opcije, @"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

Jelovnik:
" + (opcije.Length == 1 ? @"
Trenutno nema unetih jela u jelovnik. Kontaktirajte menadžera restorana!
" : ""));
                int IzabraniIndex = meni.PokreniMeni();
                if (IzabraniIndex == menuContent.Length)
                    goto line34;
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(@"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

Koliko {0} zelite da narucite: ", opcije[IzabraniIndex]);
                    int broj = -1;
                    Console.ForegroundColor = ConsoleColor.White;
                    while (!int.TryParse(Console.ReadLine(), out broj) || broj < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Nije dobar unos. Pokusajte ponovo: ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (File.ReadAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Stolovi\sto" + (IzabraniSto + 1).ToString() + ".pf").Split('=').Length == 1) 
                    {
                        File.WriteAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Stolovi\sto" + (IzabraniSto + 1).ToString() + ".pf", "");
                    }
                    if (File.ReadAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Stolovi\sto" + (IzabraniSto + 1).ToString() + ".pf") == "")
                    {
                        File.WriteAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Stolovi\sto" + (IzabraniSto + 1).ToString() + ".pf", menuContent[IzabraniIndex] + "=" + broj + "\n");
                        File.WriteAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Trenutni Racuni\racun" + (IzabraniSto + 1).ToString() + ".pf", opcije[IzabraniIndex] + ", " + broj + "\n");
                    }
                    else 
                    {
                        File.AppendAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Stolovi\sto" + (IzabraniSto + 1).ToString() + ".pf", menuContent[IzabraniIndex] + "=" + broj + "\n");
                        File.AppendAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Trenutni Racuni\racun" + (IzabraniSto + 1).ToString() + ".pf", opcije[IzabraniIndex] + ", " + broj + "\n");
                    }
                    Console.WriteLine("Uspešno dodato na račun.");
                    System.Threading.Thread.Sleep(2500);
                    goto line34;
                }
            }
            else if (IzabranaOpcija == 1) 
            {
                string[] menuContent = File.ReadAllLines(Properties.Resources.LokacijaPomocnihFajlova + "karta_pica.pf");
                string[] opcije = new string[menuContent.Length + 1];
                for (int i = 0; i < menuContent.Length; i++)
                {
                    opcije[i] = menuContent[i].Split('=')[0];
                }
                opcije[menuContent.Length] = "Povratak na glavni meni";
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                proMenu meni = new proMenu(opcije, @"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

Karta pića:
" + (opcije.Length == 1 ? @"
Trenutno nema unetih pića u kartu pića. Kontaktirajte menadžera restorana!
" : ""));
                int IzabraniIndex = meni.PokreniMeni();
                if (IzabraniIndex == menuContent.Length)
                    goto line34;
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(@"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

Koliko {0} zelite da narucite: ", opcije[IzabraniIndex]);
                    int broj = -1;
                    Console.ForegroundColor = ConsoleColor.White;
                    while (!int.TryParse(Console.ReadLine(), out broj) || broj < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Nije dobar unos. Pokusajte ponovo: ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (File.ReadAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Stolovi\sto" + (IzabraniSto + 1).ToString() + ".pf").Split('=').Length == 1)
                    {
                        File.WriteAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Stolovi\sto" + (IzabraniSto + 1).ToString() + ".pf", "");
                    }
                    if (File.ReadAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Stolovi\sto" + (IzabraniSto + 1).ToString() + ".pf") == "")
                    {
                        File.WriteAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Stolovi\sto" + (IzabraniSto + 1).ToString() + ".pf", menuContent[IzabraniIndex] + "=" + broj + "\n");
                        File.WriteAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Trenutni Racuni\racun" + (IzabraniSto + 1).ToString() + ".pf", opcije[IzabraniIndex] + ", " + broj + "\n");
                    }
                    else
                    {
                        File.AppendAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Stolovi\sto" + (IzabraniSto + 1).ToString() + ".pf", menuContent[IzabraniIndex] + "=" + broj + "\n");
                        File.AppendAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Trenutni Racuni\racun" + (IzabraniSto + 1).ToString() + ".pf", opcije[IzabraniIndex] + ", " + broj + "\n");
                    }
                    Console.WriteLine("Uspešno dodato na račun.");
                    System.Threading.Thread.Sleep(2500);
                    goto line34;
                }
            }
            else if (IzabranaOpcija == 2) 
            {
                int cena_PDV = 0;
                string[] racun = File.ReadAllLines(Properties.Resources.LokacijaPomocnihFajlova + @"Stolovi\sto" + (IzabraniSto + 1).ToString() + ".pf");
                foreach(var item in racun)
                {
                    cena_PDV += int.Parse(item.Split('=')[1]) * int.Parse(item.Split('=')[2]);
                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(@"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

Zaključivanje računa:
");
                bool penzioner = false;
                Console.Write("Da li je osoba penzioner? ");
                Console.ForegroundColor = ConsoleColor.White;
                string a = Console.ReadLine();
                while (a != "da" && a != "ne")
                {
                    Console.WriteLine("Nije dobar upis.");
                    a = Console.ReadLine();
                }
                penzioner = a == "da";
                double cena = cena_PDV * 1.11;
                if (penzioner) cena *= 0.88;
                else cena *= 1.2;
                string pdv = !penzioner ? (cena_PDV * 1.11 * 0.2).ToString() : "0";
                string popust = penzioner ? (cena_PDV * 1.11 * 0.12).ToString() : "0";
                File.AppendAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Trenutni Racuni\racun" + (IzabraniSto + 1).ToString() + ".pf",
                    @"----------------------------
Cena bez PDV-a: " + cena_PDV + @" RSD
PDV: " + pdv + @" RSD
Popust: " + popust + @" RSD
----------------------------
Ukupna cena: " + cena.ToString("0.00") + @" RSD
");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Uspešno zaključen račun. Dođite nam ponovo!");
                System.Threading.Thread.Sleep(2500);
                File.WriteAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Stolovi\sto" + (IzabraniSto + 1).ToString() + ".pf", "");
                File.Copy(Properties.Resources.LokacijaPomocnihFajlova + @"Trenutni Racuni\racun" + (IzabraniSto + 1).ToString() + ".pf",
                    Properties.Resources.LokacijaPomocnihFajlova + @"Arhiva\Racun " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".pf");
                File.WriteAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Trenutni Racuni\racun" + (IzabraniSto + 1).ToString() + ".pf", "");
                proFeatures f = new proFeatures();
                f.Init();
                return;
            }
            else if (IzabranaOpcija == 3)
            {
                proNarudzbine n = new proNarudzbine();
                n.Init();
                return;
            }
        }
    }
}
