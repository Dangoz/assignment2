using Microsoft.EntityFrameworkCore;
using StudentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Data
{
  public class StudentDbContext : DbContext
  {
    public DbSet<Student> Students { get; set; }

    public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<Student>().HasData(
        new
        {
          StudentId = Guid.NewGuid().ToString(),
          FirstName = "Tom",
          LastName = "Day",
          Email = "tom@gmail.com",
          MobileNumber = "1234567890",
          Specialization = "Science",
          City = "London",
          Province = "Ontario",
          Employer = "Google",
        },
        new
        {
          StudentId = Guid.NewGuid().ToString(),
          FirstName = "John",
          LastName = "Doe",
          Email = "john@gmail.com",
          MobileNumber = "1234567890",
          Specialization = "Engineering",
          City = "Vancouver",
          Province = "British Columbia",
          Employer = "Apple",
        },
        new
        {
          StudentId = Guid.NewGuid().ToString(),
          FirstName = "Jane",
          LastName = "Doe",
          Email = "jane@gmail.com",
          MobileNumber = "1234567890",
          Specialization = "Engineering",
          City = "Toronto",
          Province = "Ontario",
          Employer = "Microsoft"
        }
      );
    }

  }
}
