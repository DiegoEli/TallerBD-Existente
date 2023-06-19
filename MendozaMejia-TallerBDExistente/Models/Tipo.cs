using System;
using System.Collections.Generic;

namespace MendozaMejia_TallerBDExistente.Models;

public partial class Tipo
{
    public int TipoId { get; set; }

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
