namespace ShopOnCore.Discount
{
    public interface IDiscount {

        int Percentage { get; }

        bool IsApplicableTo(ShoppingCart.ShoppingCart shoppingCart);
    }
}