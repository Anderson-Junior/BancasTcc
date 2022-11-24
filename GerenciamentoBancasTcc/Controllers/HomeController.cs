using GerenciamentoBancasTcc.Data;
using GerenciamentoBancasTcc.Domains.Entities;
using GerenciamentoBancasTcc.Helpers;
using GerenciamentoBancasTcc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoBancasTcc.Controllers
{
    
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Usuario> _userManager;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [Authorize(Roles = RolesHelper.COORDENADOR + "," + RolesHelper.ORIENTADOR + "," + RolesHelper.PROFESSOR + "," + RolesHelper.ADMINISTRADOR)]
        public async Task<IActionResult> Index()
        {
            Usuario user = await _userManager.GetUserAsync(HttpContext.User);

            var result = (from banca in _context.Bancas
                          join orientador in _context.Users on banca.UsuarioId equals orientador.Id
                          join turma in _context.Turmas on banca.TurmaId equals turma.TurmaId
                          join curso in _context.Cursos on turma.CursoId equals curso.CursoId
                          where (banca.UsuarioId == user.Id || _context.UsuariosBancas.Any(x => x.BancaId == banca.BancaId && x.UsuarioId == user.Id)
                            && banca.DataHora > System.DateTime.Now)
                          orderby banca.DataHora
                          select new BancaViewModel
                          {
                              BancaId = banca.BancaId,
                              Curso = curso.Nome,
                              DataHora = banca.DataHora,
                              Orientador = orientador.Nome,
                              Tema = banca.Tema,
                              Turma = turma.Nome,
                              Alunos = banca.AlunosBancas.Select(x => x.Aluno).ToList(),
                              Professores = banca.UsuariosBancas.Select(x => x.Usuarios.Nome).ToList(),
                              Descricao = banca.Descricao,
                              QtdProfBanca = banca.QtdProfBanca
                          }).ToList();

            return View(result);
        }

        [Authorize(Roles = RolesHelper.COORDENADOR + "," + RolesHelper.ADMINISTRADOR)]
        public IActionResult CadastroUsuario()
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
