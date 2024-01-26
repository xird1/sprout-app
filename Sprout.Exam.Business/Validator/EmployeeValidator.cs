using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Validator
{
    public class EmployeeValidator
    {
        public ValidatorResponse ValidateRequest(CreateEmployeeDto employee)
        {
            ValidatorResponse response = new ValidatorResponse();
            try
            {

                if (string.IsNullOrEmpty(employee.FullName))
                {
                    response.HasError = true;
                    response.ErrorMessage = "Name can't be null or empty!";
                    return response;
                }
                if (employee.FullName.Length > 100)
                {
                    response.HasError = true;
                    response.ErrorMessage = "Name length must be less than 100.";
                    return response;
                }
                if (string.IsNullOrEmpty(employee.Tin))
                {
                    response.HasError = true;
                    response.ErrorMessage = "Tin can't be null or empty!";
                    return response;
                }
                if (employee.Tin.Length > 100)
                {
                    response.HasError = true;
                    response.ErrorMessage = "Tin length must be less than 100.";
                    return response;
                }

                if (!IsValidBirthdate(employee.Birthdate))
                {
                    response.HasError = true;
                    response.ErrorMessage = "Cannot use future dates.";
                    return response;
                }

                response.HasError = false;
            }
            catch (Exception e)
            {
                response.HasError = true;
                response.ErrorMessage = e.Message;
            }
            return response;
        }
        public ValidatorResponse ValidateRequest(EditEmployeeDto employee)
        {
            ValidatorResponse response = new ValidatorResponse();
            try
            {

                if (string.IsNullOrEmpty(employee.FullName))
                {
                    response.HasError = true;
                    response.ErrorMessage = "Name can't be null or empty!";
                    return response;
                }
                if (employee.FullName.Length > 100)
                {
                    response.HasError = true;
                    response.ErrorMessage = "Name length must be less than 100.";
                    return response;
                }
                if (string.IsNullOrEmpty(employee.Tin))
                {
                    response.HasError = true;
                    response.ErrorMessage = "Tin can't be null or empty!";
                    return response;
                }
                if (employee.Tin.Length > 100)
                {
                    response.HasError = true;
                    response.ErrorMessage = "Tin length must be less than 100.";
                    return response;
                }

                if (!IsValidBirthdate(employee.Birthdate))
                {
                    response.HasError = true;
                    response.ErrorMessage = "Cannot use future dates.";
                    return response;
                }

                response.HasError = false;
            }
            catch (Exception e)
            {
                response.HasError = true;
                response.ErrorMessage = e.Message;
            }
            return response;
        }

        private bool IsValidBirthdate(DateTime value)
        {
            return (DateTime)value < DateTime.Now;
        }
    }
}
