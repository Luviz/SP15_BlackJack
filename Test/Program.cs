
using System;
using BlackJackCore.Player;
using DeckOfCard;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test {
	class Program {
		public static void Main() {
			Player p = new Player("Jedi", 100);
			p.AddCard(new Card(Card.Suit.DIAMONDS, "A"));
			p.AddCard(new Card(Card.Suit.DIAMONDS, "A"));
			p.AddCard(new Card(Card.Suit.DIAMONDS, "10"));
			p.AddCard(new Card(Card.Suit.DIAMONDS, "K"));
			Deck d = new Deck();
			d.Shuffle();
			Console.WriteLine(p.GetValue());
			Console.ReadLine();
		}

	}
}

