using System;

namespace ShopOnCore.ShoppingCart
{
    public class NotEnoughItemsInStockException : Exception
    {
        public NotEnoughItemsInStockException(string message) : base(message) {}
            
    }
}