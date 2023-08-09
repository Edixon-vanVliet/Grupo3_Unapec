using Grupo3_Unapec.Presentation.Models;
using Microsoft.EntityFrameworkCore;

namespace Grupo3_Unapec.Presentation.data
{
    public class TitulacionContext : DbContext
    {
        public TitulacionContext(DbContextOptions<TitulacionContext> options) : base(options)
        {
        }
        public DbSet<Titulacion> Titulaciones { get; set; }
    }
}
