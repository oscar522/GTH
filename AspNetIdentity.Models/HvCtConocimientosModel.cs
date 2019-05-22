using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class HvCtConocimientosModel
    {
        [Required(ErrorMessage = "Debe ingresar un Numero")]
        [Range(0, short.MaxValue, ErrorMessage = "El valor {0} debe ser numérico.")]
        public int ID_CT_CONOCIMIENTOS { get; set; }
        [Required(ErrorMessage = "Debe ingresar el Nombre ")]

        public string NOMBRE { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Numero ")]
        [Range(0, short.MaxValue, ErrorMessage = "El valor {0} debe ser numérico.")]
        [Display(Name = "SECTOR")]
        public int CT_SECTOR { get; set; }
    }
}
