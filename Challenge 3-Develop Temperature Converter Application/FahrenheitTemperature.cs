namespace Challenge_3_Develop_Temperature_Converter_Application
{
    public class FahrenheitTemperature
    {
        private double _temp;

        public FahrenheitTemperature(double temp)
        {
            _temp = temp;
        }

        public double Temp
        {
            get { return _temp; }
            set { _temp = value; }
        }

        public static implicit operator CelsiusTemperature(FahrenheitTemperature temp)
        {
            return new CelsiusTemperature(temp.Temp * 5 / 9 - 32);
        }
    }
}