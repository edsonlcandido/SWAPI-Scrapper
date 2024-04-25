using SWAPI_Scrapper.Menu.Filmes;
using SWAPI_Scrapper.Models.SWApi;
using SWAPI_Scrapper.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SWAPI_Scrapper.Menu.Planetas
{
    internal class MainMenu
    {
        public static async Task Load()
        {
            Console.Clear();
            Console.WriteLine("Desafio May the fourth - Balta.io");
            Console.WriteLine("----");
            Console.WriteLine("Star Wars API Scrapper");
            Console.WriteLine("-----");
            Console.WriteLine("1 - Listar planetas");
            Repository<PlanetModelDAO> planetsRepository = new Repository<PlanetModelDAO>(Database.Connection);
            var planetList = await planetsRepository.Get();
            //verificar se já existe planetas no banco
            if (planetList.Count() == 0)
            {
                Console.WriteLine("2 - Popular planetas");
            }
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
                    Console.WriteLine("Listagem de planetas");
                    Console.WriteLine("-----");
                    var planetsDAO = await planetsRepository.Get();

                    foreach (var p in planetsDAO)
                    {
                        Console.WriteLine($"{p.Name}");
                        Console.WriteLine($"Rotation Period: {p.RotationPeriod}");
                        Console.WriteLine("-----");
                    }
                    Console.ReadLine();
                    break;
                case "2":
                    Root root = await ApiPlanets("https://swapi.py4e.com/api/planets/?format=json");
                    var planets = root.results;

                    while (root.next != null)
                    {
                        root = await ApiPlanets(root.next.ToString());
                        planets.AddRange(root.results);
                    }

                    foreach (var p in planets)
                    {
                        List<PlanetMoviesModelDAO> planetMovies = new List<PlanetMoviesModelDAO>();
                        foreach (var film in p.films)
                        {
                            var movieId = GetIdForUrl(film);
                            planetMovies.Add(new PlanetMoviesModelDAO(GetIdForUrl(p.url), movieId));
                        }

                        Repositories.Repository<PlanetMoviesModelDAO> planetMovieRepository = new Repositories.Repository<PlanetMoviesModelDAO>(Database.Connection);
                        foreach (var item in planetMovies)
                        {
                            planetMovieRepository.Insert(item);
                        }

                        await planetsRepository.Insert(new PlanetModelDAO
                        {
                            Id = GetIdForUrl(p.url),
                            Name = p.name,
                            RotationPeriod = p.rotation_period,
                            OrbitalPeriod = p.orbital_period,
                            Diameter = p.diameter,
                            Climate = p.climate,
                            Gravity = p.gravity,
                            Terrain = p.terrain,
                            SurfaceWater = p.surface_water,
                            Population = p.population,
                            Created = p.created,
                            Edited = p.edited,
                            Url = p.url
                            // Add other properties as needed
                        });
                    }
                    break;
                case "0":
                    Menu.MainMenu.Load();
                    break;
                default:
                    break;
            }
            Planetas.MainMenu.Load();
        }

        static int GetIdForUrl(string url)
        {
            int id = Int32.Parse(url.TrimEnd('/').Split('/').Last());
            return id;
        }

        static async Task<Root> ApiPlanets(string url)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Root>(jsonString);
        }
    }
    public class Planet
    {
        public string name { get; set; }
        public string rotation_period { get; set; }
        public string orbital_period { get; set; }
        public string diameter { get; set; }
        public string climate { get; set; }
        public string gravity { get; set; }
        public string terrain { get; set; }
        public string surface_water { get; set; }
        public string population { get; set; }
        public string created { get; set; }
        public string edited { get; set; }
        public string url { get; set; }
        public List<string> films { get; set; }
    }

    public class Root
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<Planet> results { get; set; }
    }
}
