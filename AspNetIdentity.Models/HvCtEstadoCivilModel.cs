using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class HvCtEstadoCivilModel
    {
        public int ID_CT_ESTADO_CIVIL { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Nombre")]
        public string NOMBRE { get; set; }

    }
}
