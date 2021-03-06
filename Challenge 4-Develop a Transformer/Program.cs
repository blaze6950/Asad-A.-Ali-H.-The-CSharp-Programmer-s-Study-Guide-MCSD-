﻿namespace Challenge_4_Develop_a_Transformer
{
    class Program
    {
        private static Transformer _optimusPrime;

        static void Main()
        {
            _optimusPrime = new Transformer(Landscape.Air);
            _optimusPrime.TransformationAndGo();
            _optimusPrime.LandscapeAround = Landscape.Road;
            _optimusPrime.TransformationAndGo();
            _optimusPrime.LandscapeAround = Landscape.Water;
            _optimusPrime.TransformationAndGo();
        }
    }
}
