open System
open Microsoft.AspNetCore;
open Microsoft.AspNetCore.Hosting;
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Giraffe
open Logic

let now() = DateTimeOffset.Now
let getCart = ShoppingCartService.getShoppingCartFor now Repository.ShoppingCartRepository.getShoppingCartFor

let webApp =
    choose [
        route "/api/ShoppingCart" >=>  WebApi.getShoppingCartHandler getCart  ]

type Startup() =
    member __.ConfigureServices (services : IServiceCollection) =
        // Register default Giraffe dependencies
        services.AddGiraffe() |> ignore

    member __.Configure (app : IApplicationBuilder) =
        // Add Giraffe to the ASP.NET Core pipeline
        app.UseGiraffe webApp

[<EntryPoint>]
let main args =     
     WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build()
            .Run();

     0