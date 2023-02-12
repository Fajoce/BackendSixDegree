using Entities.DTO;
using FluentValidation;

namespace Domain.Utils
{
    public class UserValidator: AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(u => u.UserName).NotNull()
                .Length(1,50)
                .WithMessage("This field only let 50 caracters");
            RuleFor(u => u.UserLastName).NotNull()
                .Length(1,50)
                .WithMessage("This field only let 50 caracters");
            RuleFor(u => u.UserAdress).NotNull()
                .Length(1,50)
                .WithMessage("This field only let 50 caracters");
            RuleFor(u => u.UserTelephone).NotNull()
                .Length(1,15)
                .WithMessage("This field only let 15 caracters");
            RuleFor(u => u.UserEmail)
                .Length(1,50);
              
        }
    }
}
