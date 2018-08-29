using System;

namespace Challenge_6_Develop_a_Custom_Generic_Collection
{
    class Program
    {
        static void Main()
        {
            MyGenericCollection<int> myGenericCollection = new MyGenericCollection<int>();
            Console.WriteLine(myGenericCollection.Count);
            myGenericCollection.Add(35);
            myGenericCollection.Add(45);
            myGenericCollection.Add(55);
            foreach (var node in myGenericCollection)
            {
                Console.Write(node + "\t");
            }
            Console.WriteLine();
            myGenericCollection.Insert(2,0);
            foreach (var node in myGenericCollection)
            {
                Console.Write(node + "\t");
            }
            Console.WriteLine();
            Console.WriteLine(myGenericCollection.Contains(0));
            myGenericCollection.Remove(55);
            foreach (var node in myGenericCollection)
            {
                Console.Write(node + "\t");
            }
        }
    }
}
