using Application;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class CarDbContext :DbContext, ICarDbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> dbContextOptions) : base(dbContextOptions) { }


        public DbSet<Register> RegisterClass => Set<Register>();
        public DbSet<Login> LoginClass => Set<Login>();

        public DbSet<Car> CarClass => Set<Car>();

        public DbSet<BookingDetails> BookingClass => Set<BookingDetails>();





        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Register>()
                 .HasKey(register => register.Id);

            modelBuilder.Entity<Login>()
                .HasKey(login => login.Id);

            modelBuilder.Entity<Car>()
                .HasKey(car => car.Id);

            modelBuilder.Entity<BookingDetails>()
                .HasKey(book => book.Id);

           

        }


    }
}
