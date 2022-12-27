using Vidly.Models;

namespace Vidly
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DatabaseTest : DbContext
    {
        // Your context has been configured to use a 'DatabaseTeat' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Vidly.DatabaseTeat' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DatabaseTeat' 
        // connection string in the application configuration file.
        public DatabaseTest()
            : base("name=DatabaseTeat")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Customer> Customers { get; set; } // My domain models
        public DbSet<Movie> Movies { get; set; }// My domain models

        public DbSet<MembershipType> MembershipTypes { get; set; }// My domain models
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}