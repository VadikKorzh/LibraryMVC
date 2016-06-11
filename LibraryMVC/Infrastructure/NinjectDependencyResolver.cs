using LibraryDataService;
using LibraryDataService.Models;
using LibraryDataService.Repositories;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryMVC.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            LibraryDbContext dbContext = new LibraryDbContext();

            _kernel.Bind<IRepository<Book>>().To<BookEFRepository>().WithConstructorArgument("context", dbContext);
            _kernel.Bind<IRepository<Writer>>().To<WriterEFRepository>().WithConstructorArgument("context", dbContext);
            _kernel.Bind<IUnitOfWork>().To<LibraryUnitOfWork>().WithConstructorArgument("dbContext", dbContext);
        }
    }
}