using EDGM.Entities;
using Microsoft.EntityFrameworkCore;

namespace EDGM
{
    public class DataContext : DbContext
    {
        //----------------------------
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        //--------------------------------------------------------------------------
        public DbSet<Category> Categories { get; set; }
        public DbSet<ColorLabel> ColorLabels { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<StarSystem> StarSystems { get; set; }
        public DbSet<JournalStarSystem> JournalStarSystems { get; set; }
        //--------------------------------------------------------------------------

        //--------------------------------------------------------------------------
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = EDGM.db");
        }
        //--------------------------------------------------------------------------  complex relationships...
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JournalStarSystem>()
                .HasKey(j => new { j.JournalId, j.StarSystemId });

            modelBuilder.Entity<Journal>()
                .HasMany(j => j.JournalStarSystems)
                .WithOne(js => js.Journal)
                .HasForeignKey(f => f.JournalId);

            modelBuilder.Entity<StarSystem>()
                .HasMany(s => s.JournalStarSystems)
                .WithOne(js => js.StarSystem)
                .HasForeignKey(f => f.StarSystemId);
        }
    }
    //--------------------------------------------------------------------------

}
