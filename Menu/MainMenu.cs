using SWAPI_Scrapper.Menu.Filmes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAPI_Scrapper.Menu
{
    internal static class MainMenu
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Desafio May the fourth - Balta.io");
            Console.WriteLine("----");
            Console.WriteLine("Star Wars API Scrapper");
            Console.WriteLine("-----");
            Console.WriteLine("opções com * não implementado ainda");
            Console.WriteLine("1 - Filmes");
            Console.WriteLine("2 - Personagens");
            Console.WriteLine("* - Planetas");
            Console.WriteLine("* - Veiculos");
            Console.WriteLine("* - Naves");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("Digite o número da opção desejada:");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    // Código para a opção Filmes
                    Filmes.MainMenu.Load();
                    break;
                case "2":
                    // Código para a opção Personagens
                    Personagens.MainMenu.Load();
                    break;
                case "3":
                    // Código para a opção Planetas
                    break;
                case "4":
                    // Código para a opção Veiculos
                    break;
                case "5":
                    // Código para a opção Naves
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Menu.MainMenu.Load();
                break; // Sai do programa se qualquer outra tecla for pressionada
            }
            
        }
    }
        
}

