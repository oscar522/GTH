using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class HvActitudesModel
    {
        [Display(Name = "ACTITUDES")]
        public int ID_ACTITUDES { get; set; }

        [Required(ErrorMessage = "Debe ingresar un Numero")]
        [Range(0, short.MaxValue, ErrorMessage = "El valor {0} debe ser numérico.")]
        public int ID_DATOS_BASICOS { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Numero")]
        [Range(0, short.MaxValue, ErrorMessage = "El valor {0} debe ser numérico.")]
        [Display(Name = "ACTITUD")]
        public int ID_CT_ACTITUDES { get; set; }
        [Display(Name = "NOMBRE")]
        public string NOMBRE_CT_ACTITUDES { get; set; }

    }
}
