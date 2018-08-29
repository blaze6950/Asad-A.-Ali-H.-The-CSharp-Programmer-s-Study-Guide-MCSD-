namespace Challenge_3_Develop_Temperature_Converter_Application
{
    public class CelsiusTemperature
    {
        private double _temp;

        public CelsiusTemperature(double temp)
        {
            _temp = temp;
        }

        public double Temp
        {
            get { return _temp; }
            set { _temp = value; }
        }

        public static implicit operator FahrenheitTemperature(CelsiusTemperature temp)
        {
            return new FahrenheitTemperature(temp.Temp * 9 / 5 + 32);
        }
    }
}