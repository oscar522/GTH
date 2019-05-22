using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class PerfilCompetenciasModel
    {

        public int ID_PERFI_COMPE { get; set; }
        public int ID_PERFIL { get; set; }
        [Required(ErrorMessage = "No Puede ser vasio")]
        [Display(Name = "COMPETENCIA")]
        public int ID_COMPETENCIA { get; set; }
        public System.DateTime F_INSERTA { get; set; }
        public int USU_INSERTA { get; set; }
        public System.DateTime F_MODIFICA { get; set; }
        public int USU_MODIFICA { get; set; }


    }
}
