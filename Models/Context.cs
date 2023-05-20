using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Tratamento.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
