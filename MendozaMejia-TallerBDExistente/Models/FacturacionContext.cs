using Microsoft.EntityFrameworkCore;

namespace MendozaMejia_TallerBDExistente.Models
{
    public class FacturacionContext : DbContext
    {
        public FacturacionContext() 
        {
        }

        public FacturacionContext(DbContextOptions<FacturacionContext> options) : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Tipo> Tipos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<FacturaCabecera> FacturaCabeceras { get; set; }
        public virtual DbSet<FacturaDetalle> FacturaDetalles { get; set; }
    }
}
