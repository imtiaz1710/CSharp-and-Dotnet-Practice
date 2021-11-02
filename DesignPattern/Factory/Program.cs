using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            var product = ProductFactory<Book>.CreateProduct("Homo sapiense", 20, 100);

            Console.WriteLine(product.Price);
            Console.WriteLine(product.GetType());
        }
    }
}
