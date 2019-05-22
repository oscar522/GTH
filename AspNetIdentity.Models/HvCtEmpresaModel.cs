using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class HvCtEmpresaModel
    {
        public int ID_CT_EMPRESA { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Nombre")]
        public string NOMBRE { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Pais")]
        public int PAIS { get; set; }
        [Display(Name = "PAIS")]
        public string NOMBRE_PAIS { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Departamento")]
        [Display(Name = "DEPARTAMENTO")]
        public int DEPTO { get; set; }
        [Display(Name = "DEPARTAMENTO")]
        public string NOMBRE_DEPTO { get; set; }
        [Required(ErrorMessage = "Debe ingresar la Ciudad")]
        public int CIUDAD { get; set; }
        [Display(Name = "CIUDAD")]
        public string NOMBRE_CIUDAD { get; set; }
        [Required(ErrorMessage = "Debe ingresar el Tipo")]
        public int TIPO { get; set; }

    }
}
