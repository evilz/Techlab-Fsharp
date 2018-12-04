using ShopOnCore.Discount;
using ShopOnCore.Products;
using ShopOnCore.Users;

namespace ShopOnCore.ShoppingCart
{
    public class ShoppingCartService
    {
        private readonly ProductService _productService;
        private readonly ShoppingCartRepository _shoppingCartRepository;
        private readonly DiscountCalculator _discountCalculator;

        public ShoppingCartService(ProductService productService,
            ShoppingCartRepository shoppingCartRepository,
            DiscountCalculator discountCalculator) {
            _productService = productService;
            _shoppingCartRepository = shoppingCartRepository;
            _discountCalculator = discountCalculator;
        }

        public void AddItem(UserId userId, ProductId productId, int quantity) {
            AbortIfNotEnoughItemsInStock(productId, quantity);
            AddProductToBasket(productId, quantity, ShoppingCartFor(userId));
        }

        public ShoppingCart ShoppingCartFor(UserId userId) {
            return _shoppingCartRepository.ShoppingCartFor(userId);
        }

        public IDiscount ShoppingCartDiscount(UserId userId) {
            var shoppingCart = _shoppingCartRepository.ShoppingCartFor(userId);
            return _discountCalculator.DiscountFor(shoppingCart);
        }

        private void AddProductToBasket(ProductId productId, int quantity, ShoppingCart shoppingCart) {
            IProduct product = _productService.ProductFor(productId);
            shoppingCart.Add(new ShoppingCartItem(product, quantity));
            _shoppingCartRepository.Save(shoppingCart);
        }

        private void AbortIfNotEnoughItemsInStock(ProductId productId, int quantity) {
            if (!_productService.HasEnoughItemsInStock(productId, quantity)) {
                throw new NotEnoughItemsInStockException($"Wanted {quantity} of {productId}");
            }
        }
    }
}