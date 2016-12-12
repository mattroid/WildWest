using System.Collections.Generic;
using Akka.Actor;

namespace State.Actors
{
	public class Player : ReceiveActor
	{
		string who;
		List<IActorRef> Cards;

		public Player(string who)
		{
			this.who = who;
			//Cards = new 
		}

		public static Props Props(string who)
		{
			return Akka.Actor.Props.Create(() => new Player(who));
		}
	}

	public class CreateNewHand
	{
		public string Who { get; set; }
	}
}