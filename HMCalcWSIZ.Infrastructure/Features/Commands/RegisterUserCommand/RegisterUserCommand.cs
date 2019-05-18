using MediatR;

namespace HMCalcWSIZ.Infrastructure.Features.Commands.RegisterUserCommand
{
    public class RegisterUserCommand : IRequest
    {
        public string Email { get; set; }

        public string EmailRepeat { get; set; }

        public string Password { get; set; }

        public string PasswordRepeat { get; set; }
    }
}
