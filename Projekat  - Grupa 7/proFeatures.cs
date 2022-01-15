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
            string[] opcije = new string[] { "Meni predjela i glavnih jela", "Karta pića", "Narudžbine", "Rezervacija", "Naručivanje", "Skladište", "Prijava za menadžera restorana", "Napusti program" };
            proMenu meni = new proMenu(opcije, @"                 _ _ _              _ _                    _____           _                        
     /\         | (_) |            (_|_)                  |  __ \         | |                       
    /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
   / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
  / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
 /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
          | |                       _/ |                                                            
          |_|                      |__/                                                             

Glavni meni:
");
            int IzabraniIndex = meni.PokreniMeni();
            
            if(IzabraniIndex == opcije.Length - 1) return;
            else if(IzabraniIndex == 0)
            {
                proMeniJelaPredjela p = new proMeniJelaPredjela();
                p.Init();
            }
            

        }
    }
}
