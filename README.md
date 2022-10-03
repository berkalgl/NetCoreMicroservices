# NetCoreMicroservices
Microservices For Net Core

https://github.com/turkayurkmez/microForTurkcell

# Why Microservices ?
- Short release dates.
- Dependency on other modules.
- Not to effect other modules.

# DDD Terms
- Entity
    Customer, Product etc..

- Bounded Context
    Basket, Catalog, Campaign & Discount, Order Management, Shipment, Comment System, Invoice System
    these are microservices and bounded context for user accounts.
    Every microservices are bounded contexts.

- Aggregate
    Customer Entity is aggregate of Order
    Order Entity is aggregate of Product.