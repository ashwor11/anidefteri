using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AniDefteri.Domain.Entities;
using Core.Security.Entities;

namespace Persistence.Contexts
{
    public class AniDefteriDbContext : IdentityDbContext<User>
    {
        public AniDefteriDbContext(DbContextOptions<AniDefteriDbContext> options) : base(options)
        {
        }
        
        public DbSet<Family> Families { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Relationship> Relationships { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Person>(person =>
            {
                person.ToTable("Persons");
                person.HasKey(x => x.Id);
                
            });

            builder.Entity<Relationship>()
                .HasOne(r => r.Person)
                .WithMany(p => p.Relationships)
                .HasForeignKey(r => r.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Entity<Relationship>()
                .HasOne(r => r.RelatedPerson)
                .WithMany()
                .HasForeignKey(r => r.RelatedPersonId)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder.Entity<Relationship>()
                .Property(r => r.RelationshipType)
                .HasConversion<int>();

            builder.Entity<Family>(familyTree =>
            {
                familyTree.ToTable("FamilyTrees");
                familyTree.HasKey(x => x.Id);
                familyTree.HasMany(x => x.Persons).WithOne(x => x.Family).HasForeignKey(x => x.FamilyId);
            });
            
            
            
            Person person1 = new(){Id = 1, Name = "Nihat", Biography = "Öğretmen mühendis", BirthDate = DateTime.Parse("01/03/1967"), FamilyId = 1};
            Person person2 = new(){Id = 2, Name = "Emine", Biography = "Ev hanımı", BirthDate = DateTime.Parse("03/03/1976"), FamilyId = 1};
            Person person3 = new(){Id = 3, Name = "Kerim", Biography = "Üniversites öğrencisi", BirthDate = DateTime.Parse("07/09/2002"), FamilyId = 1};
            Person person4 = new(){Id = 4, Name = "Mert", Biography = "Lise öğrencisi", BirthDate = DateTime.Parse("17/08/2007"), FamilyId = 1};
            builder.Entity<Person>().HasData(person1, person2, person3, person4);
            Relationship relationship1 = new() { Id = 1, PersonId = 1, RelatedPersonId = 2, RelationshipType = RelationshipType.SPOUSE};
            Relationship relationship2 = new() { Id = 2, PersonId = 1, RelatedPersonId = 3, RelationshipType = RelationshipType.CHILD };
            Relationship relationship3 = new() { Id = 3, PersonId = 2, RelatedPersonId = 3, RelationshipType = RelationshipType.CHILD };
            Relationship relationship4 = new() { Id = 4, PersonId = 1, RelatedPersonId = 4, RelationshipType = RelationshipType.CHILD };
            Relationship relationship5 = new() { Id = 5, PersonId = 2, RelatedPersonId = 4, RelationshipType = RelationshipType.CHILD};
            Relationship relationship6 = new() { Id = 6, PersonId = 3, RelatedPersonId = 4, RelationshipType = RelationshipType.SIBLING};
            
            builder.Entity<Relationship>().HasData(relationship1, relationship2, relationship3, relationship4, relationship5, relationship6);
            
            

            Family family = new() { Id = 1, Name = "YILDIRIM Ailesi", Description = "Yıldırım ailesinin soy ağacı" };
            
            
            
            builder.Entity<Family>().HasData(family);
            
            base.OnModelCreating(builder);
            
            



        }
    }
}
