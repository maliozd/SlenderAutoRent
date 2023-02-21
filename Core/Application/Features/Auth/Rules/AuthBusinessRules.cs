using Application.Rules;
using Domain.Entites.Identity;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;

namespace Application.Features.Auth.Rules
{
    public class AuthBusinessRules : BaseRules
    {
        readonly UserManager<AppUser> _userManager;

        public AuthBusinessRules(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        /// <summary>
        /// if username already taken for another user : 
        /// return true
        /// --------
        /// else :
        /// return false
        /// 
        /// </summary>
        /// <param name="username">
        /// input username
        /// </param>
        /// <returns>bool</returns>
        public bool IsUsernameExist(string username)
        {
            if (_userManager.Users.Any(t => t.UserName == username))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// if email is already in use : 
        /// return true 
        /// -------
        /// else : 
        /// return false
        /// input email
        /// </summary>
        /// 
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsEmailExist(string email)
        {
            if (_userManager.Users.Any(t => t.Email == email))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// password must contain one upperCase at least.
        /// ! can be more !
        /// </summary>
        /// 
        /// <param name="password">
        /// input password
        /// </param>
        /// <returns></returns>
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
