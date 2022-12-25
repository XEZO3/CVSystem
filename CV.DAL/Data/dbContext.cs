using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.DAL.Data
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { 
        
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            //DESKTOP-JD76U9C
            //LAPTOP-BFFJ9SQ9
            builder.UseSqlServer("Server=DESKTOP-JD76U9C;Database=CVSystem;Trusted_Connection=True;Trust Server Certificate=true;");
        }
        DbSet<Exp> experiances { get; set; }
        DbSet<Users> Users { get; set; }
        DbSet<Personal> PersonalInfo { get; set; }
        DbSet<CVMod> CV { get; set; }

    }
}
