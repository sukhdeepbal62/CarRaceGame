using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CarRaceGame
{
    public class Factory // factory class (store data  Names, maximumbet)
    {
        public Punter getPunter(String Name, Label MaximumBet, Label bet)
        {
            Punter p;
            switch (Name.ToLower())
            {
                case "matt"://player name
                    p = new Matt(null, MaximumBet, 50, bet);
                    break;

                case "dyna"://player name
                    p = new Dyna(null, MaximumBet, 50, bet);
                    break;

                case "megan"://player name
                    p = new Megan(null, MaximumBet, 50, bet);
                    break;

                default:
                    p = null;
                    break;
            }
            p.spName();
            return p;
        }
    }
}