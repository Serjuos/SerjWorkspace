using Microsoft.EntityFrameworkCore;
using Workspace.Models;

namespace Workspace
{

    public class ApplicationContext : DbContext
    {
        public DbSet<Document> Documents { get; set; } = null!;
        public DbSet<DocumentType> Types { get; set; } = null!;
        public DbSet<Status> Status { get; set; } = null!;


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}
