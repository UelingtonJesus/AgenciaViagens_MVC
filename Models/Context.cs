using Microsoft.EntityFrameworkCore;

namespace App1.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set;}
        public DbSet<Destino> Destino { get; set;}
        public DbSet<Comprar> Compra { get; set;}
        public DbSet<Contato> Contatos { get; set;}
    }
}
