//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AspNetIdentity.WebApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PERFIL_CT_AREA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PERFIL_CT_AREA()
        {
            this.PERFIL_CT_SUB_AREA = new HashSet<PERFIL_CT_SUB_AREA>();
        }
    
        public int ID_CT_AREA { get; set; }
        public string DESCRIPCION { get; set; }
        public Nullable<int> ESTADO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PERFIL_CT_SUB_AREA> PERFIL_CT_SUB_AREA { get; set; }
    }
}
