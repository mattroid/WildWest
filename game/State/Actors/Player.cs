using System.Collections.Generic;
using System;
using System.Linq;
using Akka.Actor;

namespace State.Actors
{
	public class Player : ReceiveActor
	{
		string who;
		List<Tuple<string, IActorRef>> Cards;


		public Player(string who)
		{
			this.who = who;
			//Cards = new 
			Receive<CreateNewHand>((obj) => {
				// get cards and add their actor refs to the card collection
				//generate a hand of Bangs!
				Enumerable.Range(1,4).ToList().ForEach(x => Cards.Add(new Tuple<string, IActorRef>("Bang!", Context.ActorOf(Card.Props("Bang!")))));
				Context.Parent.Tell(new StackUpdated() { Who = this.who, Cards = Cards.Select(c=>c.Item1).ToList() });
			});
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
	public class PlayCard
	{
		public string CardId { get; set; }
	}
}