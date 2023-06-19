using System;
using System.Collections.Generic;

namespace MendozaMejia_TallerBDExistente.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<FacturaCabecera> FacturaCabeceras { get; set; } = new List<FacturaCabecera>();
}
