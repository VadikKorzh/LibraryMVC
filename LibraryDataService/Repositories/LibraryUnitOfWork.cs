using LibraryDataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDataService.Repositories
{
    public class LibraryUnitOfWork : IDisposable
    {
        LibraryDbContext _dbContext = new LibraryDbContext();
        IRepository<Book> _bookRepository;
        IRepository<Writer> _writerRepository;

        //public LibraryUnitOfWork(IRepository<Book> bookRepository, IRepository<Writer> writerRepository)
        //{
        //    _bookRepository = bookRepository;
        //    _writerRepository = writerRepository;
        //}

        public IRepository<Writer> WriterRepository
        {
            get
            {
                return _writerRepository;
            }
        }

        public IRepository<Book> BookRepository
        {
            get
            {
                return _bookRepository;
            }
        }

        public LibraryUnitOfWork()
        {
            _bookRepository = new BookEFRepository(_dbContext);
            _writerRepository = new WriterEFRepository(_dbContext);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _dbContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~LibraryUnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
