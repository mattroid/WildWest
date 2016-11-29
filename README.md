# Wild West
## Card game 

Wild West is a web based implementation of the populate Bang! card game. The 
aim of this project is to provide an friendly and entertaining interface for 
playing this game with your friends accross the web.

# Architecture

The architecture will consist of a Node web server talking to a socket.io backend. The backend will translate messages from the client and relay them to the service bus. The business logic will consist of services listening on the bus and providing responses that the socket.io service will relay to the client. 

At this point in the project there are no hard decisions made, so if you have a reason to adopt a different technology. Create a ticket with the pros and cons that can be discussed. 

### No DB?
I'm not sure about which DB to use yet. I'm thinking an event store database. Concurrency is a key challenge to address with any multiplayer game. Event stores are concrrent friendly databases. 

## Why Node?
1. Serverside rendering
2. JS has a good ecosystem for quickly developing friendly UI
3. Supports sockets
