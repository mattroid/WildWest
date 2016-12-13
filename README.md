# Wild West
## Card game 

Wild West is a web based implementation of the populate Bang! card game. The 
aim of this project is to provide an friendly and entertaining interface for 
playing this game with your friends accross the web.

# Architecture

The architecture will consist of a Node web server talking to a socket.io backend. The backend will translate messages from the client and relay them to the service bus (RabbitMQ). The business logic will consist of services listening on the bus and providing responses that the socket.io service will relay to the client[s]. 

At this point in the project there are no hard decisions made, so if you have a reason to adopt a different technology. Create a ticket with the pros and cons that can be discussed. 

## Node + SocketIO
###ReactJS+Redux
React provides a platform that's reactive to state changes. Redux provides a message based service that allows our components to be decoupled from each other. 

### SocketIO
SocketIO gives us a socket interface to have a two way connection with clients. This enables us to have a lean format for message passing between client and server. No HTTP overhead, when using the Websocket protocal. However, SocketIO has fail over to simplier HTTP polling methods for when connected clients don't support Websockets. 

### RabbitJS
RabbitJS gives us a socket interface to talk to the service bus on. This is easy to use and familure to the socket interface that we use to talk to the connected clients.
