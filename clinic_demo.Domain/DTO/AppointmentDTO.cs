﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinic_demo.Domain.DTO
{
    public class AppointmentDTO
    {
        public int AppointmentId { get; set; }
        public DateTime Date { get; set; } 
        public string Title { get; set; }
    }
}
