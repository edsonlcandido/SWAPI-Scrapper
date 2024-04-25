using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI_Scrapper.Menu.Naves
{
    internal class MainMenuNaves
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Desafio May the fourth - Balta.io");
            Console.WriteLine("----");
            Console.WriteLine("Star Wars API Scrapper");
            Console.WriteLine("-----");
            Console.WriteLine("1 - Listar naves");
            Console.WriteLine("2 - Popular naves");
            Console.WriteLine("0 - Menu inicial");
            Console.WriteLine("Digite o número da opção desejada:");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Desafio May the fourth - Balta.io");
                    Console.WriteLine("----");
                    Console.WriteLine("Star Wars API Scrapper");
                    Console.WriteLine("-----");
                    Console.WriteLine("Listagem de naves");
                    Console.WriteLine("-----");
                    Console.WriteLine("Naves não implementado ainda");
                    Console.ReadKey();
                    MainMenuNaves.Load();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Desafio May the fourth - Balta.io");
                    Console.WriteLine("----");
                    Console.WriteLine("Star Wars API Scrapper");
                    Console.WriteLine("-----");
                    Console.WriteLine("Popular naves");
                    Console.WriteLine("-----");
                    Console.WriteLine("Naves não implementado ainda");
                    Console.ReadKey();
                    MainMenuNaves.Load();
                    break;
                case "0":
                    Menu.MainMenu.Load();
                    break;
                default:
                    MainMenuNaves.Load();
                    break;
            }
        }
    }
}
