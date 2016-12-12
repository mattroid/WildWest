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

namespace State
{
	public class Publisher : ReceiveActor
	{
		public Publisher()
		{
			//Receive<SomeEvent>
			//publish a serialzed message of the event to the queue
		}
	}
}
