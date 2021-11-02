using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class ProductFactory<T> where T : IProduct, new()
    {
        public static IProduct CreateProduct(string name, double? discount, double price)
        {
            var product = new T();

            if (discount.HasValue)
                product.Price = price - ((discount.Value / 100) * price);
            else
                product.Price = price;

            return product;
        }
    }
}
