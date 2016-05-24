using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDataService.Models;

namespace LibraryDataService.Repositories
{
    public class BooksEFRepository : IBooksRepository
    {
        LibraryDbContext context;

        public BooksEFRepository(LibraryDbContext context)
        {
            this.context = context;
        }

        public void AddBook(Book book)
        {
            context.Books.Add(book);
        }

        public IList<Book> GetAll()
        {
            return context.Books.ToList();
        }

        public Book GetById(int id)
        {
            return context.Books.First(b => b.Id == id);
        }

        public void RemoveBook(int id)
        {
            Book bookToRemove = context.Books.First(b => b.Id == id);
            context.Books.Remove(bookToRemove);
            
        }

        public void SubmitChanges()
        {
            context.SaveChanges();
        }
    }
}
