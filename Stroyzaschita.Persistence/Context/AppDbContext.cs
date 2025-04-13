using Microsoft.EntityFrameworkCore;
using Stroyzaschita.Domain.Entities;

namespace Stroyzaschita.Persistence.Context;

class AppDbContext: DbContext {
    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options) 
    {

    }

    public DbSet<User> Users => Set<User>();
    public DbSet<UserProfile> UserProfiles => Set<UserProfile>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
