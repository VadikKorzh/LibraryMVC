using LibraryDataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDataService.Repositories
{
    public class BookEFRepository : IRepository<Book>
    {
        LibraryDbContext context;

        public BookEFRepository(LibraryDbContext context)
        {
            this.context = context;
        }

        public Book Get(int id)
        {
            return context.Books.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return context.Books;
        }

        public void Add(Book bookToAdd)
        {
            context.Books.Add(bookToAdd);
        }

        public void Remove(int id)
        {
            Book book = context.Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                context.Books.Remove(book);
            }
        }
    }
}
