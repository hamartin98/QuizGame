using System;

namespace QuizGame
{
    class ScoreEntry
    {
        public int Id { get; set; } // Entries id
        public string Name { get; set; } // Player's name
        public string Prize { get; set; } // Prize won
        public int Helps { get; set; } // Helps used
        public long timestamp { get; set; } // Timestamp of the winning

        // Convert the timestamp to a readable string format and return it
        public string Date 
        {   
            get
            {
                DateTime dateTime = new DateTime(timestamp);
                return dateTime.ToString();
            }
        }

        public ScoreEntry()
        {

        }

        public ScoreEntry(string name, string prize, int helps, long timestamp)
        {
            this.Name = name;
            this.Prize = prize;
            this.Helps = helps;
            this.timestamp = timestamp;
        }
    }
}
