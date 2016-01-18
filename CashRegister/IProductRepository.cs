namespace CashRegister
{
    public interface IProductRepository
    {
        Product GetProductById(string productId);
    }
}