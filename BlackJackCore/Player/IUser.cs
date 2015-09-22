using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackCore.Player {
	interface IUser {
		int Bet(int amount);
		int Won(int amount);
	}
}
