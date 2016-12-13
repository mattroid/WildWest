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
using Newtonsoft.Json.Linq;
using GameStateMessages;
using System.Collections.Generic;

namespace State
{
	public class Publisher : ReceiveActor
	{
		public Publisher()
		{
			//Receive<SomeEvent>
			//publish a serialzed message of the event to the queue
			Receive<PlayersUpdated>((players) => {
				SendMessage(new Players() { PlayersInGame = players.Players.ToArray() });
			});

		}
		public void SendMessage(object message)
		{
			SendMessage(JsonConvert.SerializeObject(message));
		}
		public void SendMessage(string message)
		{
			Console.WriteLine("Starting State Actor System!");
			var factory = new ConnectionFactory() { HostName = "localhost" };
			using (var connection = factory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				channel.ExchangeDeclare(exchange: "statemessages", type: "fanout");

				var body = Encoding.UTF8.GetBytes(message);
				channel.BasicPublish(exchange: "statemessages",
									 routingKey: "",
									 basicProperties: null,
									 body: body);
				Console.WriteLine(" [x] Sent {0}", message);
			}


		}
	}
}
