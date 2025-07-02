using LibraryManagement.Services;

class Program
{
    static void Main()
    {
        var service = new LibraryService();

        while (true)
        {
            Console.WriteLine("\nLibrary Menu:");
            Console.WriteLine("1. Create Author");
            Console.WriteLine("2. Add Book");
            Console.WriteLine("3. List Books");
            Console.WriteLine("4. Update Book Title");
            Console.WriteLine("5. Delete Book");
            Console.WriteLine("6. Exit");

            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Author Name: ");
                    var name = Console.ReadLine();
                    Console.Write("Author Email: ");
                    var email = Console.ReadLine();
                    service.CreateAuthor(name, email);
                    break;

                case "2":
                    var authors = service.GetAuthors();
                    foreach (var a in authors)
                        Console.WriteLine($"{a.AuthorId}. {a.Name}");

                    Console.Write("Select Author ID: ");
                    int aid = int.Parse(Console.ReadLine());
                    Console.Write("Book Title: ");
                    var title = Console.ReadLine();
                    Console.Write("Year: ");
                    int year = int.Parse(Console.ReadLine());
                    service.AddBookToAuthor(aid, title, year);
                    break;

                case "3":
                    service.ListBooks();
                    break;

                case "4":
                    Console.Write("Book ID: ");
                    int bid = int.Parse(Console.ReadLine());
                    Console.Write("New Title: ");
                    var newTitle = Console.ReadLine();
                    service.UpdateBookTitle(bid, newTitle);
                    break;

                case "5":
                    Console.Write("Book ID: ");
                    int dbid = int.Parse(Console.ReadLine());
                    service.DeleteBook(dbid);
                    break;

                case "6":
                    return;
            }
        }
    }
}
