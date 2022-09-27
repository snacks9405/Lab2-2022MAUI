using System;
using System.Collections.Generic;

namespace Lab2_2022
{
    public class UserInterface
    {
        IBusinessLogic bl;

        public UserInterface(BusinessLogic bl)
        {
            this.bl = bl;
        }


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


        private void DeleteEntry()
        {

            int id = GetValidId("delete");
            EntryDeletionError result = bl.DeleteEntry(id);
            if (result != EntryDeletionError.NoError)
            {
                Console.WriteLine("Error while deleting entry: {0}", result);
            }
        }

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
