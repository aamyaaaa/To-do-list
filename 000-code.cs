using System;


namespace DuplicateCode
{
    class DuplicateCode
    {

        static void Main(string[] args)
        {
            //defining arrays
            string[] tasksIndividual = new string[0], tasksWork = new string[0], tasksFamily = new string[0];

            while (true)
            {
                Console.Clear();

                //instead of using > signs, we can easily use max feature here
                int max = Math.Max(Math.Max(tasksIndividual.Length, tasksWork.Length), tasksFamily.Length);

                //instead of writing seperate code for each print, I have written it as a function which is called in the next line
                PrintCategoriesTable(max, tasksIndividual, tasksWork, tasksFamily);

                Console.WriteLine("\nWhich category do you want to place a new task? Type 'Personal', 'Work', or 'Family'");
                Console.Write(">> ");
                //we hace converted it to lower so that the code reads the text and compare even if it is in captial letters
                string listName = Console.ReadLine().ToLower();

                // Ask the user to describe the task
                Console.WriteLine("Describe your task below (max. 30 symbols).");
                Console.Write(">> ");
                string task = Console.ReadLine();
                if (task.Length > 30)
                {
                    //this means even if the person types somethign more than 30 charecters, the code will not stop raather it will pick first 30 characters
                    task = task.Substring(0, 30);
                }
                // Adding the task to the correct array based on the user's choice
                if (listName == "personal")
                {
                    tasksIndividual = AddTaskToArray(tasksIndividual, task);
                }
                else if (listName == "work")
                {
                    tasksWork = AddTaskToArray(tasksWork, task);
                }
                else if (listName == "family")
                {
                    tasksFamily = AddTaskToArray(tasksFamily, task);
                }
            }
        }


        //here we have created a function to print out the table on the console
        static void PrintCategoriesTable(int max, string[] tasksIndividual, string[] tasksWork, string[] tasksFamily)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(new string(' ', 12) + "CATEGORIES");
            Console.WriteLine(new string(' ', 10) + new string('-', 94));
            Console.WriteLine("{0,10}|{1,30}|{2,30}|{3,30}|", "item #", "Personal", "Work", "Family");
            Console.WriteLine(new string(' ', 10) + new string('-', 94));

            for (int i = 0; i < max; i++)
            {
                Console.Write("{0,10}|", i);

                if (i < tasksIndividual.Length)
                {
                    Console.Write("{0,30}|", tasksIndividual[i]);
                }
                else
                {
                    Console.Write("{0,30}|", "N/A");
                }

                if (i < tasksWork.Length)
                {
                    Console.Write("{0,30}|", tasksWork[i]);
                }
                else
                {
                    Console.Write("{0,30}|", "N/A");
                }

                if (i < tasksFamily.Length)
                {
                    Console.Write("{0,30}|", tasksFamily[i]);
                }
                else
                {
                    Console.Write("{0,30}|", "N/A");
                }

                Console.WriteLine();
            }

            Console.ResetColor();
        }

        //here we have created a functionallity to add the 
        static string[] AddTaskToArray(string[] array, string task)
        {
            string[] newArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }

            newArray[newArray.Length - 1] = task;

            return newArray;
        }
    }
}
