﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Business.DataTransferObjects
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Birthdate { get; set; }
        public string Tin { get; set; }
        public int EmployeeTypeId { get; set; }
    }
}
