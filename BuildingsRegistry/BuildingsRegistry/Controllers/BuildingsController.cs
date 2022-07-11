using BuildingsRegistry.Models;
using BuildingsRegistry.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BuildingsRegistry.Controllers
{
    public class BuildingsController : Controller
    {
        // GET: Buildings/GetAll
        public ActionResult GetAll ()
        {
            List<Building> builds = new List<Building>();

            using(buildings_registryEntities bd = new buildings_registryEntities())
            {
                bd.buildings.ToList().ForEach(e =>
                {
                    builds.Add(new Building()
                    {
                        Id = e.Id,
                        BuildingName = e.BuildingName,
                        Capacity = (int)e.Capacity,
                        Province = (int)e.ProvinceCode,
                        Canton = (int)e.CantonCode,
                        Area = (int)e.AreaCode,
                        IsRent = (int)e.PropertyStatus
                    });
                });
            }
            return Json(builds, JsonRequestBehavior.AllowGet);
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
