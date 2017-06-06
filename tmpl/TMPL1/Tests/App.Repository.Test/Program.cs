using App.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repository.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Application4.Run();
        }
    }

    public class Application1
    {
        public static void Run()
        {
            var product = new Product();

            product.Code = "P001";
            product.Name = "产品1";
            product.Size = "500g/瓶";
            product.Price = 100;

            product["ref_1"] = "abc";
            product["ref_2"] = "123";

            new NPocoRepository<Product>().Insert(product);
        }
    }

    public class Application2
    {
        public static void Run()
        {
            new NPocoRepository<Product>().Get(1);
        }
    }

    public class Application3
    {
        public static void Run()
        {
            var repository = new NPocoRepository<Product>();

            var entity = repository.Get(1);
            repository.Delete(entity);
        }
    }

    public class Application4
    {
        public static void Run()
        {
            var repository = new NPocoRepository<Product>();

            var entity = repository.Get(2);

            entity["ref_1"] = "def";
            entity["ref_2"] = "456";
            repository.Update(entity);
        }
    }
}
