using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class HvCtTitulosModel
    {
        public int ID_CT_TITULOS { get; set; }
        [Display(Name = "PAIS")]
        [Required(ErrorMessage = "Debe Seleccionar un Pais")]
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
        [Required(ErrorMessage = "Debe ingresar un Nombre")]
        public string NOMBRE { get; set; }
        public int TIPO { get; set; }
    }
}
