﻿using System;
using System.Collections.Generic;

namespace MendozaMejia_TallerBDExistente.Models;

public partial class FacturaDetalle
{
    public int FacturaDetalleId { get; set; }

    public int? Cantidad { get; set; }

    public double? PrecioUnitario { get; set; }

    public double? Total { get; set; }

    public int? ProductoId { get; set; }

    public int? FacturaCabeceraId { get; set; }

    public bool? Estado { get; set; }

    public virtual FacturaCabecera? FacturaCabecera { get; set; }

    public virtual Producto? Producto { get; set; }
}
