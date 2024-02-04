using Application.CarCQ.AllDtos;
using Application.ErrorHandling;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarCQ.Command
{
    public class PostCar:IRequest<RegisterResponse<Car>>
    {
        public PostCarDto CarDto { get; set; }
    }

    public class PostCarHandler:IRequestHandler<PostCar, RegisterResponse<Car>>
    {
        public readonly ICarDbContext _context;

        public PostCarHandler(ICarDbContext context)
        {
            _context = context;
        }

        public async Task<RegisterResponse<Car>> Handle(PostCar request, CancellationToken cancellationToken)
        {
            try
            {

           
            var newCar = new Car
            {

                Name = request.CarDto.Name ,
                ContactDetails = request.CarDto.ContactDetails,
                Price = request.CarDto.Price,
                Categories = request.CarDto.Categories,
            };


            await _context.CarClass.AddAsync(newCar);
            await _context.SaveChangesAsync();


            var response = new RegisterResponse<Car> 
            {
                Status = 200,
                StatusDescription = "successfully added new car",
                Response = new List<Car>
                                    {
                                        new Car
                                        {
                                           Id = newCar.Id,
                                           Name = newCar.Name,
                                           ContactDetails = newCar.ContactDetails,
                                           Price = newCar.Price,
                                           Categories = newCar.Categories
                                            
                                        }
                                     },
                Error = null

            };

            return response;

            }
            catch (Exception ex)
            {
                return new RegisterResponse<Car>
                {
                    Status = 500,
                    StatusDescription = "error",
                    Response = null,
                    Error = ex.Message
                };
            }


        }
    }
}
