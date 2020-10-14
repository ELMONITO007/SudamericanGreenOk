using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class EquipoCliente : EntityBase
    {
        public override int Id { get; set; }

        [Required(ErrorMessage = "Campo {0} vacio")]
        [DisplayName("Numero de serie")]

        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "ingresar solo letras")]
        [StringLength(40, ErrorMessage = "El maximo de caracteres es de 40")]
        [MinLength(2, ErrorMessage = "El minimo de caracteres es de 2")]
        public string serial { get; set; }


        [Required(ErrorMessage = "Campo {0} vacio")]
        [DisplayName("Fecha de Compra")]
        [DataType(DataType.Date)]
        public DateTime fechaCompra { get; set; }


        [Required(ErrorMessage = "Campo {0} vacio")]
        [DisplayName("Peso en KG")]
        [Range(1, 1000000, ErrorMessage = "El peso debe estar entre 1 y 1000000 KiloGramos ")]

        public int peso { get; set; }

        [Required(ErrorMessage = "Campo {0} vacio")]
        [DisplayName("Antiguedad")]
        [Range(0, 50, ErrorMessage = "La antiguedad debe estar entre 0 y 50 Años ")]
        public int antiguedad { get; set; }

        [Required(ErrorMessage = "Campo {0} vacio")]
        [DisplayName("Modelo")]

        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "ingresar solo letras")]
        [StringLength(20, ErrorMessage = "El maximo de caracteres es de 20")]
        [MinLength(2, ErrorMessage = "El minimo de caracteres es de 2")]
        public string modelo { get; set; }

        public Persona persona { get; set; }
        public TipoEquipo tipoEquipo { get; set; }
        public List<TipoEquipo> listaTipoEquipo { get; set; }
        public EquipoCliente equipoCliente { get; set; }
        public Marca marca { get; set; }
        public List<Marca> listaMarca { get; set; }
        public EquipoCliente()
        {

            persona = new Persona();
            tipoEquipo = new TipoEquipo();
            listaTipoEquipo = new List<TipoEquipo>();
            marca = new Marca();
            listaMarca = new List<Marca>();

        }

    }
}
