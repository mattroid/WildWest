using System;
using System.Collections.Generic;
using System.Text;
using Akka;
using Akka.Actor;
using State.QueueMessages;

namespace State.Actors
{
	
	// Create the actor class for a game
	public class Sentinal : ReceiveActor
	{
		private List<IActorRef> Players;

		public Sentinal(IActorRef publisher)
		{
			// Tell the actor to respond
			// to the Greet message
			Receive<PlayerJoined>(player =>
			{
				Console.WriteLine("Ready {0}", player.Who);
				// Get a new ref to a player actor
				var newPlayer = Context.ActorOf(Player.Props(player.Who), "Player-"+player.Who);
				// add the player to the players actor
				Players.Add(newPlayer);
				// setup a player actor with a new hand
				newPlayer.Tell(new CreateNewHand());
				// publish the new state to the queue
				publisher.Tell(new PlayerAdded());
			});
		}
	}
	public class PlayerAdded
	{
		public string Who { get; set; }
	}
}
