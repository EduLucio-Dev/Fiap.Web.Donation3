using Fiap.Web.Donation3.Data;
using Fiap.Web.Donation3.Models;

namespace Fiap.Web.Donation3.Repository
{
    public class CategoriaRepository
    {

        //DataContext c = new DataContext();  <<--- O código abaixo representa algo parecido com esse linha
        private readonly DataContext _dataContext;
        public CategoriaRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }




        // Listar
        public List<CategoriaModel> FindAll()
        {
            var categorias = _dataContext.Categorias.ToList();
            return categorias == null ? new List<CategoriaModel>() : categorias;
        }


        // Detalhe
        public CategoriaModel FindById(int id)
        {
            return _dataContext.Categorias.Find(id);
        }


        // Insert
        public int Insert(CategoriaModel categoriaModel)
        {
            _dataContext.Categorias.Add(categoriaModel);
            _dataContext.SaveChanges();

            return categoriaModel.CategoriaId;
        }


        // Update 
        public void Update(CategoriaModel categoriaModel)
        {
            _dataContext.Categorias.Update(categoriaModel);
            _dataContext.SaveChanges();
        }


        // Delete
        public void Delete(int id)
        {
            var categoria = new CategoriaModel()
            {
                CategoriaId = id
            };

            _dataContext.Categorias.Remove(categoria);
            _dataContext.SaveChanges();

        }



    }
}