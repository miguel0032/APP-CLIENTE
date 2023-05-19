using System;
using System.Collections.Generic;

namespace Quimera.Models
{
    public partial class Direccion
    {
        public int Id { get; set; }
        public string? Calle { get; set; }
        public string? Ciudad { get; set; }
        public string? CodigoPostal { get; set; }
        public string? Pais { get; set; }
        public int? ClienteId { get; set; }

        public virtual Cliente? Cliente { get; set; }
    }
}
