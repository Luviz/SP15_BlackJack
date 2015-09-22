using DeckOfCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test {
	class Program {
		static void Main(string[] args) {
			Card c = new Card(Card.Suit.CLUBS, Card.Values[2] );
			Card c2 = new Card(Card.Suit.CLUBS, Card.Values[3]);
			Console.WriteLine(c + " "+ c2);
			Console.WriteLine(c2.CompareTo(c));
			Console.WriteLine((char)Card.Suit.CLUBS);
			Console.WriteLine(52*2 >> 1);

			Deck d = new Deck(1);

			d.Shuffle();

			foreach(Card card in d)
				Console.WriteLine(card);

			Console.ReadLine();

		}
	}
}
