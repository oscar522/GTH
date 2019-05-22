using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class PerfilCtCompetenciasModel
    {
        public int ID_CT_COMPETENCIA { get; set; }
        [Display(Name = "TIPO DE COMPETENCIA")]
        public int ID_TIPO_COMPET { get; set; }
        [Display(Name = "TIPO DE COMPETENCIA")]
        public string NOMBRE_COMPET { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Nombre")]
        public string NOMBRE { get; set; }
        [Required(ErrorMessage = "Debe ingresar una Descripcion")]
        public string DESCRIPCION { get; set; }
        public int ESTADO { get; set; }
    }
}
