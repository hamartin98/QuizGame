using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Net;
using System.Web;
using System.Net.Http;

namespace QuizGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<int> prizeList; // Store the list of prizes
        private List<AnswerButton> answerButtons; // Store the answer buttons
        private List<QuestionData> questionList; // Store the questions
        private int currentQuestionIdx; // The index of the current question

        public MainWindow()
        {
            InitializeComponent();
            InitData();
            InitPrizeList();
            InitAnswerButtons();
        }

        // Load the questions after the Window is loaded
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await GetQuestionsAsync();
            NextQuestion();
        }

        // Initialize member variables at the start
        private void InitData()
        {
            prizeList = new List<int>();
            answerButtons = new List<AnswerButton>();
            questionList = new List<QuestionData>();
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

                answerStack.Children.Add(ansBtn);
                answerButtons.Add(ansBtn);
            }
        }

        // Called when one of the answer buttons are clicked
        private void AnswerButton_Click(object sender, RoutedEventArgs e)
        {
            string answer = (sender as AnswerButton).GetText();
            MessageBox.Show(answer);
            CheckAnswer(answer);
        }

        // Gets the list of the questions required for the game
        private async Task GetQuestionsAsync()
        {
            QuestionHandler questionHandler = new QuestionHandler();
            questionList = await questionHandler.GetQuestionList();
        }

        // Sets the question and answers based on the currentQuestionIdx
        private void NextQuestion()
        {
            QuestionData currentQuestion = questionList[currentQuestionIdx];
            currentQuestion.DecodeData(); // need to decode data before usage
            lblQuestion.Text = currentQuestion.Question;

            for(int idx = 0; idx < 4; idx++)
            {
                answerButtons[idx].SetData(currentQuestion.GetAnswers()[idx]);
            }
        }

        // Checks the selected answer
        private void CheckAnswer(string answer)
        {
            MessageBox.Show(questionList[currentQuestionIdx].ToString());

            if(questionList[currentQuestionIdx].IsCorrect(answer))
            {
                MessageBox.Show("Correct answer!");
                currentQuestionIdx++;
                NextQuestion();
                // Step on the prize list
            }
            else
            {
                MessageBox.Show("Wrong answer, end of the game!");
                // End of the game
                // If there is a fix prize, the player gets it
                // Save result
            }
        }
    }
}
