using System;

using System.Windows.Forms;
using System.Drawing;

namespace CarRaceGame
{
    public abstract class Punter // abstract class 
    {
        public string Name; 
        public Bet bet;
        public int money;
        public bool busted;
        public Label statusLabel, MaxBet;


        public bool PlaceBet(int Amount, int car) // place bet 
        {
            if (Amount <= money)
            {
                bet = new Bet(Amount, car, this);
                return true;
            }
            return false;
        }


        public Punter(Bet bet, Label MaximumBet, int money, Label statusLabel)
        {
            this.bet = bet;
            this.money = money;
            this.MaxBet = MaximumBet;
            this.statusLabel = statusLabel;
            if (this.statusLabel != null)
                this.statusLabel.ForeColor = System.Drawing.Color.Red;

        }

        public void UpdateLabels()
        {
            if (bet == null)
            {
                statusLabel.Text = String.Format("{0} hasn't placed any bets", Name);

            }

            else
            {
                statusLabel.Text = bet.message();
            }
            if (money == 0)
            {
                busted = true;
                statusLabel.Text = String.Format("BUSTED!");
                statusLabel.ForeColor = System.Drawing.Color.Red;

            }
            MaxBet.Text = String.Format("Max Bet: ${0}", money);
            statusLabel.ForeColor = System.Drawing.Color.Black ;
        }


        public void ClearBet()
        {
            bet.Amount = 0;
        }

        public void Collect(int Winner)
        {
            money += bet.Pay(Winner);
        }

        public abstract void spName();
    }
}