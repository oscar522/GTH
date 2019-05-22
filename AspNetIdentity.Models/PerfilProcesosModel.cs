using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class PerfilProcesosModel
    {
        public int ID_PROCESO { get; set; }
        [Display(Name = "PERFIL")]
        [Required(ErrorMessage = "Debe ingresar un Perfil")]
        public int ID_PERFIL { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Nombre")]
        public string NOMBRE { get; set; }
        [Required(ErrorMessage = "Debe ingresar una Descripcion")]
        public string DESCRIPCION { get; set; }
        public System.DateTime F_INSERTA { get; set; }
        public int USU_INSERTA { get; set; }
        public System.DateTime F_MODIFICA { get; set; }
        public int USU_MODIFICA { get; set; }


    }
}
