# Wild West
## Card game 

Wild West is a web based implementation of the populate Bang! card game. The 
aim of this project is to provide an friendly and entertaining interface for 
playing this game with your friends accross the web.

# Architecture

The architecture will consist of a Node web server talking to a Phoenix API running the game engine. 

### No DB?
I'm not sure about which DB to use yet. I'm thinking an event store database. Concurrency is a key challenge to address with any multiplayer game. Event stores are concrrent friendly databases. However transactons are also key in a game engine and are not easily adapted to an event store. 

## Why Pheonix?
1. It's fast and supports a high level of concurrency
2. It supports a reliable Web Socket implementation 
3. Elixer language supports writing effective concurrent code with little learning curve

## Why Node?
1. Serverside rendering
2. JS has a good ecosystem for quickly developing friendly UI
