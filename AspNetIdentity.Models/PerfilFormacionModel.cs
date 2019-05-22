using System.ComponentModel.DataAnnotations;

namespace AspNetIdentity.Models
{
    public class PerfilFormacionModel
    {
        public int ID_FORMACION { get; set; }
        [Display(Name = "PERFIL")]
        [Required(ErrorMessage = "Debe ingresar un Perfil")]
        public int ID_PERFIL { get; set; }
        [Display(Name = "ESCOLARIDAD")]
        [Required(ErrorMessage = "Debe ingresar un Escolaridad")]
        public int ID_ESCOLARIDAD { get; set; }
        [Display(Name = "ESCOLARIDAD")]
        public string NombreEscolaridad { get; set; }
        [Display(Name = "ESPECIALIDAD")]
        [Required(ErrorMessage = "Debe ingresar un Especialidad")]
        public int ID_ESPECIALIDAD { get; set; }
        [Display(Name = "ESPECIALIDAD")]
        public string NombreEspecialidad { get; set; }
        [Required(ErrorMessage = "Experiencia no puede estar vacio")]
        public string EXPERIENCIA { get; set; }
        public int ESTADO { get; set; }


    }
}
