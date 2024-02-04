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
    public class PostBookingDetails:IRequest<RegisterResponse<BookingDetails>>
    {
        public PostBookingDto Booking {  get; set; } 
    }

    public class PostBookingDetailsHandler : IRequestHandler<PostBookingDetails, RegisterResponse<BookingDetails>>
    {
        public readonly ICarDbContext _context;

        public PostBookingDetailsHandler(ICarDbContext context)
        {
            _context = context;
        }

        public async Task<RegisterResponse<BookingDetails>> Handle(PostBookingDetails request, CancellationToken cancellationToken)
        {
            try
            {
                var booking = new BookingDetails
                {
                    Id = Guid.NewGuid(),
                    Name = request.Booking.Name,
                    ContactDetails = request.Booking.ContactDetails,
                    Price = request.Booking.Price,
                    Date = DateTime.Now,
                    Categories = request.Booking.Categories,
                };

                await _context.BookingClass.AddAsync(booking);
                await _context.SaveChangesAsync();

                var response = new RegisterResponse<BookingDetails>
                {
                    Status = 200,
                    StatusDescription = "successfully added Booking Details",
                    Response = new List<BookingDetails>
                                    {
                                        new BookingDetails
                                        {
                                           Id = booking.Id,
                                           Name = booking.Name,
                                           ContactDetails = booking.ContactDetails,
                                           Price = booking.Price,
                                           Categories = booking.Categories

                                        }
                                     },
                    Error = null

                };
                return response;

            }catch(Exception ex)
            {
                return new RegisterResponse<BookingDetails>
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
