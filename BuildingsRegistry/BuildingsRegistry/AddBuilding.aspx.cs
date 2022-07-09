using BuildingsRegistry.Models.ViewModel;
using BuildingsRegistry.Utilis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BuildingsRegistry
{
    public partial class AddBuilding : System.Web.UI.Page
    {
        private string _urlUbication = "https://localhost:44398/Ubication/";
        private string _urlOwnershipStatus = "https://localhost:44398/OwnerShipStatus/GetStatus";
        private string _urlBuildings = "https://localhost:44398/Buildings/Create";

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                await _LoadProvince();
                await _LoadOwnershipStatus();
            }            
        }

        private async Task _LoadOwnershipStatus()
        {
            List<OwnershipStatus> provinces = await RequestHelper.GetRequest<List<OwnershipStatus>>(_urlOwnershipStatus);
            provinces.ForEach(element =>
            {
                IsRentDD.Items.Add(new ListItem()
                {
                    Text = element.Status,
                    Value = element.Id.ToString()
                });
            });
        }

        private async Task _LoadProvince()
        {
            List<Province> provinces = await RequestHelper.GetRequest<List<Province>>(_urlUbication + "GetProvince");
            provinces.ForEach(element =>
            {
                ProvinceDD.Items.Add(new ListItem()
                {
                    Text = element.ProvinceName,
                    Value = element.ProvinceCode.ToString()
                 });
            });
        }

        protected async void SaveBuildingB_ClickAsync(object sender, EventArgs e)
        {
            Building building = new Building()
            {
                BuildingName = BuildingNameTB.Text.ToString(),
                Capacity = Convert.ToInt32(CapacityTB.Text.ToString()),
                DateAdquition = Convert.ToDateTime(GetDateC.SelectedDate.ToString()),
                Province = Convert.ToInt32(ProvinceDD.SelectedValue.ToString()),
                Canton = Convert.ToInt32(CantonDD.SelectedValue.ToString()),
                Area = Convert.ToInt32(AreaDD.SelectedValue.ToString()),
                IsRent = Convert.ToInt32(IsRentDD.SelectedValue.ToString())
            };
            await RequestHelper.PostRequest(_urlBuildings, building);
        }

        protected async void ProvinceDD_SelectedValueChangedAsync(object sender, EventArgs e)
        {
            string selectedProvinceCode = ProvinceDD.SelectedValue;
            List<Canton> cantons = await RequestHelper.GetRequest<List<Canton>>(_urlUbication + "GetCanton/" + selectedProvinceCode);

            CantonDD.Enabled = true;
            CantonDD.Items.Clear();

            cantons.ForEach(element =>
            {
                CantonDD.Items.Add(new ListItem()
                {
                    Text = element.CantonName,
                    Value = element.CantonCode.ToString()
                });
            });
        }

        protected async void CantonDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCantonCode = CantonDD.SelectedValue;
            List<Area> areas = await RequestHelper.GetRequest<List<Area>>(_urlUbication + "GetArea/" + selectedCantonCode);

            AreaDD.Enabled = true;
            AreaDD.Items.Clear();

            areas.ForEach(element =>
            {
                AreaDD.Items.Add(new ListItem()
                {
                    Text = element.AreaName,
                    Value = element.AreaCode.ToString()
                });
            });
        }
    }
}