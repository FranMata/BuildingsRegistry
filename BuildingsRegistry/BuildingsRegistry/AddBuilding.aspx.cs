using BuildingsRegistry.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BuildingsRegistry
{
    public partial class AddBuilding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void SaveBuildingB_Click(object sender, EventArgs e)
        {
            Building building = new Building()
            {
                BuildingName = BuildingNameTB.Text.ToString(),
                Capacity = Convert.ToInt32(CapacityTB.Text.ToString()),
                DateAdquition = Convert.ToDateTime(GetDateC.ToString()),
                Province = Convert.ToInt32(ProvinceDD.SelectedValue.ToString()),
                Canton = Convert.ToInt32(CantonDD.SelectedValue.ToString()),
                Area = Convert.ToInt32(AreaDD.SelectedValue.ToString()),
                IsRent = Convert.ToInt32(IsRentDD.SelectedValue.ToString())
            };
        }
    }
}