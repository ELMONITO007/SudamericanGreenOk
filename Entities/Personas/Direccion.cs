using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
 public  class Direccion :EntityBase
    {
        public override int Id { get; set; }

        [Required]
        [DisplayName("Direccion")]
        [DataType(DataType.Text, ErrorMessage = "Solo Ingrese texto")]
        public string direccion { get; set; }

        [Required]
        [DisplayName("Numero")]
        [Range(1, 99999, ErrorMessage = "Colocar numeros del 1 al 99999")]

        public int numero { get; set; }

        [Required]
        [DisplayName("Piso")]
        [Range(1, 99, ErrorMessage = "Colocar numeros del 1 al 99")]
        public int piso { get; set; }

        [Required]
        public string departamento { get; set; }
        [Required]
        [DisplayName("Departamento")]
        [DataType(DataType.Text, ErrorMessage = "Solo Ingrese texto")]
        public string localidad { get; set; }


        [Required]
        [DisplayName("Codigo Postal")]
        [Range(1, 9999, ErrorMessage = "Colocar numeros del 1 al 9999")]
        public int codigoPostal { get; set; }

        [Required]
        [DisplayName("Provincia")]
        [DataType(DataType.Text, ErrorMessage = "Solo Ingrese texto")]
        public string provincia { get; set; }
    }
}
