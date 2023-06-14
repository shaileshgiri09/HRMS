using HRMS.Domain.Entities;
using HRMS.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Domain.Context
{
    public class HRMSDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public HRMSDbContext(DbContextOptions<HRMSDbContext> options) : base(options)
        {
            
        }

        /*public DbSet<Employee> Employees { get; set; }
        public DbSet<HR> HRs { get; set; }*/
        public DbSet<Leave> leaves { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /*int User_Id = 1;
            int Role_Id = 1;*/

            builder.Entity<ApplicationRole>().HasData(
                    /*new ApplicationRole { Id = Role_Id, Name = "Admin", NormalizedName = "Admin" },*/
                    new ApplicationRole { Id = 1, Name = "Employee", NormalizedName = "Employee" },
                    new ApplicationRole { Id = 2, Name = "HR", NormalizedName = "HR" }
                );

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = 1,
                    UserName = "Jay123",
                    NormalizedUserName = "Jay123",
                    Email = "jay@gmail.com",
                    NormalizedEmail = "jay@gmail.com",
                    PhoneNumber = "1234567890",
                    PasswordHash = hasher.HashPassword(null, "Jay@123"),
                    SecurityStamp = string.Empty
                },
                 new ApplicationUser
                 {
                     Id = 2,
                     UserName = "Utsav",
                     NormalizedUserName = "Utsav",
                     Email = "utsav@gmail.com",
                     NormalizedEmail = "utsav@gmail.com",
                     PhoneNumber = "1234567890",
                     PasswordHash = hasher.HashPassword(null, "Utsav@123"),
                     SecurityStamp = string.Empty
                 },
                  new ApplicationUser
                  {
                      Id = 3,
                      UserName = "Yash",
                      NormalizedUserName = "Yash",
                      Email = "yash@gmail.com",
                      NormalizedEmail = "yash@gmail.com",
                      PhoneNumber = "1234567890",
                      PasswordHash = hasher.HashPassword(null, "Yash@123"),
                      SecurityStamp = string.Empty
                  },
                   new ApplicationUser
                   {
                       Id = 4,
                       UserName = "John",
                       NormalizedUserName = "John",
                       Email = "john@gmail.com",
                       NormalizedEmail = "john@gmail.com",
                       PhoneNumber = "1234567890",
                       PasswordHash = hasher.HashPassword(null, "John@123"),
                       SecurityStamp = string.Empty
                   }
                  /* new ApplicationUser
                   {
                       Id = 5,
                       UserName = "Rakesh",
                       NormalizedUserName = "Rakesh",
                       Email = "rakesh@gmail.com",
                       NormalizedEmail = "rakesh@gmail.com",
                       PhoneNumber = "1234567890",
                       PasswordHash = hasher.HashPassword(null, "Rakesh@123"),
                       SecurityStamp = string.Empty
                   }*/


                );

            builder.Entity<IdentityUserRole<int>>().HasData(

                    new IdentityUserRole<int>
                    {
                        UserId = 1,
                        RoleId = 1
                    },
                    new IdentityUserRole<int>
                    {
                        UserId = 2,
                        RoleId = 1
                    },
                    new IdentityUserRole<int>
                    {
                        UserId = 3,
                        RoleId = 1
                    },
                    new IdentityUserRole<int>
                    {
                        UserId = 4,
                        RoleId = 2
                    }/*,
                     new IdentityUserRole<int>
                     {
                         UserId = 5,
                         RoleId = 3
                     }*/
                );

           /* builder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 2,
                    FullName = "Ravi Kumar",
                    Age = 20,
                    Email = "ravi@gmail.com",
                    NormalizedEmail = "ravi@gmail.com",
                    Gender = "Male",
                    Salary = 20000.00,
                    PhoneNumber = "1234567890",
                    PasswordHash = hasher.HashPassword(null, "Ravi@123"),
                    SecurityStamp = string.Empty
                },
                 new Employee
                 {
                     Id = 3,
                     FullName = "John Doe",
                     Age = 25,
                     Email = "john@gmail.com",
                     NormalizedEmail = "john@gmail.com",
                     Gender = "Male",
                     Salary = 25000.00,
                     PhoneNumber = "1234567890",
                     PasswordHash = hasher.HashPassword(null, "John@123"),
                     SecurityStamp = string.Empty
                 },
                  new Employee
                  {
                      Id = 4,
                      FullName = "Jay Darji",
                      Age = 20,
                      Email = "jay@gmail.com",
                      NormalizedEmail = "jay@gmail.com",
                      Gender = "Male",
                      Salary = 30000.00,
                      PhoneNumber = "1234567890",
                      PasswordHash = hasher.HashPassword(null, "Jay@123"),
                      SecurityStamp = string.Empty
                  }
            );

            builder.Entity<HR>().HasData(
                new HR
                {
                    Id = 5,
                    FullName = "Yash Gandhi",
                    Age = 24,
                    Email = "yash@gmail.com",
                    NormalizedEmail = "yash@gmail.com",
                    Gender = "Male",
                    Salary = 40000.00,
                    PhoneNumber = "1234567890",
                    PasswordHash = hasher.HashPassword(null, "Yash@123"),
                    SecurityStamp = string.Empty
                }
                 
            );
*/

        }
    }
}
