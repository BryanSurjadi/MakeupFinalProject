//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MakeupFinalProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MakeupBrand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MakeupBrand()
        {
            this.Makeups = new HashSet<Makeup>();
        }
    
        public int MakeupBrandID { get; set; }
        public string MakeupBrandName { get; set; }
        public int MakeupBrandRating { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Makeup> Makeups { get; set; }
    }
}
