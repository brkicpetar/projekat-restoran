using System;
using System.IO;

namespace Projekat____Grupa_7
{
    class proKartaPica
    {
        public void Init(string kat)
        {
        Line10:
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
            string[] picaFolderi = Directory.GetDirectories(kategorija);
            string[] opcije2 = new string[picaFolderi.Length + 2];
            for (int i = 0; i < picaFolderi.Length; i++)
            {
                opcije2[i] = Path.GetFileName(picaFolderi[i]);
            }
            opcije2[picaFolderi.Length] = "Povratak na kategorije";
            opcije2[picaFolderi.Length + 1] = "Povratak na glavni meni";
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
" + (opcije2.Length == 2 ? @"
Trenutno nema unetih pića u kartu pića. Kontaktirajte menadžera restorana!
" : ""));
            int izabranoPice = meniPica.PokreniMeni();
            if (izabranoPice == opcije2.Length - 2)
            {
                kat = "";
                goto Line10;
            }
            else if(izabranoPice == opcije2.Length - 1)
            {
                proFeatures f = new proFeatures();
                f.Init();
                return;
            }
            proDetaljiOArtiklu p = new proDetaljiOArtiklu(1);
            p.PrikaziDetalje(Path.GetFileName(kategorija), opcije2[izabranoPice]);
        }
    }
}