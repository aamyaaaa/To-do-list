using System.Xml.Linq;

namespace z
{
    class DuplicateCode
    {
        public static List<Category> categories = new List<Category>();

        public static void Addcat()
        {
        z:
            Console.WriteLine("What category do you want to add?");
            string catname = Console.ReadLine();
            if (catname == null)
            {
                Console.WriteLine("Error! Try Again");
                goto z;
            }
            var category = new Category(catname);
            categories.Add(category);
        }

        public static void RemoveCategory()
        {

            Console.WriteLine("What category do you want to remove?");
            string catname = Console.ReadLine().ToLower();
            foreach (Category category in categories)
            {
                if (category.Name == catname)
                {
                    categories.Remove(category);
                }
                else
                {
                    Console.WriteLine("Category not found");
                }
            }
        }

        public static void AddTask()
        {

            Console.WriteLine("What category do you want to put your task in?");
            string catname = Console.ReadLine().ToLower();
            foreach (Category category in categories)
            {
                if (category.Name == catname)
                {
                    Console.WriteLine("Enter task name:");
                    string T = Console.ReadLine();
                abc:
                    Console.WriteLine("Enter task due date in the format of DD-Month-YYYY");
                    try
                    {
                        DateTime dueDate = DateTime.Parse(Console.ReadLine());
                        category.AddTask(T, dueDate);
                    }
                    catch
                    {
                        Console.WriteLine("Invalid format");
                        goto abc;
                    }

                }
                else
                {
                    Console.WriteLine("Category not found");
                }

            }

        }

        public static void DelTask()
        {

            Console.WriteLine("What category do you want to delete your task in?");
            string catname = Console.ReadLine().ToLower();
            foreach (Category category in categories)
            {
                if (category.Name == catname)
                {
                    Console.WriteLine("Enter task name:");
                    string taskName = Console.ReadLine();
                    category.DeleteTask(taskName);
                    Console.WriteLine("Task deleted successfully.");

                }
                else
                {
                    Console.WriteLine("Category not found");
                }

            }

        }



        public static void Completed()
        {
            Console.WriteLine("Well Done on your achievement");
            Console.WriteLine("What category does your completed task belong to?");
            string catname = Console.ReadLine().ToLower();
            foreach (Category category in categories)
            {
                if (category.Name == catname)
                {
                    Console.WriteLine("Enter task name:");
                    string taskName = Console.ReadLine();
                    category.DeleteTask(taskName);
                    Console.WriteLine("Task deleted successfully.");

                }
                else
                {
                    Console.WriteLine("Category not found");
                }

            }

        }


        public static void Important()
        {

            Console.WriteLine("which category does the important task belong to?");
            string catname = Console.ReadLine().ToLower();
            bool catFound = false;
            foreach (Category category in categories)
            {
                if (category.Name == catname)
                {
                    catFound = true;
                    Console.WriteLine("Enter task name:");
                    string ImpTask = Console.ReadLine();

                    bool found = false;
                    foreach (var task in category.Tasks)
                    {
                        if (task.Name.ToLower() == ImpTask.ToLower())
                        {
                            found = true;
                            task.Priority = Priority.High;
                            Console.WriteLine(ImpTask + " marked as High Priority!");
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("Task not found!");
                    }
                    //category.importantList(ImpTask);
                    break;
                }


            }

            if (catFound == false)
            {
                Console.WriteLine("Category not found");
            }
        }

        public static void RemoveHighlight()
        {

            Console.WriteLine("which category does the task belong to?");
            string catname = Console.ReadLine().ToLower();
            bool catFound = false;
            foreach (Category category in categories)
            {
                if (category.Name == catname)
                {
                    catFound = true;
                    Console.WriteLine("Enter task name:");
                    string UnImpTask = Console.ReadLine();

                    bool found = false;
                    foreach (var task in category.Tasks)
                    {
                        if (task.Name.ToLower() == UnImpTask.ToLower())
                        {
                            found = true;
                            task.Priority = Priority.Default;
                            //Console.WriteLine(UnImpTask + " marked as High Priority!");
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("Task not found!");
                    }
                    break;
                }


            }

            if (catFound == false)
            {
                Console.WriteLine("Category not found");
            }
        }

        public static void moveCatty()
        {
            Console.WriteLine("Which category does the task you want to move belong to?");
            string originalcat = Console.ReadLine();
            Console.WriteLine("Which category do you want to move the task to?");
            string newcat = Console.ReadLine();
            foreach (Category category in categories)
            {
                if (category.Name == originalcat)
                {
                    Console.WriteLine("Enter the task name you want to move?");
                    string taskName = Console.ReadLine();
                    category.DeleteTask(taskName);

                    foreach (Category cat in categories)
                    {
                        if (cat.Name == newcat)
                        {
                            cat.AddTask(taskName);
                        }
                        else
                        {
                            Console.WriteLine("Category chosen is invalid");
                        }

                    }

                }
                else
                {
                    Console.WriteLine("Invalid");
                }
            }
        }

        public static void Reorder()
        {
            Console.WriteLine("Which category do you want to reorder tasks in?");
            string catname = Console.ReadLine().ToLower();
            foreach (Category category in categories)
            {
                if (category.Name == catname)
                {
                    Console.WriteLine("Enter the task name you want to reorder:");
                    string taskName = Console.ReadLine();
                    Task taskToReorder = null;
                    foreach (Task task in category.Tasks)
                    {
                        if (task.Name.ToLower() == taskName.ToLower())
                        {
                            taskToReorder = task;
                            break;
                        }
                    }

                    if (taskToReorder != null)
                    {
                        Console.WriteLine("Enter the new position for the task (0 to " + (category.Tasks.Count - 1) + "):");
                        int newPosition;
                        if (int.TryParse(Console.ReadLine(), out newPosition) && newPosition >= 0 && newPosition < category.Tasks.Count)
                        {
                            category.Tasks.Remove(taskToReorder);
                            category.Tasks.Insert(newPosition, taskToReorder);
                            Console.WriteLine("Task reordered successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid position. Reordering failed.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Task not found in the category.");
                    }
                }
                else
                {
                    Console.WriteLine("Category not found");
                }
            }
        }




        public enum functions
        {
            AddCat,
            DelCat,
            AddTask,
            DelTask,
            markitcomp,
            important,
            MoveCat,
            Reorder,
            RemoveHighlight,
            Quit
        }


        static void Main(string[] args)
        {
            PrintCategoriesTable();
            ReadUserOption();
            functions choice;
            do
            {
                choice = ReadUserOption();
                switch (choice)
                {
                    case functions.AddCat:
                        Addcat();
                        PrintCategoriesTable();
                        break;
                    case functions.DelCat:
                        RemoveCategory();
                        PrintCategoriesTable();
                        break;
                    case functions.AddTask:
                        AddTask();
                        PrintCategoriesTable();
                        break;
                    case functions.DelTask:
                        DelTask();
                        PrintCategoriesTable();
                        break;
                    case functions.markitcomp:
                        Completed();
                        PrintCategoriesTable();
                        break;
                    case functions.important:
                        Important();
                        PrintCategoriesTable();
                        break;
                    case functions.MoveCat:
                        moveCatty();
                        PrintCategoriesTable();
                        break;
                    case functions.Reorder:
                        Reorder();
                        PrintCategoriesTable();
                        break;
                    case functions.RemoveHighlight:
                        RemoveHighlight();
                        PrintCategoriesTable();
                        break;
                    case functions.Quit:
                        Console.WriteLine("You will surely have a productive day! Bye bye for now");
                        break;

                    default:

                        break;
                }
            } while (choice != functions.Quit);

        }


        static functions ReadUserOption()
        {
            int userChoice;

            do
            {
                Console.WriteLine("\nPlease choose an option from the following menu:");
                Console.WriteLine("1. Add Category");
                Console.WriteLine("2. Delete Category");
                Console.WriteLine("3. Add Task");
                Console.WriteLine("4. Delete Task");
                Console.WriteLine("5. Mark a task complete");
                Console.WriteLine("6. Mark a task important");
                Console.WriteLine("7. Move Category");
                Console.WriteLine("8. Reorder Tasks in a Category");
                Console.WriteLine("9. Remove Highlight");
                Console.WriteLine("10.Quit");

                Console.Write("\nEnter your choice: ");

                userChoice = Convert.ToInt32(Console.ReadLine());
            } while (userChoice <= 0 || userChoice >= 10);

            return (functions)(userChoice - 1);
        }

        static void PrintCategoriesTable()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(new string(' ', 12) + "CATEGORIES");
            Console.WriteLine(new string(' ', 10) + new string('-', 94));

            Console.Write("{0,10}|", "item #");
            foreach (var category in categories)
            {
                Console.Write("{0,30}|", category.Name);
            }
            Console.WriteLine();

            Console.WriteLine(new string(' ', 10) + new string('-', 94));

            int maxItemCount = 0;
            foreach (var category in categories)
            {
                if (category.Tasks.Count > maxItemCount)
                {
                    maxItemCount = category.Tasks.Count;
                }
            }

            for (int i = 0; i < maxItemCount; i++)
            {
                Console.Write("{0,10}|", i);

                foreach (var category in categories)
                {
                    if (i < category.Tasks.Count)
                    {
                        if (category.Tasks[i].Priority == Priority.Default)
                        {
                            Console.Write("{0,30}|", category.Tasks[i].Name + " " + category.Tasks[i].DueDate);


                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("{0,30}|", category.Tasks[i].Name);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else
                    {
                        Console.Write("{0,30}|", "N/A");
                    }
                }

                Console.WriteLine();
            }

            Console.ResetColor();
        }



    }
}

using System;
using System.Threading.Tasks;

namespace z
{
    public class Category
    {
        public string Name { get; set; }

        public List<Task> Tasks = new List<Task>();

        public Category(string name)
        {
            Name = name;
        }

        public void AddTask(string name)
        {
            var task = new Task(name);
            task.DueDate = DateTime.Now.AddDays(1);
            this.Tasks.Add(task);

        }

        public void AddTask(string name, DateTime dueDate)
        {
            var task = new Task(name);
            task.DueDate = dueDate;
            this.Tasks.Add(task);

        }

        public void DeleteTask(string name)
        {
            Task taskToRemove = null;
            foreach (var task in Tasks)
            {
                if (task.Name == name)
                {
                    taskToRemove = task;
                    break;
                }
            }

            if (taskToRemove != null)
            {
                Tasks.Remove(taskToRemove);
            }
        }


    }


}


using System;
using System.Threading.Tasks;

namespace z
{
    public class Task
    {

        public string? Name { get; set; }

        public Priority Priority { get; set; } = Priority.Default;

        public DateTime DueDate { get; set; }



        public Task(string name)
        {
            this.Name = name;
        }
        public Task(string name, Priority priority, DateTime dueDate)
        {
            this.Name = name;
            this.Priority = priority;
            this.DueDate = dueDate;
        }

    }

    public enum Priority
    {
        Default,
        High
    }
}
