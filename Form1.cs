using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace CarRaceGame
{
    public partial class MainForm : Form
    {

        Car[] cars = new Car[4];         // cars arry, Four Cars run on the track

        Factory pFactory = new Factory();  //factory class where each player have fix amount when game start.

        Punter[] punters = new Punter[3];    //punter class where player can put their bet on different racer.

        // sound play on click buttons
        System.Media.SoundPlayer sound = new System.Media.SoundPlayer(Properties.Resources.sound);
        System.Media.SoundPlayer click = new System.Media.SoundPlayer(Properties.Resources.click);

       
        public MainForm()
        {
            InitializeComponent(); //  form initilize
            RaceTrack();// race track function
            sound.Play(); // sound play 
        }       
        private void RaceTrack() // function , set the required range of track and direction
        {
                                                   
            Car.Go = Car1.Bottom - pbRaceTrack.Top;// cars go botton to top side direction
                                                   
            Car.newtrackheight = pbRaceTrack.Size.Height +620;// finish line
                                                           
            cars[0] = new Car() { pbCar = Car1 };
            cars[1] = new Car() { pbCar = Car2 };   //car numbers
            cars[2] = new Car() { pbCar = Car3 };
            cars[3] = new Car() { pbCar = Car4 };
                                                             
            punters[0] = pFactory.getPunter("matt", lblMaxBet, lblMattStatus);
            punters[1] = pFactory.getPunter("dyna", lblMaxBet, lblDynaStatus); //get  players details form factory class
            punters[2] = pFactory.getPunter("megan", lblMaxBet, lblMeganStatus); 


            foreach (Punter punter in punters)
            {
                punter.UpdateLabels();// update detail when someone losse or win the game
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           

        }
        // Player Matt radio button
        private void RBmatt_CheckedChanged(object sender, EventArgs e)
        {
            click.Play();
            maximumbetlbl(punters[0].money); // maximum bet 
        }
       // Player dyna radio button
        private void RBdyna_CheckedChanged(object sender, EventArgs e)
        {
            click.Play();
            maximumbetlbl(punters[1].money);// maximum bet
        }
        //Player megan radio button
        private void RBmegan_CheckedChanged(object sender, EventArgs e)
        {
            click.Play();
            maximumbetlbl(punters[2].money); //maximum bet
        }
        // maximun bet function
        private void maximumbetlbl(int money)
        {
           
            lblMaxBet.Text = String.Format("Max Bet: ${0}", money); //update label time to time
        }
        // bet button , where player can make a bet 
        private void Bets_Click_1(object sender, EventArgs e)
        {
            click.Play();
            int PunterNum = 0;

            if (RBmatt.Checked)
            {
                PunterNum = 0;


            }
            if (RBdyna.Checked)
            {
                PunterNum = 1;

                
            }
            if (RBmegan.Checked)
            {
                PunterNum = 2;


            }
            //place bet by chosse amount and car number
            punters[PunterNum].PlaceBet((int)BetValue.Value, (int)CarNum.Value);

            punters[PunterNum].UpdateLabels();
        }
        // race button .. for start the race
        private void racebtn_Click(object sender, EventArgs e)
        {
            click.Play();
            bool NoWinner = true; 
            int winningCar;
            racebtn.Enabled = false; //disable race button

            while (NoWinner)
            { // loop until someone  win the race
                Application.DoEvents();
                for (int i = 0; i < cars.Length; i++)
                {
                    if (Car.Run(cars[i]))
                    {
                        winningCar = i + 1;
                        NoWinner = false;
                        MessageBox.Show(" Car "
                            + winningCar  + " Win the Race");
                        foreach (Punter punter in punters)
                        {
                            if (punter.bet != null)
                            {
                                punter.Collect(winningCar); // money added as a double in winner side or deducted from others
                                punter.bet = null;
                                punter.UpdateLabels();
                            }
                        }
                        foreach (Car car in cars)
                        {
                            car.TakeStartingPosition();
                        }
                        break;
                    }
                }
            }
            if (punters[0].busted && punters[1].busted && punters[2].busted)
            {                                                   //no can place bet if they run out of cash
                String message = "Do you want to Play Again?";
                String title = "End Game!";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                   RaceTrack(); //restart game
                }
                else
                {
                    this.Close();
                }

            }
            racebtn.Enabled = true; //enable race button 
        }

        private void lblMattStatus_Click(object sender, EventArgs e)
        {
            
        }

        private void BettingAmount_Scroll(object sender, EventArgs e)
        {

        }

        private void MaximumBet_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
        //exit game
        private void btnExit_Click(object sender, EventArgs e)
        {
            click.Play();
            Application.Exit();//exit
        }
        // restart game
        private void btnRestart_Click(object sender, EventArgs e)
        {
            click.Play();
            Application.Restart();// restart
        }

        private void BetValue_ValueChanged(object sender, EventArgs e)
        {
            click.Play();
        }
    }
}
