using System;
using System.ComponentModel;

namespace Challenge_8_Invoke_an_event_if_a_person_s_name_is_changed
{
    public class Person
    {
        private string _name;

        public Person()
        {
            NameChanged += OnNameChanged;
        }

        private void OnNameChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName.Equals(_name))
            {
                Console.WriteLine("The name has not been changed");
            }
            else
            {
                Console.WriteLine("The name has been changed!");
                _name = propertyChangedEventArgs.PropertyName;
            }
        }

        public event PropertyChangedEventHandler NameChanged;
        public string Name
        {
            get => _name;
            set
            {
                NameChanged.Invoke(this, new PropertyChangedEventArgs(value));
            }
        }
    }
}