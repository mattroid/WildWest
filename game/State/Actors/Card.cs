using System;
using Akka.Actor;

namespace State.Actors
{
	public class Card : ReceiveActor
	{
		private string _cardId;
		public Card(string cardId)
		{
			_cardId = cardId;
		}
		public static Props Props(string cardId)
		{
			return Akka.Actor.Props.Create(() => new Card(cardId));
		}
	}
}