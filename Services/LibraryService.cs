using LibraryManagement.Data;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Services
{
    public class LibraryService
    {
        public void CreateAuthor(string name, string email)
        {
            using var context = new LibraryContext();
            var author = new Author { Name = name, Email = email };
            context.Authors.Add(author);
            context.SaveChanges();
        }

        public void AddBookToAuthor(int authorId, string title, int year)
        {
            using var context = new LibraryContext();
            var book = new Book { Title = title, YearPublished = year, AuthorId = authorId };
            context.Books.Add(book);
            context.SaveChanges();
        }

        public void ListBooks()
        {
            using var context = new LibraryContext();
            var books = context.Books.Include(b => b.Author).ToList();
            foreach (var book in books)
            {
                Console.WriteLine($"Book ID: {book.BookId}, Title: {book.Title}, Author: {book.Author.Name}, Year: {book.YearPublished}");
            }
        }

        public void UpdateBookTitle(int bookId, string newTitle)
        {
            using var context = new LibraryContext();
            var book = context.Books.Find(bookId);
            if (book != null)
            {
                book.Title = newTitle;
                context.SaveChanges();
            }
        }

        public void DeleteBook(int bookId)
        {
            using var context = new LibraryContext();
            var book = context.Books.Find(bookId);
            if (book != null)
            {
                context.Books.Remove(book);
                context.SaveChanges();
            }
        }

        public  List<Author> GetAuthors()
        {
            using var context = new LibraryContext();
            return context.Authors.ToList();
        }
    }
}
