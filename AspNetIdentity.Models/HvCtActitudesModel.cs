using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class HvCtActitudesModel
    {
        [Required(ErrorMessage = "Debe ingresar el Nombre ")]
        public int ID_ACTITUDES { get; set; }

        public string NOMBRE { get; set; }
    }
}
