using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRaceGame
{
    using System;

    public class Dyna : Punter // player class
    {
        public Dyna(Bet bet, Label MaximumBet, int money, Label label) : base(bet, MaximumBet, money, label)
        {
        }
        //set punter name
        public override void spName()
        {
            Name = "Dyna"; // player name
        }
    }
}