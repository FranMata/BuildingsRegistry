using System;

namespace BuildingsRegistry.Models.ViewModel
{
    public class Building
    {
        public int? Id { get; set; }
        public string BuildingName { get; set; }
        public int Capacity { get; set; }
        public DateTime? DateAdquition { get; set; }
        public int Province { get; set; }
        public int Canton { get; set; }
        public int Area { get; set; }
        public int IsRent { get; set; }
    }
}