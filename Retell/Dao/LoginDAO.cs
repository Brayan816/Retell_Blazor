using Microsoft.AspNetCore.Components;
using Retell.Api;
using Retell.Model.Login;

namespace Retell.Dao
{
    public class LoginDAO
    {
        private readonly IApiRetell _apiRetell;
        public LoginDAO(IApiRetell apiRetell) { 
            _apiRetell = apiRetell;
        }
        public async Task<User> LoginRetell(User user)
        {
            user = await _apiRetell.LoginAsync(user);
            return user;
        }
    }
}
