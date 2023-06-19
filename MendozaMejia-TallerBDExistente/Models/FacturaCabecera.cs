using System;
using System.Collections.Generic;

namespace MendozaMejia_TallerBDExistente.Models;

public partial class FacturaCabecera
{
    public int FacturaCabeceraId { get; set; }

    public DateTime? Fecha { get; set; }

    public double? Total { get; set; }

    public int? ClienteId { get; set; }

    public bool? Estado { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<FacturaDetalle> FacturaDetalles { get; set; } = new List<FacturaDetalle>();
}
