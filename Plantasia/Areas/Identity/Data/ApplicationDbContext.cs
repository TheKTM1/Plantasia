using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Plantasia.Areas.Identity.Data;
using Plantasia.Models;

namespace Plantasia.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Pet> Pets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pet>().HasKey(m => m.Id);
        modelBuilder.Entity<Pet>().HasData(GetPets());
        base.OnModelCreating(modelBuilder);
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
