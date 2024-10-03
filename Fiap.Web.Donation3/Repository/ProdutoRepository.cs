using Fiap.Web.Donation3.Data;
using Fiap.Web.Donation3.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.Donation3.Repository
{
    public class ProdutoRepository
    {

        private readonly DataContext _dataContext;
        public ProdutoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public List<ProdutoModel> FindAll()
        {
            var Produtos = _dataContext.Produtos.AsNoTracking().ToList();
            return Produtos == null ? new List<ProdutoModel>() : Produtos;
        }


        public ProdutoModel FindById(int id)
        {
            return _dataContext.Produtos.AsNoTracking().SingleOrDefault(p => p.ProdutoId == id);
        }

        public int Insert(ProdutoModel ProdutoModel)
        {
            _dataContext.Produtos.Add(ProdutoModel);
            _dataContext.SaveChanges();

            return ProdutoModel.ProdutoId;
        }


        public void Update(ProdutoModel ProdutoModel)
        {
            _dataContext.Produtos.Update(ProdutoModel);
            _dataContext.SaveChanges();
        }


        public void Delete(int id)
        {


            var Produtos = new ProdutoModel()
            {
                ProdutoId = id
            };

            _dataContext.Produtos.Remove(Produtos);
            _dataContext.SaveChanges();

        }

        public List<ProdutoModel> FindAllAvaliable()
        {
            var Produtos = _dataContext
                            .Produtos
                                .Include(p => p.Usuario)
                                .Include(p => p.Categoria)
                                .Where(p => p.Disponivel == true &&
                                            p.DataExpiracao >= DateTime.Now)
                            .ToList();

            return Produtos == null ? new List<ProdutoModel>() : Produtos;
        }


        public List<ProdutoModel> FindAllAvaliableForChange(int idUsuario)
        {
            var Produtos = _dataContext
                            .Produtos
                                .Include(p => p.Usuario)
                                .Include(p => p.Categoria)
                                .Where(p => p.Disponivel == true &&
                                            p.DataExpiracao >= DateTime.Now &&
                                            p.UsuarioId != idUsuario)
                            .ToList();

            return Produtos == null ? new List<ProdutoModel>() : Produtos;
        }


        public List<ProdutoModel> FindAllAvaliableByUser(int idUsuario)
        {
            var Produtos = _dataContext
                            .Produtos
                                .Include(p => p.Usuario)
                                .Include(p => p.Categoria)
                                .Where(p => p.Disponivel == true &&
                                            p.DataExpiracao >= DateTime.Now &&
                                            p.UsuarioId == idUsuario)
                            .ToList();

            return Produtos == null ? new List<ProdutoModel>() : Produtos;
        }

    }
}