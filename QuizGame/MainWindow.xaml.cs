using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Net;
using System.Web;
using System.Net.Http;
using System;

namespace QuizGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<AnswerButton> answerButtons; // Store the answer buttons
        private List<QuestionData> questionList; // Store the questions
        private int currentQuestionIdx; // The index of the current question
        
        public MainWindow()
        {
            InitializeComponent();
            InitData();
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
            answerButtons = new List<AnswerButton>();
            questionList = new List<QuestionData>();
            currentQuestionIdx = 0;
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
                ansBtn.Margin = new Thickness(5);
                ansBtn.Click += AnswerButton_Click;

                answerStack.Children.Add(ansBtn);
                answerButtons.Add(ansBtn);
            }
        }

        // Called when one of the answer buttons are clicked
        private void AnswerButton_Click(object sender, RoutedEventArgs e)
        {
            string answer = (sender as AnswerButton).GetText();
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

            // For testing only
            Console.WriteLine(currentQuestion.Correct_answer);

            for(int idx = 0; idx < 4; idx++)
            {
                answerButtons[idx].SetData(currentQuestion.GetAnswers()[idx]);
            }
        }

        // Checks the selected answer
        private void CheckAnswer(string answer)
        {
            if(questionList[currentQuestionIdx].IsCorrect(answer))
            {
                currentQuestionIdx++;
                NextQuestion();
                prizeList.StepUp();
            }
            else
            {
                MessageBox.Show($"Wrong answer, end of the game!\nYour prize: {prizeList.GetPrize(true)}");
                // Show Endgame screen
                // Save result
            }
        }
    }
}
