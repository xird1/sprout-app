using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Models
{
    public class ValidatorResponse
    {
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
    }
}
