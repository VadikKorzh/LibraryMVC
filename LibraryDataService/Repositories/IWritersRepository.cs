using LibraryDataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDataService.Repositories
{
    public interface IWritersRepository
    {
        void AddWriter(Writer writer);
        IList<Writer> GetAll();
        //Writer GetByName(string name);
        void SubmitChanges();
    }
}
