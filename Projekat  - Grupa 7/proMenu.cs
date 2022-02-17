using System;

namespace Projekat____Grupa_7
{
    class proMenu
    {
        private int IzabraniIndex;
        private string[] Opcije;
        private string Naslov;

        public proMenu(string[] opcije, string naslov)
        {
            Opcije = opcije;
            Naslov = naslov;
            IzabraniIndex = 0;
        }

        private void IspisOpcija()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Naslov);
            Console.ResetColor();
            for (int i = 0; i < Opcije.Length; i++)
            {
                if (i == IzabraniIndex)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write((i + 1).ToString() + ". ");
                Console.ResetColor();
                Console.WriteLine(Opcije[i]);
            }
            Console.ResetColor();
        }

        public int PokreniMeni()
        {
            ConsoleKeyInfo keyInfo;
            do
            {
                Console.Clear();
                IspisOpcija();
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.UpArrow && IzabraniIndex > 0) IzabraniIndex--;
                else if (keyInfo.Key == ConsoleKey.DownArrow && IzabraniIndex < Opcije.Length - 1) IzabraniIndex++;
            } while (keyInfo.Key != ConsoleKey.Enter);
            return IzabraniIndex;
        }

    }
}
