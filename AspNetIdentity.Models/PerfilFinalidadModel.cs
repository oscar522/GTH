using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class PerfilFinalidadModel
    {
        public int ID_FINALIDAD { get; set; }
        public int ID_PERFIL { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Accion")]
        public string ACCION { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Funcion")]
        public string FUNCION { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Resultado")]
        public string RESULTADOS { get; set; }



    }
}
