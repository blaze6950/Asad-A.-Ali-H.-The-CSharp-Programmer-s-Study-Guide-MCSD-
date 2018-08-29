using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_7_Student_Report_Card_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            int input;
            ReportCard report = new ReportCard();
            report.Result += ReportOnResult;
            Console.WriteLine("Enter you marks: ");
            Console.Write("Computer science: ");
            Int32.TryParse(Console.ReadLine(), out input);
            report.ComputerScience = input;
            Console.WriteLine();

            Console.Write("Math: ");
            Int32.TryParse(Console.ReadLine(), out input);
            report.Math = input;
            Console.WriteLine();

            Console.Write("English: ");
            Int32.TryParse(Console.ReadLine(), out input);
            Console.WriteLine();
            report.English = input;
        }

        private static void ReportOnResult(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (((ReportCard) sender).Sum >= 75)
            {
                Console.WriteLine(
                    $"Congratulations!!! You've been passed an exam! Your score: {((ReportCard) sender).Sum}/150");
            }
            else
            {
                Console.WriteLine(
                    $"Don't worry! Try again later! Your score: {((ReportCard)sender).Sum}/150");
            }
            Console.WriteLine();
        }
    }
}
