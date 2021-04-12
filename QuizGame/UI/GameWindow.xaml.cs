using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System;


namespace QuizGame
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private List<AnswerButton> answerButtons; // Store the answer buttons
        private List<QuestionData> questionList; // Store the questions
        private int currentQuestionIdx; // The index of the current question
        QuestionData currentQuestion; // Store the current question
        private int helpsUsed = 0;

        public GameWindow()
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
            IsEnabled = true;
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
        private void NextQuestion(bool bonusQuestion = false)
        {
            currentQuestion = questionList[currentQuestionIdx];
            string indexText = (currentQuestionIdx + 1).ToString() + ".";
            
            if (bonusQuestion)
            {
                currentQuestion = questionList[12];
                indexText = "Bonus";
            }

            tbIndex.Text = indexText;
            currentQuestion.DecodeData(); // need to decode data before usage
            lblQuestion.Text = currentQuestion.Question;

            tbDifficulty.Text = currentQuestion.Difficulty;
            tbCategory.Text = currentQuestion.Category;

            for (int idx = 0; idx < 4; idx++)
            {
                answerButtons[idx].SetData(currentQuestion.GetAnswers()[idx]);
            }
        }

        // Checks the selected answer
        private void CheckAnswer(string answer)
        {
            if (currentQuestion.IsCorrect(answer))
            {
                prizeList.StepUp();
                currentQuestionIdx++;
                if (currentQuestionIdx == 12)
                {
                    EndGame(false);
                    return;
                }

                NextQuestion();
            }
            else
            {
                int correctIdx = currentQuestion.GetCorrectIdx();
                answerButtons[correctIdx].ChangeState(AnswerButton.State.CORRECT);

                MessageBox.Show($"Wrong answer, end of the game!\nYour prize: {prizeList.GetPrize(true)}");
                EndGame(true);
            }
        }

        // Called when the game ends
        // The game ends when the player take the current prize or lose
        private void EndGame(bool lost)
        {
            int prize = prizeList.GetPrize(lost);
            //string prizeStr = PrizeListItem.FormatPrize(prize);

            EndScreen endScreen = new EndScreen(lost, prize, helpsUsed);
            endScreen.Show();
            Close();
        }

        // Hides two of the wrong answers
        // Remove indexes from the indexes list that will be visible
        private void btnHalf_Click(object sender, RoutedEventArgs e)
        {
            int correctIndex = currentQuestion.GetCorrectIdx();
            List<int> indexes = new List<int>() { 0, 1, 2, 3 };
            Random rnd = new Random();
            int idxToRemove = rnd.Next(0, 3); // remove one index randomly from the list

            indexes.Remove(correctIndex);
            indexes.Remove(idxToRemove);

            foreach (int idx in indexes)
            {
                answerButtons[idx].Visibility = Visibility.Hidden;
            }

            helpsUsed++;
            btnHalf.IsEnabled = false;
        }

        // Show the correct answer
        private void btnShowCorrect_Click(object sender, RoutedEventArgs e)
        {
            int correctIndex = currentQuestion.GetCorrectIdx();
            answerButtons[correctIndex].ChangeState(AnswerButton.State.CORRECT);
            helpsUsed++;
            btnShowCorrect.IsEnabled = false;
        }

        // Get a new question
        private void btnGetNewQuestion_Click(object sender, RoutedEventArgs e)
        {
            NextQuestion(true);
            helpsUsed++;
            btnGetNewQuestion.IsEnabled = false;
        }

        // Take the money and leave the game
        private void btnTakeMoney_Click(object sender, RoutedEventArgs e)
        {
            EndGame(false);
            btnTakeMoney.IsEnabled = false;
        }
    }
}
