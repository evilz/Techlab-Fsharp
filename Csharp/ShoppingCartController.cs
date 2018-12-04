using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ShopOnCore.Discount;
using ShopOnCore.Products;
using ShopOnCore.ShoppingCart;
using ShopOnCore.Users;

namespace ShopOnCore
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ShoppingCartService _shoppingCartService;
        private static  Random _rdn = new Random();

        // FAKE USER
        private readonly UserId _me = new UserId("Vincent");

        public ShoppingCartController(ShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

       [HttpGet(Name = "GetShoppingCart")]
        public ActionResult<ShoppingCart.ShoppingCart> GetShoppingCart()
        {
            return _shoppingCartService.ShoppingCartFor(_me);
        }

        #region Add item
        //[HttpPost]
        [HttpGet("{id}/{quantity}")]
        public IActionResult AddItem(int id, int quantity)
        {
            // valid input here !!!
            try
            {
                _shoppingCartService.AddItem(_me, new ProductId(id), quantity );
            }
            catch (Exception NotEnoughItemsInStockException)
            {
                return BadRequest("No more product left");
            }

            return RedirectToRoute("GetShoppingCart");
        }
        #endregion

        [HttpGet("discount",Name = "GetDiscount")]
        public ActionResult<IDiscount> GetDiscount()
        {
            return Ok(_shoppingCartService.ShoppingCartDiscount(_me));
        }

    }
}