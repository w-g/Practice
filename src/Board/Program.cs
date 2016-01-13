using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Board
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputBlock = string.Empty;

            string[] fruits = { "apple", "mango", "orange", "passionfruit", "grape" };

            // Determine whether any string in the array is longer than "banana".
            string longestName =
                fruits.Aggregate("banana",
                                (longest, next) =>
                                {
                                    Console.WriteLine(next+ " " + longest);
                                    return next.Length > longest.Length ? next : longest;
                                },
                                // Return the final result as an upper case string.
                                fruit => fruit.ToUpper());

            outputBlock += String.Format(
                "The fruit with the longest name is {0}.",
                longestName) + "\n";

            Console.WriteLine(outputBlock);

            Console.ReadKey();
        }
    }
}
