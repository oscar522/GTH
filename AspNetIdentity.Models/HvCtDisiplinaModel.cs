using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class HvCtDisiplinaModel
    {
        [Required(ErrorMessage = "Debe ingresar un Numero de Identificacion de la Disiplina")]
        [Range(0, short.MaxValue, ErrorMessage = "El valor {0} debe ser numérico.")]
        public int ID_CT_DISIPLINA { get; set; }
        [Required(ErrorMessage = "Debe ingresar el Nombre ")]

        public string NOMBRE { get; set; }
        [Required(ErrorMessage = "Debe ingresar el Descripion ")]

        public string DESCRIPCION { get; set; }
    }
}
