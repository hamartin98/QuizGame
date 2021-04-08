using System;
using System.Collections.Generic;

namespace QuizGame
{
    class QuestionData
    {
        public string Category { get; set; }
        public string Difficulty { get; set; }
        public string Question { get; set; }
        public string Correct_answer { get; set; }
        public List<string> Incorrect_answers { get; set; }

        // Returns the correct answer to the question
        public string GetCorrectAnswer()
        {
            return Correct_answer;
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
                    result.Add(Incorrect_answers[idx]);
                }
                else
                {
                    result.Add(Correct_answer);
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
            return $"{Question}, Correct answer: {Correct_answer}\nIncorrect answers: {Incorrect_answers[0]}\n {Incorrect_answers[1]}\n {Incorrect_answers[2]}";
        }
    }
}
