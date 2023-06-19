using Microsoft.EntityFrameworkCore;

namespace MendozaMejia_TallerBDExistente.Models
{
    public class AplicationDbContext: DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
        
        }
    }
}
