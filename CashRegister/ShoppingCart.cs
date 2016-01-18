using System.Collections.Generic;
using System.Linq;

namespace CashRegister
{
    public class ShoppingCart
    {
        private readonly IProductRepository _repository;
        private readonly List<Product> _selectedProducts;

        public ShoppingCart(IProductRepository repository)
        {
            _repository = repository;
            _selectedProducts = new List<Product>();
        }

        public double Total
        {
            get
            {
                return _selectedProducts.Sum(product => product.Price);
            }
        }

        public void Clear()
        {
            _selectedProducts.Clear();
        }

        public void AddItem(string itemId)
        {
            var product = _repository.GetProductById(itemId);

            _selectedProducts.Add(product);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _selectedProducts.ToArray();
        }
    }
}
