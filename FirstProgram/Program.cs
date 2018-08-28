using System;
using System.CodeDom;
using Microsoft.CSharp.RuntimeBinder;

namespace FirstProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Chapter 1: Fundamentals of C #

            //ProgramStructureNLanguageFundamentals();

            //ImplementProgramFlow();

            //MethodsInCSharp();

            //Summary();
        }

        private static void ProgramStructureNLanguageFundamentals()
        {
            //// First Program in C#


            //// Variables & Data Types
            //int age = 10;


            //// Operator in C#


            //// Expression in C#
            //int i = 4;
            //int j = (i * 4) + 3;
            ////Output j = 19


            //// Type Casting
            //i = 10;
            //double d = i;
            //object o = new Program();
            //double d = 3.1417;
            //i = (int)d;
            // use (type) to convert a type explicitly
            //string s = "22";
            //int age = int.Parse(s);


            //// var keyword
            //var age = 22; //type of age is int32
            //var name = "Ali Asad"; //type of name is string
            //var math = 10 / int.Parse("10"); //type of math is int32


            //// Array in C#
            //string[] friends = new string[4];
            //friends[0] = "Ali";
            //friends[1] = "Mubashar";
            //string[] friends = { "Ali", "Mubashar" };
            //string[] friends = { "Ali", "Mubashar" };
            //int[,] numbers = new int[2, 5];
            //int[,] numbers = new int[2, 5]{
            //    {2,4,6,8,10},
            //    {1,3,5,7,9} };
            //int[,] numbers = new int[2, 5]
            //{
            //    {2,4,6,8,10},
            //    {1,3,5,7,9}
            //};
            //for (int row = 0; row < numbers.GetLength(0); row++){
            //    for (int col = 0; col < numbers.GetLength(1); col++)
            //    {
            //        Console.Write(numbers[row, col]);
            //    }
            //    Console.WriteLine();
            //}
            //Output 246810 13579
            //int[][] jagged = new int[4][];
            //jagged[0] = new int[2];
            //jagged[1] = new int[3];
            //jagged[2] = new int[4];
            //jagged[3] = new int[5];
            //jagged[0][0] = 4;
            //jagged[0][1] = 5;
            //jagged[0] = new int[] { 4, 5 };
            //jagged[1] = new int[] { 6, 7, 8 };
            //int[][] jagged =
            //{
            //    new int[]{4,5},
            //    new int[]{6,7,8},
            //    new int[]{9,10,11},
            //    new int[]{12,13,14,15}
            //};
            //Console.WriteLine(jagged[0][0]);
            //Console.WriteLine(jagged[0][1]);
            //Initialize Jagged Array with Values
            //int[][] jagged =
            //{
            //    new int[]{4,5},
            //    new int[]{6,7,8},
            //    new int[]{9,10,11},
            //    new int[]{12,13,14,15}
            //};
            ////Loop over each index of jagged array
            //for (int i = 0; i < jagged.Length; i++)
            //{
            //    for (int j = 0; j < jagged[i].Length; j++)
            //    {
            //        Console.Write(jagged[i][j]);
            //    }
            //    Console.WriteLine();
            //}
        }

        #region ImplementProgramFlow
        private static void ImplementProgramFlow()
        {
            //// Decision Structure
            //int number = 16;
            //if (number % 2 == 0)
            //{
            //    Console.WriteLine("Even Number");
            //}
            ////Output Even Number
            //string username = "dev";
            //if (username == "dev")
            //{
            //    Console.WriteLine("Login Successful");
            //}
            //else
            //{
            //    Console.WriteLine("Inavlid username, please try again");
            //}
            ////Output Login Successful
            //int age = 20;
            //if (age < 11)
            //{
            //    Console.WriteLine("You're a child!");
            //}
            //else if (age < 18)
            //{
            //    Console.WriteLine("You're a teenager!");
            //}
            //else if (age < 50)
            //{
            //    Console.WriteLine("You're an adult!");
            //}
            //else
            //{
            //    Console.WriteLine("You're an old person");
            //}
            //int i = 3;
            //switch (i % 2)
            //{
            //    case 0:
            //        Console.WriteLine("{0} is an even number", i);
            //        break;
            //    case 1:
            //        Console.WriteLine("{0} is an odd number", i);
            //        break;
            //}


            //// Decision Operators
            //int num = 2;
            //string result = (num % 2 == 0) ? "Even" : "Odd";
            //Console.WriteLine("{0} is {1}", num, result);
            //string name = null;
            ////set username = name, if name is not null.
            ////set username = “user”, if name is null.
            //string username = name ?? "user";


            //// Loops in C#
            //bool isFound = false;
            //int value = 0;
            //while (isFound != true) //check whether or not run code inside its block
            //{
            //    if(value == 99)
            //    {
            //        isFound = true;
            //    }
            //    value = value + 3;
            //}
            //int count = 1;
            //do //Do not check condition on first iteration
            //{
            //    Console.WriteLine("Hello World");
            //    count++;
            //} while (count <= 5); //check condition: if true, do block execute
            //for (int count = 1; count <= 5; count++)
            //{
            //    Console.WriteLine("Hello World");
            //}
            //int[] array = { 1, 2, 3, 4, 5 }; //Collection of int
            //foreach (int item in array) //iterating over each index of collection
            //{
            //    Console.WriteLine(item); //print value stored in that index
            //}


            ////Jump Statements in C#
            //char character = 'e';
            //switch (character)
            //{
            //    case 'a':
            //    {
            //        Console.WriteLine("Character is a vowel.");
            //        break;
            //    }
            //    case 'e':
            //    {
            //        goto case 'a';
            //    }
            //    case 'i':
            //    {
            //        goto case 'a';
            //    }
            //    case 'o':
            //    {
            //        goto case 'a';
            //    }
            //    case 'u':
            //    {
            //        goto case 'a';
            //    }
            //    case 'y':
            //    {
            //        Console.WriteLine("Character is sometimes a vowel.");
            //        break;
            //    }
            //    default:
            //    {
            //        Console.WriteLine("Character is a consonant");
            //        break;
            //    }
            //}
            ////Output: Character is vowel.
            //int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //for (int i = 0; i < 10; i++)
            //{
            //    if (numbers[i] == 8)
            //    {
            //        goto Control;
            //    }
            //}
            //Console.WriteLine("End of Loop");
            //Control:
            //Console.WriteLine("The number is 8");
            ////Output
            ////The number is 8
            //int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //for (int i = 0; i < 10; i++)
            //{
            //    if (numbers[i] == 3)
            //    {
            //        break;
            //    }
            //    Console.Write(numbers[i]);
            //}
            //Console.WriteLine("End of Loop");
            //int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //for (int i = 0; i < 10; i++)
            //{
            //    if (numbers[i] == 5)
            //    {
            //        continue;
            //    }
            //    Console.Write(numbers[i]);
            //}
            //Console.WriteLine("End of Loop");
            ////Output 1234678910 End of Loop
            //Console.WriteLine("Welcome to Exam 70-483 Certification");
            //int age = getAge();
            //Console.WriteLine("Age is: " + age);
            //Console.WriteLine("Welcome to Exam 70-483 Certification");
            //return;
            //Console.WriteLine("This Statement will never executed!");
        }

        static int getAge()
        {
            return 20;
        }
        #endregion

        #region MethodsInCSharp
        private static void MethodsInCSharp()
        {
            //// Named Argument
            //Sum(b: 5, a: 10);


            //// Optional Argument
            //SumOpt(10); //a = 10, b = 1
            //SumOpt(10, 5); // a = 10, b = 5


            //// Pass by Reference with ref Keyword
            //int j = 0;
            //PassByRef(ref j);
            //Console.WriteLine(j); //j = 1


            //// Pass by Reference with out Keyword
            //int j;
            //outMethod(out j);
            //Console.WriteLine(j); // j = 1


            //// Use Params Array to Pass Unlimited Method Argument
            //Sum(1, 2, 3, 4, 5); // return 15
        }

        static int Sum(int a, int b)
        {
            int add = a + b;
            return add;
        }

        static int SumOpt(int a, int b = 1)
        {
            int add = a + b;
            return add;
        }

        static void PassByRef(ref int i)
        {
            i = i + 1;
        }

        static void outMethod(out int i)
        {
            i = 1;
        }

        static int Sum(params int[] args)
        {
            int add = 0;
            foreach (int item in args)
            {
                add = add + item;
            }
            return add;
        }
        #endregion

        private static void Summary()
        {
            /* var is an implicit type; it can store data of any type at compile time.
             • Operators are special symbols that manipulate data to produce a required result. 
             • C# is a strongly typed language. 
             • No data loss in implicit type conversion. No special syntax required for implicit type conversion. 
             • Data may be lost in explicit type conversion. Special syntax required for explicit type conversion. 
             • Jagged array is an array of an array, which means number of rows in jagged array is fixed but number of columns isn’t fixed. 
             • Use “ref” keyword in method’s parameter to pass data by its reference. 
             • Use “params array” to pass unlimited arguments in methods. 
             • Use switch when we have given constants to compare with. 
             • To repeat statements again and again use loops. 
             • To iterate over collection use foreach loop. 
             • Use jump statements (i.e., goto, break, continue, and return) to change normal flow of program             */
        }
    }
}
