using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class Persona :EntityBase
    {
        public override int Id { get; set; }
        [Required]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Formato invalido")]
        public string   email { get; set; }

        [Required]
        [DisplayName("Cuil")]
        [Range(20000000000, 30000000000, ErrorMessage = "El cuil debe tener al menos 11 digitos")]
        [StringLength(11, ErrorMessage = "El cuil debe tener al menos 11 digitos")]

        public string cuil { get; set; }


        [Required]
        [DisplayName("Telefono")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Formato invalido")]
        public string telefono { get; set; }
        public Usuarios usuarios { get; set; }
        public List<TipoPersona> listaTipoPersona { get; set; }
        public TipoPersona tipoPersona { get; set; }
        public Direccion Direccion = new Direccion();
        public Persona()
        {
            usuarios = new Usuarios();
            listaTipoPersona = new List<TipoPersona>();
            tipoPersona = new TipoPersona();
            Direccion = new Direccion();
        }
    }
}
