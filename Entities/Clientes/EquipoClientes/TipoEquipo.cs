﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
   public class TipoEquipo :EntityBase
    {

        public override int Id { get; set; }

        [Required(ErrorMessage ="Campo {0} vacio")]
        [DisplayName("Tipo de Equipo")]

        [RegularExpression(@"[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙ.-]+", ErrorMessage = "ingresar solo letras")]
        [StringLength(20, ErrorMessage = "El maximo de caracteres es de 20")]
        [MinLength(2, ErrorMessage = "El minimo de caracteres es de 2")]
        public string tipoEquipo { get; set; }

        [Required(ErrorMessage = "Campo {0} vacio")]
        [DisplayName("Descripcion")]
        [RegularExpression(@"[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙ.-]+", ErrorMessage = "ingresar solo letras")]
        [StringLength(60, ErrorMessage = "El maximo de caracteres es de 60")]
        [MinLength(2, ErrorMessage = "El minimo de caracteres es de 2")]
        public string descripcion { get; set; }


    }
}
