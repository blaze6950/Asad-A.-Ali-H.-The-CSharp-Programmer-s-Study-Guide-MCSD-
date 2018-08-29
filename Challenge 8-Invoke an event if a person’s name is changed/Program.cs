using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_8_Invoke_an_event_if_a_person_s_name_is_changed
{
    class Program
    {
        static void Main(string[] args)
        {
            Person newPerson = new Person();
            newPerson.Name = "Nikita";
            newPerson.Name = "Nikita";
            newPerson.Name = "Alesha";
        }
    }
}
