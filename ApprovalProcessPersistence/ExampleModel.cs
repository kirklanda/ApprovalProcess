using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApprovalProcessPersistence
{
    // This is to simply get the EF Core working and for messing around with examples
    class ExampleContext : DbContext
    {
        private const string ConnectionString = "Data Source=ANDREW-SURFACE-\\SQLEXPRESS;Database=ApprovalProcess;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public DbSet<ExampleModel> ExampleModels { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(ConnectionString);
    }

    class ExampleModel
    {
        public int ExampleModelId { get; set; }
        public string Name { get; set; }
    }
}
