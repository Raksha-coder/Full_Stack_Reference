﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarCQ.AllDtos
{
    public class PostBookingDto
    {
        public string Name { get; set; }

        public string ContactDetails { get; set; }

        public float Price { get; set; }

        public DateTime Date { get; set; }

        public string Categories { get; set; }
    }
}
