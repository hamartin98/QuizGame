using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace QuizGame
{
    class QuestionData
    {
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("difficulty")]
        public string Difficulty { get; set; }
        [JsonProperty("question")]
        public string Question { get; set; }
        [JsonProperty("correct_answer")]
        public string CorrectAnswer { get; set; }
        [JsonProperty("incorrect_answers")]
        public List<string> IncorrectAnswers { get; set; }

        // Returns the correct answer to the question
        public string GetCorrectAnswer()
        {
            return CorrectAnswer;
        }

        // Return the list of answers in random order, including the correct one
        public List<string> GetAnswers()
        {
            List<string> result = new List<string>();
            HashSet<int> randomIndexes = GetRandomIndexOrder(4); // a hashset with values 0-3 randomly

            // we add the questions from the incorrect answers based on their indexes, and add the correct answer if the value is 3
            foreach (int idx in randomIndexes)
            {
                if(idx != 3)
                {
                    result.Add(IncorrectAnswers[idx]);
                }
                else
                {
                    result.Add(CorrectAnswer);
                }
            }

            return result;
        }

        // returns a set of distinct indexes between 0 and the given count
        // e.g.: count = 4, result: 2 0 3 1
        private HashSet<int> GetRandomIndexOrder(int count)
        {
            Random rnd = new Random();
            HashSet<int> result = new HashSet<int>();
            
            do
            {
                result.Add(rnd.Next(0, count));
            }
            while (count != result.Count);

            return result;
        }

        // Returns the question and the answers as a string
        public override string ToString()
        {
            string result = $"{Question}, Correct answer: {CorrectAnswer}\n";

            for (int idx = 0; idx < IncorrectAnswers.Count; idx++)
            {
                result += IncorrectAnswers[idx] + "\n";
            }

            return result;
        }

        // Some data are in html encoding, so it's necessary to decode it
        public void DecodeData()
        {
            Question = WebUtility.HtmlDecode(Question);
            CorrectAnswer = WebUtility.HtmlDecode(CorrectAnswer);
            
            for(int idx = 0; idx < IncorrectAnswers.Count; idx++)
            {
                IncorrectAnswers[idx] = WebUtility.HtmlDecode(IncorrectAnswers[idx]);
            }
        }

        // Returns true if the given answer is correct
        public bool IsCorrect(string answer)
        {
            return answer == CorrectAnswer;
        }
    }
}
