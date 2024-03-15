using Microsoft.AspNetCore.Mvc;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Business.Models;
using Sprout.Exam.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Services
{
    public class EmployeeFactory
    {

        public static IEmployee GetEmployee(int employeeTypeId, CalculateEmployeeDto input)
        {
            var typeId = (EmployeeType)employeeTypeId;

            return typeId switch
            {
                EmployeeType.Regular =>
                    new Regular(input.AbsentDays),
                EmployeeType.Contractual =>
                    new Contractual(input.WorkedDays),
                _ => null
            };
        }

    }
}
