using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPECommerce.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; }

        public ValidationException(IEnumerable<ValidationFailure> failures)
        {
            Errors = new List<string>();
            foreach (var failure in failures)
            {
                Errors.Add($"{failure.PropertyName}: {failure.ErrorMessage}");
            }
        }

        public ValidationException(string message) : base(message)
        {
            Errors = new List<string> { message };
        }
    }
}
