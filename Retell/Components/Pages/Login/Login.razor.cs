
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Retell.Api;
using Retell.Commons;
using Retell.Dao;
using Retell.Model.Login;
using Retell.Services;

namespace Retell.Components.Pages.Login
{
    public partial class Login
    {
        [Inject]
        private NavigationManager navigationManager { get; set; }
        [Inject]
        private ISessionService _session { get; set; }
        [Inject]
        private IApiRetell apiRetell { get; set; }
        [Inject]
        private IToastService toastService { get; set; }
        private User user = new User();
        private LoginDAO _loginDao;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _loginDao = new LoginDAO(apiRetell);
                user.EMPRESA = await _session.GetSessionValue(SessionVariables.EMPRESA);
                user.USERNAME = await _session.GetSessionValue(SessionVariables.USERNAME);
                user.PASSWORD = await _session.GetSessionValue(SessionVariables.PASSWORD);
                StateHasChanged();
            }
        }
        private async Task Submit()
        {
            User org = user;
            user = await _loginDao.LoginRetell(user);
            if (user.SUCCESS)
            {
                await _session.SetSessionValue(SessionVariables.EMPRESA, user.EMPRESA);
                await _session.SetSessionValue(SessionVariables.EMPRESAID, user.EMPRESAID);
                await _session.SetSessionValue(SessionVariables.PASSWORD, org.PASSWORD);
                await _session.SetSessionValue(SessionVariables.TOKEN, user.TOKEN);
                await _session.SetSessionValue(SessionVariables.PERM1, "1");
                await _session.SetSessionValue(SessionVariables.PERM2, "1");
                await _session.SetSessionValue(SessionVariables.PERM3, "1");
            }
            else
            {
                toastService.ShowError("Usuario o contraseña incorrecto");
                user = org;
                return ;   
            }
            navigationManager.NavigateTo("/Dashboard",true);

        }
        private async Task ConsultarModulos()
        {
                 
        }

    }
}
