using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Xamarin.Forms;

namespace Czerwiec2024Mobilna
{
    public partial class MainPage : TabbedPage
    {
        private int gameScore = 0;
        Random random = new Random();

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnRollDiceButtonClicked(object sender, EventArgs e)
        {
            List<int> rolls = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                rolls.Add(random.Next(1,7));
            }

            diceImage1.Source = $"k6_{rolls[0]}.jpg";
            diceImage2.Source = $"k6_{rolls[1]}.jpg";
            diceImage3.Source = $"k6_{rolls[2]}.jpg";
            diceImage4.Source = $"k6_{rolls[3]}.jpg";
            diceImage5.Source = $"k6_{rolls[4]}.jpg";

            int rollScore = 0;

            for(int i = 1; i <= 6; i++)
            {
                int count = 0;
                foreach(int roll in rolls)
                {
                    if(roll == i)
                    {
                        count++;
                    }                    
                }
                if(count > 1)
                {
                    rollScore += i * count;
                }
            }

            rollResultLabel.Text = $"Wynik tego losowania to: {rollScore}";
            gameScore += rollScore;
            gameResultLabel.Text = $"Wynik gry: {gameScore}";
        }

        private void OnResetButtonClicked(object sender, EventArgs e)
        {
            gameScore = 0;
            rollResultLabel.Text = "Wynik tego losowania to: 0";           
            gameResultLabel.Text = "Wynik gry: 0";
            diceImage1.Source = $"k6_0.jpg";
            diceImage2.Source = $"k6_0.jpg";
            diceImage3.Source = $"k6_0.jpg";
            diceImage4.Source = $"k6_0.jpg";
            diceImage5.Source = $"k6_0.jpg";

        }
    }
}
