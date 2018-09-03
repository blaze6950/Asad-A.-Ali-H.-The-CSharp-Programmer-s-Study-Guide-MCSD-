using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksAdoNetExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var newDb = new AdventureWorksContext())
            {
                //newDb.GetDataFromDimAccountTable();
                //newDb.GetDataFromDimCurrencyTable();
                //Console.WriteLine("========================================");
                //newDb.InsertIntoDimCurrencyTable(new DimCurrency(0, "ZZZ", "All Cops Are Bastards"));
                //Console.WriteLine("========================================");
                //newDb.GetDataFromDimCurrencyTable();
                //newDb.InsertIntoDimCurrencyTable(new DimCurrency(0, "UAH", "Ukrainian hryvna"));
                //newDb.GetSearchDataFromDimCurrencyTable("z");
                //newDb.RemoveSearchDataFromDimCurrencyTable("zzz");
                newDb.GetSearchDataFromDimCurrencyTable("z");
                newDb.GetCountOfRowsFromDimCurrency();
            }
        }
    }
}
