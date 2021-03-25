using System;
using System.Windows.Forms;
using System.Drawing;

namespace CarRaceGame
{
    public class Car
    {
        private static int go;
        private static int trackheight;
        public PictureBox pbCar = null;
        public int Location = 0;
        public static Random rand = new Random(); //declared random object as static to avoid same random number

        public static int Go { get => go; set => go = value; }
        public static int newtrackheight { get => trackheight; set => trackheight = value; }

        // generation across all horse objects
        public void runpbcar(int area)
        {
            Point p = pbCar.Location;
            p.Y -= area;
            pbCar.Location = p; //move horse in x-axis
        }

        public static bool Run(Car obj)
        {
            int area = rand.Next(1, 10);
            if (obj.pbCar != null)
                obj.runpbcar(area);

            obj.Location += area;
            if (obj.Location >= (newtrackheight - Go))
            {
                return true;
            }
            return false;
        }

        public void TakeStartingPosition()
        {
            runpbcar(-Location); //reset location to -ve distance ie. to starting point
            Location = 0;

        }

        
    }
}
