using EvolveDb;
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
            Database.Connection = new SqliteConnection("Data Source=./SWApi.db");
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
            Console.ReadLine();
        }
    }
}