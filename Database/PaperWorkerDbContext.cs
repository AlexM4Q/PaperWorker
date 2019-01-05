﻿using Core;
using Database.Models;
using Database.Models.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;

namespace Database
{
    /// <summary>
    /// dotnet ef migrations add [comment]
    /// dotnet ef database update [comment]
    /// </summary>
    public class PaperWorkerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            var connectionString = new ConfigurationBuilder()
                .AddJsonFile("db.settings.json")
                .Build()
                .GetConnectionString(nameof(PaperWorkerDbContext));

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var roleNameConverter = new EnumToStringConverter<RoleName>();
            var userStatusConverter = new EnumToStringConverter<UserStatus>();

            #region User

            modelBuilder.Entity<User>()
                .HasOne(user => user.Profile)
                .WithOne(profile => profile.User)
                .HasForeignKey<Profile>(profile => profile.UserId);

            modelBuilder.Entity<User>()
                .Property(user => user.Status)
                .HasConversion(userStatusConverter);

            #endregion

            #region Role

            modelBuilder.Entity<Role>().HasData(
                new Role {Id = RoleNameExtension.ConsumerRoleId, Name = RoleName.Consumer},
                new Role {Id = RoleNameExtension.LocksmithRoleId, Name = RoleName.Locksmith},
                new Role {Id = RoleNameExtension.AdminRoleId, Name = RoleName.Admin}
            );

            modelBuilder.Entity<Role>()
                .Property(role => role.Name)
                .HasConversion(roleNameConverter);

            #endregion

            #region UserRole

            modelBuilder.Entity<UserRole>()
                .HasKey(userRole => new {userRole.UserId, userRole.RoleId});

            modelBuilder.Entity<UserRole>()
                .HasOne(userRole => userRole.User)
                .WithMany(user => user.Roles)
                .HasForeignKey(userRole => userRole.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(userRole => userRole.Role)
                .WithMany(role => role.Users)
                .HasForeignKey(userRole => userRole.RoleId);

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}