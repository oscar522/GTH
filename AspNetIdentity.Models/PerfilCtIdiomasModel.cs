using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class PerfilCtIdiomasModel
    {
        public int ID_IDIOMA { get; set; }
        [Display(Name = "NIVEL")]
        public string NOMBRE_NIVEL { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Nombre")]
        public string NOMBRE { get; set; }
        public int ESTADO { get; set; }
    }
}
