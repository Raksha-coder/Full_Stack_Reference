using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ErrorHandling
{
    public class RegisterResponse<T>
    {
        public int Status { get; set; }
        public string StatusDescription { get; set; }
        public List<T> Response { get; set; }
        public string Error { get; set; }
    }
}
