using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoBancasTcc.Controllers
{
    public class AvaliacaoController : Controller
    {
        public IActionResult AvaliacaoApresentacao()
        {
            return View("avaliacaoApresentacao");
        }

        public IActionResult AvaliacaoArtigo1()
        {
            return View("avaliacaoArtigo1");
        }

        public IActionResult AvaliacaoArtigo2()
        {
            return View("avaliacaoArtigo2");
        }
    }
}
