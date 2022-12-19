Event Driven Architecture
- The architecture uses events to trigger and communicate between decoupled services and is common in modern applications built with microservices.
- An event is a change in state, or and update, like an item being placed in shopping cart on an e-commerce website.
- Event can either carry the state(the item purchased, its price, and a delivery address) or event can be identifiers(a notification that an order was shipped)

- Event-Driven Architectures have three key components; Event producers, router and consumer.
- A producer publishes an event to the router, which filters and pushes the events to consumers.
- Producer services and consumer services are decouple, which allows them to be scaled, updated and deployed independently.

Benefits
- Scale and fail independently
	By decoupling your services, they are only aware of the event router, not each other. This means that your services are interoperable,
	but if one service has a failure, the rest will keep running. The event router acts as an elastic buffer that will accommodate surges in workloads.
- Develop with agility
	You no longer need to write custom code to poll, filter, and route events; the event router will automatically filter and push events to consumers.
	The router also removes the need for heavy coordination between producer and consumer services, speeding up your development process.
- Audit with ease
	An event router acts as a centralized location to audit your application and define policies. These policies can restrict who can publish and subsribe to a router and
	control which users and resources have permission to access your data. You can also encrypt your events both in transit and at rest.
- Cut costs
	Event-driven architectures are push-based, so everything happens on-demand as the event presents itself in the router.
	This way, you are not paying for continuous polling to check for an event. This means less network bandwidth consumption, 
	less CPU utilization, less idle fleet capacity, and less SSL/TLS handshakes

Messaging Broker / RabbitMQ
- It is a system that receives message and send it to an another application in order.
- Helps us to create process that can run asyncronchsly.
- Exchange receives the messages from producer and redirect it to the related queue with specified route. Then the message is put the queue(FIFO)
	Types of exchanges
	- Default, empty string which is set in rabbit mq configuration. amqp default exchange type.
	- Direct, it sends the queue with specified routing key. routing_key = 'queue1'
	- Topic, with specified topic, topic name is like 'like' operator in SQL. health.* topic exchange will send the messages to the queues like health.*
	- Fanout, messages will be sent to every queue without any control. (Broadcasting)
	- Header, when messages and queue header is a match. any --> or, all --> all key
	- Dead letter
- Independent from language
- Uses AMQP(Advanced Message Queuing Protocol)
- Developed with Erland
- Open source
- Cross platform
- Well-documented
- User-Interface

Enterprise Service Bus(ESB) / Messaging Bus
- It is hard to maintain and run distributed systems because of exception handling, try again, waiting, transaction etc. processes.
- MassTransit is a service bus and transport gateway which helps us to maintain components that is integration between services.
  It helps distrubuted systems which are designed and based on messaging, loosely coupled and async, highly available, scalable, safe.
- Two ways of sending a message, Publish and Send
 
Benefits
- Open source and free
- Easy to use
- Strong message patterns
- Distributed transaction
- Testable
- Monitoring
- Reduces complexity in transport processes
- Multiple transports
- Error handling
- Scheduling
- Request, responses pattern
- Message broker exchange

Outbox Design pattern
