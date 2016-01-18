using CashRegister;
using CashRegisterTests;
using NUnit.Framework;
using FakeItEasy;

namespace CashRegisterTests
{
    [TestFixture]
    public class ShoppingCartTests
    {
        [Test]
        public void NoItemsInCart_TotalEqual0()
        {
            IProductRepository products = null; // repository doesn't matter - no reference to him is being made - nullify
            ShoppingCart shoppingCart = new ShoppingCart(products);

            Assert.That(shoppingCart.Total, Is.EqualTo(0));
        }

        [Test]
        public void AddItem_AddValidProductToCart_TotalEqualsItemPrice()
        {
            // Arrange
            IProductRepository products = A.Fake<IProductRepository>();
            ShoppingCart shoppingCart = new ShoppingCart(products);

            A.CallTo(() => products.GetProductById("item-1")).Returns(new Product("item-1", "Banana", 14.5));

            // Act
            shoppingCart.AddItem("item-1");

            // Assert
            Assert.AreEqual(shoppingCart.Total, 14.5);
        }

        [Test]
        public void AddItem_AddTwoValidProductsToCart_TotalEqualsItemsPrice()
        {
            IProductRepository products = A.Fake<IProductRepository>();
            ShoppingCart shoppingCart = new ShoppingCart(products);

            A.CallTo(() => products.GetProductById("item-1")).Returns(new Product("item-1", "Banana", 14.5));
            A.CallTo(() => products.GetProductById("item-2")).Returns(new Product("item-2", "Orange", 2.5));

            shoppingCart.AddItem("item-1");
            shoppingCart.AddItem("item-2");

            Assert.That(shoppingCart.Total, Is.EqualTo(17));
        }

        [Test]
        public void Clear_AddValidItemToCartThenClear_TotalEquals0()
        {
            IProductRepository products = A.Fake<IProductRepository>();
            ShoppingCart shoppingCart = new ShoppingCart(products);

            A.CallTo(() => products.GetProductById("item-1")).Returns(new Product("item-1", "Banana", 14.5));

            shoppingCart.AddItem("item-1");
            shoppingCart.Clear();

            Assert.That(shoppingCart.Total, Is.EqualTo(0));
        }

        [Test]
        public void Clear_AddInvalidItemToCartThenClear_ThrowUnknownProductException()
        {
            IProductRepository products = A.Fake<IProductRepository>();

            A.CallTo(() => products.GetProductById(A<string>.Ignored)).Throws(new UnknownProductException("UnknownProductException was thrown."));

            ShoppingCart shoppingCart = new ShoppingCart(products);

            Assert.Throws<UnknownProductException>(() => shoppingCart.AddItem("item-999"));
        }

        [Test]
        public void Add_AddValidItem_ItemNameAndPriceDisplayed()
        {
            IProductRepository products = A.Fake<IProductRepository>();
            ShoppingCart shoppingCart = new ShoppingCart(products);
            IDisplay consoleDisplay = A.Fake<IDisplay>();
            Register register = new Register(shoppingCart, consoleDisplay);

            A.CallTo(() => products.GetProductById("item-1")).Throws(new UnknownProductException(""));
            register.Add("item-1");

            A.CallTo(() => consoleDisplay.ShowMessage("Invalid item code!")).MustHaveHappened();
        }

        [Test]
        public void Total_AddTwoValidItems_ItemsNamesAndPricesDisplayed()
        {
            IProductRepository products = A.Fake<IProductRepository>();
            ShoppingCart shoppingCart = new ShoppingCart(products);
            IDisplay consoleDisplay = A.Fake<IDisplay>();
            Register register = new Register(shoppingCart, consoleDisplay);

            A.CallTo(() => products.GetProductById("item-1")).Returns(new Product("item-1", "Banana", 10.5));

            register.Add("item-1");
            register.Add("item-1");

            register.Total();

            A.CallTo(() => consoleDisplay.ShowMessage("Total: 21")).MustHaveHappened();
        }
    }
}
