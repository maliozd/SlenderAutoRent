using Application.Repositories;
using Application.Rules;
using System.Text.RegularExpressions;

namespace Application.Features.Auth.Rules
{
    public class AuthBusinessRules : BaseRules
    {
        readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository repository)
        {
            _userRepository = repository;
        }
        /// <summary>
        /// if username already exist in db for another user : 
        /// return true
        /// 
        /// else :
        /// return false
        /// </summary>
        /// <param name="username"></param>
        /// <returns>bool</returns>
        public bool IsUsernameExist(string username)
        {
            if (_userRepository.Table.Any(t => t.Username == username))
            {
                return true;
            }
            return false;
        }

        public bool IsEmailExist(string email)
        {
            if (_userRepository.Table.Any(t => t.Email == email))
            {
                return true;
            }
            return false;
        }
        public bool PasswordMustContainSpecialCharacters(string password)
        {
            var lowercase = new Regex("[a-z]+");
            var uppercase = new Regex("[A-Z]+");
            //var digit = new Regex("(\\d)+");
            //var symbol = new Regex("(\\W)+");

            return lowercase.IsMatch(password) && uppercase.IsMatch(password);
        }
    }
}
