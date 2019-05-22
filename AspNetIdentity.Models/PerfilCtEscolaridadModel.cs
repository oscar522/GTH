using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class PerfilCtEscolaridadModel
    {
        public int ID_ESCOLARIDAD { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Nombre")]
        public string NOMBRE { get; set; }
        public int ESTADO { get; set; }
    }
}
