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
	
	// Create the actor class
	
	public abstract class IConnectToRabbitMQ : IDisposable
	{

		public string Server { get; set; }
		public string ExchangeName { get; set; }

		protected IModel Model { get; set; }
		protected IConnection Connection { get; set; }
		protected string ExchangeTypeName { get; set; }

		public IConnectToRabbitMQ(string server, string exchange, string exchangeType)
		{
			Server = server;
			ExchangeName = exchange;
			ExchangeTypeName = exchangeType;
		}

		//Create the Connection, Model and Exchange(if one is required)
		public bool ConnectToRabbitMQ()
		{
			try
			{
				var connectionFactory = new ConnectionFactory();
				connectionFactory.HostName = Server;
				Connection = connectionFactory.CreateConnection();
				Model = Connection.CreateModel();
				bool durable = false;
				if (!String.IsNullOrEmpty(ExchangeName))
					Model.ExchangeDeclare(ExchangeName, ExchangeTypeName, durable);
				return true;
			}
			catch (BrokerUnreachableException)
			{
				return false;
			}
		}

		public void Dispose()
		{
			if (Connection != null)
				Connection.Close();
			if (Model != null)
				Model.Abort();
		}
	}

}
