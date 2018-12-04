namespace ShopOnCore.Products
{
    public interface IProduct
    {
        ProductId Id { get; }
        string Name { get; }
        decimal Price { get; }
    }
}