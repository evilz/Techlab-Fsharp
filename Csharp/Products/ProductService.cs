using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopOnCore.Products
{
    public class ProductService
    {
        private static  Random _rdn = new Random();
        private static readonly IDictionary<ProductId, IProduct> _products =
            Enumerable.Range(0, 10)
                .Select(i =>
                {
                    IProduct product;
                    switch (i % 4)
                                         {
                        case 0:
                            product = new BeautyPersonalCare {Id = new ProductId(i), Price = 3 * i, Name = $"BeautyPersonalCare_{i}", Brand = "Brand", Attributes = i.ToString()};
                            break;
                        case 1:
                            product = new Book {Id = new ProductId(i), Price = 1.2m * i, Name = $"Book_{i}", Author = "Author", Category = "Category"};
                            break;
                        case 2:
                            product = new Electronic {Id = new ProductId(i), Price = 11 * i, Name = $"Electronic_{i}", Brand = "Brand"};
                            break;
                        default:
                            product = new Music {Id = new ProductId(i), Price = .8m * i, Name = $"Music_{i}", Genre = "Genre", Artist = "Artist"};
                            break;
                    }

                    return product;
                })
                .ToDictionary(product => product.Id, product => product);


        public IProduct ProductFor(ProductId productId)
        {
            _products.TryGetValue(productId, out var value);
            return value;
        }

        public bool HasEnoughItemsInStock(ProductId productId, int quantity)
        {
            // FAKE
            return _rdn.Next(100) % 2 == 0;
        }
    }
}