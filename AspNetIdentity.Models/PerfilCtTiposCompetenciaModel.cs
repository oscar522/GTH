using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class PerfilCtTiposCompetenciaModel
    {
        public int ID_TIPO_COMPET { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Nombre")]
        public string NOMBRE { get; set; }
        public int ESTADO { get; set; }
    }
}
