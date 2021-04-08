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
        private List<int> prizeList; // Store the list of prizes
        private List<AnswerButton> answerButtons; // Store the answer buttons
        private List<Question> questionList; // Store the questions
        private int currentQuestionIdx; // The index of the current question

        public MainWindow()
        {
            InitializeComponent();
            InitData();
            InitPrizeList();
            InitAnswerButtons();
        }

        // Initialize member variables at the start
        private void InitData()
        {
            prizeList = new List<int>();
            answerButtons = new List<AnswerButton>();
            questionList = new List<Question>();
            currentQuestionIdx = 0;
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

        // Initialize and add the answer buttons to the ui and store them in the answerButtons list
        private void InitAnswerButtons()
        {
            AnswerButton ansBtn;
            string labelText;

            for (int idx = 0; idx < 4; idx++)
            {
                labelText = ((char)(65 + idx)).ToString(); // Ascii A is 65
                ansBtn = new AnswerButton(labelText);
                ansBtn.Margin = new Thickness(10);
                ansBtn.Click += AnswerButton_Click;

                Grid.SetColumn(ansBtn, idx % 2);
                Grid.SetRow(ansBtn, idx / 2);
                
                answerGrid.Children.Add(ansBtn);
                answerButtons.Add(ansBtn);
            }
        }

        // Called when one of the answer buttons are clicked
        private void AnswerButton_Click(object sender, RoutedEventArgs e)
        {
            string answer = (sender as AnswerButton).GetText();
            MessageBox.Show(answer);
        }
    }
}
