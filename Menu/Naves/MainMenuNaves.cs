using SWAPI_Scrapper.Menu.Veiculos;
using SWAPI_Scrapper.Models.SWApi;
using SWAPI_Scrapper.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SWAPI_Scrapper.Menu.Naves
{
    internal class MainMenuNaves
    {
        public static async Task Load()
        {
            Console.Clear();
            Console.WriteLine("Desafio May the fourth - Balta.io");
            Console.WriteLine("----");
            Console.WriteLine("Star Wars API Scrapper");
            Console.WriteLine("-----");
            Console.WriteLine("1 - Listar naves");
            Repository<SpaceshipModelDAO> spaceshipRepository = new Repository<SpaceshipModelDAO>(Database.Connection);
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
                    Console.WriteLine("Não implementado ainda");
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
                    Root root = await ApiSpaceships("https://swapi.py4e.com/api/starships/?format=json");
                    var spaceships = root.results;
                    while (root.next != null)
                    {
                        root = await ApiSpaceships(root.next.ToString());
                        spaceships.AddRange(root.results);
                    }
                    foreach (var s in spaceships)
                    {
                        int id = GetIdForUrl(s.url);
                        List<SpaceshipMoviesModelDAO> spaceshipMovies = new List<SpaceshipMoviesModelDAO>();
                        foreach (var film in s.films)
                        {
                            int filmId = GetIdForUrl(film);
                            spaceshipMovies.Add(new SpaceshipMoviesModelDAO(id, filmId));
                        }
                        Repository<SpaceshipMoviesModelDAO> spaceshipMoviesRepository = new Repository<SpaceshipMoviesModelDAO>(Database.Connection);
                        foreach (var item in spaceshipMovies)
                        {
                            await spaceshipMoviesRepository.Insert(item);
                        }

                        SpaceshipModelDAO spaceship = new SpaceshipModelDAO
                        {
                            Id = id,
                            Name = s.name,
                            Model = s.model,
                            Manufacturer = s.manufacturer,
                            CostInCredits = s.cost_in_credits,
                            Length = s.length,
                            MaxSpeed = s.max_atmosphering_speed,
                            Crew = s.crew,
                            Passengers = s.passengers,
                            CargoCapacity = s.cargo_capacity,
                            Consumables = s.consumables,
                            Class = s.starship_class,
                            HyperdriveRating = s.hyperdrive_rating,
                            MGLT = s.MGLT
                        };
                        await spaceshipRepository.Insert(spaceship);
                    }
                    Console.WriteLine("Naves populadas com sucesso!");
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
            MainMenuNaves.Load();
        }
        static int GetIdForUrl(string url)
        {
            int id = Int32.Parse(url.TrimEnd('/').Split('/').Last());
            return id;
        }

        static async Task<Root> ApiSpaceships(string url)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Root>(jsonString);
        }
    }
    public class Root
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<Spaceship> results { get; set; }
    }

    public class Spaceship
    {
        public string name { get; set; }
        public string model { get; set; }
        public string manufacturer { get; set; }
        public string cost_in_credits { get; set; }
        public string length { get; set; }
        public string max_atmosphering_speed { get; set; }
        public string crew { get; set; }
        public string passengers { get; set; }
        public string cargo_capacity { get; set; }
        public string consumables { get; set; }
        public string hyperdrive_rating { get; set; }
        public string MGLT { get; set; }
        public string starship_class { get; set; }
        public List<string> pilots { get; set; }
        public List<string> films { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }
    }
}
