ClientServerMessagingApp

A client server messaging app developed with .NET.
It contains an authentication&authorization microservice, which connects to a dockerized PostgreSQL database. 
The client app communicates with the auth microservice through REST endpoints, and connects the server app using websockets.
The server app also connects to a dockerized database in order to keep track of rooms and messages.
