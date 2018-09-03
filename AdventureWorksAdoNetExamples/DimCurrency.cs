using System;

namespace AdventureWorksAdoNetExamples
{
    public class DimCurrency
    {
        public DimCurrency(int currencyKey, string currencyAlternateKey, string currencyName)
        {
            CurrencyKey = currencyKey;
            CurrencyAlternateKey = currencyAlternateKey;
            CurrencyName = currencyName;
        }

        public int CurrencyKey { get; set; }
        public string CurrencyAlternateKey { get; set; }
        public string CurrencyName { get; set; }

        public override string ToString()
        {
            return $"{CurrencyKey}.\t{CurrencyAlternateKey}, {CurrencyName}\n";
        }
    }
}