using wprawka_01.Models;
using Microsoft.EntityFrameworkCore;
public class WprawkaDBContext : DbContext
{
    public WprawkaDBContext(DbContextOptions<WprawkaDBContext> options) : base(options)
    {
    }

    public DbSet<Klient> Klienci { get; set; }
    public DbSet<Denat> Denaci { get; set; }
    public DbSet<Placowka> Placowki { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Denat>()
            .HasOne(d => d.Klient)
            .WithMany(k => k.Denaci)
            .HasForeignKey(d => d.KlientId)
            .OnDelete(DeleteBehavior.Cascade); // nie mozemy odpalic klienta jesli dalej ma denatow przypisanych

        modelBuilder.Entity<Denat>()
            .HasOne(d => d.AktualnaPlacowka)
            .WithMany(p => p.Denaci)
            .HasForeignKey(d => d.PlacowkaId)
            .OnDelete(DeleteBehavior.SetNull); // w przypadku usuniecia placowki, denatowi przypisujemy null
    }
}