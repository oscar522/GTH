using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class PerfilModel
    {
        public int ID_PERFIL { get; set; }
        [Display(Name = "AREA")]
        [Required(ErrorMessage = "Debe ingresar un Area")]
        public int ID_CT_AREA { get; set; }
        [Display(Name = "AREA")]
        public string NombreArea { get; set; }
        [Display(Name = "SUB AREA")]
        [Required(ErrorMessage = "Debe ingresar un Sub Area")]
        public int ID_CT_SUB_AREA { get; set; }
        [Display(Name = "SUB AREA")]
        public string NombreSubArea { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Nombre")]
        public string NOMBRE { get; set; }
        [Display(Name = "PERFIL REPORTA")]
        public int REPORTA { get; set; }
        [Display(Name = "REPORTA A")]
        public string NombreReporta { get; set; }
        public int SUPERVISA { get; set; }
        [Display(Name = "PERFIL SUPERVISA")]
        public string NombreSupervisa { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Objetivo")]
        public string OBJETIVO { get; set; }
        public int ESTADO { get; set; }


    }
}
