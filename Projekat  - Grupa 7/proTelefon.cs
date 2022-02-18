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
            proMenu glavniMeni = new proMenu(new string[] { "Napravi novu porudžbinu", "Preuzmi i plati porudžbinu",
                "Povratak na glavni meni" }, @"                           _ _ _              _ _                    _____           _                        
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
            int izabranaOpcija = glavniMeni.PokreniMeni();
            if (izabranaOpcija == 3)
            {
                proFeatures f = new proFeatures();
                f.Init();
                return;
            }
            else if (izabranaOpcija == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(@"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

Unesite ime:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.CursorVisible = true;
                string ime = Console.ReadLine();
                Console.CursorVisible = false;
                while (ime == "")
                {
                    Console.Write("Pogrešno ste uneli. Unesite ponovo: ");
                    ime = Console.ReadLine();
                }
                string date = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                File.Create(Properties.Resources.LokacijaPomocnihFajlova + @"Narudzbine preko telefona\Narudzbina " + ime + " " + date + ".pf").Close();
            Line62:
                string[] kategorije = Directory.GetDirectories(Properties.Resources.LokacijaPomocnihFajlova + "Jelovnik");
                string[] katOpcije = new string[kategorije.Length + 1];
                for (int i = 0; i < kategorije.Length; i++) katOpcije[i] = Path.GetFileName(kategorije[i].Split(new string[] { ". " }, StringSplitOptions.None)[1]);
                katOpcije[kategorije.Length] = "Završi račun";
                proMenu meniKategorije = new proMenu(katOpcije, @"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

Jelovnik:
" + (katOpcije.Length == 1 ? @"
Trenutno nema unetih jela u jelovnik. Kontaktirajte menadžera restorana!
" : ""));
                int izabranaKategorija = meniKategorije.PokreniMeni();
                if (izabranaKategorija == kategorije.Length)
                {
                    if (string.IsNullOrEmpty(File.ReadAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Narudzbine preko telefona\Narudzbina " + ime + " " + date + ".pf")))
                        File.Delete(Properties.Resources.LokacijaPomocnihFajlova + @"Narudzbine preko telefona\Narudzbina " + ime + " " + date + ".pf");
                    proTelefon f = new proTelefon();
                    f.Init();
                    return;
                }
                else
                {
                    string kategorijaPath = kategorije[izabranaKategorija];
                    string[] jelaPath = Directory.GetDirectories(kategorijaPath);
                    string[] jelaOpcije = new string[jelaPath.Length + 1];
                    for (int i = 0; i < jelaPath.Length; i++) jelaOpcije[i] = Path.GetFileName(jelaPath[i]);
                    jelaOpcije[jelaPath.Length] = "Povratak na kategorije";
                    proMenu meniJela = new proMenu(jelaOpcije, @"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

Jelovnik - " + Path.GetFileName(kategorijaPath) + @":
" + (jelaOpcije.Length == 1 ? @"
Trenutno nema unetih jela u jelovnik. Kontaktirajte menadžera restorana!
" : ""));
                    int izabranoJelo = meniJela.PokreniMeni();
                    if (izabranoJelo == jelaPath.Length) goto Line62;
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(@"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

Koliko {0} želite da naručite: ", jelaOpcije[izabranoJelo]);
                        int broj = -1;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.CursorVisible = true;
                        while (!int.TryParse(Console.ReadLine(), out broj) || broj < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Nije dobar unos. Pokušajte ponovo: ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        Console.CursorVisible = false;
                        if (broj != 0)
                        {
                            if (File.ReadAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Narudzbine preko telefona\Narudzbina " + ime + " " + date + ".pf") == "")
                            {
                                File.WriteAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Narudzbine preko telefona\Narudzbina " + ime + " " + date + ".pf",
                                    jelaPath[izabranoJelo] + "=" + broj + "\n");
                                File.WriteAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Trenutni Racuni\racun " + ime + " " + date + ".pf",
                                    jelaOpcije[izabranoJelo] + ", " + broj + ", " + (broj * double.Parse(File.ReadAllLines(jelaPath[izabranoJelo] + @"\o_jelu.pf")[1])).ToString("0.00") + " RSD\n");
                            }
                            else
                            {
                                File.AppendAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Narudzbine preko telefona\Narudzbina " + ime + " " + date + ".pf",
                                    jelaPath[izabranoJelo] + "=" + broj + "\n");
                                File.AppendAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Trenutni Racuni\racun " + ime + " " + date + ".pf",
                                    jelaOpcije[izabranoJelo] + ", " + broj + ", " + (broj * double.Parse(File.ReadAllLines(jelaPath[izabranoJelo] + @"\o_jelu.pf")[1])).ToString("0.00") + " RSD\n");
                            }
                            Console.WriteLine("Uspešno dodato na račun.");
                            System.Threading.Thread.Sleep(2500);
                        }
                        goto Line62;
                    }
                }
            }
            else if (izabranaOpcija == 1)
            {
                string[] narudzbinePath = Directory.GetFiles(Properties.Resources.LokacijaPomocnihFajlova + "Narudzbine preko telefona");
                string[] narudzbineOpcije = new string[narudzbinePath.Length + 1];
                for (int i = 0; i < narudzbinePath.Length; i++) narudzbineOpcije[i] = Path.GetFileName(narudzbinePath[i]);
                narudzbineOpcije[narudzbinePath.Length] = "Povratak na odabir opcija";
                proMenu meniPorudzbine = new proMenu(narudzbineOpcije, @"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             

_______________________________________________________________________________________________________________

Izaberite porudžbinu za preuzimanje: 
");
                int izabranaPorudzbina = meniPorudzbine.PokreniMeni();
                if (izabranaPorudzbina == narudzbinePath.Length)
                {
                    proTelefon f = new proTelefon();
                    f.Init();
                    return;
                }
                string imeNarudzbine = narudzbineOpcije[izabranaPorudzbina].Split(' ')[1];
                string datumNarudzbine = Path.GetFileNameWithoutExtension(narudzbineOpcije[izabranaPorudzbina]).Split(' ')[2];

                double cenaBezPDVa = 0;
                string[] stavkeSaRacuna = File.ReadAllLines(narudzbinePath[izabranaPorudzbina]);
                foreach (var stavka in stavkeSaRacuna)
                    cenaBezPDVa += double.Parse(File.ReadAllLines(stavka.Split('=')[0] + @"\o_jelu.pf")[1]) * int.Parse(stavka.Split('=')[1]);

                string cenaSaPDVomIUslugom = (cenaBezPDVa * 1.11 * 1.2).ToString("0.00");
                string uslugaUCeni = (cenaBezPDVa * 0.11).ToString("0.00");
                string PDVUCeni = (cenaBezPDVa * 1.11 * 0.2).ToString("0.00");

                File.AppendAllText(Properties.Resources.LokacijaPomocnihFajlova + @"Trenutni Racuni\racun " + imeNarudzbine + " " + datumNarudzbine + ".pf",
                    @"----------------------------
Cena bez PDV-a: " + cenaBezPDVa.ToString("0.00") + @" RSD
PDV: " + PDVUCeni + @" RSD
Usluga: " + uslugaUCeni + @" RSD
Popust: 0.00 RSD
----------------------------
Ukupna cena: " + cenaSaPDVomIUslugom + @" RSD
");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Uspešno plaćanje. Dođite nam ponovo!");
                System.Threading.Thread.Sleep(2500);
                File.Delete(narudzbinePath[izabranaPorudzbina]);
                File.Copy(Properties.Resources.LokacijaPomocnihFajlova + @"Trenutni Racuni\racun " + imeNarudzbine + " " + datumNarudzbine + ".pf",
                    Properties.Resources.LokacijaPomocnihFajlova + @"Arhiva\Racun " + datumNarudzbine + ".pf");
                File.Delete(Properties.Resources.LokacijaPomocnihFajlova + @"Trenutni Racuni\racun " + imeNarudzbine + " " + datumNarudzbine + ".pf");
                proFeatures mainMenu = new proFeatures();
                mainMenu.Init();
                return;
            }
        }
    }
}
