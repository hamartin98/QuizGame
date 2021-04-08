using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuizGame
{
    class QuestionHandler
    {
        private List<QuestionData> questions;

        // Returns 12 questions used in the game
        // We need 4 question from each of the 3 difficulty
        // The questions will be ordered by difficulty from easy to hard
        public async Task<List<QuestionData>> GetQuestionList()
        {
            ApiHelper.InitializeClient();
            questions =  new List<QuestionData>();

            await LoadQuestions("easy", 4);
            await LoadQuestions("medium", 4);
            await LoadQuestions("hard", 4);
            
            return this.questions;
        }

        // Gets questions with the specified difficulty
        public async Task LoadQuestions(string difficulty, int amount)
        {
            string url = $"https://opentdb.com/api.php?amount={ amount }&difficulty={ difficulty }&type=multiple";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if(response.IsSuccessStatusCode)
                {
                    QuestionListModel questionList = await response.Content.ReadAsAsync<QuestionListModel>();
                    questions.AddRange(questionList.Results);
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
