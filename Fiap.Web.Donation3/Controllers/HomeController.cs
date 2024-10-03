using Fiap.Web.Donation3.Data;
using Fiap.Web.Donation3.Models;
using Fiap.Web.Donation3.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Fiap.Web.Donation3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ProdutoRepository _produtoRepository;
        private readonly CategoriaRepository _categoriaRepository;

        public HomeController(ILogger<HomeController> logger, DataContext dataContext)
        {
            _logger = logger;
            _produtoRepository = new ProdutoRepository(dataContext);
            _categoriaRepository = new CategoriaRepository(dataContext);
        }

        public IActionResult Index()
        {
            var listaProdutos = _produtoRepository.FindAllAvaliable();

            return View(listaProdutos);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
