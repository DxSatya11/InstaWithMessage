using Instagram.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Infrastructure.Data
{
    public class InstagramDbContext : DbContext
    {
        public InstagramDbContext(DbContextOptions<InstagramDbContext> options): base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Follow> Follows { get; set; } 
        public DbSet<UserPassword> UserPassword { get; set; }
        public DbSet<Messaging> Messagestb { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Confugration for Users Class
            modelBuilder.Entity<Users>(entity =>
            {
                //User fluent validater

                entity.ToTable("Users");  //Give TableName
                entity.HasKey(pk => pk.Id);   //Make Id as Primary key

                // Required properties
                entity.Property(e => e.UserName).IsRequired();  
                entity.Property(e => e.GivenName).IsRequired();
                entity.Property(e => e.Email).IsRequired();
                //entity.Property(e => e.DOB).IsRequired();
                entity.Property(e => e.DOB)
                      .IsRequired()
                      .HasConversion(
                         v => v.ToString("yyyy-MM-dd"),   
                         v => DateOnly.Parse(v)           
                      );
                entity.Property(e => e.ContactNo).IsRequired();




                // Optional properties
                entity.Property(e => e.Bio).IsRequired(false);
                entity.Property(e => e.ProfilPicture).IsRequired(false);
                entity.Property(e => e.Country).IsRequired(false);
            });

            //Confugration for Posts Class
            modelBuilder.Entity<Posts>(entity =>
            {
                entity.ToTable("Posts"); //Give table name as UserPost
                entity.HasKey(pk =>pk.Id);  //Set Id as Primary key

                //Optional Property
                entity.Property(e =>e.UserPosts).IsRequired(false);

                //One to many relationship between user and post
                entity.HasOne(p => p.User).WithMany(u => u.Posts).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);

            });


            //One-to-One Relation for Password
            modelBuilder.Entity<Users>()
                .HasOne(u => u.UserPassword)
                .WithOne(pi => pi.Users)
                .HasForeignKey<UserPassword>(pi => pi.UserId);



            modelBuilder.Entity<Domain.Models.Messaging>(entity =>
            {
                entity.ToTable("Messagestb"); 
                entity.HasKey(pk => pk.Id);   

                // Configure foreign keys and relationships
                entity.HasOne(m => m.Sender)
               .WithMany(u => u.SentMessages)
                .HasForeignKey(m => m.SenderUserId)
               .OnDelete(DeleteBehavior.Cascade);
 

                // Restrict cascade delete for the other relationship
                entity.HasOne(m => m.Receiver)
                    .WithMany(u => u.ReceivedMessages)
                    .HasForeignKey(m => m.ReceiverUserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);

        }
    }
}
