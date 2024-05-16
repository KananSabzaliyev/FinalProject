﻿using Entities.Concrete.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SqlDbContext
{
    public class ApplicationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = Localhost; Initial Catalog = CarDb; Integrated Security = true;Trust Server Certificate = true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarBody> CarBodies { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Gear> Gears { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}
