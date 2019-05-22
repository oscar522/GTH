using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class HvCtInstitucionesModel
    {
        public int ID_CT_INSTITUCION { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Pais")]
        [Display(Name = "PAIS")]
        public int ID_CT_PAIS { get; set; }
        public string NOMBRE_PAIS { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Departamento")]
        [Display(Name = "DEPARTAMENTO")]
        public int ID_CT_DEPTO { get; set; }
        public string NOMBRE_DEPTO { get; set; }
        [Required(ErrorMessage = "Debe ingresar una Ciudad")]
        [Display(Name = "CIUDAD")]
        public int ID_CT_CIUDAD { get; set; }
        public string NOMBRE_CIUDAD { get; set; }
        [Required(ErrorMessage = "Debe ingresar el Nombre")]
        public string NOMBRE { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Tipo")]
        public int TIPO { get; set; }

    }
}
