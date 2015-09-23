using DeckOfCard;
using BlackJackCore.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_CA {
	class BlackJack {
		private bool ShowDealerHand;
		private bool GameOver;
		private bool DealerBusted;

		private List<Card> DealersHand { get; set; }
		private Deck deck { get; set; }
		private List<Player> players { get; set; }

		public BlackJack(int nrOStacks) {
			deck = new Deck(nrOStacks);
			players = new List<Player>();
			DealersHand = new List<Card>();
			Init();

		}
		private void Init() {
			Start();
		}

		private void Start() {
			Console.Clear();
			Console.WriteLine(" ==============================================");
			Console.WriteLine("/Welcome The AwesomeCool BackJack with hockers/");
			Console.WriteLine("==============================================");
			Console.Write("Name: ");
			string name = Console.ReadLine();
			players.Add(new Player(name, 100));

			GameStart();
		}

		private void GameStart() {
			deck.Shuffle();
			players[0].AddCard(deck.Pop());
			DealersHand.Add(deck.Pop());
			players[0].AddCard(deck.Pop());
			DealersHand.Add(deck.Pop());
			ShowDealerHand = false;
			GameOver = false;
			DealerBusted = false;
			Update();
		}

		private void Update() {
			Console.Clear();
			Console.Write("Dealer: ");
			if (ShowDealerHand) {
				DealersHand.ForEach(c => Console.Write("[{0}] ", c));
				Console.WriteLine("\nValue: {0}", new Player(DealersHand).GetValue());
			}
			else {
				Console.WriteLine("[{0}] [?]", DealersHand[0]);

			}
			Console.WriteLine();
			Console.WriteLine();
			Console.Write("{0}: ", players[0].Name);
			players.ForEach(p => p.hand.ForEach(c => Console.Write("[{0}] ", c)));
			Console.WriteLine();
			
			Console.WriteLine("Value: {0}", players[0].GetValue());
			if (!GameOver) {
				Console.WriteLine("1. Hit ");
				Console.WriteLine("2. Hold");
				char choice = Console.ReadKey().KeyChar;
				if (choice == '1')
					Hit();
				else 
					Hold(); 
			}
			else {
				//show win loss status
				if (players[0].GetValue() > 21) {
					//busted

					Console.WriteLine("Busted!");
					EndGame();
				}
				else if (!ShowDealerHand) {
					DealersTurn();
				}
				else {
					Console.WriteLine("{0}: {1} | Dealer: {2}", players[0].Name, players[0].GetValue(), new Player(DealersHand).GetValue());
					if (players[0].GetValue() < new Player(DealersHand).GetValue() && !DealerBusted) {
						//Dealer wins
						Console.WriteLine("you lost");
					}
					else {
						//Player win hard!
						Console.WriteLine("You WON!");
					}
					EndGame();
				}
			}
		}

		
		private void Hit() {
			players[0].AddCard(deck.Pop());
			if (players[0].GetValue() > 21)
				GameOver = true;
			Update();
		}

		private void Hold() {
			DealersTurn();
			GameOver = true;
		}

		private void DealersTurn() {
			while (new Player(DealersHand).GetValue() < 17) {
				//hit
				DealersHand.Add(deck.Pop());
			}
			if (new Player(DealersHand).GetValue() > 21)
				DealerBusted = true;
			GameOver = true;
			ShowDealerHand = true;
			Update();
		}
		private void EndGame() {
			Console.WriteLine("The game is over!");
			Console.WriteLine("press Enter to end!");
			Console.ReadLine();
		}
	}
}
