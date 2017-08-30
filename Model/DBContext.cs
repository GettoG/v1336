namespace v1336.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DBContext : DbContext
    {
        public DBContext() : base("name=DBContext")
        {
        }
        
        public DbSet<Order> Orders { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Nomenclature> Nomenclatures { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}