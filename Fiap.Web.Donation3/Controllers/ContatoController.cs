using Fiap.Web.Donation3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Donation3.Controllers
{
    public class ContatoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            Console.WriteLine("Metodo Index");
            return View();
        }
        [HttpPost]
        public IActionResult Index(ContatoModel contatoModel)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Help()
        {
            Console.WriteLine("Metodo Help");
            return View();
        }

        [HttpPost]
        public IActionResult Gravar(ContatoModel contatoModel)
        {
            return View();
        }
    }
}
