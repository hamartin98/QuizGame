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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> prizeList;

        public MainWindow()
        {
            InitializeComponent();
            InitData();
            InitPrizeList();
        }

        // Initialize global variables at the start
        private void InitData()
        {
            prizeList = new List<int>();
        }

        // Initialize the list of prizes with values
        // sets the itemsource for the prize list
        private void InitPrizeList()
        {
            prizeList.Add(500);
            prizeList.Add(1000);
            prizeList.Add(2000); // fixed prize
            prizeList.Add(5000);
            prizeList.Add(10000);
            prizeList.Add(20000);
            prizeList.Add(50000); // fixed prize
            prizeList.Add(75000);
            prizeList.Add(150000);
            prizeList.Add(250000);
            prizeList.Add(500000);
            prizeList.Add(1000000); // fixed prize

            lbPrizes.ItemsSource = prizeList;
        }
    }
}
