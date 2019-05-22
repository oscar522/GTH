using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class HvCtTipoIdentificacionModel
    {
        public int ID_CT_TIPO_IDENTIFICACION { get; set; }
        [Required(ErrorMessage = "Debe ingresar el Nombre del Tipo de Identificación")]

        public string NOMBRE { get; set; }

    }
}
