namespace v1336.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DBContext : DbContext
    {
        public DBContext() : base("DBContext")
        {
        }

        // Справочники
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<WorkerPost> WorkerPosts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Nomenclature> Nomenclatures { get; set; }
        public DbSet<NomenclatureCategory> NomenclatureCategorys { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<CommentTheme> CommentThemes { get; set; }
        public DbSet<OrderRowStatus> OrderRowStatus { get; set; }

        // Документы
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderRow> OrderRows { get; set; }
        public DbSet<OrderRowHistory> OrderRowHistorys { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}