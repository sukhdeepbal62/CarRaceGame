using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRaceGame
{
    public class Bet   // bet class 
    {
        public int Amount; // betting amount 
        public int carNum; // choise car number 
        public Punter Bettor; // which player bet on car

        public Bet(int Amount, int carNum, Punter Bettor) // bet function
        {
            this.Amount = Amount;
            this.carNum = carNum;
            this.Bettor = Bettor;
        }

        public string message() // notification 
        {
            string msg = "";

            if (Amount > 0) // if statement show msg  player place bet on car
            {
                msg = String.Format("{0} make ${1} bet on Car {2}",
                    Bettor.Name, Amount, carNum);
            }
            else // else statement show msg  player  hasn't place bet on any car
            {
                msg = String.Format("{0} hasn't placed any bet yet",
                    Bettor.Name);
            }
            return msg; 
        }

        public int Pay(int Winner)
        {
            if (carNum == Winner)
            {
                return Amount;
            }
            return -Amount;
        }
    }
}