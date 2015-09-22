using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCard {
	public class Card : IComparable<Card> {
		public enum Suit { CLUBS = '♣', SPADES = '♠' , HEARTS = '♥', DIAMONDS = '♦'};
		public static readonly String[] Values = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" }; // Fuuuuuck u 10
		public String [] s = { "♥", "♦", "♣", "♣" };

		private Suit _Suit;
		private String _Value;

		public Card(Suit s, String value) {
			this._Suit = s;
			this._Value = value;
		}

		public Suit GetSuit() {
			return _Suit;
		}
		public String GetValue() {
			return _Value;
		}

		public override string ToString() {
			string ret = "";
			ret += (char)_Suit+ _Value;
			return ret;
		}


		public int CompareTo(Card other) {
			return this.ToString().CompareTo(other.ToString());
		}
	}
}
