using System;

namespace BuildingsRegistry.Models.ViewModel
{
    public class AsociatedService
    {
        public int? Id { get; set; }
        public int BuildingId { get; set; }
        public int ServiceId { get; set; }     
        public DateTime? Expiration { get; set; }
    }
}