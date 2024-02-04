using Application.CarCQ.AllDtos;
using Application.ErrorHandling;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarCQ.Command
{
    public class PostLogin : IRequest<LoginResponse>
    {

        public PostLoginDto LoginDto { get; set; }
    }

    public class PostLoginHandler : IRequestHandler<PostLogin, LoginResponse>
    {
        public readonly ICarDbContext _context;

        public PostLoginHandler(ICarDbContext context)
        {
            _context = context;
        }

        public async Task<LoginResponse> Handle(PostLogin request, CancellationToken cancellationToken)
        {

            try
            {
                //to add details in db , but it is not necessary
                var newLogin = new Login
                {
                    //class = dtoclass
                        Username = request.LoginDto.Username,
                        Password = request.LoginDto.Password

                };




               var checkCredential = _context.RegisterClass.FirstOrDefault(r => r.Username == request.LoginDto.Username
                && r.Password == request.LoginDto.Password);




                if(checkCredential !=null)  //yaha change kar sakte h
                {


                    //error handling
                    var chkCredential = new LoginResponse
                    {
                        Status = 200,
                        User = "Valid",
                        Role = checkCredential.Role

                    };

                    await _context.LoginClass.AddAsync(newLogin);
                    await _context.SaveChangesAsync();
                    return chkCredential;
                }
                else
                {
                    var chkCredential = new LoginResponse
                    {
                        Status = 400,
                        User = "Invalid",
                        Role = null

                    };


                    return chkCredential;
                }

               

            }
            catch (Exception ex)
            {
                return new LoginResponse
                {
                    Status = 500,
                    User = ex.Message,
                    Role= null
                };

            }

        }


    }
}
