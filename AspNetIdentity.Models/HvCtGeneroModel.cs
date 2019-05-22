using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class HvCtGeneroModel
    {
        public int ID_GENERO { get; set; }
        [Required(ErrorMessage = "Debe ingresar el Nombre ")]
        public string NOMBRE { get; set; }
    }
}
