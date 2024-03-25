using Microsoft.AspNetCore.Components;
using Retell.Commons;
using Retell.Services;

namespace Retell.Components.Layout
{
    public partial class HeaderLayout
    {
        [Inject]
        private ISessionService _session {  get; set; }
        private string userName="";

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                userName = await _session.GetSessionValue(SessionVariables.USERNAME);
                StateHasChanged();
            }
        }
    }
}
