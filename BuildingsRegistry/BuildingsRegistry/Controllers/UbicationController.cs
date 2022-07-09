using BuildingsRegistry.Models;
using BuildingsRegistry.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BuildingsRegistry.Controllers
{
    public class UbicationController : Controller
    {
        //// GET: Ubication/GetCanton/5
        public ActionResult GetArea(int id)
        {
            List<Area> cantons = new List<Area>();
            using (buildings_registryEntities bd = new buildings_registryEntities())
            {
                bd.area.Where(e => e.CantonCode == id).ToList().ForEach(e =>
                {
                    cantons.Add(new Area()
                    {
                        Id = e.Id,
                        CantonCode = (int)e.CantonCode,
                        AreaCode = (int)e.AreaCode,
                        AreaName = e.AreaName
                    });
                });
            }
            return Json(cantons, JsonRequestBehavior.AllowGet);
        }

        //// GET: Ubication/GetCanton/5
        public ActionResult GetCanton(int id)
        {
            List<Canton> cantons = new List<Canton>();
            using (buildings_registryEntities bd = new buildings_registryEntities())
            {
                bd.canton.Where(e => e.ProvinceCode == id).ToList().ForEach(e =>
                {
                    cantons.Add(new Canton()
                    {
                        Id = e.Id,
                        CantonCode = (int)e.CantonCode,
                        ProvinceCode = (int)e.ProvinceCode,
                        CantonName = e.CantonName
                    });
                });
            }
            return Json(cantons, JsonRequestBehavior.AllowGet);
        }

        //// GET: Ubication/GetProvince
        public ActionResult GetProvince()
        {
            List<Province> provinces = new List<Province>();
            using (buildings_registryEntities bd = new buildings_registryEntities())
            {
                bd.province.ToList().ForEach(e =>
                {
                    provinces.Add(new Province()
                    {
                        Id = e.Id,
                        ProvinceCode = (int)e.ProvinceCode,
                        ProvinceName = e.ProvinceName
                    });
                });
            }
            return Json(provinces, JsonRequestBehavior.AllowGet);
        }
    }
}