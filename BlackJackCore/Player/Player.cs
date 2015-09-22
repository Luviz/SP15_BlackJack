using DeckOfCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackCore.Player {
	class Player : IUser {
		public int Balance { get; private set; }
		public string Name { get; set; }
		public List<Card> hand { get; set; }
		public Player(String name, int balance) {
			Name = name;
			Balance = balance;
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
