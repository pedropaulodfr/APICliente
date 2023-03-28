using APICliente.Models;
using Microsoft.EntityFrameworkCore;

namespace APICliente.Context
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
