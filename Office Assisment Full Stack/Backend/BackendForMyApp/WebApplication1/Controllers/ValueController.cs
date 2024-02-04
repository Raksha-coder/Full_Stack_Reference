using Application.CarCQ.Command;
using Application.CarCQ.Queries;
using Application.ErrorHandling;
using Domain;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApplication1.Controllers
{
    public class ValueController : ApiController
    {

        [HttpPost("Register")]
        public async Task<RegisterResponse<Register>> Post([FromBody] PostRegisterDetails register)
        {
            return await Mediator.Send(register);

        }

        [HttpPost("Login")]

        public async Task<IActionResult> Post([FromBody] PostLogin login)
        {
            var x =  await Mediator.Send(login);

            if(x.Status==200)
            {
                return Ok(await Mediator.Send(login));
            }
            else if(x.Status== 400)
            {
                return BadRequest(x);
            }
            else
            {
                return BadRequest(x);
            }
        }


        [HttpPost("Cars")]

        public async Task<RegisterResponse<Car>> Post([FromBody] PostCar car)
        {
            return await Mediator.Send(car);
        }



        [HttpPut("id")]
        public async Task<IActionResult> Update([FromBody] PutCarById command)
        {
             return Ok(await Mediator.Send(command));
        }


        [HttpGet("id")]
         
        public async Task<IActionResult> GetById(Guid id)
        {
            var x = await Mediator.Send(new GetCarById { Id = id });
            var response = new GetByIdResponse<Car>
            {
                Status = 200,
                StatusDescription = "successful",
                Response = x,
                Error = null

            };

            var errorResponse = new GetByIdResponse<Car>
            {
                Status = 400,
                StatusDescription = "data is empty",
                Response = null,
                Error = null
            };
            try
            {
                if (x != null)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(errorResponse);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new GetByIdResponse<Car>
                    {

                        Status = 400,
                        StatusDescription = "error in data fetch",
                        Response = null,
                        Error = ex.Message
                    });
            }
          
         
        }
        //404 => url



        [HttpGet("allCars")]

        public async Task<IActionResult> GetAllCars()
        {
            var x = await Mediator.Send(new GetAllCars());
            var response = new RegisterResponse<Car>
            {
                Status = 200,
                StatusDescription = "successful",
                Response = x,
                Error = null

            };

            var errorResponse = new RegisterResponse<Car>
            {
                Status = 400,
                StatusDescription = "data is empty",
                Response = null,
                Error = null
            };

            try
            {
                if (x != null)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(errorResponse);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new RegisterResponse<Car>
                    {

                        Status = 400,
                        StatusDescription = "error in data fetch",
                        Response = null,
                        Error = ex.Message
                    });
            }





        }





        [HttpPost("Booking Details")]
        public async Task<RegisterResponse<BookingDetails>> Post([FromBody] PostBookingDetails command)
        {
            return await Mediator.Send(command);

        }




    }
}
