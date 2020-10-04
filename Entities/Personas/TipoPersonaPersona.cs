using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{ 
 public   class TipoPersonaPersona : EntityBase
    {
        public override int Id { get; set; }
        public Persona persona { get; set; }
        public TipoPersona tipoPersona { get; set; }
        
        public TipoPersonaPersona()
        {
            persona = new Persona();
            tipoPersona = new TipoPersona();

        }
    }
}
