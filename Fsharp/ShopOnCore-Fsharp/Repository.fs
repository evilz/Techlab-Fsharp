namespace Repository

module ShoppingCartRepository =
    
    let mutable _shoppingCarts = Map.empty

    let getShoppingCartFor userId =
        _shoppingCarts |> Map.tryFind userId
            
    let save (userId:Types.UserId) (shoppingCart:Types.ShoppingCart) =
        match getShoppingCartFor userId with
        | None -> _shoppingCarts <- _shoppingCarts |> Map.add userId shoppingCart
        | Some c ->
             _shoppingCarts <-
                 _shoppingCarts
                 |> Map.remove userId
                 |> Map.add userId shoppingCart
        
        ignore()

