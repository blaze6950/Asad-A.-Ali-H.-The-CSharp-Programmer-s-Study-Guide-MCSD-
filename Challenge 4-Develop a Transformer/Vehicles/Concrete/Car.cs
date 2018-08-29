using System;
using Challenge_4_Develop_a_Transformer.Vehicles.Abstract;

namespace Challenge_4_Develop_a_Transformer.Vehicles.Concrete
{
    public class Car : Vehicle
    {
        public Car()
        {
            Wheels = 4;
            MaxSpeed = 350;
        }

        public override void Run()
        {
            Console.WriteLine("Moving on the road!");
        }
    }
}