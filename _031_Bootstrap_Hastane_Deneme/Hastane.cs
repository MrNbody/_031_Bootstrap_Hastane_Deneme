//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _031_Bootstrap_Hastane_Deneme
{
    using System;
    using System.Collections.Generic;
    
    public partial class Hastane
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hastane()
        {
            this.Kliniks = new HashSet<Klinik>();
        }
    
        public int hastaneID { get; set; }
        public int ilceID { get; set; }
        public string hastaneAd { get; set; }
    
        public virtual Ilce Ilce { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Klinik> Kliniks { get; set; }
    }
}
