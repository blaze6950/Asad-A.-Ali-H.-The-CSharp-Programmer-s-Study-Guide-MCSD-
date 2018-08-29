using System;

namespace Challenge_3_Develop_Temperature_Converter_Application
{
    class Program
    {
        static void Main()
        {
            CelsiusTemperature celsiusTemperature = new CelsiusTemperature(36);
            FahrenheitTemperature fahrenheitTemperature;
            fahrenheitTemperature = celsiusTemperature;
            Console.WriteLine(fahrenheitTemperature.Temp);
        }
    }
}
