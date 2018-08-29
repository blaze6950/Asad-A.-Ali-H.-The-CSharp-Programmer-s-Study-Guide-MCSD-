using System;
using Challenge_4_Develop_a_Transformer.Vehicles.Abstract;

namespace Challenge_4_Develop_a_Transformer.Vehicles.Concrete
{
    public class Jet : Vehicle
    {
        public Jet()
        {
            Wheels = 8;
            MaxSpeed = 900;
        }

        public override void Run()
        {
            Console.WriteLine("Flies through the air!");
        }
    }
}