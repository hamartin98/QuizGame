using System;
using System.Collections.Generic;
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
    /// Interaction logic for PrizeListControl.xaml
    /// </summary>
    public partial class PrizeListControl : UserControl
    {
        private List<int> prizeList;
        private int currentStep = -1;
        private int fixedPrize = 0;
        private List<PrizeListItem> prizeListItems;

        public PrizeListControl()
        {
            InitializeComponent();
            AddListItems();
        }

        private void InitPrizeList()
        {
            prizeList = new List<int>();

            prizeList.Add(500);
            prizeList.Add(1000);
            prizeList.Add(2000);
            prizeList.Add(5000); // new fixed prize
            prizeList.Add(10000);
            prizeList.Add(20000);
            prizeList.Add(50000);
            prizeList.Add(75000); // new fixed prize
            prizeList.Add(150000);
            prizeList.Add(250000);
            prizeList.Add(500000);
            prizeList.Add(1000000); // fixed prize
        }

        private void AddListItems()
        {
            InitPrizeList();

            prizeListItems = new List<PrizeListItem>();
            PrizeListItem prizeListItem;
            bool isFixed = false;

            for (int idx = 0; idx < prizeList.Count; idx++)
            {
                isFixed = (idx == 3 || idx == 7 || idx == 11) ? true : false;
                prizeListItem = new PrizeListItem(idx + 1, prizeList[idx], isFixed);
                prizePanel.Children.Add(prizeListItem);
                prizeListItems.Add(prizeListItem);
            }
        }
        
        // Step to the next prize
        public void StepUp()
        {
            currentStep++;

            if(currentStep == 3 || currentStep == 7 || currentStep == 11)
            {
                fixedPrize = prizeList[currentStep];
            }

            prizeListItems[currentStep].ChangeStateToReached();
        }

        // Returns the prize of the player based on the criteria
        // If the player lost, returns the last fixed value, otherwise the player stopped and gets the prize
        public int GetPrize(bool lost)
        {
            if(!lost)
            {
                return prizeList[currentStep];
            }

            return fixedPrize;
        }
    }
}
