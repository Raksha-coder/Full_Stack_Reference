using Application.CarCQ.Command;
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
    public class GetCarById : IRequest<Car>
    {
        public Guid Id { get; set; }
    }

    public class GetCarByIdHandler : IRequestHandler<GetCarById, Car>
    {
        private readonly ICarDbContext _context;

        public GetCarByIdHandler(ICarDbContext context)
        {
            _context = context;
        }

        public async Task<Car> Handle(GetCarById request, CancellationToken cancellationToken)
        {
           
                return await _context.CarClass.Where(r => r.Id == request.Id).FirstOrDefaultAsync();
         
          
        }


    }

}
