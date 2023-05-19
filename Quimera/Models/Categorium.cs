using System;
using System.Collections.Generic;

namespace Quimera.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
