﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class DireccionPersona :EntityBase
    {
        public override int Id { get; set; }
        public Direccion direccion { get; set; }
        public Persona persona { get; set; }
        public List<DireccionPersona> direccionPersona { get; set; }

        public DireccionPersona()
        {
            direccion = new Direccion();
            persona = new Persona();
        }
    }
}
