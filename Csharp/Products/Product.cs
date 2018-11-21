using System;

namespace ShopOnCore.Products
{
    public abstract class BaseProduct : IProduct
    {
        public ProductId Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}