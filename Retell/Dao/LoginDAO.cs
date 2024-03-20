using Microsoft.AspNetCore.Components;
using Retell.Api;
using Retell.Model.Login;

namespace Retell.Dao
{
    public class LoginDAO
    {
        [Inject]
        private IApiRetell _apiRetell {  get; set; }

        public async Task<User> LoginRetell(User user)
        {
            user = await _apiRetell.LoginAsync(user);
            return user;
        }
    }
}
