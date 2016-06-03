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
        LibraryDbContext context;

        public WriterEFRepository(LibraryDbContext context)
        {
            this.context = context;
        }

        public Writer Get(int id)
        {
            return context.Writers.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Writer> GetAll()
        {
            return context.Writers;
        }

        public void Add(Writer writerToAdd)
        {
            context.Writers.Add(writerToAdd);
        }

        public void Remove(int id)
        {
            Writer writer = context.Writers.FirstOrDefault(b => b.Id == id);
            if (writer != null)
            {
                context.Writers.Remove(writer);
            }
        }
    }
}
