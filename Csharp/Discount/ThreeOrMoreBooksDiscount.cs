using ShopOnCore.Products;
using System.Linq;

namespace ShopOnCore.Discount
{
    public class ThreeOrMoreBooksDiscount : IDiscount
    {
        public int Percentage => 10;

        public bool IsApplicableTo(ShoppingCart.ShoppingCart shoppingCart)
        {
            return shoppingCart.Count(p => p.Product is Book) >= 3;
        }
    }
}