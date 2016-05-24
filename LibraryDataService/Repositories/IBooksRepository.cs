using LibraryDataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDataService.Repositories
{
    public interface IBooksRepository
    {
        void AddBook(Book writer);
        IList<Book> GetAll();
        Book GetById(int id);
        void RemoveBook(int id);
        void SubmitChanges();
    }
}
