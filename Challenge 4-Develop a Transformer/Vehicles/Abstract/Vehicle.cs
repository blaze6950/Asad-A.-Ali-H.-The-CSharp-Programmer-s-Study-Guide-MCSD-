namespace Challenge_4_Develop_a_Transformer.Vehicles.Abstract
{
    public abstract class Vehicle
    {
        public int Wheels { get; set; }
        public int MaxSpeed { get; set; }
        public abstract void Run();
    }
}