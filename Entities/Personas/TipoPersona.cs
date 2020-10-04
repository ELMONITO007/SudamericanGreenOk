using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class TipoPersona :EntityBase
    {
        public override int Id { get; set; }

        [Required]
        [DisplayName("Tipo")]
        [DataType(DataType.Text,ErrorMessage ="Solo Ingrese texto")]
        public string tipoPersona { get; set; }




    }
}
