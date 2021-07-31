using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeyboardSimulator
{
    public class KeyboardSimulatorContext:DbContext
    {
        public DbSet<User> Users { get; set; }


        public KeyboardSimulatorContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-CUCHL8L\\SQLEXPRESS;Database=KeyboardSimulatorDB;Trusted_Connection=True;");
        }
    }
}
