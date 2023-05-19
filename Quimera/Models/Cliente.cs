using System;
using System.Collections.Generic;

namespace Quimera.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Direccions = new HashSet<Direccion>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Telefono { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Cedula { get; set; }
        public string? Empresa { get; set; }
        public int? CategoriaId { get; set; }
        // Propiedad adicional para almacenar el Id como texto
        public string IdTexto { get; set; }

        public virtual Categorium? Categoria { get; set; }
        public virtual ICollection<Direccion> Direccions { get; set; }
    }
}
