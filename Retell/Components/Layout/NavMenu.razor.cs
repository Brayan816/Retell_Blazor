using Microsoft.AspNetCore.Components;
using Retell.Commons;
using Retell.Services;

namespace Retell.Components.Layout
{
    public partial class NavMenu
    {
        [Inject]
        private ISessionService _session { get; set; }
        private string perm1="0", perm2 = "0", perm3 = "0";
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                perm1 = await _session.GetSessionValue(SessionVariables.PERM1);
                perm2 = await _session.GetSessionValue(SessionVariables.PERM2);
                perm3 = await _session.GetSessionValue(SessionVariables.PERM3);
                StateHasChanged();
            }
        }
    }
}
