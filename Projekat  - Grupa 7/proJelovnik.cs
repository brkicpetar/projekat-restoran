using System;
using System.IO;

namespace Projekat____Grupa_7
{
    class proJelovnik
    {
        public void Init(string kat)
        {
            Line10:
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
            
            if(izabranaKategorija == opcije1.Length - 1)
            {
                proFeatures f = new proFeatures();
                f.Init();
                return;
            }
            string kategorija = kategorije1[izabranaKategorija];
            string[] jelaFolderi = Directory.GetDirectories(Properties.Resources.LokacijaPomocnihFajlova + @"Jelovnik\" + Path.GetFileName(kategorija));
            string[] opcije2 = new string[jelaFolderi.Length + 2];
            for (int i = 0; i < jelaFolderi.Length; i++)
            {
                opcije2[i] = Path.GetFileName(jelaFolderi[i]);
            }
            opcije2[jelaFolderi.Length] = "Povratak na kategorije";
            opcije2[jelaFolderi.Length + 1] = "Povratak na glavni meni";
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
            if (izabranoJelo == opcije2.Length - 2)
            {
                kat = "";
                goto Line10;
            }
            else if(izabranoJelo == opcije2.Length - 1)
            { 
                proFeatures f = new proFeatures();
                f.Init();
                return;
            }
            proDetaljiOArtiklu p = new proDetaljiOArtiklu(0);
            p.PrikaziDetalje(Path.GetFileName(kategorija), opcije2[izabranoJelo]);
        }
    }
}
