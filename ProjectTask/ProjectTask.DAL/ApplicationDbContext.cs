using Microsoft.EntityFrameworkCore;
using ProjectTask.Domain.Entity;
using System.Collections.Generic;

namespace ProjectTask.DAL
{
    public class ApplicationDbContext : DbContext // creating a database context to interact with database
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Project> Projects { get; set; }

    }
}