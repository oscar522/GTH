using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class HvCtCargoModel
    {
        public int ID_CT_CARGO { get; set; }
        [Required(ErrorMessage = "Debe ingresar el Nombre ")]

        public string NOMBRE { get; set; }
        [Required(ErrorMessage = "Debe ingresar el Descripion ")]

        public string DESCRIPCION { get; set; }
    }
}
