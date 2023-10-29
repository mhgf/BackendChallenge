using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendChallenge.core.Entity.Validators
{
    public class TransactionValidator : AbstractValidator<Transaction>
    {
        public TransactionValidator()
        {
            RuleFor(x => x.ResiverId).NotNull().NotEmpty();
            RuleFor(x => x.SenderId).NotNull().NotEmpty();
        }
    }
}
