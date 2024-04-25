using SWAPI_Scrapper.Models.SWApi;
using SWAPI_Scrapper.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SWAPI_Scrapper.Menu.Veiculos
{
    internal class MainMenuVeiculos
    {
        public static async Task Load()
        {
            Console.Clear();
            Console.WriteLine("Desafio May the fourth - Balta.io");
            Console.WriteLine("----");
            Console.WriteLine("Star Wars API Scrapper");
            Console.WriteLine("-----");
            Console.WriteLine("1 - Listar veículos");
            Repository<VehicleModelDAO> vehicleRepository = new Repository<VehicleModelDAO>(Database.Connection);
            var vehicleList = await vehicleRepository.Get();
            // Verificar se já existe veículos no banco
            if (vehicleList.Count() == 0)
            {
                Console.WriteLine("2 - Popular veículos");
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
                    Console.WriteLine("Listagem de veículos");
                    Console.WriteLine("-----");
                    var vehiclesDAO = await vehicleRepository.Get();

                    foreach (var v in vehiclesDAO)
                    {
                        Console.WriteLine($"{v.Name}");
                        Console.WriteLine($"Modelo: {v.Model}");
                        Console.WriteLine("-----");
                    }
                    Console.ReadKey();
                    Veiculos.MainMenuVeiculos.Load();
                    break;
                case "2":
                    Root root = await ApiVehicles("https://swapi.py4e.com/api/vehicles/?format=json");
                    var vehicles = root.results;

                    while (root.next != null)
                    {
                        root = await ApiVehicles(root.next.ToString());
                        vehicles.AddRange(root.results);
                    }

                    foreach (var v in vehicles)
                    {
                        // 1. Get the vehicle ID (assuming you have a method for this)
                        int vehicleId = GetIdForUrl(v.url);

                        // 2. Create VehicleMovies for each film
                        List<VehicleMoviesModelDAO> vehicleMovies = new List<VehicleMoviesModelDAO>();
                        foreach (var filmUrl in v.films)
                        {
                            int movieId = GetIdForUrl(filmUrl);
                            vehicleMovies.Add(new VehicleMoviesModelDAO(vehicleId, movieId));
                        }

                        // 3. Insert VehicleMovies into the database
                        Repositories.Repository<VehicleMoviesModelDAO> vehicleMovieRepository = new Repositories.Repository<VehicleMoviesModelDAO>(Database.Connection);
                        foreach (var item in vehicleMovies)
                        {
                            await vehicleMovieRepository.Insert(item);
                        }

                        await vehicleRepository.Insert(new VehicleModelDAO
                        {
                            Id = vehicleId,
                            Name = v.name,
                            Model = v.model,
                            Manufacturer = v.manufacturer,
                            CostInCredits = v.cost_in_credits,
                            Length = v.length,
                            MaxAtmospheringSpeed = v.max_atmosphering_speed,
                            Crew = v.crew,
                            Passengers = v.passengers,
                            CargoCapacity = v.cargo_capacity,
                            Consumables = v.consumables,
                            VehicleClass = v.vehicle_class,
                            Created = v.created,
                            Edited = v.edited,
                            Url = v.url
                        });
                    }
                    Console.ReadKey();
                    Veiculos.MainMenuVeiculos.Load();
                    break;
                case "0":
                    Menu.MainMenu.Load();
                    break;
                default:
                    break;
            }
            Veiculos.MainMenuVeiculos.Load();
        }

        static int GetIdForUrl(string url)
        {
            int id = Int32.Parse(url.TrimEnd('/').Split('/').Last());
            return id;
        }

        static async Task<Root> ApiVehicles(string url)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Root>(jsonString);
        }
    }

    // Classes para desserializar o JSON (ajustar de acordo com a estrutura do JSON)
    public class Vehicle
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
        public string vehicle_class { get; set; }
        public List<string> pilots { get; set; }
        public List<string> films { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }
    }

    public class Root
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<Vehicle> results { get; set; }
    }
}

