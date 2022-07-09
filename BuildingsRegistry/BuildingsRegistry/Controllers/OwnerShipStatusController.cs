using BuildingsRegistry.Models;
using BuildingsRegistry.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BuildingsRegistry.Controllers
{
    public class OwnerShipStatusController : Controller
    {
        // GET: OwnerShipStatus/GetStatus
        public ActionResult GetStatus()
        {
            List<OwnershipStatus> statuses = new List<OwnershipStatus>();

            using(buildings_registryEntities bd = new buildings_registryEntities())
            {
                bd.propertyStatus.ToList().ForEach(e =>
                {
                    statuses.Add(new OwnershipStatus()
                    {
                        Id = e.Id,
                        Status = e.Status
                    });
                });
            }

            return Json(statuses, JsonRequestBehavior.AllowGet);
        }
    }
}
