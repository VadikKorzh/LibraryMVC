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
        LibraryDbContext _context;

        public BookEFRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public Book Get(int id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books;
        }

        public void Add(Book bookToAdd)
        {
            _context.Books.Add(bookToAdd);
        }

        public void Remove(int id)
        {
            Book book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }
        }
    }
}
