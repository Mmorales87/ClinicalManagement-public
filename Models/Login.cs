using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }


[Required(ErrorMessage ="Debe introducir un usuario.")]
        public string Usuario { get; set; }
        

[Required(ErrorMessage ="Debe introducir una contraseña.")]
        public string Password { get; set; }
    }
}