//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BuildingsRegistry.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class publicServices
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public publicServices()
        {
            this.servicesAssigned = new HashSet<servicesAssigned>();
        }
    
        public int Id { get; set; }
        public string NameService { get; set; }
        public Nullable<int> TypeService { get; set; }
        public string CompanyName { get; set; }
    
        public virtual unit unit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<servicesAssigned> servicesAssigned { get; set; }
    }
}
