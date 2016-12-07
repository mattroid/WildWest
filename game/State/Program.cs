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

namespace State
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
	
	class MainClass
	{
		private static IActorRef sentinal;
		public static void Main(string[] args)
		{
			Console.WriteLine("Starting State Actor System!");
			// Create a new actor system (a container for your actors)
			var system = ActorSystem.Create("StateActorSystem");

			// Create your actor and get a reference to it.
			// This will be an "ActorRef", which is not a
			// reference to the actual actor instance
			// but rather a client or proxy to it.
			sentinal = system.ActorOf<Sentinal>("message-watcher");
			SetupRabbit(sentinal);

			// Send a message to the actor
			//sentinal.Tell(new PlayerJoined("Player 1"));

			//SendMessage("{MessageType: 'PlayerJoined', Who: 'Player 2'}");
			// This prevents the app from exiting
			// before the async work is done
			Console.ReadLine();
		}

		public static void SetupRabbit(IActorRef listeningActor)
		{
			var consumer = new Consumer("localhost", "statemessages", "fanout");

			//connect to RabbitMQ
			if (!consumer.ConnectToRabbitMQ())
			{
				//Show a basic error if we fail
				Console.WriteLine("Could not connect to Broker");
			}

			//Register for message event
			//consumer.onMessageReceived += handleMessage;
			consumer.onMessageReceived += (message) => {
				var msg = JsonConvert.DeserializeObject<StateMessage>(System.Text.Encoding.UTF8.GetString(message));
				switch (msg.MessageType)
				{
					case "PlayerJoined":
						listeningActor.Tell(new PlayerJoined(msg.Who));
						break;
				}
			};

			//Start consuming
			consumer.StartConsuming();
		}

	}
	public class StateMessage
	{
		public string MessageType { get; set; }
		public string Who { get; set; }
	}
	
	

}
