This is a sample project to demonstrate the communication between services that is driven by events. I used MassTransit RabbitMQ to build this project . 
The project is divided to api part which is used to create an order.  
The order service is responsible for publish the createdOrder event to queue.
When the consumer of createdOrder event consumes message from the queue, then calls inventory services in order to update or check out of stock status.
We have a notification service that listens to orderUpdated or outOfStock events and send  notifications about them.
I added simple fault tolerance by adding configurations to rabbitmq in order to retry consuming messages when fault happened.
I added fault consumers to consume fault messsages. 
How to run the project :
Go to MessageConsumers project , click right and choose debug==> start new instance : by run this project the queues will be generated.
run api and create the new order using swagger.
