using System.Windows;
using System.Windows.Controls;

namespace QuizGame
{
    /// <summary>
    /// Interaction logic for AnswerButton.xaml
    /// </summary>
    public partial class AnswerButton : UserControl
    {
        public event RoutedEventHandler Click;

        // Create the answer button with the given label
        public AnswerButton(string label)
        {
            InitializeComponent();
            tbLabel.Text = label;
        }

        // Sets the text of the answer button
        public void SetData(string text)
        {
            tbText.Text = text;
        }

        // Occurs when the button is clicked
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(this.Click != null)
            {
                this.Click(this, e);
            }
        }

        // Returns the current text of the button
        public string GetText()
        {
            return tbText.Text;
        }
    }
}
