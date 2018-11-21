using System;
using System.Collections;
using System.Collections.Generic;
using ShopOnCore.Users;

namespace ShopOnCore.ShoppingCart
{
    public class ShoppingCart : IEnumerable<ShoppingCartItem>
    {
        public UserId UserId { get; }
        public DateTimeOffset CreationDate { get; }
        private readonly List<ShoppingCartItem> _items  = new List<ShoppingCartItem>();

        public ShoppingCart(UserId userId, Func<DateTimeOffset> now)
        {
            UserId = userId;
            CreationDate = now();
        }

        public void Add(ShoppingCartItem shoppingCartItem)
        {
            _items.Add(shoppingCartItem);
        }

        public IEnumerator<ShoppingCartItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}