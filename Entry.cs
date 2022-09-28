using CommunityToolkit.Mvvm.ComponentModel;
namespace Lab2_2022
/*
 * this one is mostly the same, just added that observable guff I still don't fully understand
 */
{
    [Serializable()]
    public class Entry : ObservableObject
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
