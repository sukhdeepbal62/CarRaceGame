using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CarRaceGame
{
    

    public class Matt : Punter // player class
    {
        public Matt(Bet bet, Label MaximumBet, int money, Label label) : base(bet, MaximumBet, money, label)
        {
        }
        //set punter name 
        public override void spName()
        {
            Name = "Matt";// player name
        }
    }
}