using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lab2_2022
{
    /**
     * Enums for invalid Add,delete,edit
     */
    public enum InvalidFieldError
    {
        InvalidClueLength,
        InvalidAnswerLength,
        InvalidDifficulty,
        InvalidDate,
        NoError
    }

    public enum EntryDeletionError
    {
        EntryNotFound,
        DBDeletionError,
        NoError
    }

    public enum EntryEditError
    {
        EntryNotFound,
        InvalidFieldError,
        DBEditError,
        NoError
    }
    /**
     * Class for business logic 
     * handles invalid entries
     */
    public class BusinessLogic : IBusinessLogic
    {
        const int MAX_CLUE_LENGTH = 250;
        const int MAX_ANSWER_LENGTH = 21;
        const int MAX_DIFFICULTY = 3;

        IDatabase db;

        /**
         * Constructor for Business Logic
         */
        public BusinessLogic()
        {
            db = new Database();
        }

        /**
         * retunrs the list of Entries
         */

        public ObservableCollection<Entry> GetEntries()
        {
            return db.GetEntries();
        }

        /**
         * Finds a specific entry to using an id
         */
        public Entry FindEntry(int id)
        {
            return db.FindEntry(id);
        }

        /**
         * Finds checks each entry field: clue, answer, difficulty, date
         *                      
         */
        private InvalidFieldError CheckEntryFields(string clue, string answer, int difficulty, string date)
        {
            if (clue == null || clue.Length < 1 || clue.Length > MAX_CLUE_LENGTH)
            {
                return InvalidFieldError.InvalidClueLength;
            }
            if (answer == null || answer.Length < 1 || answer.Length > MAX_ANSWER_LENGTH)
            {
                return InvalidFieldError.InvalidAnswerLength;
            }
            if (difficulty < 1 || difficulty > MAX_DIFFICULTY)
            {
                return InvalidFieldError.InvalidDifficulty;
            }
            if (date == null)
            {
                return InvalidFieldError.InvalidDate;
            }

            return InvalidFieldError.NoError;
        }

        /**
         * Invalid AddEntry checks
         */

        public InvalidFieldError AddEntry(string clue, string answer, int difficulty, string date)
        {

            var result = CheckEntryFields(clue, answer, difficulty, date);      //checks if an error was found
            if (result != InvalidFieldError.NoError)
            {

                return result;
            }
            
            Entry entry = new Entry(clue, answer, difficulty, date, db.GetNextAvailableID());
            db.AddEntry(entry);

            return InvalidFieldError.NoError;
        }

        /**
         * Invalid DeleteEntry checks

         */

        public EntryDeletionError DeleteEntry(int entryId)
        {

            var entry = db.FindEntry(entryId);      

            if (entry != null)                          //checks if entry is not null
            {
                bool success = db.DeleteEntry(entry);
                if (success)
                {
                    return EntryDeletionError.NoError;

                }
                else
                {
                    return EntryDeletionError.DBDeletionError;
                }
            }
            else
            {
                return EntryDeletionError.EntryNotFound;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clue"></param>
        /// <param name="answer"></param>
        /// <param name="difficulty"></param>
        /// <param name="date"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public EntryEditError EditEntry(string clue, string answer, int difficulty, string date, int id)
        {

            var fieldCheck = CheckEntryFields(clue, answer, difficulty, date);
            if (fieldCheck != InvalidFieldError.NoError)
            {
                return EntryEditError.InvalidFieldError;
            }

            var entry = db.FindEntry(id);
            entry.Clue = clue;
            entry.Answer = answer;
            entry.Difficulty = difficulty;
            entry.Date = date;

            bool success = db.ReplaceEntry(entry);
            if (!success)
            {
                return EntryEditError.DBEditError;
            }

            return EntryEditError.NoError;
        }
    }


}
