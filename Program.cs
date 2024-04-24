﻿using EvolveDb;
using Microsoft.Data.Sqlite;
using SWAPI_Scrapper.Menu;
using SWAPI_Scrapper.Models.SWApi;
using SWAPI_Scrapper.Repositories;
using System;
using System.Text.Json;

namespace SWAPI_Scrapper
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            Database.Connection = new SqliteConnection("Data Source=SWApi.db");
            try
            {
                var cnx = Database.Connection;
                var evolve = new Evolve(cnx)
                {
                    Locations = new[] { "Migrations" },
                    IsEraseDisabled = true,
                };

                evolve.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database migration failed.", ex);
                throw;
            }

            MainMenu.Load();
            Console.ReadKey();
        }



        static async Task<Character> ApiCharacter(string url)
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Character>(jsonString);
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
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }
    }

    public class FilmTable
    {
        public string title { get; set; }
        public int episode_id { get; set; }
        public string opening_crawl { get; set; }
        public string director { get; set; }
        public string producer { get; set; }
        public string release_date { get; set; }
        public string characters { get; set; }
        public string planets { get; set; }
        public string starships { get; set; }
        public string vehicles { get; set; }
        public string species { get; set; }
        public DateTime created { get; set; }
        public DateTime edited { get; set; }
        public string url { get; set; }
    }

    public static class SqliteHelper
    {
        public static void CreateFilmTable(SqliteConnection connection)
        {
            string createTableQuery = @"CREATE TABLE IF NOT EXISTS Film (
                                        title TEXT,
                                        episode_id INTEGER,
                                        opening_crawl TEXT,
                                        director TEXT,
                                        producer TEXT,
                                        release_date TEXT,
                                        created TEXT,
                                        edited TEXT,
                                        url TEXT
                                    );";

            using (SqliteCommand command = new SqliteCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

}