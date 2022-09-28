using System;
using CommunityToolkit.Mvvm.ComponentModel;
namespace Lab2_2022
{
    [Serializable()]
    public class Entry : ObservableObject
    {
        String clue;
        String answer;
        int difficulty;
        String date;
        int id;

        // Sets the properties for clue, answer, difficulty, date, id
        public String Clue { get { return clue; } set { SetProperty(ref clue, value); } }
        public String Answer { get { return answer; } set { SetProperty(ref answer, value); } }
        public int Difficulty { get { return difficulty; } set { SetProperty(ref difficulty, value); } }
        public String Date { get { return date; } set { SetProperty(ref date, value); } }
        public int Id { get { return id; } set { SetProperty(ref id, value); } }

        /**
         * Constructor for entries
         * 
         */

        public Entry(String clue, String answer, int difficulty, String date, int id)
        {
            this.Clue = clue;
            this.Answer = answer;
            this.Difficulty = difficulty;
            this.Date = date;
            this.Id = id;
        }

        public bool Equals(Entry other)
        {
            return Id == other.Id;
        }
    }
}
