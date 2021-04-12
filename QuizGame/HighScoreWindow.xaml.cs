using System.Collections.Generic;
using System.Windows;

namespace QuizGame
{
    /// <summary>
    /// Interaction logic for HighScoreWindow.xaml
    /// </summary>
    public partial class HighScoreWindow : Window
    {
        private List<ScoreEntry> scores = new List<ScoreEntry>();

        public HighScoreWindow()
        {
            InitializeComponent();
            GetScores();
            lbScores.ItemsSource = scores;
        }

        // Load the scores from the database into the scores list
        private void GetScores()
        {
            scores = ScoreHandler.LoadScores();
        }

        // Show the MainWindow Window
        private void btnBackToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
