using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class HvConocimientosModel
    {
        public int ID_CONOCIMIENTOS { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Numero ")]
        public int ID_DATOS_BASICOS { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Numero ")]
        [Display(Name = "NOMBRE")]
        public int ID_CT_CONOCIMIENTOS { get; set; }
        public string NOMBRE_CT_CONOCIMIENTOS { get; set; }
    }
}
