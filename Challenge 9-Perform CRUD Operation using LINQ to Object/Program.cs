using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_9_Perform_CRUD_Operation_using_LINQ_to_Object
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu(new CountryManager());
            mainMenu.MainMenuProcessor();
        }
    }
}
