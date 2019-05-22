using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class HvCtCiudadModel
    {
        public int ID_CT_CIUDAD { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Departamento")]
        [Display(Name = "DEPARTAMENTO")]
        public int ID_CT_DEPTO { get; set; }
        [Display(Name = "DEPARTAMENTO")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string NOMBRE_DEPTO { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Pais")]
        [Display(Name = "PAIS")]
        public int ID_CT_PAIS { get; set; }
        [Display(Name = "PAIS")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string NOMBRE_PAIS { get; set; }
        [Required(ErrorMessage = "Debe ingresar el Descripion ")]

        public string NOMBRE { get; set; }
    }
}
