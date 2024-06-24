using System.ComponentModel.DataAnnotations;

namespace CRUD_MVC_EF.Models
{
    public class Contacto
    {
        [Key] //Si tiene la palabra Id entity framewor detecta que es una clave primaria automaticamente
        //pero se pued ecolocar explicitamete que es una key
        public int IdContacto { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El telefono es obligatorio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El email es obligatorio")]
        public string Email { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
