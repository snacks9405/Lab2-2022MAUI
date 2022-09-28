using System.Collections.ObjectModel;

namespace Lab2_2022
{
    public interface IDatabase
    {
        void AddEntry(Entry entry);
        bool DeleteEntry(Entry entry);
        Entry FindEntry(int id);
        ObservableCollection<Entry> GetEntries();
        int GetNextAvailableID();
        bool ReplaceEntry(Entry replacementEntry);
    }
}