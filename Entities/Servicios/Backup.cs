
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities
{
 public   class Backups :EntityBase
    {
        public string Nombre { get; set; }
        public string Fecha { get; set; }
        public override int Id { get ; set ; }

    }
}
