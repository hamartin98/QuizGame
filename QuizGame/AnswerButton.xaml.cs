using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Threading;

namespace QuizGame
{
    /// <summary>
    /// Interaction logic for AnswerButton.xaml
    /// </summary>
    public partial class AnswerButton : UserControl
    {
        public event RoutedEventHandler Click;

        public enum State { SELECTED, CORRECT, INCORRECT }

        // Create the answer button with the given label
        public AnswerButton(string label)
        {
            InitializeComponent();
            tbLabel.Text = label;
        }

        // Sets the text of the answer button
        public void SetData(string text)
        {
            border.BorderThickness = new Thickness(0);
            tbText.Text = text;
        }

        // Occurs when the button is clicked
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(this.Click != null)
            {
                ChangeState(State.SELECTED);
                this.Click(this, e);
            }
        }

        // Returns the current text of the button
        public string GetText()
        {
            return tbText.Text;
        }

        // Change the state of the current answer button
        public void ChangeState(State state)
        {
            Brush color = Brushes.Transparent;

            switch(state)
            {
                case State.SELECTED:
                    color = Brushes.Yellow;
                    break;

                case State.CORRECT:
                    color = Brushes.Green;
                    break;

                case State.INCORRECT:
                    color = Brushes.Red;
                    break;
            }

            ChangeBorderColor(color);
        }

        // Sets the color of the border
        private void ChangeBorderColor(Brush color)
        {
            border.BorderThickness = new Thickness(2);
            border.BorderBrush = color;
        }
    }
}
