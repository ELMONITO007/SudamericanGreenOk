using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
 public   class Marca :EntityBase
    {
        public override int Id { get; set; }

        [Required(ErrorMessage = "Campo {0} vacio")]
        [DisplayName("Marca")]

        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "ingresar solo letras")]
        [StringLength(20, ErrorMessage = "El maximo de caracteres es de 20")]
        [MinLength(2, ErrorMessage = "El minimo de caracteres es de 2")]
        public string marca { get; set; }
    }
}
