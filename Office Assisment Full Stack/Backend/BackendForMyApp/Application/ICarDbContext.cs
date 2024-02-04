using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface ICarDbContext
    {


        DbSet<Register> RegisterClass {get;}

        DbSet<Login> LoginClass { get; }

        DbSet<Car> CarClass { get; }

        DbSet<BookingDetails> BookingClass { get; }


        Task SaveChangesAsync();
    }
}
