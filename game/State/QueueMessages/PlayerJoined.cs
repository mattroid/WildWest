using System;
using System.Text;
using Akka;
using Akka.Actor;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using RabbitMQ.Client.MessagePatterns;
using RabbitMQ.Client.Exceptions;
using State.Actors;

namespace State.QueueMessages
{
	// Create an (immutable) message type that your actor will respond to
	public class PlayerJoined
	{
		public PlayerJoined(string who)
		{
			Who = who;
		}
		public string Who { get; private set; }
	}

	// Create the actor class

}
