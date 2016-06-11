using LibraryDataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDataService.Repositories
{
    public class WriterEFRepository : IRepository<Writer>
    {
        LibraryDbContext _context;

        public WriterEFRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public Writer Get(int id)
        {
            return _context.Writers.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Writer> GetAll()
        {
            return _context.Writers;
        }

        public void Add(Writer writerToAdd)
        {
            _context.Writers.Add(writerToAdd);
        }

        public void Remove(int id)
        {
            Writer writer = _context.Writers.FirstOrDefault(b => b.Id == id);
            if (writer != null)
            {
                _context.Writers.Remove(writer);
            }
        }
    }
}
