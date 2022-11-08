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

# Docker
- We are using dockerfile for our application to run in any os.
- A Dockerfile is a text document that contains all the commands a user could call on the command line to assemble an image. 

- Docker Compose for managing dependency images 
- Docker Compose is a tool that was developed to help define and share multi-container applications.

- For SQL Server Image
    docker pull mcr.microsoft.com/mssql/server:2019-latest
    docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Pa55W0rd" -p 1433:1433 --name sql1 --hostname sql1 -d mcr.microsoft.com/mssql/server:2019-latest

- To Create Docker File in VS:
    main project --> right click --> Add --> Docker Support

- Docker Compose:
    main project --> right click --> Add --> Container Orchestrator Support
    You need to create dependency of SQL Server in here.
    In Environment part of compose file you can give key to change environment in appsettings.json

- To run the application via docker
    go to the powershell and the path which contains Dockerfile use the commands below
    docker-compose build
    docker-compose up

# Event Driven Arch
- Adding a product to basket can be managed by events with async.

- Sending a request to an API then put the message into message broker to handle event which is adding a product to basket.

- Catalog --> Message Broker(Queue FIFO) --> Basket

- Messaging Types;
  Fire and Forget events.
  Specific message to specific queue.

- PUB-SUB Pattern (observable) 
# Message Resourcing
- Azure Service Bus, Rabbit MQ, Kafka etc...

# RabbitMQ 
- To run RabbitMQ via Docker
  docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.10-management
  15672 --> rabbitMQ Dashboard
  5672 --> For the message processes

  MassTransit package for handling processes of RabbitMQ in .NET
  https://masstransit-project.com/usage/configuration.html#net-generic-host
  http://localhost:15672/#/connections

  Basket.API and consumer are created for consuming messages for process of adding a product to a Basket
  
  MailNotification and consumer are created for consuming messages and sending notification for process of adding a product to a Basket

# SAGA Choreography and Orchestration 
- The system is built with SAGA Pattern, every step is triggered after the step executed successfully.
  When there is a exception or fail, rollback or fix action will be taken.
  
- Why ?
  There is some consideration when we are developing an app with distributed transaction.
  - Data consistency between microservices
  - Possible rollback senarios in case of exception.

- Old ways of a transaction is 2PC Pattern to consist of ACID priciples in one request pipeline.

- Handling many events.
  https://microservices.io/patterns/data/saga.html

- To plan events from start to end.
  event storming

- Example of Saga Choreography
1. Order created event is thrown(OrderCreated)
2. Stock API consumes the OrderCreated event
3. If there is enough stock, StockReserved event is thrown
4. If not, StockNotReserved event is thrown
5. Payment API consumes the StockReserved event
6. If payment is successful, PaymentCompleted event is thrown
7. If not, PaymentFailed event is thrown.
8. Orders API consumes the PaymentCompleted event and process is done
9. Orders API consumes the StockNotReserved event and throws OrderFailed and updates the DB
10. Stocks API consumes the PaymentFailed event and changes the stocks
11. Orders API consumes the PaymentFailed event and updated the DB as OrderFailed

# CQRS 
- CQRS stands for Command and Query Responsibility Segregation, a pattern that separates read and update operations for a data store. Implementing CQRS in your    application can maximize its performance, scalability, and security. The flexibility created by migrating to CQRS allows a system to better evolve over time and prevents update commands from causing merge conflicts at the domain level.

- One domain has more consumer than the other, so you can implement CQRS into the module
- Which commands and queries are going to be handled by handler.
- splitting the query and commands without interrupting each other.
- It is kind of managing DTOs
    https://learn.microsoft.com/en-us/azure/architecture/patterns/cqrs
- We can use CQRS with MediatR

# MediatR
- We can implement command independently to handler thanks to MediatR.

# Event Sourcing
- in t moment, how can we know that entity effected from something in that state
- to answer this question event sourcing, so we can track events on an entity
- an entity exists with events that happens on itself
- it costs us more because we are holding more data
https://www.youtube.com/watch?v=lxjUtijFj60&ab_channel=DevnotTV
https://ademcatamak.medium.com/event-sourcing-6683f3f28b5d
https://github.com/devmentors/Pacco
# What about UI ?
- how to manage all the apis endpoints ?
  api gateway
  facade
  ocelot api
  https://learn.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/implement-api-gateways-with-ocelot

# Eureka Netflix
  -services mess
  implementing new microservice
  saving it to eureka.
  it captures the endpoint and register it
  https://www.baeldung.com/spring-cloud-netflix-eureka
  it helps microservices to communicate eachother without needing to know name of the machine or connection port

# Authentication and Authorization
  OpenAPI and OpenAuthentication to manage our auths
  IdentityServer is a tool of managing
  https://duendesoftware.com/products/identityserver