using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_6_Develop_a_Custom_Generic_Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            MyGenericCollection<int> _myGenericCollection = new MyGenericCollection<int>();
            Console.WriteLine(_myGenericCollection.Count);
            _myGenericCollection.Add(35);
            _myGenericCollection.Add(45);
            _myGenericCollection.Add(55);
            foreach (var node in _myGenericCollection)
            {
                Console.Write(node + "\t");
            }
            Console.WriteLine();
            _myGenericCollection.Insert(2,0);
            foreach (var node in _myGenericCollection)
            {
                Console.Write(node + "\t");
            }
            Console.WriteLine();
            Console.WriteLine(_myGenericCollection.Contains(0));
            _myGenericCollection.Remove(55);
            foreach (var node in _myGenericCollection)
            {
                Console.Write(node + "\t");
            }
        }
    }
}
