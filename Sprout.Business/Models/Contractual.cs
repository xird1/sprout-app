using System;

namespace Sprout.Business.Models
{
    public class Contractual : IEmployee
    {
        private readonly decimal _daysReported;
        // based on the requirements day rate is not saved in database at the moment, so for now use 500 as default for contractual
        private readonly decimal _dailyRate;

        public Contractual(decimal daysReported)
        {
            this._daysReported = daysReported;
            this._dailyRate = 500;
        }
        public decimal CalculateSalary()
        {
            return Math.Round(this._dailyRate * this._daysReported, 2);
        }
    }
}
