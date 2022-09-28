
using System.Collections.ObjectModel;
using System.Text.Json;

// https://www.dotnetperls.com/serialize-list
// https://www.daveoncsharp.com/2009/07/xml-serialization-of-collections/

/*
 * kept comments pretty brief as 99% of this is written by you! :)
 */
namespace Lab2_2022
{
    public class Database : IDatabase
    {
        readonly String filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "clues.txt");


        SortedDictionary<int, Entry> entries;
        JsonSerializerOptions options;
        ObservableCollection<Entry> observableEntries = new ObservableCollection<Entry>();

        /// <summary>
        /// constructor constructs
        /// </summary>
        public Database()
        {
            GetEntries();
            options = new JsonSerializerOptions { WriteIndented = true };
        }

        /// <summary>
        /// adds entry 
        /// </summary>
        /// <param name="entry"></param>
        public void AddEntry(Entry entry)
        {
            entries.Add(entry.Id, entry);
            CommitChanges();
        }

        /// <summary>
        /// gets the lowest unused ID from the dictionary
        /// </summary>
        /// <returns></returns>
        public int GetNextAvailableID()
        {
            if (entries == null)
            {
                return 1;
            }
            List<int> keys = new(entries.Keys);

            for (int i = 1; i <= keys.Count; i++)
            {
                if (i < keys[i - 1])
                {
                    return i;
                }
            }
            return (keys.Count == 0 ? 1 : keys.Count + 1);

        }

        /// <summary>
        /// finds entry by id number
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Entry FindEntry(int id)
        {
            if (entries.ContainsKey(id))
            {
                return entries[id];
            }
            return null;
        }

        /// <summary>
        /// Deletes an entry 
        /// </summary>
        /// 
        /// <param name="entry">An entry, which is presumed to exist</param>
        public bool DeleteEntry(Entry entry)
        {

            var result = entries.Remove(entry.Id);
            return CommitChanges();

        }

        /// <summary>
        /// modifies an existing entry
        /// </summary>
        /// <param name="replacementEntry"></param>
        /// <returns></returns>
        public bool ReplaceEntry(Entry replacementEntry)
        {
            Entry entry = entries[replacementEntry.Id];

            entry.Answer = replacementEntry.Answer;
            entry.Clue = replacementEntry.Clue;
            entry.Difficulty = replacementEntry.Difficulty;
            entry.Date = replacementEntry.Date;

            return CommitChanges();
        }

        /// <summary>
        /// initializes the database from the flat db
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Entry> GetEntries()
        {
            observableEntries = new ObservableCollection<Entry>();
            if (!File.Exists(filename))
            {
                File.CreateText(filename);
                entries = new SortedDictionary<int, Entry>();
                return observableEntries;
            }


            string jsonString = File.ReadAllText(filename);
            if (jsonString.Length > 0)
            {
                entries = JsonSerializer.Deserialize<SortedDictionary<int, Entry>>(jsonString);
                observableEntries = new ObservableCollection<Entry>();
                foreach (KeyValuePair<int, Entry> pair in entries)
                {
                    observableEntries.Add(pair.Value);
                }
            }
            else { entries = new SortedDictionary<int, Entry>(); }

            return observableEntries;
        }

        /// <summary>
        /// saves changes to entries and confirms observable is maintaining an accurate collection
        /// </summary>
        /// <returns></returns>
        private bool CommitChanges()
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(entries, options);
                File.WriteAllText(filename, jsonString);
                observableEntries = new ObservableCollection<Entry>();
                foreach (KeyValuePair<int, Entry> pair in entries)
                {
                    observableEntries.Add(pair.Value);
                }
                return true;
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Error while replacing entry: {0}", ioe);
            }
            return false;
        }

    }
}
