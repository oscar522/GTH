using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class HvEstudiosModel
    {
        public int ID_ESTUDIOS { get; set; }
        public int ID_DATOS_BASICOS { get; set; }
        [Required(ErrorMessage = "Debe ingresar la institucion ")]
        [Display(Name = "NOMBRE INSTITUCION")]
        public int ID_CT_INSTITUCION { get; set; }
        public string NOMBRE_INSTITUCION { get; set; }
        [Required(ErrorMessage = "Debe ingresar el titulo ")]
        [Display(Name = "TITULOS")]
        public int ID_CT_TITULOS { get; set; }
        public string NOMBRE_TITULO { get; set; }
        [Required(ErrorMessage = "Debe ingresar la disiplina ")]
        [Display(Name = "DISIPLINA")]
        public int ID_CT_DISIPLINA { get; set; }
        public string NOMBRE_DISIPLINA { get; set; }
        public System.DateTime DESDE { get; set; }
        public System.DateTime HASTA { get; set; }
        public int NOTA { get; set; }
        public string DESCRIPCION { get; set; }
        [Display(Name = "ARCHIVO")]
        public string ARCHIVO_RUTA { get; set; }
        [Required(ErrorMessage = "Debe ingresar una Actividad")]
        public string ACTIVIDADES { get; set; }


    }
}
