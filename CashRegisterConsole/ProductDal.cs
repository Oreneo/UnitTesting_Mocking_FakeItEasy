using System.Collections.Generic;
using CashRegister;

namespace CashRegisterConsole
{
    public class ProductDal : IProductRepository
    {
        // please ignore the mand behind the curtain :)
        private readonly Dictionary<string, Product> _products = new Dictionary<string, Product>();

        public void AddProduct(Product product)
        {
            _products[product.Id] = product;
        }

        public Product GetProductById(string productId)
        {
            if (!_products.ContainsKey(productId))
            {
                throw new UnknownProductException("You keep using that id. I do not think it means what you think it means.");
            }

            return _products[productId];
        }
    }
}