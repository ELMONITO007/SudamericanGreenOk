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

        [DisplayName("Direccion")]
        [Required]
        
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "ingresar solo letras")]
        [StringLength(20, ErrorMessage = "El maximo de caracteres es de 20")]
        [MinLength(2, ErrorMessage = "El minimo de caracteres es de 2")]
        public string direccion { get; set; }

        [Required]
        [DisplayName("Numero")]
        [Range(1, 99999, ErrorMessage = "Colocar numeros del 1 al 99999")]

        public int numero { get; set; }

    
        [DisplayName("Piso")]
        [Range(0, 99, ErrorMessage = "Colocar numeros del 1 al 99")]
        public int piso { get; set; }


        [DisplayName("Departamento")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "ingresar solo letras")]
        [StringLength(3, ErrorMessage = "El maximo de caracteres es de 20")]
        
        public string departamento { get; set; }

        [Required]
        [DisplayName("Localidad")]
        [DataType(DataType.Text, ErrorMessage = "Solo Ingrese texto")]
        public string localidad { get; set; }


        [Required]
        [DisplayName("Codigo Postal")]
        [Range(1, 9999, ErrorMessage = "Colocar numeros del 1 al 9999")]
        public int codigoPostal { get; set; }

        [Required]
        [DisplayName("Provincia")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "ingresar solo letras")]
        [StringLength(20, ErrorMessage = "El maximo de caracteres es de 20")]
        [MinLength(2, ErrorMessage = "El minimo de caracteres es de 2")]
        public string provincia { get; set; }
    }
}
