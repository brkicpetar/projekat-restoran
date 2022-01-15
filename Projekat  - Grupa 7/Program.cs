using System;
using System.Text;

namespace Projekat____Grupa_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Projekat \"Aplikacija za Restoran\" - Grupa 7";
            Console.WriteLine(@"                           _ _ _              _ _                    _____           _                        
──────▄▀─      /\         | (_) |            (_|_)                  |  __ \         | |                       
─█▀▀▀█▀█─     /  \   _ __ | |_| | ____ _  ___ _ _  __ _   ______ _  | |__) |___  ___| |_ ___  _ __ __ _ _ __  
──▀▄░▄▀──    / /\ \ | '_ \| | | |/ / _` |/ __| | |/ _` | |_  / _` | |  _  // _ \/ __| __/ _ \| '__/ _` | '_ \ 
────█────   / ____ \| |_) | | |   < (_| | (__| | | (_| |  / / (_| | | | \ \  __/\__ \ || (_) | | | (_| | | | |
──▄▄█▄▄──  /_/    \_\ .__/|_|_|_|\_\__,_|\___|_| |\__,_| /___\__,_| |_|  \_\___||___/\__\___/|_|  \__,_|_| |_|
                    | |                       _/ |                                                            
                    |_|                      |__/                                                             
");
            Console.WriteLine();
            Console.WriteLine("                                            Aplikacija se učitava...\n");
            Console.Write("      ");
            for (int i = 0; i < 100; i++)
            {
                Console.Write("║");
                System.Threading.Thread.Sleep(50);
            }
            System.Threading.Thread.Sleep(1500);

            Console.Clear();
            Console.ResetColor();
            proFeatures p = new proFeatures();
            p.Init();
        }
    }
}
