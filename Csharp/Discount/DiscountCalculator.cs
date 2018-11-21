using System.Collections.Generic;
using System.Linq;

namespace ShopOnCore.Discount
{
    public class DiscountCalculator
    {
        private List<IDiscount> _discounts;

        public DiscountCalculator(IEnumerable<IDiscount> discounts)
        {
            _discounts = new List<IDiscount>(discounts);
        }

        public IDiscount DiscountFor(ShoppingCart.ShoppingCart shoppingCart)
        {
            return _discounts
                .Where(discount => discount.IsApplicableTo(shoppingCart))
                .OrderByDescending(discount => discount.Percentage)
                .DefaultIfEmpty(new NoDiscount())
                .First();
        }
    }
}