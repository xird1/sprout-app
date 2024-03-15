using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Models
{
    public class Regular : IEmployee
    {
        private readonly decimal _absences;
        private readonly decimal _tax;
        // based on the requirements salary is not saved in database at the moment, so for now use 20k as default for regular
        private decimal _salary;

        public Regular(decimal absentDays)
        {
            this._absences = absentDays;
            this._tax = 0.12m;
            this._salary = 20000;
        }
        public decimal CalculateSalary()
        {
            decimal absentDeduction = 0;
            if (_absences > 0)
            {
                absentDeduction = Math.Round((this._salary / 22) * _absences, 2);
            }
            return Math.Round(this._salary - absentDeduction - (this._salary * _tax), 2);

        }
    }
}
