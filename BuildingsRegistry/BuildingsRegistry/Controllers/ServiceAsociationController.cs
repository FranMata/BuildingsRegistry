using BuildingsRegistry.Models;
using BuildingsRegistry.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BuildingsRegistry.Controllers
{
    public class ServiceAsociationController : Controller
    {
        // POST: ServiceAsociation/AddAsociation
        [HttpPost]
        public ActionResult AddAsociation(AsociatedService asociatedService)
        {
            try
            {
                using(buildings_registryEntities bd = new buildings_registryEntities())
                {
                    servicesAssigned servicesAssigned = new servicesAssigned()
                    {
                        BuildingId = asociatedService.BuildingId,
                        ServiceId = asociatedService.ServiceId,
                        Expiration = asociatedService.Expiration
                    };

                    bd.servicesAssigned.Add(servicesAssigned);
                    bd.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceAsociation/GetBuildingServices/5
        public ActionResult GetBuildingServices(int id)
        {
            List<AsociatedService> asociatedServices = new List<AsociatedService>();

            using(buildings_registryEntities bd = new buildings_registryEntities())
            {
                bd
                .servicesAssigned
                .Where(e => e.BuildingId == id)
                .ToList()
                .ForEach(e =>
                {
                    asociatedServices.Add(new AsociatedService()
                    {
                        Id = e.Id,
                        BuildingId = (int)e.BuildingId,
                        ServiceId = (int)e.ServiceId,
                        Expiration = (DateTime)e.Expiration
                    });
                });
            }
            return Json(asociatedServices, JsonRequestBehavior.AllowGet);
        }

        // GET: ServiceAsociation/Delete/5
        public ActionResult Delete(int id)
        {            
            using(buildings_registryEntities bd = new buildings_registryEntities())
            {
                servicesAssigned serviceAssigned = bd.servicesAssigned.Find(id);

                if (serviceAssigned == null)
                    return Content("0");

                bd.servicesAssigned.Remove(serviceAssigned);
                bd.SaveChanges();
            }
            return Content("1");
        }      
    }
}
