﻿using SWAPI_Scrapper.Models.SWApi;
using SWAPI_Scrapper.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SWAPI_Scrapper.Menu.Filmes
{
    internal class MainMenuFilmes
    {
        public static async Task Load()
        {
            Console.Clear();
            Console.WriteLine("Desafio May the fourth - Balta.io");
            Console.WriteLine("----");
            Console.WriteLine("Star Wars API Scrapper");
            Console.WriteLine("-----");
            Console.WriteLine("1 - Listar filmes");
            Repository<MovieModelDAO> moviesRepository = new Repository<MovieModelDAO>(Database.Connection);
            var moviesList = await moviesRepository.Get();
            //verificar se já existe filmes no banco
            if (moviesList.Count() == 0)
            {
                Console.WriteLine("2 - Popular filmes");
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
                    Console.WriteLine("Listagem de filmes");
                    Console.WriteLine("-----");
                    var moviesDAO =  await moviesRepository.Get();

                    foreach (var m in moviesDAO)
                    {
                        Console.WriteLine($"{m.Episode} - {m.Title}");
                        Console.WriteLine($"Data de lançamento: {m.ReleaseDate}");
                        Console.WriteLine("-----");
                    }
                    Console.ReadKey();
                    Filmes.MainMenuFilmes.Load();
                    break;
                case "2":
                    Root movies = await ApiMovies();

                    foreach (var m in movies.results)
                    {
                        MovieModelDAO movieModelDAO = new MovieModelDAO
                        {
                            Id = GetIdForUrl(m.url),
                            Title = m.title,
                            Episode = m.episode_id,
                            OpeningCrawl = m.opening_crawl,
                            Director = m.director,
                            Producer = m.producer,
                            ReleaseDate = m.release_date
                        };
                        await moviesRepository.Insert(movieModelDAO);
                    }
                    Console.WriteLine("Filmes adicionados");
                    Console.ReadKey();
                    MainMenuFilmes.Load();
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
                    Menu.MainMenu.Load();
                    break;
                default:
                    MainMenuFilmes.Load();
                    break;
            }
            Filmes.MainMenuFilmes.Load();
        }

        static int GetIdForUrl(string url)
        {
            int id = Int32.Parse(url.TrimEnd('/').Split('/').Last());
            return id;
        }

        static async Task<Root> ApiMovies()
        {
            using var client = new HttpClient();
            var url = "https://swapi.py4e.com/api/films/?format=json";
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Root>(jsonString);
        }
    }
    public class Movie
    {
        public string title { get; set; }
        public int episode_id { get; set; }
        public string opening_crawl { get; set; }
        public string director { get; set; }
        public string producer { get; set; }
        public string release_date { get; set; }
        public List<string> characters { get; set; }
        public List<string> planets { get; set; }
        public List<string> starships { get; set; }
        public List<string> vehicles { get; set; }
        public List<string> species { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }
    }

    public class Root
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<Movie> results { get; set; }
    }
}
