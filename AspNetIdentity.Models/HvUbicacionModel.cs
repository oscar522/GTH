using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class HvUbicacionModel
    {
        public int ID_DATOS_BASICOS { get; set; }
        [Required(ErrorMessage = "Debe Seleccionar uno")]
        [Display(Name = "PAIS")]
        public int ID_CT_PAIS { get; set; }
        public string NOMBRE_PAIS { get; set; }
        [Required(ErrorMessage = "Debe Seleccionar uno")]
        [Display(Name = "DEPARTAMENTO")]
        public int ID_CT_DEPTO { get; set; }
        public string NOMBRE_DEPTO { get; set; }
        [Required(ErrorMessage = "Debe Seleccionar uno")]
        [Display(Name = "CIUDAD")]
        public int ID_CT_CIUDAD { get; set; }
        [Required(ErrorMessage = "No puede ser Vacio")]
        public string NOMBRE_CIUDAD { get; set; }
        [Display(Name = "UBICACION")]
        public int ID_HV_HUBICACION { get; set; }
        [Required(ErrorMessage = "No puede ser Vacio")]
        public string NOMENCLATURA { get; set; }
        [Required(ErrorMessage = "No puede ser Vacio")]
        public string LOCALIDAD { get; set; }

    }
}
