using System;

namespace Challenge_5_Develop_Steve_Jobs_Laundry_System
{
    public class Clothes
    {
        private string _name;
        private DateTime _lastWash;

        public Clothes(string name, DateTime lastWash)
        {
            _name = name;
            _lastWash = lastWash;
        }

        public bool IsDirty {
            get
            {
                if (_lastWash - DateTime.Now > TimeSpan.FromDays(3))
                {
                    return true;
                }
                return false;
            }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public DateTime LastWash
        {
            get { return _lastWash; }
            set { _lastWash = value; }
        }
    }
}