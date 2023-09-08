using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{

    public class Paciente
    {
        [Key]
        public int IdPaciente {get; set;}

        [StringLength(70, ErrorMessage = "No es posible introducir mas de 70 carácteres en el nombre")]
        [Required (ErrorMessage = "Debe ingresar un nombre")]
        public string Nombre {get; set;}


        [Required (ErrorMessage = "Debe ingresar un apellido")]
        public string Apellido {get; set;}

        [Display(Name = "Dirección")]
        [Required (ErrorMessage = "Debe ingresar una dirección ")]
        public string Direccion {get; set;}

        [Display(Name = "Teléfono")]
        [Required (ErrorMessage = "Debe ingresar un teléfono")]
        public string Telefono {get; set;}

        [Required (ErrorMessage = "Debe ingresar un email")]
        [EmailAddress(ErrorMessage = "No es una dirección de email válida")]
        public string Email {get; set;}
        public List<Turno> Turno { get; set; }
    }
}