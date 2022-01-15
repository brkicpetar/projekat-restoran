﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projekat____Grupa_7
{
    class proMeniJelaPredjela
    {
        public void Init()
        {
            string[] menuContent = File.ReadAllLines(Properties.Resources.LokacijaPomocnihFajlova + "meni.pf");
            string[] opcije = new string[menuContent.Length + 1];
            for (int i = 0; i < menuContent.Length; i++)
            {
                opcije[i] = menuContent[i];
            }
            opcije[menuContent.Length] = "Povratak na glavni meni";
            proMenu meni = new proMenu(opcije, @"                 _ _ _              _ _                    _____           _                        
     /\         | (_) |            (_|_)                  |  __ \         | |                       
    /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
   / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
  / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
 /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
          | |                       _/ |                                                            
          |_|                      |__/                                                             

Meni predjela i glavnih jela:
");
            int IzabraniIndex = meni.PokreniMeni();
            if (IzabraniIndex == menuContent.Length)
            {
                proFeatures p = new proFeatures();
                p.Init();
            }
            else
            {
                proDetaljiOArtiklu p = new proDetaljiOArtiklu();
                p.PrikaziDetalje(opcije[IzabraniIndex]);
            }
        }
    }
}
