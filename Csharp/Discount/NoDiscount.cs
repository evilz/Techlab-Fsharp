namespace ShopOnCore.Discount
{
    public class NoDiscount : IDiscount
    {
        public int Percentage => 0;
        public bool IsApplicableTo(ShoppingCart.ShoppingCart shoppingCart) => true;
    }
}