﻿// ReSharper disable NonReadonlyMemberInGetHashCode

using System;

namespace Challenge_9_Perform_CRUD_Operation_using_LINQ_to_Object
{
    [Serializable]
    public class Country
    {
        private string _name;
        private string _capitalCity;
        private long _population;

        public Country()
        {
        }

        public Country(string name = "", string capitalCity = "", long population = 0)
        {
            Name = name;
            CapitalCity = capitalCity;
            Population = population;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string CapitalCity
        {
            get { return _capitalCity; }
            set { _capitalCity = value; }
        }

        public long Population
        {
            get { return _population; }
            set { _population = value; }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Country))
            {
                return false;
            }
            Country country = (Country) obj;
            return Name.Equals(country.Name) && CapitalCity.Equals(country.CapitalCity) &&
                   Population == country.Population;
        }

        protected bool Equals(Country other)
        {
            return string.Equals(Name, other.Name) && string.Equals(CapitalCity, other.CapitalCity) && Population == other.Population;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Name != null ? Name.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (CapitalCity != null ? CapitalCity.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Population.GetHashCode();
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"{Name} (Capital: {CapitalCity}, Population: {Population});";
        }
    }
}