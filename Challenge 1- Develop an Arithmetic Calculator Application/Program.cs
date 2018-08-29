using System;

namespace Challenge_1__Develop_an_Arithmetic_Calculator_Application
{
    enum CalcActions
    {
        Addition = 1,
        Subtraction,
        Multipliation,
        Division
    };

    class Program
    {
        static void Main()
        {
            StartCalc();
        }

        private static void StartCalc()
        {
            while (true)
            {
                do
                {
                    string input;
                    int num1, num2;
                    Int32? res;
                    CalcActions action;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Press any following key to perform an arithmetic operation:");
                        Console.WriteLine("1 - Addition\n2 - Subtraction\n3 - Multipliation\n4 - Division");
                        input = Console.ReadKey().KeyChar.ToString();
                    } while (!Enum.TryParse(input, out action));

                    GetNumbers(out num1, out num2);

                    switch (action)
                    {
                        case CalcActions.Addition:
                            res = Addition(num1, num2);
                            break;
                        case CalcActions.Subtraction:
                            res = Subtraction(num1, num2);
                            break;
                        case CalcActions.Multipliation:
                            res = Multipliation(num1, num2);
                            break;
                        case CalcActions.Division:
                            res = Division(num1, num2);
                            break;
                        default:
                            res = null;
                            break;
                    }

                    PrintResult(num1, num2, res, action);
                } while (IsAgain());
            }
            // ReSharper disable once FunctionNeverReturns
        }

        private static bool IsAgain()
        {
            while (true)
            {
                Console.Write("Do you want to continue again (Y/N)?");
                char res = Console.ReadKey().KeyChar;
                if (res.Equals('Y'))
                {
                    return true;
                }
                else if (res.Equals('N'))
                {
                    return false;
                }
            }
        }

        private static void PrintResult(int num1, int num2, int? res, CalcActions action)
        {
            char actionChar = '#';
            switch (action)
            {
                case CalcActions.Addition:
                    actionChar = '+';
                    break;
                case CalcActions.Subtraction:
                    actionChar = '-';
                    break;
                case CalcActions.Multipliation:
                    actionChar = '*';
                    break;
                case CalcActions.Division:
                    actionChar = '/';
                    break;
            }

            Console.WriteLine($"{num1} {actionChar} {num2} = {res}");
        }

        private static int Division(int num1, int num2)
        {
            return num1 / num2;
        }

        private static int Multipliation(int num1, int num2)
        {
            return num1 * num2;
        }

        private static int Subtraction(int num1, int num2)
        {
            return num1 - num2;
        }

        private static int Addition(int num1, int num2)
        {
            return num1 + num2;
        }

        private static void GetNumbers(out int num1, out int num2)
        {
            string input;
            do
            {
                Console.Write("\nEnter Value 1: ");
                input = Console.ReadLine();
            } while (!Int32.TryParse(input, out num1));

            do
            {
                Console.Write("\nEnter Value 2: ");
                input = Console.ReadLine();
            } while (!Int32.TryParse(input, out num2));
        }
    }
}
