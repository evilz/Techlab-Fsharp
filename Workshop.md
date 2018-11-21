# Créer une Application web en F# 

## Introduction TODO

Do you want to learn F# and Functional Programming? Well, you better start coding! Learning a new programming
language is not easy, on top of reading a lot you need to practice even more.
This workshop is designed to teach you some of the basics of F# and Functional Programming by combining theory
and practice. The course is split into 4 modules, each of them contains a presentation (theory) and one exercise
(practice). You can find exercises for each module in this document, for the presentation and source code, refer to
the section “Source Code, Additional Material and Updates”.

## Pre-requisites

- [NET Core SDK](https://www.microsoft.com/net/download)
- [Visual Studio Code](https://code.visualstudio.com/)
- [Ionide package](https://code.visualstudio.com/)



---

Customer
orders

```fsharp
type Customer = {
    Id: Guid
    Name: string
    Orders: order list
    }


type OrderLine = {
    product: Product
    qty: int 
}

type Order = {
    Id: Guid
    Items: list OrderLine
}


type Product = {
    Id: Guid
    Name: string
    Price: Decimal
}
```
