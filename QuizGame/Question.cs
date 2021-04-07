using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    class Question
    {
        private int id;
        private string difficulty;
        public string Category { get; }
        public string question { get; }

        private List<string> incorrectAnswers;
        private string correctAnswer;

        // Basic constructor to initialize question data
        public Question(int id, string difficulty, string category, string question, List<string> incorrectAnswers, string correctAnswer)
        {
            this.id = id;
            this.difficulty = difficulty;
            this.Category = category;
            this.question = question;
            this.incorrectAnswers = incorrectAnswers;
            this.correctAnswer = correctAnswer;
        }

        // Constructor only for test purposes
        public Question(string question, List<string> incorrectAnswers, string correctAnswer)
        {
            this.question = question;
            this.incorrectAnswers = incorrectAnswers;
            this.correctAnswer = correctAnswer;
        }

        // Returns the correct answer to the question
        public string GetCorrectAnswer()
        {
            return correctAnswer;
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
                    result.Add(incorrectAnswers[idx]);
                }
                else
                {
                    result.Add(correctAnswer);
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
            return $"{question}, Correct answer: {correctAnswer}\nIncorrect answers: {incorrectAnswers[0]}\n {incorrectAnswers[1]}\n {incorrectAnswers[2]}";
        }
    }
}
