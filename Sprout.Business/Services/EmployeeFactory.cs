using Microsoft.AspNetCore.Mvc;
using Sprout.Business.DataTransferObjects;
using Sprout.Business.Models;
using Sprout.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Business.Services
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
