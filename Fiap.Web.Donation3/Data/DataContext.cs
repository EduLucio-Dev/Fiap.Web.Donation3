using Fiap.Web.Donation3.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Donation3.Data
{
    public class DataContext : DbContext
    {
        public DbSet<CategoriaModel> Categorias { get; set; }

        public DbSet<UsuarioModel> Usuarios { get; set; }

        public DbSet<ProdutoModel> Produtos { get; set; }


        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected DataContext()
        {
        }
    }
}
