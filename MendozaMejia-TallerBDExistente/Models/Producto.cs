using System;
using System.Collections.Generic;

namespace MendozaMejia_TallerBDExistente.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string? Nombre { get; set; }

    public double? PrecioCompra { get; set; }

    public double? PrecioVenta { get; set; }

    public int? Cantidad { get; set; }

    public int? TipoId { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<FacturaDetalle> FacturaDetalles { get; set; } = new List<FacturaDetalle>();

    public virtual Tipo? Tipo { get; set; }
}
