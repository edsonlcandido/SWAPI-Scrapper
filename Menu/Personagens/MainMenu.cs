using SWAPI_Scrapper.Menu.Filmes;
using SWAPI_Scrapper.Models.SWApi;
using SWAPI_Scrapper.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SWAPI_Scrapper.Menu.Personagens
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
            Console.WriteLine("1 - Listar personagens");
            Repository<CharacterModelDAO> charactersRepository = new Repository<CharacterModelDAO>(Database.Connection);
            var characterList = await charactersRepository.Get();
            //verificar se já existe personagens no banco
            if (characterList.Count() == 0)
            {
                Console.WriteLine("2 - Popular personagens");
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
                    Console.WriteLine("Listagem de personagens");
                    Console.WriteLine("-----");
                    var charactersDAO = await charactersRepository.Get();

                    foreach (var c in charactersDAO)
                    {
                        Console.WriteLine($"{c.name}");
                        Console.WriteLine($"Ano de nascimento: {c.birth_year}");
                        Console.WriteLine("-----");
                    }
                    Console.ReadLine();
                    break;
                case "2":
                    Root root = await ApiCharacters("https://swapi.py4e.com/api/people/?format=json");
                    var characters = root.results;

                    while (root.next != null)
                    {
                        root = await ApiCharacters(root.next.ToString());
                        characters.AddRange(root.results);
                    }

                    foreach (var c in characters)
                    {
                        List<CharacterMovieModelDAO> characterMovies = new List<CharacterMovieModelDAO>();
                        foreach (var film in c.films)
                        {
                            var movieId = GetIdForUrl(film);
                            characterMovies.Add(new CharacterMovieModelDAO(GetIdForUrl(c.url), movieId));
                        }
                        //List<CharacterVehicleModelDAO> characterVehicles = new List<CharacterVehicleModelDAO>();
                        //foreach (var vehicle in c.vehicles)
                        //{
                        //    var vehicleId = GetIdForUrl(vehicle);
                        //    characterVehicles.Add(new CharacterVehicleModelDAO(GetIdForUrl(c.url), vehicleId));
                        //}
                        //List<CharacterStarshipModelDAO> characterStarships = new List<CharacterStarshipModelDAO>();
                        //foreach (var starship in c.starships)
                        //{
                        //    var starshipId = GetIdForUrl(starship);
                        //    characterStarships.Add(new CharacterStarshipModelDAO(GetIdForUrl(c.url), starshipId));
                        //}

                        Repositories.Repository<CharacterMovieModelDAO> characterMovieRepository = new Repositories.Repository<CharacterMovieModelDAO>(Database.Connection);
                        foreach (var item in characterMovies)
                        {
                            characterMovieRepository.Insert(item);
                        }

                        await charactersRepository.Insert(new CharacterModelDAO
                        {
                            id = GetIdForUrl(c.url),
                            name = c.name,
                            birth_year = c.birth_year,
                            created = c.created,
                            edited = c.edited,
                            eye_color = c.eye_color,
                            gender = c.gender,
                            hair_color = c.hair_color,
                            height = c.height,
                            homeworld_id = GetIdForUrl(c.homeworld),
                            mass = c.mass,
                            url = c.url,
                            skin_color = c.skin_color
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
            Personagens.MainMenu.Load();
        }

        static int GetIdForUrl(string url)
        {
            int id = Int32.Parse(url.TrimEnd('/').Split('/').Last());
            return id;
        }

        static async Task<Root> ApiCharacters(string url)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Root>(jsonString);
        }
    }
    public class Character
    {
        public string name { get; set; }
        public string height { get; set; }
        public string mass { get; set; }
        public string hair_color { get; set; }
        public string skin_color { get; set; }
        public string eye_color { get; set; }
        public string birth_year { get; set; }
        public string gender { get; set; }
        public string homeworld { get; set; }
        public List<string> films { get; set; }
        public List<string> species { get; set; }
        public List<string> vehicles { get; set; }
        public List<string> starships { get; set; }
        public string created { get; set; }
        public string edited { get; set; }
        public string url { get; set; }
    }

    public class Root
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<Character> results { get; set; }
    }


}
