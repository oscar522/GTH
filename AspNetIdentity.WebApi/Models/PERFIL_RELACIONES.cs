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
    
    public partial class PERFIL_RELACIONES
    {
        public int ID_RELACION { get; set; }
        public int ID_PERFIL { get; set; }
        public int TIPO { get; set; }
        public string NOMBRE { get; set; }
        public string MOTIVO { get; set; }
        public Nullable<int> ESTADO { get; set; }
    
        public virtual PERFIL PERFIL { get; set; }
    }
}
