using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge_9_Perform_CRUD_Operation_using_LINQ_to_Object
{
    enum MenuItem
    {
        Create = 1,
        Update,
        Delete,
        Print,
        Search,
        Exit
    };

    public class MainMenu
    {
        private CountryManager _countryManager;

        public MainMenu(CountryManager countryManager)
        {
            _countryManager = countryManager;
        }

        public void MainMenuProcessor()
        {
            int choosedItem;
            do
            {
                Console.Clear();
                PrintMainMenu();
                Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out choosedItem);
            } while (choosedItem < 1 || choosedItem > 7);
            DoAction((MenuItem) choosedItem);
        }

        private void PrintMainMenu()
        {
            Console.WriteLine("Please choose action:");
            Console.WriteLine("1. Create\n2. Update\n3. Delete\n4. Print\n5. Search\n6. Exit");
        }

        private void DoAction(MenuItem choosedItem)
        {
            switch (choosedItem)
            {
                case MenuItem.Create:
                    CreateAction();
                    break;
                case MenuItem.Update:
                    UpdateAction();
                    break;
                case MenuItem.Delete:
                    DeleteAction();
                    break;
                case MenuItem.Print:
                    PrintAction();
                    break;
                case MenuItem.Search:
                    SearchAction();
                    break;
                case MenuItem.Exit:
                    ExitAction();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(choosedItem), choosedItem, null);
            }
        }

        #region Actions
        private void ExitAction()
        {
            string input;
            Console.Clear();
            do
            {
                Console.WriteLine("Are you sure? (y/n)");
                input = Console.ReadKey().KeyChar.ToString();
            } while (!(input.Equals("y")) && !(input.Equals("n")));
            if (input.Equals("y"))
            {
                throw new Exception("exit with code 0");
            }
            MainMenuProcessor();
        }

        private void SearchAction()
        {
            int input;
            Console.Clear();
            do
            {
                Console.WriteLine("Select search criteria: ");
                Console.WriteLine("1. Name\n2. Capital city\n3. Population");
                Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out input);
            } while (input < 1 || input > 3);
            Console.Clear();

            string key;
            switch (input)
            {
                case 1:
                    Console.Write("Enter the name of the country you are searching for: ");
                    key = Console.ReadLine();
                    PrintFindResult(GetFindResult(key, 1));
                    break;
                case 2:
                    Console.Write("Enter the name of the capital of the country you are looking for: ");
                    key = Console.ReadLine();
                    PrintFindResult(GetFindResult(key, 2));
                    break;
                case 3:
                    Console.Write("Enter the number of people to search for a country: ");
                    key = Console.ReadLine();
                    PrintFindResult(GetFindResult(key, 3));
                    break;
            }
        }

        private IEnumerable<Country> GetFindResult(string key, int criterion)
        {
            IEnumerable<Country> res = null;
            switch (criterion)
            {
                case 1:
                    res = _countryManager.Countries.Where(c => c.Name.Contains(key)).Select(c => c);
                    break;
                case 2:
                    res = _countryManager.Countries.Where(c => c.CapitalCity.Contains(key)).Select(c => c);
                    break;
                case 3:
                    Int32.TryParse(key, out int num);
                    res = _countryManager.Countries.Where(c =>
                            c.Population - (c.Population * 0.5) < num && c.Population + (c.Population * 0.5) > num)
                        .Select(c => c);
                    break;
            }
            return res;
        }

        private void PrintFindResult(IEnumerable<Country> res)
        {
            if (res != null)
            {
                foreach (var country in res)
                {
                    Console.WriteLine(country.ToString());
                }
            }
            else
            {
                Console.WriteLine("--no results found--");
            }

            Console.WriteLine("For continue press any key...");
            Console.ReadKey();
            MainMenuProcessor();
        }

        private void PrintAction()
        {
            Console.Clear();
            Console.WriteLine("List of countries:");
            Console.WriteLine(_countryManager.ToString());
            Console.WriteLine();

            Console.WriteLine("Press any key for return to main menu...");
            Console.ReadKey();
            MainMenuProcessor();
        }

        private void DeleteAction()
        {
            Console.Clear();
            Console.WriteLine("Select the country to be removed from the list: ");
            int i = 1;
            foreach (var country in _countryManager.Countries)
            {
                Console.WriteLine($"{i}. {country}");
                i++;
            }
            Int32.TryParse(Console.ReadLine(), out int deleteResult);
            _countryManager.Countries.RemoveAt(deleteResult - 1);
            Console.WriteLine("Remove completed successfully! Please press any key for continue...");
            Console.ReadKey();
            MainMenuProcessor();
        }

        private void UpdateAction()
        {
            Console.Clear();
            Console.WriteLine("Select the country to be updated from the list: ");
            int i = 1;
            foreach (var country in _countryManager.Countries)
            {
                Console.WriteLine($"{i}. {country}");
                i++;
            }
            Int32.TryParse(Console.ReadLine(), out int updateResult);
            UpdateCountry(updateResult - 1);

            Console.WriteLine("For continue press any key...");
            Console.ReadKey();
            MainMenuProcessor();
        }

        private void UpdateCountry(int index)
        {
            int res;
            Console.Clear();
            do
            {
                Console.WriteLine("Please choose attributes for updating: ");
                Console.WriteLine("1. Name\n2. Capital city\n3. Population");
                Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out res);
            } while (res < 1 || res > 3);

            Console.WriteLine();
            switch (res)
            {
                case 1:
                    Console.Write($"Enter new name (old: \"{_countryManager.Countries[index].Name}\"): ");
                    _countryManager.Countries[index].Name = Console.ReadLine();
                    break;
                case 2:
                    Console.Write($"Enter new name of capital city (old: \"{_countryManager.Countries[index].CapitalCity}\"): ");
                    _countryManager.Countries[index].CapitalCity = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine($"Enter new population (old: \"{_countryManager.Countries[index].Population}\"): ");
                    Int32.TryParse(Console.ReadLine(), out int newPop);
                    _countryManager.Countries[index].Population = newPop;
                    break;
            }

            Console.WriteLine("The country Updated successfully!");
            Console.WriteLine(_countryManager.Countries[index].ToString());
        }

        private void CreateAction()
        {
            Country newCountry = new Country();

            Console.Clear();
            Console.WriteLine("Creating new country:");

            do
            {
                Console.Write("Name: ");
                newCountry.Name = Console.ReadLine();
            } while (newCountry.Name != null && newCountry.Name.Length < 3);
            Console.WriteLine();

            do
            {
                Console.Write("Capital city: ");
                newCountry.CapitalCity = Console.ReadLine();
            } while (newCountry.CapitalCity != null && newCountry.CapitalCity.Length < 3);
            Console.WriteLine();

            int pop;
            do
            {
                Console.Write("Population: ");
            } while (!Int32.TryParse(Console.ReadLine(), out pop));
            newCountry.Population = pop;
            Console.WriteLine();

            _countryManager.Countries.Add(newCountry);

            Console.WriteLine("The new record was successfully created and added to the list! Press any key for continue...");
            Console.ReadKey();

            MainMenuProcessor();
        }
        #endregion
    }
}