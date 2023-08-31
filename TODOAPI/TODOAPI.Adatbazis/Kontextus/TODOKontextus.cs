using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOAPI.Adatbazis.Model;

namespace TODOAPI.Adatbazis.Kontextus
{
  public class TODOKontextus : DbContext, ITODOKontextus
  {
    private bool inMemory;
    public TODOKontextus(bool inmemory = false) : base()
    {
      this.inMemory = inmemory;
    }

    public DbSet<TODO> TODOS { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<TODO>().ToContainer("TODOS").HasPartitionKey(nameof(TODO.partitionKey));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (inMemory)
      {
        optionsBuilder.UseInMemoryDatabase("TODOS");
      }
      else
      {
        optionsBuilder.UseCosmos(
          "https://localhost:8081",
          "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
          databaseName: "TODODB");
      }
    }
  }
}
