using Application.ErrorHandling;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarCQ.Queries
{
    public class GetAllCars:IRequest<List<Car>>
    {

    }
    public class GetAllCarsHandler : IRequestHandler<GetAllCars, List<Car>>
    {
        private readonly ICarDbContext _context;

        public GetAllCarsHandler(ICarDbContext context)
        {
            _context = context;
        }


        public async Task<List<Car>> Handle(GetAllCars request, CancellationToken cancellationToken)
        {
           
               
            return await _context.CarClass.ToListAsync();
                   

          
        }









    }

    }
