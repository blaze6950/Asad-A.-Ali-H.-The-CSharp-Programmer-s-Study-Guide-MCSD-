using System.Collections.Generic;
using System.Text;

namespace Challenge_9_Perform_CRUD_Operation_using_LINQ_to_Object
{
    public class CountryManager
    {
        private List<Country> _countries;

        private void Initial()
        {
            _countries = new List<Country>();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var country in _countries)
            {
                stringBuilder.AppendLine(country.ToString());
            }
            return stringBuilder.ToString();
        }

        public CountryManager()
        {
            Initial();
        }

        public CountryManager(List<Country> countries)
        {
            Countries = countries;
        }

        public List<Country> Countries
        {
            get { return _countries; }
            set { _countries = value; }
        }
    }
}