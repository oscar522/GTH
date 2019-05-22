using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class PerfilCtSubAreaModel
    {
        public int ID_CT_SUB_AREA { get; set; }
        [Required(ErrorMessage = "Debe ingresar el Area")]
        [Display(Name = "AREA")]
        public int ID_CT_AREA { get; set; }
        [Required(ErrorMessage = "Debe ingresar una Descripcion")]
        public string DESCRIPCION { get; set; }//NombreArea
        [Display(Name = "AREA")]
        public string NombreArea { get; set; }//NombreArea
        public int ESTADO { get; set; }
    }
}
