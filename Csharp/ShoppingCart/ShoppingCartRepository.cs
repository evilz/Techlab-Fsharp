using System;
using System.Collections.Concurrent;
using ShopOnCore.Users;

namespace ShopOnCore.ShoppingCart
{
    public class ShoppingCartRepository
    {
        private readonly Func<DateTimeOffset> _now;

        private readonly ConcurrentDictionary<UserId, ShoppingCart> _shoppingCarts =
            new ConcurrentDictionary<UserId, ShoppingCart>();

        public ShoppingCartRepository(Func<DateTimeOffset> now)
        {
            _now = now;
        }

        public ShoppingCart ShoppingCartFor(UserId userId)
        {
            return _shoppingCarts.GetOrAdd(userId, CreateShoppingCart);
        }

        public void Save(ShoppingCart shoppingCart)
        {
            _shoppingCarts.AddOrUpdate(shoppingCart.UserId,
                shoppingCart,
                (userId, oldCart) => shoppingCart);
        }

        private ShoppingCart CreateShoppingCart(UserId userId)
        {
            return new ShoppingCart(userId, _now);
        }
    }
}