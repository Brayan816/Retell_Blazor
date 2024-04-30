using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;
using Retell.Api;
using Retell.Commons;
using Retell.Dao;
using Retell.Model.Llanta;

namespace Retell.Components.Pages.Llanta
{
    public partial class EditLlanta
    {
        [Parameter]
        public string LlantaId { get; set; }
        [Inject]
        private IApiRetell apiRetell { get; set; }
        [Inject]
        private NavigationManager navigationManager{ get; set; }

        private EditAnexo editAnexo { get; set; }
        private EditMaterial editMaterial{ get; set; }
        private EditReasignar editReasignar{ get; set; }

        public IQueryable<DeLlanta> deLlanta;
        public List<DeLlanta> listDellanta;

        public IQueryable<LlantaDoc> docLlanta;
        public List<LlantaDoc> listDocllanta;

        private LlantaDao _llantaDao;
        public ModelLlanta llanta = new ModelLlanta();
        public bool enabled=false;
        
        PaginationState pagination = new PaginationState { ItemsPerPage = 15 };
        List<BreadcrumbItem> breadcums = new List<BreadcrumbItem>()
        { new BreadcrumbItem { Text = "Home", Href = "/Dashboard" }, new BreadcrumbItem{ Text="Llantas", Href="/llantas"}, new BreadcrumbItem{ Text="Llanta"}};

        protected override async Task OnParametersSetAsync()
        {
            LlantaId = Security.Decrypt(LlantaId);
            StateHasChanged();
        }
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
            if(!LlantaId.Equals("0"))
                await GetData();
            else
                await ClearData();
            StateHasChanged();
        }

        private async Task GetData()
        {
            llanta = await _llantaDao.GetLlanta(LlantaId);
            listDellanta = await _llantaDao.GetAllDeLlantas(LlantaId);
            if (listDellanta?.Count > 0)
                deLlanta = listDellanta.AsQueryable();
            listDocllanta = await _llantaDao.GetAllDocLlantas(LlantaId);
            if (listDocllanta?.Count > 0)
                docLlanta = listDocllanta.AsQueryable();
        }
        private async Task ClearData()
        {
            enabled = true;
            llanta = new ModelLlanta();
        }
        private async Task EditAnexo(string llantaId)
        {
            editAnexo.OnShowModalClick();
        }
        private async Task EditReasignar(string llantaId)
        {
            editReasignar.OnShowModalClick();
        }
        private async Task EditMaterial(string llantaId)
        {
            editMaterial.OnShowModalClick();
        }
        private async Task GoBack()
        {
            navigationManager.NavigateTo("/llantas");
        }
        //private async Task<GridDataProviderResult<DeLlanta>> DeLlantasDataProvider(GridDataProviderRequest<DeLlanta> request)
        //{
        //    return await Task.FromResult(request.ApplyTo(deLlantas));
        //}
    }
}
