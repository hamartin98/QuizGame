using System.Windows;

namespace QuizGame
{
    /// <summary>
    /// Interaction logic for EndScreen.xaml
    /// </summary>
    public partial class EndScreen : Window
    {
        public EndScreen(bool lost, string prize, int helpsUsed)
        {
            InitializeComponent();

            tbPrize.Text = prize;
            tbHelps.Text = helpsUsed.ToString();
        }
    }
}
