using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Car
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ContactDetails { get; set; }

        public float Price { get; set; }

        public string Categories {  get; set; }
    }
}


//( Price, categories (Buy/Rent)
