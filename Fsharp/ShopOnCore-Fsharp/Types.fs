module Types
open System

type UserId = UserId of string
type ProductId = ProductId of string

type BeautyPersonalCare =  { id: ProductId; name: string; price : decimal; brand: string; attributes: string; }
type Book =                { id: ProductId; name: string; price : decimal; author: string; category: string; }
type Electronic =          { id: ProductId; name: string; price : decimal; brand: string }
type Music =               { id: ProductId; name: string; price : decimal; genre: string; artist: string; }
    
type Product =
    | BeautyPersonalCare of BeautyPersonalCare
    | Book of Book
    | Electronic of Electronic
    | Music of Music

type ShoppingCartItem = { product: Product; quantity : int }
// public decimal TotalPrice => Quantity * Product.Price;

        
type ShoppingCart = { userId : UserId; creationDate: DateTimeOffset; items: ShoppingCartItem list}

module ShoppingCart =
    
    let add item cart =
        { cart with items = item :: cart.items}
    let emptyFor now userId =
        { userId = userId; creationDate = now(); items = List.empty}