using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCard {
	public class Deck :IEnumerable {
		private Stack<Card> _deck;

		public object Current {
			get {
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// this will genrate an Empty deck
		/// </summary>
		public Deck() {
			_deck = new Stack<Card>();
		}

		/// <summary>
		/// this will genreate a nr of decks
		/// </summary>
		/// <param name="stacks"></param>
		public Deck(int stacks) {
			_deck = new Stack<Card>();
			Card.Suit[] suits = { Card.Suit.CLUBS, Card.Suit.SPADES, Card.Suit.HEARTS, Card.Suit.DIAMONDS };
			for (int i =0; i < stacks;  i++) 
				foreach (Card.Suit s in suits) 
					foreach (String v in Card.Values) 
						_deck.Push(new Card(s, v));

		}

		public void TruffelShuffle() {
			Stack<Card>[] s = new Stack<Card>[2];
			s[0] = new Stack<Card>();
			s[1] = new Stack<Card>();
			int DeckSize = _deck.Count();
			int i = 0;
			for (; i < DeckSize >> 1; i++)
				s[0].Push(_deck.Pop());
			for (; i < DeckSize; i++)
				s[1].Push(_deck.Pop());

			//an Elegant Bridge
			while(s[0].Any() || s[1].Any()) {
				if (s[0].Any())
					_deck.Push(s[0].Pop());
				if (s[1].Any())
					_deck.Push(s[1].Pop());
			}
			
		}
		public void TruffelShuffle (int times) {
			for (int i = 0; i < times; i++)
				TruffelShuffle();
		}

		public void Shuffle() {
			Random r = new Random();
			List<Card> tmp = new List<Card>(_deck);
			_deck.Clear();
			while (tmp.Any()) {
				int index = r.Next(tmp.Count);
				_deck.Push(tmp[index]);
				tmp.RemoveAt(index);				// damn u MS all you had to just is return the GOD DAMN REMOVED ITEM is that hard!!!!!!!!
			}
		}
		/// <summary>
		/// pops out a card form the stack
		/// </summary>
		/// <returns>Card</returns>
		public Card Pop() {
			return _deck.Pop();
		}
		/// <summary>
		/// peeks the next card
		/// </summary>
		/// <returns>Card</returns>
		public Card Peek() {
			return _deck.Peek();
		}

		public IEnumerator GetEnumerator() {
			return ((IEnumerable)_deck).GetEnumerator();
		}
	}
}
