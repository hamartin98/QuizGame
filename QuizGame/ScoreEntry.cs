﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    class ScoreEntry
    {
        public int Id { get; set; } // Entries id
        public string Name { get; set; } // Player's name
        public string Prize { get; set; } // Prize won
        public int Helps { get; set; } // Helps used
        public long timestamp { get; set; } // Timestamp of the winning

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
