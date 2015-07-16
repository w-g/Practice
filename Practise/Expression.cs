using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Sediment.Practise.Expression
{
    class Person
    {
        public string Name { get; set; }

        public short Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Func<Person, bool> func = x => x.Age > 21;
            Expression<Func<Person, bool>> expression = x => x.Age > 21;

            Console.ReadKey();
        }
    }
}
