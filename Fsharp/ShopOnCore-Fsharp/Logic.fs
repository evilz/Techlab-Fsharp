namespace  Logic

module ProductService =
    open Types
    open System
    
    let _rdn = new Random()
    
    let _products =
         seq { for i in 0 .. 9 ->
                 match i % 4 with
                 | 0 -> ProductId (i.ToString()),  Product.BeautyPersonalCare {id = ProductId (i.ToString()) ; price = decimal(3 * i); name = (sprintf "BeautyPersonalCare_{%i}" i); brand = "Brand";attributes = i.ToString()};
                 | 1 -> ProductId (i.ToString()),  Product.Book {id = ProductId (i.ToString()) ; price = 1.2m * (decimal i); name = (sprintf "Book_{%i}" i); author = "Author"; category = "Category"}
                 | 2 -> ProductId (i.ToString()), Product.Electronic {id = ProductId (i.ToString()) ; price = 11m * (decimal i); name = (sprintf "Electronic_{%i}" i); brand = "Brand"};
                 | _ -> ProductId (i.ToString()), Product.Music {id = ProductId (i.ToString()) ; price = 0.8m * (decimal i); name = (sprintf "Music_{%i}" i); genre = "Genre"; artist = "Artist" };
         }
         |> Map.ofSeq
         
    let getProductFor productId =
        _products |> Map.tryFind productId
        
    let (|InStock|NoMore|) (productId,quantity) =
        if _rdn.Next(100) % 2 = 0
        then InStock
        else NoMore
        
module ShoppingCartService =
        open Types
        
        let getShoppingCartFor now dbGetCart userId =
            match dbGetCart userId with
            | Some c -> c
            | None -> ShoppingCart.emptyFor now userId
            
        let addItemForUser getProduct dbGetCart dbSaveCart userId productId quantity =
           
           match productId quantity with
           | ProductService.NoMore -> Error ("No more product")
           | ProductService.InStock ->
                  let product = getProduct productId
                  let newCart = userId
                                  |> dbGetCart
                                  |> ShoppingCart.add  {product = product; quantity = quantity}
                  
                  newCart |> dbSaveCart                
                  newCart |> Ok
        
//           
//
//        public IDiscount ShoppingCartDiscount(UserId userId) {
//            var shoppingCart = _shoppingCartRepository.ShoppingCartFor(userId);
//            return _discountCalculator.DiscountFor(shoppingCart);
//        }

