using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Projekat____Grupa_7
{
    class proNarudzbine
    {
        public void Init(string kat, int sto, int meniKarta)
        {
            Console.Clear();
            proMenu OdabirStola = new proMenu(new string[] { "Prvi sto", "Drugi sto", "Treci sto", "Četvrti sto", "Peti sto", "Povratak na glavni meni" }, @"                           _ _ _              _ _                    _____           _                        
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
            int IzabraniSto = -1;
            if (sto == -1) IzabraniSto = OdabirStola.PokreniMeni();
            else IzabraniSto = sto;
            if (IzabraniSto == 5)
            {
                proFeatures f = new proFeatures();
                f.Init();
                return;
            }
        Line36:
            proMenu OdabirOpcije = new proMenu(new string[] { "Jelovnik", "Karta pića", "Zaključi račun", "Povratak na odabir stolova" }, @"                           _ _ _              _ _                    _____           _                        
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
            int IzabranaOpcija = -1;
            if (meniKarta == -1) IzabranaOpcija = OdabirOpcije.PokreniMeni();
            else IzabranaOpcija = meniKarta;

            if (IzabranaOpcija == 0) //jelovnik
            {
            Line56:
                string[] kategorije1 = Directory.GetDirectories(Properties.Resources.LokacijaPomocnihFajlova + "Jelovnik");
                string[] opcije1 = new string[kategorije1.Length + 1];
                for (int i = 0; i < kategorije1.Length; i++)
                {
                    opcije1[i] = Path.GetFileName(kategorije1[i]).Split(new string[] { ". " }, StringSplitOptions.None)[1];
                }
                opcije1[kategorije1.Length] = "Povratak na glavni meni";
                proMenu meniKategorija = new proMenu(opcije1, @"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             
 
_______________________________________________________________________________________________________________
 
Jelovnik:
" + (opcije1.Length == 1 ? @"
Trenutno nema unetih jela u jelovnik. Kontaktirajte menadžera restorana!
" : ""));
                int izabranaKategorija = -1;
                if (kat == "") izabranaKategorija = meniKategorija.PokreniMeni();
                else izabranaKategorija = Array.IndexOf(opcije1, kat.Split(new string[] { ". " }, StringSplitOptions.None)[1]);

                if (izabranaKategorija == opcije1.Length - 1)
                {
                    proFeatures f = new proFeatures();
                    f.Init();
                    return;
                }
                string kategorija = kategorije1[izabranaKategorija];
                string[] jelaFolderi = Directory.GetDirectories(Properties.Resources.LokacijaPomocnihFajlova + @"Jelovnik\" + Path.GetFileName(kategorija));
                string[] opcije2 = new string[jelaFolderi.Length + 1];
                for (int i = 0; i < jelaFolderi.Length; i++)
                {
                    opcije2[i] = Path.GetFileName(jelaFolderi[i]);
                }
                opcije2[jelaFolderi.Length] = "Povratak na kategorije";
                proMenu meniJela = new proMenu(opcije2, @"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             
 
_______________________________________________________________________________________________________________
 
Jelovnik - " + opcije1[izabranaKategorija] + @":
" + (opcije2.Length == 1 ? @"
Trenutno nema unetih jela u jelovnik. Kontaktirajte menadžera restorana!
" : ""));
                int izabranoJelo = meniJela.PokreniMeni();
                if (izabranoJelo == opcije2.Length - 1)
                {
                    kat = "";
                    goto Line56;
                }


                Console.Clear();
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
 
Koliko {0} zelite da narucite: ", opcije2[izabranoJelo]);
                int broj = -1;
                Console.ResetColor();
                Console.CursorVisible = true;
                while (!int.TryParse(Console.ReadLine(), out broj) || broj < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Nije dobar unos. Pokušajte ponovo: ");
                    Console.ResetColor();
                }
                Console.CursorVisible = false;

                if (File.ReadAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Stolovi\sto" + (IzabraniSto + 1).ToString() + ".pf").Split('=').Length == 1)
                {
                    File.WriteAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Stolovi\sto" + (IzabraniSto + 1).ToString() + ".pf", "");
                }
                if (File.ReadAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Stolovi\sto" + (IzabraniSto + 1).ToString() + ".pf") == "")
                {
                    File.WriteAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Stolovi\sto" + (IzabraniSto + 1).ToString() + ".pf",
                        opcije2[izabranoJelo] + "=" + File.ReadAllLines(jelaFolderi[izabranoJelo] + @"\o_jelu.pf")[1] + "=" + broj + "\n");
                    File.WriteAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Trenutni racuni\racun" + (IzabraniSto + 1).ToString() + ".pf",
                        opcije2[izabranoJelo] + ", " + broj + ", " + (broj * int.Parse(File.ReadAllLines(jelaFolderi[izabranoJelo] + @"\o_jelu.pf")[1])).ToString("0.00") + " RSD\n");
                }
                else
                {
                    File.AppendAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Stolovi\sto" + (IzabraniSto + 1).ToString() + ".pf",
                        opcije2[izabranoJelo] + "=" + File.ReadAllLines(jelaFolderi[izabranoJelo] + @"\o_jelu.pf")[1] + "=" + broj + "\n");
                    File.AppendAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Trenutni racuni\racun" + (IzabraniSto + 1).ToString() + ".pf",
                        opcije2[izabranoJelo] + ", " + broj + ", " + (broj * int.Parse(File.ReadAllLines(jelaFolderi[izabranoJelo] + @"\o_jelu.pf")[1])).ToString("0.00") + " RSD\n");
                }
                Console.WriteLine("Uspešno dodato na račun.");
                System.Threading.Thread.Sleep(2500);
                kat = "";
                meniKarta = -1;
                goto Line36;
            }
            else if (IzabranaOpcija == 1)
            {
            Line169:
                string[] kategorije1 = Directory.GetDirectories(Properties.Resources.LokacijaPomocnihFajlova + "Karta pica");
                string[] opcije1 = new string[kategorije1.Length + 1];
                for (int i = 0; i < kategorije1.Length; i++)
                {
                    opcije1[i] = Path.GetFileName(kategorije1[i]).Split(new string[] { ". " }, StringSplitOptions.None)[1];
                }
                opcije1[kategorije1.Length] = "Povratak na glavni meni";
                proMenu meniKategorija = new proMenu(opcije1, @"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             
 
_______________________________________________________________________________________________________________
 
Karta pića:
" + (opcije1.Length == 1 ? @"
Trenutno nema unetih pića u kartu pića. Kontaktirajte menadžera restorana!
" : ""));
                int izabranaKategorija = -1;
                if (kat == "") izabranaKategorija = meniKategorija.PokreniMeni();
                else izabranaKategorija = Array.IndexOf(opcije1, kat.Split(new string[] { ". " }, StringSplitOptions.None)[1]);

                if (izabranaKategorija == opcije1.Length - 1)
                {
                    proFeatures f = new proFeatures();
                    f.Init();
                    return;
                }
                string kategorija = kategorije1[izabranaKategorija];
                string[] picaFolderi = Directory.GetDirectories(Properties.Resources.LokacijaPomocnihFajlova + @"Karta pica\" + Path.GetFileName(kategorija));
                string[] opcije2 = new string[picaFolderi.Length + 1];
                for (int i = 0; i < picaFolderi.Length; i++)
                {
                    opcije2[i] = Path.GetFileName(picaFolderi[i]);
                }
                opcije2[picaFolderi.Length] = "Povratak na kategorije";
                proMenu meniPica = new proMenu(opcije2, @"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             
 
_______________________________________________________________________________________________________________
 
Karta pića - " + opcije1[izabranaKategorija] + @":
" + (opcije2.Length == 1 ? @"
Trenutno nema unetih pića u kartu pića. Kontaktirajte menadžera restorana!
" : ""));
                int izabranoPice = meniPica.PokreniMeni();
                if (izabranoPice == opcije2.Length - 1)
                {
                    kat = "";
                    goto Line169;
                }


                Console.Clear();
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
 
Koliko {0} zelite da narucite: ", opcije2[izabranoPice]);
                int broj = -1;
                Console.ResetColor();
                Console.CursorVisible = true;
                while (!int.TryParse(Console.ReadLine(), out broj) || broj < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Nije dobar unos. Pokušajte ponovo: ");
                    Console.ResetColor();
                }
                Console.CursorVisible = false;

                if (File.ReadAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Stolovi\sto" + (IzabraniSto + 1).ToString() + ".pf").Split('=').Length == 1)
                {
                    File.WriteAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Stolovi\sto" + (IzabraniSto + 1).ToString() + ".pf", "");
                }
                if (File.ReadAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Stolovi\sto" + (IzabraniSto + 1).ToString() + ".pf") == "")
                {
                    File.WriteAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Stolovi\sto" + (IzabraniSto + 1).ToString() + ".pf",
                        opcije2[izabranoPice] + "=" + File.ReadAllLines(picaFolderi[izabranoPice] + @"\o_jelu.pf")[1] + "=" + broj + "\n");
                    File.WriteAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Trenutni racuni\racun" + (IzabraniSto + 1).ToString() + ".pf",
                        opcije2[izabranoPice] + ", " + broj + ", " + (broj * int.Parse(File.ReadAllLines(picaFolderi[izabranoPice] + @"\o_jelu.pf")[1])).ToString("0.00") + " RSD\n");
                }
                else
                {
                    File.AppendAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Stolovi\sto" + (IzabraniSto + 1).ToString() + ".pf",
                        opcije2[izabranoPice] + "=" + File.ReadAllLines(picaFolderi[izabranoPice] + @"\o_jelu.pf")[1] + "=" + broj + "\n");
                    File.AppendAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Trenutni racuni\racun" + (IzabraniSto + 1).ToString() + ".pf",
                        opcije2[izabranoPice] + ", " + broj + ", " + (broj * int.Parse(File.ReadAllLines(picaFolderi[izabranoPice] + @"\o_jelu.pf")[1])).ToString("0.00") + " RSD\n");
                }
                Console.WriteLine("Uspešno dodato na račun.");
                System.Threading.Thread.Sleep(2500);
                kat = "";
                meniKarta = -1;
                goto Line36;
            }
            else if (IzabranaOpcija == 2)
            {
                int cena_PDV = 0;
                string[] racun = File.ReadAllLines(Properties.Resources.LokacijaPomocnihFajlova + @"Stolovi\sto" + (IzabraniSto + 1).ToString() + ".pf");
                foreach (var item in racun)
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
                Console.CursorVisible = true;
                string a = Console.ReadLine();
                while (a != "da" && a != "ne")
                {
                    Console.WriteLine("Nije dobar upis.");
                    a = Console.ReadLine();
                }
                Console.CursorVisible = false;
                penzioner = a == "da";
                double cena = cena_PDV * 1.11;
                if (penzioner) cena *= 0.88;
                else cena *= 1.2;
                string pdv = !penzioner ? (cena_PDV * 1.11 * 0.2).ToString("0.00") : "0.00";
                string popust = penzioner ? (cena_PDV * 1.11 * 0.12).ToString("0.00") : "0.00";
                string usluga = (cena_PDV * 0.11).ToString("0.00");
                File.AppendAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Trenutni Racuni\racun" + (IzabraniSto + 1).ToString() + ".pf",
                    @"---------------------------------------
Cena bez PDV-a: " + cena_PDV + @" RSD
PDV: " + pdv + @" RSD
Usluga: " + usluga + @" RSD
Popust: " + popust + @" RSD
---------------------------------------
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
                n.Init("", -1, -1);
                return;
            }
        }
    }
}
