using BuildingsRegistry.Models;
using BuildingsRegistry.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuildingsRegistry.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Index()
        {
            return View();
        }

        // GET: Service/GetServiceType/
        public ActionResult GetServiceType()
        {
            List<ServiceType> serviceTypes = new List<ServiceType>();

            using(buildings_registryEntities bd = new buildings_registryEntities())
            {
                bd.serviceType.ToList().ForEach(e =>
                {
                    serviceTypes.Add(new ServiceType()
                    {
                        Id = e.Id,
                        Type = e.Type
                    });
                });
            }

            return Json(serviceTypes, JsonRequestBehavior.AllowGet);
        }

        // GET: Service/GetUnits
        public ActionResult GetUnits()
        {
            List<Unit> units = new List<Unit>();

            using (buildings_registryEntities bd = new buildings_registryEntities())
            {
                bd.unit.ToList().ForEach(e =>
                {
                    units.Add(new Unit()
                    {
                        Id = e.Id,
                        UnitName = e.UnitName
                    });
                });
            }

            return Json(units, JsonRequestBehavior.AllowGet);
        }

        // POST: Service/Create
        [HttpPost]
        public ActionResult AddService(Service service)
        {
            try
            {
                using (buildings_registryEntities bd = new buildings_registryEntities())
                {
                    publicServices publicService = new publicServices()
                    {
                        NameService = service.NameService,
                        TypeService = service.TypeService,
                        CompanyName = service.CompanyName,
                        
                    };

                    bd.publicServices.Add(publicService);
                    bd.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: Service/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Service/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Service/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Service/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
