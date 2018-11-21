using System;
using System.Linq;
using ShopOnCore.Products;

namespace ShopOnCore.Discount
{
    public class AtLeastOneBookAndOneMusicDiscount : IDiscount
    {
        public int Percentage { get; }

        public AtLeastOneBookAndOneMusicDiscount(int percentage)
        {
            Percentage = percentage;
        }

        public bool IsApplicableTo(ShoppingCart.ShoppingCart shoppingCart)
        {
            return shoppingCart.Any(p => p.Product is Book) && shoppingCart.Any(p => p.Product is Music);
        }
    }
}