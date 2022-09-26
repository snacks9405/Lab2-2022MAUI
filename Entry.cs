using System;
namespace Lab2_2022
{
    [Serializable()]
    public class Entry : IEquatable<Entry>
    {
        public String Clue { get; set; }
        public String Answer { get; set; }
        public int Difficulty { get; set; }
        public String Date { get; set; }
        public int Id { get; set; }

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
