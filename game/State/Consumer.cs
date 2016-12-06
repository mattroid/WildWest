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
	
	public class Consumer : IConnectToRabbitMQ
	{
		protected bool isConsuming;
		protected string QueueName;

		// used to pass messages back to UI for processing
		public delegate void onReceiveMessage(byte[] message);
		public event onReceiveMessage onMessageReceived;

		public Consumer(string server, string exchange, string exchangeType) : base(server, exchange, exchangeType)
		{
		}

		//internal delegate to run the consuming queue on a seperate thread
		private delegate void ConsumeDelegate();

		public void StartConsuming()
		{

			Model.BasicQos(0, 1, false);
			QueueName = Model.QueueDeclare();
			Model.QueueBind(QueueName, ExchangeName, "");
			isConsuming = true;
			ConsumeDelegate c = new ConsumeDelegate(Consume);
			c.BeginInvoke(null, null);

			//if (ExchangeTypeName == ExchangeType.Fanout)
			//AddBinding("");//fanout has default binding

		}

		protected Subscription mSubscription { get; set; }

		private void Consume()
		{
			bool autoAck = false;

			//create a subscription
			mSubscription = new Subscription(Model, QueueName, autoAck);

			while (isConsuming)
			{
				BasicDeliverEventArgs e = mSubscription.Next();
				byte[] body = e.Body;
				onMessageReceived(body);
				mSubscription.Ack(e);

			}
		}

		public new void Dispose()
		{
			isConsuming = false;
			base.Dispose();
		}
	}

}
