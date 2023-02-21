using Application.Dtos.AccessToken;

namespace Application.Features.Auth.Dtos
{
    public class LoginCommandResponse
    {

    }
    public class LoginSuccessCommandResponse : LoginCommandResponse
    {
        public LoginSuccessCommandResponse(Token token)
        {
            Token = token;
        }

        public Token Token { get; set; }
    }
    public class LoginErrorCommandResponse : LoginCommandResponse
    {
        public LoginErrorCommandResponse(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; set; }
    }
}
