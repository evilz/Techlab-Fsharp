using System;
using Newtonsoft.Json;
using ShopOnCore.Discount;
using ShopOnCore.Products;
using ShopOnCore.ShoppingCart;
using ShopOnCore.Users;

namespace ShopOnCore
{
    class Program
    {
        private static readonly Func<DateTimeOffset> Now = () => DateTimeOffset.Now;
        
        static void Main(string[] args)
        {
            var me = new UserId("Vincent");


            var discountCalculator = new DiscountCalculator(new []{new ThreeOrMoreBooksDiscount(), new ThreeOrMoreBooksDiscount(), });
            var productService = new ProductService();
            var shoppingCartRepository = new ShoppingCartRepository(Now);
            
            var shoppingCartService = new ShoppingCartService(productService, shoppingCartRepository,discountCalculator );

            var myCart = shoppingCartService.ShoppingCartFor(me);

            shoppingCartService.AddItem(me, new ProductId(1), 2 );
            shoppingCartService.AddItem(me, new ProductId(2), 3 );
            var discount = shoppingCartService.ShoppingCartDiscount(me);
            
            
            
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(myCart, new JsonSerializerSettings(){TypeNameHandling = TypeNameHandling.Auto } );
            //var json = Newtonsoft.Json.JsonConvert.SerializeObject(ShoppingCart, new JsonSerializerSettings() );
            Console.WriteLine(json);


            var sc = Newtonsoft.Json.JsonConvert.DeserializeObject<ShoppingCart.ShoppingCart>(json,  new JsonSerializerSettings(){TypeNameHandling = TypeNameHandling.Auto });
        }
    }
}
