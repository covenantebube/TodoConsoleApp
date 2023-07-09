// See https://aka.ms/new-console-template for more information
using TODO_Console_App;

class Program
{
    static void Main(string[] args)
    {
        var repository = new TodoRepository();

        while (true)
        {
            Console.WriteLine("Todo App");
            Console.WriteLine("1. Add Todo Item");
            Console.WriteLine("2. Edit Todo Item");
            Console.WriteLine("3. Delete Todo Item");
            Console.WriteLine("4. Search Todo Items");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTodoItem(repository);
                    break;
                case "2":
                    EditTodoItem(repository);
                    break;
                case "3":
                    DeleteTodoItem(repository);
                    break;
                case "4":
                    SearchTodoItems(repository);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void AddTodoItem(TodoRepository repository)
    {
        Console.WriteLine("Add Todo Item");
        var item = new TodoItem();

        Console.Write("Title: ");
        item.Title = Console.ReadLine();

        Console.Write("Description: ");
        item.Description = Console.ReadLine();

        Console.Write("Due Date (yyyy-mm-dd): ");
        if (DateTime.TryParse(Console.ReadLine(), out var dueDate))
        {
            item.DueDate = dueDate;
        }

        repository.AddTodoItem(item);

        Console.WriteLine("Todo item added successfully.");
    }

    static void EditTodoItem(TodoRepository repository)
    {
        Console.WriteLine("Edit Todo Item");
        Console.Write("Enter Todo Item ID: ");
        if (int.TryParse(Console.ReadLine(), out var id))
        {
            var item = repository.SearchTodoItems(null, null).FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                Console.Write("New Title: ");
                item.Title = Console.ReadLine();

                Console.Write("New Description: ");
                item.Description = Console.ReadLine();

                Console.Write("New Due Date (yyyy-mm-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out var dueDate))
                {
                    item.DueDate = dueDate;
                }

                repository.UpdateTodoItem(item);

                Console.WriteLine("Todo item updated successfully.");
                return;
            }
        }

        Console.WriteLine("Invalid Todo Item ID.");
    }

    static void DeleteTodoItem(TodoRepository repository)
    {
        Console.WriteLine("Delete Todo Item");
        Console.Write("Enter Todo Item ID: ");
        if (int.TryParse(Console.ReadLine(), out var id))
        {
            repository.DeleteTodoItem(id);
            Console.WriteLine("Todo item deleted successfully.");
            return;
        }

        Console.WriteLine("Invalid Todo Item ID.");
    }

    static void SearchTodoItems(TodoRepository repository)
    {
        Console.WriteLine("Search Todo Items");
        Console.Write("Enter Date (yyyy-mm-dd) [optional]: ");
        DateTime? date = null;
        if (DateTime.TryParse(Console.ReadLine(), out var searchDate))
        {
            date = searchDate;
        }

        Console.Write("Enter Keyword [optional]: ");
        var keyword = Console.ReadLine();

        var items = repository.SearchTodoItems(date, keyword);
        if (items.Count > 0)
        {
            Console.WriteLine("Search Results:");
            foreach (var item in items)
            {
                Console.WriteLine($"ID: {item.Id}");
                Console.WriteLine($"Title: {item.Title}");
                Console.WriteLine($"Description: {item.Description}");
                Console.WriteLine($"Due Date: {item.DueDate.ToShortDateString()}");
                String vee = "hi"; Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No items found.");
        }
    }
}
