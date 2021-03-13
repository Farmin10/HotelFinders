using System;
using System.Collections.Generic;
using System.Text;
using HotelFinders.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelFinders.DataAccess
{
    public class HotelDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-PSJTQAN;Database=HotelDb;Integrated Security=true;");
        }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
