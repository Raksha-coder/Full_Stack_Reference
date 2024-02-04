using Application.CarCQ.AllDtos;
using Application.ErrorHandling;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarCQ.Command
{
    public class PostRegisterDetails:IRequest<RegisterResponse<Register>>
    {
        
        //dto bas yaha lagta
        public PostRegisterDto RegisterDto { get; set; }
    }

    public class PostRegisterDetailsHandler:IRequestHandler<PostRegisterDetails,RegisterResponse<Register>>
    {
        public readonly ICarDbContext _context;

        public PostRegisterDetailsHandler(ICarDbContext context)
        {
            _context = context;
        }


        public async Task<RegisterResponse<Register>> Handle(PostRegisterDetails request, CancellationToken cancellationToken)
        {

            try
            {

                var newRegister = new Register
                {
                    Username = request.RegisterDto.Username,
                    Password = request.RegisterDto.Password,
                    Role = request.RegisterDto.Role
                };

                await _context.RegisterClass.AddAsync(newRegister);
                await _context.SaveChangesAsync();




                var Response = new RegisterResponse<Register>
                {
                    Status = 200,
                    StatusDescription = "successful",
                    Response = new List<Register>
                                    {
                                        new Register
                                        {
                                           Id = newRegister.Id,
                                           Username = newRegister.Username,
                                           Password = newRegister.Password,
                                           Role = newRegister.Role
                                        }
                                     },
                    Error = null
                };
                
                
                return  Response;

            }
            catch (Exception ex) 
            {
                return new RegisterResponse<Register>
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

