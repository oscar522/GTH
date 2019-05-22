using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class PerfilFormacionIdiomasModel
    {
        public int ID_FORMA_IDIOM { get; set; }
        public int ID_PERFIL { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Idioma")]
        [Display(Name = "IDIOMA")]
        public int ID_IDIOMA { get; set; }
        [Display(Name = "IDIOMA")]
        public string NombreIdioma { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Nivel de Experiencia")]
        [Display(Name = "NIVEL")]
        public int ID_IDIOM_NIVEL { get; set; }
        [Display(Name = "NIVEL")]
        public string NombreNivel { get; set; }
        public int ESTADO { get; set; }
    }
}
