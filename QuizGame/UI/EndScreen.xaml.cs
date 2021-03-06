using System;
using System.Windows;

namespace QuizGame
{
    /// <summary>
    /// Interaction logic for EndScreen.xaml
    /// </summary>
    public partial class EndScreen : Window
    {
        private int prize;
        private int helpsUsed;

        public EndScreen(bool lost, int prize, int helpsUsed)
        {
            InitializeComponent();

            tbPrize.Text = PrizeListItem.FormatPrize(prize);
            tbHelps.Text = helpsUsed.ToString();

            this.prize = prize;
            this.helpsUsed = helpsUsed;
        }

        // Save the player's result
        private void btnSaveResult_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;

            if(name != "")
            {
                long timestamp = DateTime.Now.Ticks;
                ScoreEntry score = new ScoreEntry(name, prize, helpsUsed, timestamp);
                
                ScoreHandler.AddAndSaveScore(score);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("You didn't entered your name!");
            }
        }
    }
}
