using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Newtonsoft.Json;
using RabbitMQ.Client.MessagePatterns;
using RabbitMQ.Client.Exceptions;

namespace TestMessages
{

	class MainClass
	{

		public static void Main(string[] args)
		{
			System.Threading.Thread.Sleep(5000);

			while (true)
			{
				SendMessage("{MessageType: 'PlayerJoined', Who: 'Player 2'}");
				Console.WriteLine(" Press [enter] to send again.");
				// This prevents the app from exiting
				// before the async work is done
				Console.ReadLine();
			}
		}

		public static void SendMessage(string message)
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
