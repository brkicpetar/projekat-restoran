using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projekat____Grupa_7
{
    class proMenadzer
    {
        private string ispravniUsername = "admin";
        private string ispravnaLozinka = "R3J1cGE3";
        private bool daLiJePrijavljeno = false;
        private void IspisNaslova()
        {
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
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

Menadžer restorana - prijava na sistem:
");
        }
        //jela
        private void IzmenaJelovnika()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.ResetColor();
            proMenu meniIzmenaJelovnika = new proMenu(new string[] { "Novo jelo", "Izmeni jelo", "Briši jelo", "Povratak na menadžerski meni" }, @"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

Izmena jelovnika:
");
            List<string> jela = File.ReadAllLines(Properties.Resources.LokacijaPomocnihFajlova + "meni.pf").ToList();
            List<string> jelaMeni = new List<string>();
            foreach (var item in jela) jelaMeni.Add(item);
            jelaMeni.Add("Odustani od izmena");
            int izabranaStavka = meniIzmenaJelovnika.PokreniMeni();
            if (izabranaStavka == 3)
            {
                Console.Clear();
                Init();
            }
            else if (izabranaStavka == 2)
            {
                proMenu izborJelaZaBrisanje = new proMenu(jelaMeni.ToArray(), @"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

Izaberite jelo koje želite da obrišete iz jelovnika:
");
                int jeloZaBrisanjeIndex = izborJelaZaBrisanje.PokreniMeni();
                if (jeloZaBrisanjeIndex == jela.Count) IzmenaJelovnika();
                else
                {
                    string jeloZaBrisanjeString = jela[jeloZaBrisanjeIndex];
                    jela.Remove(jeloZaBrisanjeString);
                    File.Delete(Properties.Resources.LokacijaPomocnihFajlova + "meni.pf");
                    File.WriteAllLines(Properties.Resources.LokacijaPomocnihFajlova + "meni.pf", jela.ToArray());
                    File.Delete(Properties.Resources.LokacijaPomocnihFajlova + @"Detalji o artiklima\" + jeloZaBrisanjeString + ".pf");
                    IzmenaJelovnika();
                }
            }
            else if (izabranaStavka == 0)
            {
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

Unos novog jela:
");
                Console.ResetColor();
                Console.CursorVisible = true;
                Console.Write("Ime jela: ");
                Console.InputEncoding = Encoding.UTF8;
                string imeNovogJela = Console.ReadLine();
                while (imeNovogJela == "")
                {
                    Console.Write("Podaci nisu uneti! Molim unesite ime novog jela: ");
                    imeNovogJela = Console.ReadLine();
                }
                Console.Write("Cena u dinarima(bez PDV-a): ");
                string cena = Console.ReadLine();
                while (!int.TryParse(cena, out int tempInt) || tempInt == 0)
                {
                    Console.Write("Podaci nisu uneti! Molim unesite cenu: ");
                    cena = Console.ReadLine();
                }
                Console.WriteLine("Detalji o jelu (pisati sve rečenice u jednom redu, biće prikazane svaka posebno):");
                string[] detaljiOJelu = Console.ReadLine().Split('.');
                while (detaljiOJelu.Length == 0 || detaljiOJelu[0] == "")
                {
                    Console.Write("Podaci nisu uneti! Molim unesite detalje: ");
                    detaljiOJelu = Console.ReadLine().Split('.');
                }
                Console.CursorVisible = false;
                for (int i = 0; i < detaljiOJelu.Length; i++)
                {
                    detaljiOJelu[i] = detaljiOJelu[i].Trim();
                }
                if (!File.ReadAllLines(Properties.Resources.LokacijaPomocnihFajlova + "meni.pf").Contains(imeNovogJela + "=" + cena))
                {
                    if(File.ReadAllText(Properties.Resources.LokacijaPomocnihFajlova + "meni.pf").EndsWith(Environment.NewLine))
                    {
                        File.AppendAllText(Properties.Resources.LokacijaPomocnihFajlova + "meni.pf", imeNovogJela + "=" + cena);
                    }
                    else File.AppendAllText(Properties.Resources.LokacijaPomocnihFajlova + "meni.pf", "\n" + imeNovogJela + "=" + cena);
                }
                else
                {
                    Console.WriteLine("Ovo jelo već postoji u jelovniku. Prebacujem na meni izmene jelovnika.");
                    System.Threading.Thread.Sleep(1000);
                    IzmenaJelovnika();
                }
                File.WriteAllLines(Properties.Resources.LokacijaPomocnihFajlova + @"Detalji o artiklima\" + imeNovogJela + "=" + cena + ".pf", detaljiOJelu);
                Console.WriteLine("");
                Console.WriteLine("Novo jelo dodato u jelovnik!");
                System.Threading.Thread.Sleep(1000);
                IzmenaJelovnika();
            }
            else if (izabranaStavka == 1)
            {
                proMenu meniZaIzmenuJela = new proMenu(jelaMeni.ToArray(), @"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

Izaberite jelo koje želite da izmenite:
");
                if (jelaMeni.Count == 1)
                {
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

Izaberite jelo koje želite da izmenite:
");
                    Console.WriteLine("Nema unetih jela u sistem. Za povratak na prethodni meni pritisnite dugme ESC.");
                    while (Console.ReadKey(true).Key != ConsoleKey.Escape) { }
                    IzmenaJelovnika();
                }
                else
                {
                    int izabranoJeloZaIzmenuIndex = meniZaIzmenuJela.PokreniMeni();
                    if (izabranoJeloZaIzmenuIndex == jelaMeni.Count - 1) IzmenaJelovnika();
                    string izabranoJeloZaIzmenuString = jela[izabranoJeloZaIzmenuIndex];
                    IzmenaJela(izabranoJeloZaIzmenuIndex, izabranoJeloZaIzmenuString, jela.ToArray());
                }
            }
        }

        private void IzmenaJela(int index, string item, string[] jela)
        {
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

{0}:
", item);
            Console.Write("Novo ime jela (ukoliko ne želite da promenite ime, ostavite prazno): ");
            Console.CursorVisible = true;
            Console.InputEncoding = Encoding.UTF8;
            string novoIme = Console.ReadLine();
            if (novoIme == "") novoIme = item.Split('=')[0];
            Console.Write("Nova cena jela (ukoliko ne želite da promenite cenu, ostavite prazno): ");
            string novaCena = Console.ReadLine();
            Console.CursorVisible = false;
            if (novaCena == "") novaCena = item.Split('=')[1];
            File.Move(Properties.Resources.LokacijaPomocnihFajlova + @"Detalji o artiklima\" + item + ".pf", Properties.Resources.LokacijaPomocnihFajlova + @"Detalji o artiklima\" + novoIme + "=" + novaCena + ".pf");
            StringBuilder builder = new StringBuilder(File.ReadAllText(Properties.Resources.LokacijaPomocnihFajlova + "meni.pf"));
            builder.Replace(item, novoIme + "=" + novaCena);
            File.WriteAllText(Properties.Resources.LokacijaPomocnihFajlova + "meni.pf", builder.ToString());
            Console.Write("Uskoro će se otvoriti Notepad sa deskripcijom jela. Unesite željene izmene, sačuvajte i izađite iz Notepada.");
            System.Threading.Thread.Sleep(1500);
            System.Diagnostics.Process.Start("notepad.exe", Properties.Resources.LokacijaPomocnihFajlova + @"Detalji o artiklima\" + novoIme + "=" + novaCena + ".pf");
            while (System.Diagnostics.Process.GetProcessesByName("notepad").Length != 0) { }
            Console.WriteLine("\nIzmene uspešno unete!");
            System.Threading.Thread.Sleep(1500);
            IzmenaJelovnika();
        }
        //end jela


        //pica
        private void IzmenaKartePica()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.ResetColor();
            proMenu meniIzmenaKartePica = new proMenu(new string[] { "Novo piće", "Izmeni piće", "Briši piće", "Povratak na menadžerski meni" }, @"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

Izmena karte pića:
");
            List<string> pica = File.ReadAllLines(Properties.Resources.LokacijaPomocnihFajlova + "karta_pica.pf").ToList();
            List<string> picaMeni = new List<string>();
            foreach (var item in pica) picaMeni.Add(item);
            picaMeni.Add("Odustani od izmena");
            int izabranaStavka = meniIzmenaKartePica.PokreniMeni();
            if (izabranaStavka == 3)
            {
                Console.Clear();
                Init();
            }
            else if (izabranaStavka == 2)
            {
                proMenu izborPicaZaBrisanje = new proMenu(picaMeni.ToArray(), @"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

Izaberite piće koje želite da obrišete iz karte pića:
");
                int piceZaBrisanjeIndex = izborPicaZaBrisanje.PokreniMeni();
                if (piceZaBrisanjeIndex == pica.Count) IzmenaKartePica();
                else
                {
                    string piceZaBrisanjeString = pica[piceZaBrisanjeIndex];
                    pica.Remove(piceZaBrisanjeString);
                    File.Delete(Properties.Resources.LokacijaPomocnihFajlova + "karta_pica.pf");
                    File.WriteAllLines(Properties.Resources.LokacijaPomocnihFajlova + "karta_pica.pf", pica.ToArray());
                    File.Delete(Properties.Resources.LokacijaPomocnihFajlova + @"Detalji o artiklima\" + piceZaBrisanjeString + ".pf");
                    IzmenaKartePica();
                }
            }
            else if (izabranaStavka == 0)
            {
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

Unos novog pića:
");
                Console.ResetColor();
                Console.CursorVisible = true;
                Console.Write("Ime pića: ");
                Console.InputEncoding = Encoding.UTF8;
                string imeNovogPica = Console.ReadLine();
                while(imeNovogPica == "")
                {
                    Console.WriteLine("Podaci nisu uneti! Molim unesite ime novog jela: ");
                }
                Console.Write("Cena u dinarima(bez PDV-a): ");
                string cena = Console.ReadLine();
                while(!int.TryParse(cena, out int tempInt) || tempInt == 0)
                {
                    Console.WriteLine("Podaci nisu uneti! Molim unesite cenu: ");
                    cena = Console.ReadLine();
                }
                Console.WriteLine("Detalji o piću (pisati sve rečenice u jednom redu, biće prikazane svaka posebno):");
                string[] detaljiOPicu = Console.ReadLine().Split('.');
                while(detaljiOPicu.Length == 0 || detaljiOPicu[0] == "")
                {
                    Console.WriteLine("Podaci nisu uneti! Molim unesite detalje: ");
                    detaljiOPicu = Console.ReadLine().Split('.');
                }
                Console.CursorVisible = false;
                for (int i = 0; i < detaljiOPicu.Length; i++)
                {
                    detaljiOPicu[i] = detaljiOPicu[i].Trim();
                }
                if (!File.ReadAllLines(Properties.Resources.LokacijaPomocnihFajlova + "karta_pica.pf").Contains(imeNovogPica + "=" + cena))
                {
                    if(File.ReadAllText(Properties.Resources.LokacijaPomocnihFajlova + "karta_pica.pf").EndsWith(Environment.NewLine))
                    {
                        File.AppendAllText(Properties.Resources.LokacijaPomocnihFajlova + "karta_pica.pf", imeNovogPica + "=" + cena);
                    }
                    else File.AppendAllText(Properties.Resources.LokacijaPomocnihFajlova + "karta_pica.pf", "\n" + imeNovogPica + "=" + cena);
                }
                else
                {
                    Console.WriteLine("Ovo piće već postoji u karti pića. Prebacujem na meni izmene karte pića.");
                    System.Threading.Thread.Sleep(1000);
                    IzmenaKartePica();
                }
                File.WriteAllLines(Properties.Resources.LokacijaPomocnihFajlova + @"Detalji o artiklima\" + imeNovogPica + "=" + cena + ".pf", detaljiOPicu);
                Console.WriteLine("");
                Console.WriteLine("Novo piće dodato u kartu pića!");
                System.Threading.Thread.Sleep(1000);
                IzmenaKartePica();
            }
            else if (izabranaStavka == 1)
            {
                proMenu meniZaIzmenuPica = new proMenu(picaMeni.ToArray(), @"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

Izaberite piće koje želite da izmenite:
");
                if (picaMeni.Count == 1)
                {
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

Izaberite piće koje želite da izmenite:
");
                    Console.WriteLine("Nema unetih pića u sistem. Za povratak na prethodni meni pritisnite dugme ESC.");
                    while(Console.ReadKey(true).Key != ConsoleKey.Escape) { }
                    IzmenaKartePica();
                }
                else
                {
                    int izabranoPiceZaIzmenuIndex = meniZaIzmenuPica.PokreniMeni();
                    if (izabranoPiceZaIzmenuIndex == picaMeni.Count - 1) IzmenaKartePica();
                    string izabranoPiceZaIzmenuString = pica[izabranoPiceZaIzmenuIndex];
                    IzmenaPica(izabranoPiceZaIzmenuIndex, izabranoPiceZaIzmenuString, pica.ToArray());
                }
            }
        }

        private void IzmenaPica(int index, string item, string[] pica)
        {
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

{0}:
", item);
            Console.InputEncoding = Encoding.UTF8;
            Console.Write("Novo ime pića (ukoliko ne želite da promenite ime, ostavite prazno): ");
            Console.CursorVisible = true;
            string novoIme = Console.ReadLine();
            if (novoIme == "") novoIme = item.Split('=')[0];
            Console.Write("Nova cena pića (ukoliko ne želite da promenite cenu, ostavite prazno): ");
            string novaCena = Console.ReadLine();
            Console.CursorVisible = false;
            if (novaCena == "") novaCena = item.Split('=')[1];
            File.Move(Properties.Resources.LokacijaPomocnihFajlova + @"Detalji o artiklima\" + item + ".pf", Properties.Resources.LokacijaPomocnihFajlova + @"Detalji o artiklima\" + novoIme + "=" + novaCena + ".pf");
            StringBuilder builder = new StringBuilder(File.ReadAllText(Properties.Resources.LokacijaPomocnihFajlova + "karta_pica.pf"));
            builder.Replace(item, novoIme + "=" + novaCena);
            File.WriteAllText(Properties.Resources.LokacijaPomocnihFajlova + "karta_pica.pf", builder.ToString());
            Console.Write("Uskoro će se otvoriti Notepad sa opisom pića. Unesite željene izmene, sačuvajte i izađite iz Notepada.");
            System.Threading.Thread.Sleep(1500);
            System.Diagnostics.Process.Start("notepad.exe", Properties.Resources.LokacijaPomocnihFajlova + @"Detalji o artiklima\" + novoIme + "=" + novaCena + ".pf");
            while (System.Diagnostics.Process.GetProcessesByName("notepad").Length != 0) { }
            Console.WriteLine("\nIzmene uspešno unete!");
            System.Threading.Thread.Sleep(1500);
            IzmenaKartePica();
        }
        //end pica

        private string UnosSifre()
        {
            StringBuilder builder = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo k = Console.ReadKey(true);
                if (k.Key == ConsoleKey.Enter) break;
                if (k.Key == ConsoleKey.Backspace && builder.Length > 0) builder.Remove(builder.Length - 1, 1);
                else if (k.Key != ConsoleKey.Backspace) builder.Append(k.KeyChar);
            }
            return builder.ToString();

        }

        private void PrijavaNaSistem()
        {
            IspisNaslova();
            Console.ResetColor();
            Console.WriteLine("Ukoliko želite da nastavite sa prijavom, pritisnite dugme ENTER");
            Console.WriteLine("Ukoliko želite da se vratite na glavni meni, pritisnite dugme ESC");
            Console.WriteLine("Povratak na glavni meni sa prijavnog formulara nije moguć.");
            ConsoleKeyInfo k = Console.ReadKey(true);

            while (k.Key != ConsoleKey.Escape && k.Key != ConsoleKey.Enter) k = Console.ReadKey(true);
            if (k.Key == ConsoleKey.Escape)
            {
                new proFeatures().Init();
            }
            IspisNaslova();
            Console.ResetColor();
            Console.CursorVisible = true;
            Console.Write("Korisničko ime: ");
            string unetiUsername = Console.ReadLine();
            Console.Write("Lozinka: ");
            string unetaLozinka = UnosSifre();
            Console.WriteLine();
            Console.CursorVisible = false;

            if (unetiUsername != ispravniUsername || Convert.ToBase64String(Encoding.ASCII.GetBytes(unetaLozinka)) != ispravnaLozinka)
            {
                Console.WriteLine("Prijava na sistem neuspešna! Proverite unete parametre i pokušajte ponovo!");
                System.Threading.Thread.Sleep(2000);
                Console.Clear();
                Init();
            }
            Console.WriteLine("Prijava uspešna!");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            daLiJePrijavljeno = true;
        }
        public void Init()
        {
            if (!daLiJePrijavljeno) PrijavaNaSistem();

            proMenu meni = new proMenu(new string[] { "Izmena jelovnika", "Izmena karte pića", "Brisanje podataka iz knjige utisaka", "Povratak na glavni meni" }, @"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

Pristup sistemu restorana:
");
            int izabraniIndex = meni.PokreniMeni();
            if (izabraniIndex == 3)
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

Da li ste sigurni da želite da se vratite na glavni meni?
");
                Console.WriteLine("Pritisnite dugme ENTER ukoliko želite, u suprotnom pritisnite dugme ESC");
                ConsoleKeyInfo k = Console.ReadKey(true);
                while (k.Key != ConsoleKey.Enter && k.Key != ConsoleKey.Escape) k = Console.ReadKey(true);
                if (k.Key == ConsoleKey.Enter)
                {
                    daLiJePrijavljeno = false;
                    new proFeatures().Init();
                }
                else if (k.Key == ConsoleKey.Escape) Init();
            }
            else if (izabraniIndex == 2)
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

Da li ste sigurni da želite da obrišete sadržaj knjige utisaka? Ova radnja je neopoziva.
");
                Console.WriteLine("Pritisnite dugme ENTER ukoliko želite, u suprotnom pritisnite dugme ESC");
                ConsoleKeyInfo k = Console.ReadKey(true);
                if (k.Key == ConsoleKey.Enter)
                {
                    File.WriteAllText(Properties.Resources.LokacijaPomocnihFajlova + "knjiga_utisaka.pf", "");
                    Init();
                }
                else if (k.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Init();
                }
            }
            else if(izabraniIndex == 0)
            {
                IzmenaJelovnika();
            }
            else if(izabraniIndex == 1)
            {
                IzmenaKartePica();
            }

        }
    }
}