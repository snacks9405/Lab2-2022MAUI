using System.Collections.Generic;

namespace Lab2_2022
{
    public interface IDatabase
    {
        void AddEntry(Entry entry);
        bool DeleteEntry(Entry entry);
        Entry FindEntry(int id);
        SortedDictionary<int, Entry> GetEntries();
        int GetNextAvailableID();
        bool ReplaceEntry(Entry replacementEntry);
    }
}