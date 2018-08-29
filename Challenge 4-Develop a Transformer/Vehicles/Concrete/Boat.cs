using System;
using Challenge_4_Develop_a_Transformer.Vehicles.Abstract;

namespace Challenge_4_Develop_a_Transformer.Vehicles.Concrete
{
    public class Boat : Vehicle
    {
        public Boat()
        {
            Wheels = 0;
            MaxSpeed = 200;
        }

        public override void Run()
        {
            Console.WriteLine("Floats on water!");
        }
    }
}