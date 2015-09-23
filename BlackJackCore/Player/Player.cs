using DeckOfCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackCore.Player {
	public class Player : IUser {
		public int Balance { get; private set; }
		public string Name { get; set; }
		public List<Card> hand { get; private set; }
		public Player(String name, int balance) {
			Name = name;
			Balance = balance;
			hand = new List<Card>();
		}
		/// <summary>
		/// this ctor is used for an anunoms player
		/// </summary>
		/// <param name="hand"></param>
		public Player(List<Card> hand) {
			this.hand = hand;
		}
		/// <summary>
		/// Retures the value of a players hand
		/// </summary>
		/// <returns>value Players hand</returns>
		public int GetValue() {
			int value = 0;
			
			int tmp =0;
			value += hand.Where(c => int.TryParse(c.GetValue(), out tmp)).Sum(c => int.Parse(c.GetValue()));
			value += hand.Where(c => !int.TryParse(c.GetValue(), out tmp) && c.GetValue() != "A").Count()*10;
			value += hand.Where(c => c.GetValue() == "A").Count() * 11;
			//check value <= 21
			if (value <= 21)
				return value;
			else {
				//check how many A:es are there 
				int aceCont = hand.Where(c => c.GetValue() == "A").Count();
				value -= aceCont * 10;
				return value;
			}
		}
		
		public void AddCard(Card c) {
			hand.Add(c);
		}
		/// <summary>
		/// subtacrat amount from Balance
		/// </summary>
		/// <param name="amount"></param>
		/// <returns></returns>
		public int Bet(int amount) {
			return Balance -= amount;
		}

		/// <summary>
		/// Addeds the amount to the Balance
		/// </summary>
		/// <param name="amount"></param>
		/// <returns></returns>
		public int Won(int amount) {
			return Balance;
		}
	}
}