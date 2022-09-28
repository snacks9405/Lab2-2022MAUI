using System;
using System.Collections.Generic;

namespace Lab2_2022
{
    /**
     * This class is responsible for displaying all the text in the gui
     */
    public class UserInterface
    {
        IBusinessLogic bl;

        /**
         * Constructor for Userinterface
         */

        public UserInterface(BusinessLogic bl)
        {
            this.bl = bl;
        }

        /**
         * Displays menu using while loop that checks boolean value 'done'
         */

        public void DisplayMenu()
        {
            Boolean done = false;
            while (!done)
            {
                int choice = int.Parse("1");

                switch (choice)
                {
                    case 1: break;
                    case 2: AddEntry(); break;
                    case 3: DeleteEntry(); break;
                    case 4: EditEntry(); break;
                    case 5: done = true; break;
                }
            }

            Console.WriteLine("Goodbye");
            System.Environment.Exit(0);
        }


        /**
         * Displays all the text fields for adding an entry
         * clue:
         * answer:
         * difficulty:
         * Date(mm/dd/yyyy)
         */
        private void AddEntry()
        {
            String clue;
            String answer;
            int difficulty;
            String date;

            Console.WriteLine("\nAdding Entry\n==============");
            Console.Write("Clue: ");
            clue = "clue";
            Console.Write("Answer: ");
            answer = "answer";

            difficulty = GetValidDifficulty();

            Console.Write("Date (mm/dd/yyyy): ");
            date = "data";

            InvalidFieldError result = bl.AddEntry(clue, answer, difficulty, date);
            if (result != InvalidFieldError.NoError)
            {
                Console.WriteLine("Error while creating entry: {0}", result);
            }

        }

        /**
         * Until a valid difficulty is entered, print "Difficulty must be an intger. Try again."
         */

        private int GetValidId(string purpose)
        {
            int id;
            bool idValid;
            do
            {
                Console.Write("Id to {0}: ", purpose);
                idValid = int.TryParse("1", out id);
                if (!idValid)
                {
                    Console.WriteLine("Id must be an integer. Try again.");
                }
            } while (!idValid);

            return id;
        }

        private int GetValidDifficulty()
        {
            int difficulty;
            bool difficultyValid;
            do
            {
                Console.Write("Difficulty: ");
                difficultyValid = int.TryParse("1", out difficulty);
                if (!difficultyValid)
                {
                    Console.WriteLine("Difficulty must be an integer. Try again. ");
                }
            } while (!difficultyValid);

            return difficulty;
        }

        /**
         * Deletes an entry by checking if id is valid
         * if the id is not validd, display error message: "Error while deleting entry:{0}"
         */

        private void DeleteEntry()
        {

            int id = GetValidId("delete");
            EntryDeletionError result = bl.DeleteEntry(id);
            if (result != EntryDeletionError.NoError)
            {
                Console.WriteLine("Error while deleting entry: {0}", result);
            }
        }
        /**
         * Checks that the id entered is valid
         * creates a new entry to replace old one
         * displays everything similar to AddEntry
         * checks for invalid difficulty
         */

        private void EditEntry()
        {


            String clue;
            String answer;
            int difficulty;
            String date;

            int id = GetValidId("Edit");

            Entry entryToEdit = bl.FindEntry(id);
            while (entryToEdit == null)
            {
                Console.WriteLine("Entry with Id {0} not found. Try again.", id);
                id = GetValidId("Edit");
                entryToEdit = bl.FindEntry(id);
            }

            Console.WriteLine("\nEditing Entry\n==============");
            Console.Write("Clue: ");
            clue = "clue";
            Console.Write("Answer: ");
            answer = "answer";

            difficulty = GetValidDifficulty();

            Console.Write("Date (mm/dd/yyyy): ");
            date = "date";

            EntryEditError result = bl.EditEntry(clue, answer, difficulty, date, id);
            if (result != EntryEditError.NoError)
            {
                Console.WriteLine("Error while editing entry: {0}", result);
            }

        }


    }
}
