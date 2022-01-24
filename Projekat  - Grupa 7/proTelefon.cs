using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projekat____Grupa_7
{
    class proTelefon
    {
        public void Init()
        {
            proMenu opcija = new proMenu(new string[] { "Napravi novu porudzbinu", "Preuzmi i plati narucenu porudzbinu", "Povratak na glavni meni" }, @"                           _ _ _              _ _                    _____           _                        
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
            int izabraniIndex = opcija.PokreniMeni();
            if(izabraniIndex == 0)
            {
                Console.Write("Unesite ime: ");
                string ime = Console.ReadLine();
                while (ime == "")
                {
                    Console.Write("Pogresno ste uneli. Unesite ponovo: ");
                    ime = Console.ReadLine();
                }
                string date = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
                File.Create(Properties.Resources.LokacijaPomocnihFajlova + @"Narudzbine preko telefona\Narudzbina " + ime + " " + date + ".pf").Close();
                line39:
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
                {
                    proTelefon f = new proTelefon();
                    f.Init();
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

Koliko {0} zelite da narucite: ", opcije[IzabraniIndex]);
                    int broj = -1;
                    Console.ForegroundColor = ConsoleColor.White;
                    while (!int.TryParse(Console.ReadLine(), out broj) || broj < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Nije dobar unos. Pokusajte ponovo: ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    
                    if (File.ReadAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Narudzbine preko telefona\Narudzbina " + ime + " " + date + ".pf") == "")
                    {
                        File.WriteAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Narudzbine preko telefona\Narudzbina " + ime + " " + date + ".pf", menuContent[IzabraniIndex] + "=" + broj + "\n");
                        File.WriteAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Trenutni Racuni\racun " + ime + " " + date + ".pf" , opcije[IzabraniIndex] + ", " + broj + "\n");
                    }
                    else
                    {
                        File.AppendAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Narudzbine preko telefona\Narudzbina " + ime + " " + date + ".pf", menuContent[IzabraniIndex] + "=" + broj + "\n");
                        File.AppendAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Trenutni Racuni\racun " + ime + " " + date + ".pf", opcije[IzabraniIndex] + ", " + broj + "\n");
                    }
                    Console.WriteLine("Uspešno dodato na račun.");
                    System.Threading.Thread.Sleep(2500);
                    goto line39;
                }
            }
        

            else if(izabraniIndex == 1)
            {
                string[] fajlovi = Directory.GetFiles(Properties.Resources.LokacijaPomocnihFajlova + "Narudzbine preko telefona");
                List<string> listaFajlova = new List<string>();

                foreach(var item in fajlovi)
                {
                    listaFajlova.Add(Path.GetFileName(item));
                }
                listaFajlova.Add("Povratak na izbor opcija");
                proMenu meni = new proMenu(listaFajlova.ToArray(), @"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

Izaberite porudzbinu za preuzimanje: 
");
                int izabranaPorudzbina = meni.PokreniMeni();
                if(izabranaPorudzbina == fajlovi.Length)
                {
                    proTelefon g = new proTelefon();
                    g.Init();
                    return;
                }
                string ime = listaFajlova[izabranaPorudzbina].Split(' ')[1].Trim();
                string date = listaFajlova[izabranaPorudzbina].Split(' ')[2].Trim() + " " + Path.GetFileNameWithoutExtension(listaFajlova[izabranaPorudzbina]).Split(' ')[3].Trim(); 
                
                int cena_PDV = 0;
                string[] racun = File.ReadAllLines(Properties.Resources.LokacijaPomocnihFajlova + @"Narudzbine preko telefona\" + listaFajlova[izabranaPorudzbina]);

                foreach (var item in racun)
                {
                    cena_PDV += int.Parse(item.Split('=')[1]) * int.Parse(item.Split('=')[2]);
                }
                double cena = cena_PDV * 1.11 * 1.2;
                string pdv = (cena_PDV * 1.11 * 0.2).ToString("0.00");
                string popust = "0.00";
                string usluga = (cena_PDV * 1.11).ToString("0.00");
                File.AppendAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Trenutni Racuni\racun " + ime + " " + date + ".pf",
                    @"----------------------------
Cena bez PDV-a: " + cena_PDV.ToString("0.00") + @" RSD
PDV: " + pdv + @" RSD
Usluga: " + usluga + @" RSD
Popust: " + popust + @" RSD
----------------------------
Ukupna cena: " + cena.ToString("0.00") + @" RSD
");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Uspešno plaćanje. Dođite nam ponovo!");
                System.Threading.Thread.Sleep(2500);
                File.Delete(Properties.Resources.LokacijaPomocnihFajlova + @"Narudzbine preko telefona\" + listaFajlova[izabranaPorudzbina]);
                File.Copy(Properties.Resources.LokacijaPomocnihFajlova + @"Trenutni Racuni\racun " + ime + " " + date + ".pf",
                    Properties.Resources.LokacijaPomocnihFajlova + @"Arhiva\Racun " + date + ".pf");
                File.Delete(Properties.Resources.LokacijaPomocnihFajlova + @"Trenutni Racuni\racun " + ime + " " + date + ".pf");
                proFeatures f = new proFeatures();
                f.Init();
                return;
            }

            else if (izabraniIndex == 2)
            {
                proFeatures f = new proFeatures();
                f.Init();
                return;
            }
        }
    }
}
