using Microsoft.EntityFrameworkCore;

public class TodoContextDb : DbContext
{
    public DbSet<TodoDTO> Todos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=./Data.db");
    }
}
