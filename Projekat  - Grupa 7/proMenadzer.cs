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
            Console.OutputEncoding = Encoding.Unicode;
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
            proMenu meniIzmenaJelovnika = new proMenu(new string[] { "Novo jelo", "Izmeni jelo", "Briši jelo", "Dodaj novu kategoriju", "Izmeni kategoriju", "Briši kategoriju", "Povratak na menadžerski meni" }, @"                           _ _ _              _ _                    _____           _                        
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
            List<string> kategorijeSaPathovima = Directory.GetDirectories(Properties.Resources.LokacijaPomocnihFajlova + @"Jelovnik\").ToList();
            List<string> kategorije = new List<string>();
            List<string> kategorijeZaMeni = new List<string>();
            foreach (var item in kategorijeSaPathovima)
            {
                kategorije.Add(Path.GetFileName(item).Trim());
                kategorijeZaMeni.Add(Path.GetFileName(item).Split('.')[1].Trim());
            }
            kategorijeZaMeni.Add("Povratak na glavni meni");

            int izabraniIndex = meniIzmenaJelovnika.PokreniMeni();
            if (izabraniIndex == 6)
            {
                Console.Clear();
                Init();
                return;
            }
            else if (izabraniIndex == 3)
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

Unesite ime nove kategorije:");
                Console.ResetColor();
                Console.CursorVisible = true;
                string imeKategorije = Console.ReadLine();
                while (imeKategorije == "")
                {
                    Console.Write("Nije dobar unos! Pokušajte ponovo: ");
                    imeKategorije = Console.ReadLine();
                }
                Console.CursorVisible = false;
                string[] dirs = Directory.GetDirectories(Properties.Resources.LokacijaPomocnihFajlova + @"Jelovnik\");
                string broj = (int.Parse(Path.GetFileName(dirs[dirs.Length - 1].Split('.')[0].Trim())) + 1).ToString();
                Directory.CreateDirectory(Properties.Resources.LokacijaPomocnihFajlova + @"Jelovnik\" + broj + ". " + imeKategorije);
                IzmenaJelovnika();
            }
            else if (izabraniIndex == 4)
            {
                proMenu izborKategorija = new proMenu(kategorijeZaMeni.ToArray(), @"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

Izaberite kategoriju za izmenu:
");
                int index = izborKategorija.PokreniMeni();
                if (index == kategorije.Count)
                {
                    IzmenaJelovnika();
                    return;
                }
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

Novo ime za kategoriju {0}: ", kategorije[index]);
                    Console.ResetColor();
                    string novoIme = Console.ReadLine();
                    string broj = kategorije[index].Split('.')[0].Trim();
                    while (novoIme == "")
                    {
                        Console.Write("Nije dobar unos! Pokušajte ponovo: ");
                        novoIme = Console.ReadLine();
                    }
                    Directory.Move(kategorijeSaPathovima[index], Properties.Resources.LokacijaPomocnihFajlova + @"Jelovnik\" + broj + ". " + novoIme);
                    Console.WriteLine(Environment.NewLine + "Izmene uspešno unete!");
                    System.Threading.Thread.Sleep(1500);
                    IzmenaJelovnika();
                }
            }
            else if (izabraniIndex == 5)
            {
                proMenu izborKategorija = new proMenu(kategorijeZaMeni.ToArray(), @"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

Izaberite kategoriju za izmenu:
");
                int index = izborKategorija.PokreniMeni();
                if (index == kategorije.Count)
                {
                    IzmenaJelovnika();
                    return;
                }
                else
                {
                    Directory.Delete(kategorijeSaPathovima[index], true);
                    IzmenaJelovnika();
                }
            }
            else if (izabraniIndex == 2)
            {
            Line72:
                proMenu izborKategorije = new proMenu(kategorijeZaMeni.ToArray(), @"                           _ _ _              _ _                    _____           _                        
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
                int izabranaKategorija = izborKategorije.PokreniMeni();
                if (izabranaKategorija == kategorije.Count)
                {
                    IzmenaJelovnika();
                    return;
                }
                else
                {
                    List<string> jelaSaPathovima = Directory.GetDirectories(Properties.Resources.LokacijaPomocnihFajlova + @"Jelovnik\" + kategorije[izabranaKategorija] + @"\").ToList();
                    List<string> jela = new List<string>();
                    foreach (var item in jelaSaPathovima) jela.Add(Path.GetFileName(item).Trim());
                    jela.Add("Povratak na izbor kategorija");
                    proMenu izborJela = new proMenu(jela.ToArray(), @"                           _ _ _              _ _                    _____           _                        
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
                    int izabranoJelo = izborJela.PokreniMeni();
                    if (izabranoJelo == jelaSaPathovima.Count) goto Line72;
                    else
                    {
                        Directory.Delete(jelaSaPathovima[izabranoJelo], true);
                        Console.WriteLine(Environment.NewLine + "Brisanje uspešno");
                        System.Threading.Thread.Sleep(1500);
                        IzmenaJelovnika();
                    }

                }
            }
            else if (izabraniIndex == 0)
            {
                proMenu izborKategorije = new proMenu(kategorijeZaMeni.ToArray(), @"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

Izaberite kategoriju u koju želite da dodate jelo:
");
                int izabranaKategorija = izborKategorije.PokreniMeni();
                string kat = "";
                if (izabranaKategorija == kategorije.Count)
                {
                    IzmenaJelovnika();
                    return;
                }
                else kat = kategorije[izabranaKategorija];
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
                Console.InputEncoding = Encoding.Unicode;
                string imeNovogJela = Console.ReadLine();
                while (imeNovogJela == "")
                {
                    Console.Write("Podaci nisu uneti! Molim unesite ime novog jela: ");
                    imeNovogJela = Console.ReadLine();
                }
                Console.Write("Cena u dinarima (bez PDV-a): ");
                string cena = Console.ReadLine();
                while (!int.TryParse(cena, out int tempInt) || tempInt == 0)
                {
                    Console.Write("Podaci nisu uneti! Molimo unesite cenu: ");
                    cena = Console.ReadLine();
                }
                Console.Write("Sastojci jela (nije obavezno): ");
                string detaljiOJelu = Console.ReadLine();

                detaljiOJelu = detaljiOJelu == "" ? "<==>" : detaljiOJelu;

                Console.CursorVisible = false;

                Console.OutputEncoding = Encoding.Unicode;
                Console.WriteLine(Properties.Resources.LokacijaPomocnihFajlova + @"Jelovnik\" + kat + @"\" + imeNovogJela + @"\");
                Directory.CreateDirectory(Properties.Resources.LokacijaPomocnihFajlova + @"Jelovnik\" + kat + @"\" + imeNovogJela + @"\");
                File.WriteAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Jelovnik\" + kat + @"\" + imeNovogJela + @"\o_jelu.pf", detaljiOJelu + Environment.NewLine + cena, Encoding.Unicode);
                Console.WriteLine(Environment.NewLine + "Novo jelo uspešno dodato!");
                System.Threading.Thread.Sleep(1500);
                IzmenaJelovnika();
            }
            else if (izabraniIndex == 1)
            {
            Line189:
                proMenu izborKategorije = new proMenu(kategorijeZaMeni.ToArray(), @"                           _ _ _              _ _                    _____           _                        
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
                int izabranaKategorija = izborKategorije.PokreniMeni();
                string kat = "";
                if (izabranaKategorija == kategorije.Count)
                {
                    IzmenaJelovnika();
                    return;
                }
                else kat = kategorije[izabranaKategorija];
                List<string> jelaSaPathovima = Directory.GetDirectories(Properties.Resources.LokacijaPomocnihFajlova + @"Jelovnik\" + kat + @"\").ToList();
                List<string> jela = new List<string>();
                foreach (var item in jelaSaPathovima) jela.Add(Path.GetFileName(item).Trim());
                jela.Add("Povratak na izbor kategorija");
                proMenu izborJela = new proMenu(jela.ToArray(), @"                           _ _ _              _ _                    _____           _                        
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
                int izabranoJelo = izborJela.PokreniMeni();
                string jeloZaIzmenu = "";
                if (izabranoJelo == jelaSaPathovima.Count) goto Line189;
                else jeloZaIzmenu = jela[izabranoJelo];

                IzmenaJela(izabranoJelo, jeloZaIzmenu, jelaSaPathovima.ToArray());
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
            Console.InputEncoding = Encoding.Unicode;
            string novoIme = Console.ReadLine();
            if (novoIme != "")
            {
                Directory.Move(jela[index], Path.GetDirectoryName(jela[index]) + @"\" + novoIme);
                item = novoIme;
            }
            Console.Write("Nova cena jela (ukoliko ne želite da promenite cenu, ostavite prazno): ");
            string novaCena = Console.ReadLine();
            if (novaCena == "") novaCena = File.ReadAllLines(Path.GetDirectoryName(jela[index]) + @"\" + novoIme + @"\o_jelu.pf")[1];
            Console.Write("Da li želite da obrišete sastojke jela (da/ne): ");
            string brisati = Console.ReadLine().Trim();
            string noviSastojciJela = "";
            while (brisati != "da" && brisati != "ne")
            {
                Console.WriteLine("Nije dobar unos! Pokušajte ponovo: ");
                brisati = Console.ReadLine();
            }
            if (brisati == "da") noviSastojciJela = "<==>";
            else
            {
                Console.Write("Novi sastojci jela (ukoliko ne želite da promenite sastojke, ostavite prazno): ");
                noviSastojciJela = Console.ReadLine();
                Console.CursorVisible = false;
                if (noviSastojciJela == "") noviSastojciJela = File.ReadAllLines(Path.GetDirectoryName(jela[index]) + @"\" + novoIme + @"\o_jelu.pf")[0];
            }

            File.WriteAllText(Path.GetDirectoryName(jela[index]) + @"\" + novoIme + @"\o_jelu.pf", noviSastojciJela + Environment.NewLine + novaCena);
            Console.WriteLine(Environment.NewLine + "Izmene uspešno unete!");
            System.Threading.Thread.Sleep(1500);
            IzmenaJelovnika();
        }
        //end jela




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
                return;
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
                return;
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
                    return;
                }
                else if (k.Key == ConsoleKey.Escape)
                {
                    Init();
                    return;
                }
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
                    return;
                }
                else if (k.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Init();
                    return;
                }
            }
            else if (izabraniIndex == 0)
            {
                IzmenaJelovnika();
            }
        }
    }
}