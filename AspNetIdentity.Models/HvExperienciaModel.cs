using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class HvExperienciaModel
    {
        public int ID_EXPERIENCIA { get; set; }
        public int ID_DATOS_BASICOS { get; set; }
        [Required(ErrorMessage = "Debe Seleccionar la empresa")]
        [Display(Name = "EMPRESA")]
        public int ID_CT_EMPRESA { get; set; }
        public string NOMBRE_EMPRESA { get; set; }
        [Display(Name = "CARGO")]
        [Required(ErrorMessage = "Debe Seleccionar el cargo")]
        public int ID_CT_CARGO { get; set; }
        public string NOMBRE_CARGO { get; set; }
        [Required(ErrorMessage = "Debe Seleccionar una fecha")]
        public System.DateTime DESDE { get; set; }
        [Required(ErrorMessage = "Debe Seleccionar una fecha")]
        public System.DateTime HASTA { get; set; }
        [Display(Name = "ACTUALMENTE ?")]
        public int TRABAJO_ACTUAL { get; set; }
        [Required(ErrorMessage = "No debe estar Vacio")]
        public string DESCRIPCION { get; set; }
        [Required(ErrorMessage = "No debe estar Vacio")]
        [Display(Name = "ARCHIVO")]
        public string ARCHIVO_RUTA { get; set; }

    }
}
