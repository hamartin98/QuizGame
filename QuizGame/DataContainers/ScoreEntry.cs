using System;

namespace QuizGame
{
    class ScoreEntry
    {
        public int Id { get; set; } // Entries id
        public string Name { get; set; } // Player's name
        public int Prize { get; set; } // Prize won
        public int Helps { get; set; } // Helps used
        public long Timestamp { get; set; } // Timestamp of the winning

        // Convert the timestamp to a readable string format and return it
        public string Date
        {
            get
            {
                DateTime dateTime = new DateTime(Timestamp);
                return dateTime.ToString();
            }
        }

        public string Money
        {
            get
            {
                return PrizeListItem.FormatPrize(Prize);
            }
        }

        public ScoreEntry()
        {

        }

        public ScoreEntry(string name, int prize, int helps, long timestamp)
        {
            this.Name = name;
            this.Prize = prize;
            this.Helps = helps;
            this.Timestamp = timestamp;
        }
    }
}
