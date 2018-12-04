using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ShopOnCore.Discount;
using ShopOnCore.Products;
using ShopOnCore.ShoppingCart;

namespace ShopOnCore
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            var discountCalculator = new DiscountCalculator(new []{new ThreeOrMoreBooksDiscount(), new ThreeOrMoreBooksDiscount(), });
            var productService = new ProductService();
            var shoppingCartRepository = new ShoppingCartRepository( () => DateTimeOffset.Now);
            var shoppingCartService = new ShoppingCartService(productService, shoppingCartRepository,discountCalculator );

            services.AddSingleton(shoppingCartService);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}