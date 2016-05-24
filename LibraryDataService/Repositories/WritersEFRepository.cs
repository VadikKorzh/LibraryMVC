using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDataService.Models;

namespace LibraryDataService.Repositories
{
    public class WritersEFRepository : IWritersRepository
    {
        LibraryDbContext context;

        public WritersEFRepository(LibraryDbContext context)
        {
            this.context = context;
        }

        public void AddWriter(Writer writer)
        {
            context.Writers.Add(writer);
        }

        public IList<Writer> GetAll()
        {
            return context.Writers.ToList();
        }

        public void SubmitChanges()
        {
            context.SaveChanges();
        }
    }
}
