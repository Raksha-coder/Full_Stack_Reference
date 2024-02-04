using Application.CarCQ.AllDtos;
using Application.ErrorHandling;
using Azure;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Application.CarCQ.Command
{
    public class PutCarById:IRequest<RegisterResponse<Car>>
    {
        public Car Cars { get; set; }
    }

    public class PutCarByIdHandler:IRequestHandler<PutCarById, RegisterResponse<Car>>
    {
        private readonly ICarDbContext _context;

        public PutCarByIdHandler(ICarDbContext context)
        {
            _context = context;
        }

        public async Task<RegisterResponse<Car>> Handle(PutCarById request, CancellationToken cancellationToken)
        {




            try {
                var existingCar = await _context.CarClass.FirstOrDefaultAsync(r => r.Id == request.Cars.Id);

                if (existingCar == null)
                {
                    return new RegisterResponse<Car>
                    {
                        Status = 404,
                        StatusDescription = "Car not found",
                        Response = null,
                        Error = "Car not found with the specified ID"
                    };
                }

                //id milne ke baad
                // Update the existing car properties
                existingCar.Name = request.Cars.Name;
                existingCar.ContactDetails = request.Cars.ContactDetails;
                existingCar.Price = request.Cars.Price;
                existingCar.Categories = request.Cars.Categories;

                //_context.CarClass.Update(existingCar);
                await _context.SaveChangesAsync();

                var response = new RegisterResponse<Car>
                {
                    Status = 200,
                    StatusDescription = "Successfully updated car",
                    Response = new List<Car>
                    {
                        new Car
                        {
                            Id = existingCar.Id,
                            Name = existingCar.Name,
                            ContactDetails = existingCar.ContactDetails,
                            Price = existingCar.Price,
                            Categories = existingCar.Categories
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
                    Status = 0,
                    StatusDescription = null,
                    Response = null,
                    Error = ex.Message
                }; 
            }


            }
     





          


        }
        







    }

