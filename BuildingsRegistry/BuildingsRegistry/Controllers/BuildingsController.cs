using BuildingsRegistry.Models;
using BuildingsRegistry.Models.ViewModel;
using System.Web.Mvc;

namespace BuildingsRegistry.Controllers
{
    public class BuildingsController : Controller
    {
        // GET: Buildings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Buildings/Create
        [HttpPost]
        public ActionResult Create(Building building)
        {
            try
            {
                using(buildings_registryEntities bd = new buildings_registryEntities())
                {
                    buildings buildingToSav = new buildings()
                    {
                        BuildingName = building.BuildingName,
                        Capacity = building.Capacity,
                        ProvinceCode = building.Province,
                        CantonCode = building.Canton,
                        AreaCode = building.Area,
                        PropertyStatus = building.IsRent
                    };

                    bd.buildings.Add(buildingToSav);
                    bd.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
