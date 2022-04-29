using GerenciamentoBancasTcc.Data;
using GerenciamentoBancasTcc.Domains.Entities;
using GerenciamentoBancasTcc.Helpers;
using GerenciamentoBancasTcc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GerenciamentoBancasTcc.Controllers
{
    [Authorize(Roles = RolesHelper.COORDENADOR + "," + RolesHelper.ORIENTADOR)]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Usuario> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<Usuario> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        
        {
            Usuario user = await _userManager.GetUserAsync(HttpContext.User);

            var teste = await _context.UsuariosBancas
                .Include(x => x.Bancas)
                .Include(x => x.Usuarios)
                .Include(x => x.Bancas.Turma)
                .Include(x => x.Bancas.AlunosBancas)
                .Where(x => x.UsuarioId == user.Id)
                .ToListAsync();

            return View(teste);
        }

        public IActionResult cadastroUsuario()
        {
            return View();
        }

        [Authorize(Roles = RolesHelper.COORDENADOR)]
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
