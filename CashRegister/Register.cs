using System;

namespace CashRegister
{
    public class Register
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly IDisplay _display;

        public Register(ShoppingCart shoppingCart, IDisplay display)
        {
            _shoppingCart = shoppingCart;
            _display = display;
        }

        public void Add(string itemId)
        {
            try
            {
                _shoppingCart.AddItem(itemId);
            }
            catch (UnknownProductException e)
            {
                _display.ShowMessage("Invalid item code!");
            }
        }

        public void Total()
        {
            var products = _shoppingCart.GetProducts();

            foreach (var product in products)
            {
                _display.ShowMessage(product.Name + ": " + product.Price);
            }

            _display.ShowMessage("----------------------");
            _display.ShowMessage("Total: " + _shoppingCart.Total);
        }
    }
}