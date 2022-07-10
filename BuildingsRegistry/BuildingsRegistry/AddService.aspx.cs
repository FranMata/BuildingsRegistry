using BuildingsRegistry.Models.ViewModel;
using BuildingsRegistry.Utilis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unit = BuildingsRegistry.Models.ViewModel.Unit;

namespace BuildingsRegistry
{
    public partial class AddService : System.Web.UI.Page
    {
        private string _urlService = "https://localhost:44398/Service/";
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                await _LoadServiceTypeAsync();
                await _LoadUnit();
            }
        }

        private async Task _LoadServiceTypeAsync()
        {
            TypeServiceDD.Items.Clear();
            List<ServiceType> serviceTypes = await RequestHelper.GetRequest<List<ServiceType>>(_urlService + "GetServiceType");

            serviceTypes.ForEach(e =>
            {
                TypeServiceDD.Items.Add(new ListItem()
                {
                    Text = e.Type,
                    Value = e.Id.ToString()
                });
            });
        }

        private async Task _LoadUnit()
        {
            UnitDD.Items.Clear();
            List<Unit> units = await RequestHelper.GetRequest<List<Unit>>(_urlService + "GetUnits");

            units.ForEach(e =>
            {
                UnitDD.Items.Add(new ListItem()
                {
                    Text = e.UnitName,
                    Value = e.Id.ToString()
                });
            });
        }

        protected async void SaveServiceB_Click(object sender, EventArgs e)
        {
            Service service = new Service()
            {
                NameService = NameServiceTB.Text.ToString(),
                TypeService = Convert.ToInt32(TypeServiceDD.SelectedValue.ToString()),
                CompanyName = CompanyNameTB.Text.ToString()
            };
            await RequestHelper.PostRequest(_urlService + "AddService", service);
        }
    }
}