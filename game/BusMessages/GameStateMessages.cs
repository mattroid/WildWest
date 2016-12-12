using System;

namespace GameStateMessages
{
	public class GameJoined
	{
		//public string GameId
		public string PlayerName { get; set; }
	}
	public class Cards
	{
		public string StackId { get; set; }
		public string[] Cards { get; set; }
	}


	public class CardPlayed
	{
		public string CardId { get; set; }
		public string StackId { get; set; }
	}
	public class Players
	{
		public string[] PlayersInGame { get; set; }

	}
	public class Health
	{
		public string PlayerId { get; set; }
		public int HealthPoints { get; set; }
	}
	public class Turn
	{
		public string PlayerId { get; set; }
	}
	public class tookCard
	{
		public string StackId { get; set; }
		public string CardId { get; set; }

	}

}
