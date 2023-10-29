
using BackendChallenge.core.Utils;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendChallenge.core.Entity.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
       public UserValidator() { 
        
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name can't by null").MinimumLength(3).WithMessage("Name must be at least 3 characters");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
            RuleFor(x => x.Email).EmailAddress().WithMessage("The email is not valid");
            RuleFor(x => x.Document).Custom((document, constext) =>
            {
                if (Cpf.IsInvalid(document))
                    constext.AddFailure("Document is not valid");
            });
        }
    }
}
