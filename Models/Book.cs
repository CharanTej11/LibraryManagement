using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace LibraryManagement.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int YearPublished { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
