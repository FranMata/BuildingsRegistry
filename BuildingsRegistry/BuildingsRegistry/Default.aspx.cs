using BuildingsRegistry.Models.ViewModel;
using BuildingsRegistry.Utilis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BuildingsRegistry
{
    public partial class _Default : Page
    {
        private string _urlService = "https://localhost:44398/Service/GetAll";
        private string _urlBuilding = "https://localhost:44398/Buildings/GetAll";
        private string _urlAssing = "https://localhost:44398/ServiceAsociation/"; 
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                await _LoadBuildings();
                await _LoadService();
            }
        }

        private async Task _LoadBuildings()
        {
            BuildingDD.Items.Clear();

            List<Building> buildings = await RequestHelper.GetRequest<List<Building>>(_urlBuilding);
            buildings.ForEach(e =>
            {
                BuildingDD.Items.Add(new ListItem()
                {
                    Value = e.Id.ToString(),
                    Text = e.BuildingName
                });
            });
        }
        
        private async Task _LoadService()
        {
            ServiceDD.Items.Clear();

            List<Service> services = await RequestHelper.GetRequest<List<Service>>(_urlService);

            services.ForEach(e =>
            {
                ServiceDD.Items.Add(new ListItem()
                {
                    Value = e.Id.ToString(),
                    Text = e.NameService
                });
            });
        }

        private async Task<AsociatedService> _ServiceAlreadyAssing(int buildingId, int serviceId)
        {
            List<AsociatedService> asociatedServices = await RequestHelper
                .GetRequest<List<AsociatedService>>(_urlAssing + "GetBuildingServices/" + buildingId);

            return asociatedServices.Where(e => e.ServiceId == serviceId).FirstOrDefault();            
        }

        protected async void SaveB_Click(object sender, EventArgs e)
        {
            ServiceAsociatedError.Visible = false;

            AsociatedService asociatedService = new AsociatedService()
            {
                BuildingId = Convert.ToInt32(BuildingDD.SelectedValue.ToString()),
                ServiceId = Convert.ToInt32(ServiceDD.SelectedValue.ToString()),
                Expiration = Convert.ToDateTime(ExpirationDateC.SelectedDate.ToString())
            };

            string selectedAtion = ActionCB.SelectedValue.ToString();
            AsociatedService alreadyAsociated = await _ServiceAlreadyAssing(asociatedService.BuildingId, asociatedService.ServiceId);

            if (selectedAtion.Equals("Add"))
                await _AddAsociatedService(asociatedService, alreadyAsociated);
            else if (selectedAtion.Equals("Delete"))
                await _DeleteAsociatedService((int)alreadyAsociated.Id);
        }

        private async Task _DeleteAsociatedService(int asociatedService) => await RequestHelper.DeleteRequest(_urlAssing + "Delete/" + asociatedService);
        private async Task _AddAsociatedService(AsociatedService asociatedService, AsociatedService alreadyAsociated)
        {
            if (alreadyAsociated == null)
                await RequestHelper.PostRequest(_urlAssing + "AddAsociation", asociatedService);
            else
                ServiceAsociatedError.Visible = true;
        }
    }
}