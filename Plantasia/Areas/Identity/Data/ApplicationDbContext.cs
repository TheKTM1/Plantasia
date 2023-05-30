using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Plantasia.Areas.Identity.Data;
using Plantasia.Models;

namespace Plantasia.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pet>().HasKey(m => m.Id);
        modelBuilder.Entity<Pet>().HasData(GetPets());
        base.OnModelCreating(modelBuilder);
    }
abstract class Bug 
    {
        int StingPower { get; set; }
        int HealthPoints { get; set; }
        int Speed { get; set; }
        bool IsAlive { get; set; }
        bool Exoskeleton { get; set; }
        bool Flight { get; set; }

    }
    abstract class Vegetable
    {
        int TheThicknessOfTheCrust { get; set; }
        int HealthPoints { get; set; }
        int Speed { get; set; }
        int CrushDamage { get; set; }

        bool IsAlive { get; set; }

    }
    abstract class Tomato : Vegetable
    {

    }
    abstract class TomaTanko : Tomato
    {

    }
    abstract class KillerBee : Bee
    {

    }
    abstract class Bee : Bug
    {

    }


    private List<Pet> GetPets()
    {
        return Enumerable.Range(1, 10)
            .Select(index => new Pet
            {
                Id = index,
                Level = index,
                Exp = 1327*index,
                RequiredExp = 5000*index,
                PictureHref = ".",
                Produce = $"PRODUCE{index}"
            })
            .ToList();
    }
}
