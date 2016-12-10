using System;
using System.Text;
using Akka;
using Akka.Actor;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using RabbitMQ.Client.MessagePatterns;
using RabbitMQ.Client.Exceptions;
using State.QueueMessages;

namespace State.Actors
{
	
	// Create the actor class
	public class Sentinal : ReceiveActor
	{
		public Sentinal()
		{
			// Tell the actor to respond
			// to the Greet message
			Receive<PlayerJoined>(player =>
			   Console.WriteLine("Ready {0}", player.Who));
		}
	}

}
