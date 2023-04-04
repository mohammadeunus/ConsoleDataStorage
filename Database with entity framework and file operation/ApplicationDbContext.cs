﻿using Database_with_entity_framework_and_file_operation.DataBaseModelEntity;
using Microsoft.EntityFrameworkCore;

namespace Database_with_entity_framework_and_file_operation
{
    internal class ApplicationDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-R0B9L4A\\SQLEXPRESS;Initial Catalog=devskillB13;TrustServerCertificate=True;Integrated Security=True"); // cause taking in string using constructor is causing problems
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


        public DbSet<UserFiles> CoursesDbSet { get; set; } //represents the collection of all entities in the context, or that can be queried from the database, of a given type
        //only the aggregate roots will set in DBset, since admin is a sub object of Course and don't want to access it directly, we won't set it in DbSet

    }
}
