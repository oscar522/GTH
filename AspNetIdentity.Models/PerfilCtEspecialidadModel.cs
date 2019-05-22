using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class PerfilCtEspecialidadModel
    {
        public int ID_ESPECIALIDAD { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Nombre")]
        public string NOMBRE { get; set; }
        public int ESTADO { get; set; }
    }
}
