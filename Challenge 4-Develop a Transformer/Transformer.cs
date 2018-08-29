using System;
using Challenge_4_Develop_a_Transformer.Vehicles.Abstract;
using Challenge_4_Develop_a_Transformer.Vehicles.Concrete;

namespace Challenge_4_Develop_a_Transformer
{
    public class Transformer
    {
        private Vehicle _vehicle;
        private Landscape _landscape;

        public Transformer(Landscape landscape)
        {
            LandscapeAround = landscape;
        }

        public Landscape LandscapeAround
        {
            get { return _landscape; }
            set
            {
                _landscape = value;
                ConfigTransformation();
            }
        }

        private void ConfigTransformation()
        {
            switch (LandscapeAround)
            {
                case Landscape.Air:
                    _vehicle = new Jet();
                    break;
                case Landscape.Road:
                    _vehicle = new Car();
                    break;
                case Landscape.Water:
                    _vehicle = new Boat();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void TransformationAndGo()
        {
            _vehicle?.Run();
        }
    }
}