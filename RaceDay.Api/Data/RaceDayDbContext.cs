using Microsoft.EntityFrameworkCore;
using RaceDay.Api.Models;
namespace RaceDay.Api.Data;
public class RaceDayDbContext(DbContextOptions<RaceDayDbContext> options) : DbContext(options)
{
 public DbSet<User> Users => Set<User>(); public DbSet<EventType> EventTypes => Set<EventType>(); public DbSet<Event> Events => Set<Event>(); public DbSet<Category> Categories => Set<Category>(); public DbSet<Enrolment> Enrolments => Set<Enrolment>(); public DbSet<Result> Results => Set<Result>();
 protected override void OnModelCreating(ModelBuilder b) {
  b.Entity<User>().HasIndex(x=>x.Email).IsUnique(); b.Entity<User>().Property(x=>x.Role).HasDefaultValue("Participant");
  b.Entity<Event>().Property(x=>x.DistanceKm).HasPrecision(8,2); b.Entity<Event>().HasOne(x=>x.Organiser).WithMany(x=>x.OrganisedEvents).HasForeignKey(x=>x.OrganiserId).OnDelete(DeleteBehavior.Restrict);
  b.Entity<Event>().HasOne(x=>x.EventType).WithMany(x=>x.Events).HasForeignKey(x=>x.EventTypeId).OnDelete(DeleteBehavior.Restrict);
  b.Entity<Category>().Property(x=>x.DistanceKm).HasPrecision(8,2); b.Entity<Enrolment>().HasIndex(x=>new{x.ParticipantId,x.EventId}).IsUnique();
  b.Entity<Enrolment>().HasOne(x=>x.Participant).WithMany(x=>x.Enrolments).HasForeignKey(x=>x.ParticipantId).OnDelete(DeleteBehavior.Restrict);
  b.Entity<Enrolment>().HasOne(x=>x.Category).WithMany(x=>x.Enrolments).HasForeignKey(x=>x.CategoryId).OnDelete(DeleteBehavior.Restrict);
  b.Entity<Result>().HasIndex(x=>x.EnrolmentId).IsUnique(); b.Entity<Result>().HasOne(x=>x.Enrolment).WithOne(x=>x.Result).HasForeignKey<Result>(x=>x.EnrolmentId).OnDelete(DeleteBehavior.Cascade);
  b.Entity<EventType>().HasData(new EventType{EventTypeId=1,Name="Run"},new EventType{EventTypeId=2,Name="Walk"},new EventType{EventTypeId=3,Name="Cycle"});
 }
}
