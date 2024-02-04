using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ErrorHandling
{
    public class LoginResponse
    {
        public int Status {  get; set; }
        public string User {  get; set; }

        public string Role { get; set; }

    }
}
