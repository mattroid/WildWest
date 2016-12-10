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
using State.QueueMessages;

namespace State
{

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

			//SendMessage like "{MessageType: 'PlayerJoined', Who: 'Player 2'}");

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
				var msgString = System.Text.Encoding.UTF8.GetString(message);
				var msg = JsonConvert.DeserializeObject<StateMessage>(msgString);
				switch (msg.MessageType)
				{
					case "PlayerJoined":
						dynamic joinMsg = JsonConvert.DeserializeObject(msgString);
						listeningActor.Tell(new PlayerJoined(joinMsg.Who));
						break;
					case "PlayerNameChanged":
						break;
					case "GameStarted":
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
	}
}
