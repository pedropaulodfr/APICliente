using ClientesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientesAPI.Context
{

    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
