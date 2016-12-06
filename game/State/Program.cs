using System;
using System.Text;
using Akka;
using Akka.Actor;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using RabbitMQ.Client.MessagePatterns;
using RabbitMQ.Client.Exceptions;

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

		static void SendMessage(string v)
		{
			var factory = new ConnectionFactory() { HostName = "localhost" };
			using (var connection = factory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				channel.ExchangeDeclare(exchange: "statemessages", type: "fanout");

				string message = v;
				var body = Encoding.UTF8.GetBytes(message);

				channel.BasicPublish(exchange: "statemessages",
									 routingKey: "gamestate",
									 basicProperties: null,
									 body: body);
				Console.WriteLine(" [x] Sent {0}", message);
			}

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
			consumer.onMessageReceived += handleMessage;

			//Start consuming
			consumer.StartConsuming();

		}
		public static void handleMessage(Byte[] message)
		{
			var msg = JsonConvert.DeserializeObject<StateMessage>(System.Text.Encoding.UTF8.GetString(message));
			switch (msg.MessageType)
			{
				case "PlayerJoined":
					sentinal.Tell(new PlayerJoined(msg.Who));
					break;
			}

		}
	}
	public class StateMessage
	{
		public string MessageType { get; set; }
		public string Who { get; set; }
	}
	
	

}
