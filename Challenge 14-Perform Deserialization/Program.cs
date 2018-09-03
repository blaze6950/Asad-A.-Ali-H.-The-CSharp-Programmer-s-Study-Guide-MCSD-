using System;
using System.Collections.Generic;
using System.Threading;
using Challenge_9_Perform_CRUD_Operation_using_LINQ_to_Object;

namespace Challenge_14_Perform_Deserialization
{
    class Program
    {
        static void Main()
        {
            CountryManager newCountryManager = new CountryManager()
            {
                Countries = new List<Country>()
                {
                    new Country(name: "Ukraine", capitalCity: "Kyiv", population: 22000000),
                    new Country(name: "Russia", capitalCity: "Moscow", population: 147000000),
                    new Country(name: "Poland", capitalCity: "Warsaw", population: 50000000),
                    new Country(name: "USA", capitalCity: "Washington", population: 300000000),
                    new Country(name: "Brazil", capitalCity: "Brasilia", population: 230000000),
                    new Country(name: "Turkey", capitalCity: "Istanbul", population: 37000000),
                    new Country(name: "Spain", capitalCity: "Barcelone", population: 67000000)
                }
            };
            Console.WriteLine("Creating the list of countries. Current count: " + newCountryManager.Countries.Count);
            DataManager<Country> dataManager = new DataManager<Country>();
            dataManager.SerializeCollection(newCountryManager.Countries);
            Console.WriteLine("Serializing collection...");
            newCountryManager.Countries.Clear();
            Console.WriteLine("Clearing collection...");
            Thread.Sleep(2000);
            Console.WriteLine("Count of countries: " + newCountryManager.Countries.Count);
            newCountryManager.Countries = dataManager.DeserializeCollection();
            Console.WriteLine("Deserializing collection... Current count: " + newCountryManager.Countries.Count);
            Console.ReadKey();
        }
    }
}
