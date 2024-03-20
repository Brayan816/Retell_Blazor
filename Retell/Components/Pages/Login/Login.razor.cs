using Microsoft.AspNetCore.Components;
using Retell.Dao;
using Retell.Model.Login;

namespace Retell.Components.Pages.Login
{
    public partial class Login
    {
        [Inject]
        private NavigationManager navigationManager {  get; set; }
        private User user= new User();
        private LoginDAO loginDAO = new LoginDAO();

        private async Task Submit()
        {
            user = await loginDAO.LoginRetell(user);
            navigationManager.NavigateTo("/DashBoard");

        }
    }
}
