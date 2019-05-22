using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class PerfilConocimientoModel
    {

        public int ID_CONOCIMIENTO { get; set; }
        public int ID_PERFIL { get; set; }
        [Required(ErrorMessage = "No Puede ser vasio")]
        public string NOMBRE { get; set; }
        [Required(ErrorMessage = "No Puede ser vasio")]
        public string DESCRIPCION { get; set; }

        public System.DateTime F_INSERTA { get; set; }
        public int USU_INSERTA { get; set; }
        public System.DateTime F_MODIFICA { get; set; }
        public int USU_MODIFICA { get; set; }


    }
}
