using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class PerfilCtIdiomasNivelModel
    {
        public int ID_IDIOM_NIVEL { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Nombre")]
        public string NOMBRE { get; set; }
        public int ESTADO { get; set; }
    }
}
