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
    
    public partial class PERFIL_CT_SUB_AREA
    {
        public int ID_CT_SUB_AREA { get; set; }
        public int ID_CT_AREA { get; set; }
        public string DESCRIPCION { get; set; }
        public Nullable<int> ESTADO { get; set; }
    
        public virtual PERFIL_CT_AREA PERFIL_CT_AREA { get; set; }
    }
}
