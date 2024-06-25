using System;
using System.Threading.Channels;

namespace Unit8Practice.Delegates
{
    internal class DelegateTypes
    {
        public static void DelegateTypesLogic()
        {
            // Action - void delegate
            Action<int, int> printSum = (x, y) => Console.WriteLine($"Sum: {x + y}");
            Action<int, int> printDifference = (x, y) => Console.WriteLine($"Difference: {x - y}");

            PrintCalculation(printSum, 10, 25);
            PrintCalculation(printDifference, 5, 6);

            // <parameters, ..., returnType>
            Func<int, int, string> printMultiply = (x, y) => $"{x} * {y} = {x * y}";
            Console.WriteLine(printMultiply(5,4));

            // Takes 1 parmeter and returns bool (to check conditions)
            Predicate<int> isEven = x => x % 2 == 0;
            const int EvenNumber = 4;
            bool result = isEven(EvenNumber);
            Console.WriteLine($"Is {EvenNumber} even? {result}");
        }

        private static void PrintCalculation(Action<int, int> PrintAction, int a, int b)
        {
            PrintAction(a, b);
        }
    }
}
