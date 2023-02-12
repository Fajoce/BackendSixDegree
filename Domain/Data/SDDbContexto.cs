using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    public class SDDbContexto: DbContext
    {
        #region Properties
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<TypeOfUser> TypeOfUsers  { get; set; }

        #endregion Properties
        #region Constructor
        public SDDbContexto(DbContextOptions<SDDbContexto> options): base(options)
        {

        }
        #endregion Constructor

        #region Public Methods 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SD");
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<User>()
                .Property(u => u.UserName)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);
            
            modelBuilder.Entity<User>()
                .Property(u => u.UserLastName)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);
            modelBuilder.Entity<User>().Property(u => u.UserAdress).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(u => u.UserTelephone).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(u => u.UserEmail).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(u => u.password).HasMaxLength(10);
            modelBuilder.Entity<TypeOfUser>().HasKey(tu => tu.TypeOfUserId);

            modelBuilder.Entity<TypeOfUser>()
                .Property(tu => tu.TypeOfUserName)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);
            modelBuilder.Entity<TypeOfUser>()
               .Property(tu => tu.TypeOfUserDescription)
               .HasMaxLength(50);
        }
        #endregion Public Methods 
    }
}
