using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class PerfilRelacionesModel
    {
        public int ID_RELACION { get; set; }
        [Display(Name = "PERFIL")]
        [Required(ErrorMessage = "Debe ingresar un Perfil")]
        public int ID_PERFIL { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Tipo")]
        public int TIPO { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Nombre")]
        public string NOMBRE { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Motivo")]
        public string MOTIVO { get; set; }
        public int ESTADO { get; set; }

    }
}
