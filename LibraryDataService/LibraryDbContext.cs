namespace LibraryDataService
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LibraryDbContext : DbContext
    {
        // Your context has been configured to use a 'LibraryDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'LibraryDataService.LibraryDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'LibraryDbContext' 
        // connection string in the application configuration file.
        public LibraryDbContext()
            : base("name=LibraryDbContext")
        {
            
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Writer> Writers { get; set; }
    }
}