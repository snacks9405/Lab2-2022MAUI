using System.Collections.Generic;

namespace Lab2_2022
{
    public interface IBusinessLogic
    {
        InvalidFieldError AddEntry(string clue, string answer, int difficulty, string date);
        EntryDeletionError DeleteEntry(int entryId);
        EntryEditError EditEntry(string clue, string answer, int difficulty, string date, int id);
        Entry FindEntry(int id);
        SortedDictionary<int, Entry> GetEntries();
    }
}