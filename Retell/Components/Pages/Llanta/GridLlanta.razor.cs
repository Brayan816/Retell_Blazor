using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;
using Retell.Api;
using Retell.Dao;
using Retell.Model.Llanta;

namespace Retell.Components.Pages.Llanta
{
    public partial class GridLlanta
    {
        [Inject]
        private IApiRetell apiRetell { get; set; }

        public IQueryable<LlantaGrid> data;
        private LlantaDao _llantaDao;
        private string searchText="";
        public List<LlantaGrid> llantas = new List<LlantaGrid>();
        PaginationState pagination = new PaginationState { ItemsPerPage = 15 };
        List<BreadcrumbItem> breadcums = new List<BreadcrumbItem>() 
        { new BreadcrumbItem { Text = "Home", Href = "/Dashboard" }, new BreadcrumbItem{ Text="Llantas"} };

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                _llantaDao = new LlantaDao(apiRetell);

                await SearchData();
            }
        }
        private async Task SearchData()
        {
            llantas = await _llantaDao.GetAllLlantas(searchText);
            if (llantas?.Count > 0)
                data = llantas.AsQueryable();
            StateHasChanged();
        }
    }
}
