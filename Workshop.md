---
theme: Night
---
# Créer une Application web en F# 

---

## Introduction TODO

Do you want to learn F# and Functional Programming? Well, you better start coding! Learning a new programming
language is not easy, on top of reading a lot you need to practice even more.
This workshop is designed to teach you some of the basics of F# and Functional Programming by combining theory
and practice. The course is split into 4 modules, each of them contains a presentation (theory) and one exercise
(practice). You can find exercises for each module in this document, for the presentation and source code, refer to
the section “Source Code, Additional Material and Updates”.

---

## Pre-requisites

- [NET Core SDK](https://www.microsoft.com/net/download)
- [Visual Studio Code](https://code.visualstudio.com/)
- [Ionide package](https://code.visualstudio.com/)

---

# F# basic

- Value binding
- Namespace / Module
- type inference => https://fsharpforfunandprofit.com/posts/type-inference/

--

##  Value binding

**Liaisons `let`**

Un liaison associe un identificateur à une valeur ou une fonction.

```fsharp
let x = 1 // OK
x = x + 1 // ERREUR => x est immutable !!!
let y = x + 1  // OK
let x = x + 1  // Shadow
```

--

## Variables mutables

- Le mot clé `mutable` permet de spécifier une variable pouvant être modifiée.
- Le mot clé `let` assigne une valeur initiale à une variable mutable et `<-` assigne une nouvelles valeurs.

```fsharp
let mutable x = 1   // Explicitement mutable
x <- x + 1          // Nouvelle valeur

```

--

## Inférence de type

L'inférence de type permet de déterminer le type depuis l'utilisation de la façon suivante :

- Directment depuis les litérals
- Depuis les fonctions utilisées 
- Depuis les contraintes explicites
- Sinon, generalise en type générique

--

## Inférence de type

```fsharp
let inferInt x = x + 1
let inferDecimal x = x + 1m
let inferChar x = x + 'a'
let inferString x = x + "my string"

let inferInt i = i + 1
let inferIndirectInt x = inferInt x
let inferStringList x = for y in x do printfn "%s" y  // Sequence
let inferIntList x = 99::x // list

let inferIntPrint x = printf "x is %i" x 
let inferGeneric x = x 
```

---

## Namespace et Module

En F#, un `namespace` ou un `module`est un regroupement de code (fonction, type, valeur ...)

- Le namespace est unique dans un fichier et peut contenir plusieurs modules.
- On ouvre un module ou un namespace avec le mot clé `open`

--

## Namespace et Module

```fsharp
// =========================
// File: Person.fs
// =========================
namespace Example

// declare a module for functions that work on the type
module Person = 

    // constructor
    let create first last = 
        {First=first; Last=last}

    // method that works on the type
    let fullName {First=first; Last=last} = 
        first + " " + last
```

---


# F# types

| | |
|--------|--------|
| Record | Tuple |
| Discriminated Unions | Enum types |
| Option Types | Result Type |
| Units of measure | Type Abbreviations|
| POO (Class & interface) | Generic types | 
| Collection : List / Array / Seq | |
| | |

---

## Record

Les `record` représentent des agrégats simples de valeurs nommées, éventuellement avec des membres.

```fsharp
type Point = { x: float; y: float; z: float; }

let p1 = { x = 1.0; y = 1.0; z = 1.0 }

let p1' = { p1 with x = 2.0 }
```

--

## Tuple

Un `tuple` est un regroupement de valeurs sans nom, mais ordonnées.

```fsharp
// Tuple de plusieurs types.
("one", 1, 2.0)

//déconstruire un tuple
let (a, b) = (1, 2)

```

---

# Exercice 1
## record

http://bit.ly/2GW7djm

Questions :

- Comment avez-vous modelisez l'interface ?
- Comment avez-vous modelisez la class de base ?

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
