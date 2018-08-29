using System;
using Challenge_4_Develop_a_Transformer.Vehicles.Abstract;

namespace Challenge_4_Develop_a_Transformer.Vehicles.Concrete
{
    public class Jet : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Flies through the air!");
        }
    }
}