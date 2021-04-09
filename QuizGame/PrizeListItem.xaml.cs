using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuizGame
{
    /// <summary>
    /// Interaction logic for PrizeListItem.xaml
    /// </summary>
    public partial class PrizeListItem : UserControl
    {
        public int Prize { get; } // Amount of the prize
        public bool IsFixed { get; } = false; // If it's true, the player wins this money if once it's reached

        public enum State { DEFAULT, REACHED }
        private State state;

        public PrizeListItem(int index, int prize, bool isFixed)
        {
            InitializeComponent();

            Prize = prize;
            this.IsFixed = isFixed;
            state = State.DEFAULT;
            SetUiData(index);
        }

        // Sets the values on the UI
        private void SetUiData(int index)
        {
            if(IsFixed)
            {
                Foreground = Brushes.White;
            }
            tbIndex.Text = $"{index}.";
            tbPrize.Text = FormatPrize(Prize);
        }

        // Change the state of the current prizeList item
        public void ChangeStateToReached()
        {
            this.state = State.REACHED;
            UpdateUI();
        }

        // Update the UI based on the stated
        private void UpdateUI()
        {
            if(state == State.REACHED)
            {
                rectReached.Visibility = Visibility.Visible;
            }
        }

        // Format the prize the return as a string
        public static string FormatPrize(int prize)
        {
            decimal prizeAsDecimal = Convert.ToDecimal(prize);
            return prizeAsDecimal.ToString("C1", CultureInfo.CreateSpecificCulture("en-Us"));
        }
    }
}
