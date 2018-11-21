using System;
using ShopOnCore.Products;

namespace ShopOnCore.ShoppingCart
{
    public class ShoppingCartItem
    {
        public IProduct Product { get; }
        public readonly int Quantity;

        public ShoppingCartItem(IProduct product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        
        public Decimal TotalPrice => Quantity * Product.Price;

        public override string ToString()
        {
            return $"ShoppingBasketItem{{product={Product}, quantity={Quantity}{'}'}";
        }
    }
}