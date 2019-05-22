using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class PerfilCtAreaModel
    {
        public int ID_CT_AREA { get; set; }
        [Display(Name = "NOMBRE AREA")]
        [Required(ErrorMessage = "Debe ingresar una Descripcion")]
        public string DESCRIPCION { get; set; }
        public int ESTADO { get; set; }
    }
}
