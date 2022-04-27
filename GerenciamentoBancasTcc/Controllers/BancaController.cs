using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciamentoBancasTcc.Data;
using GerenciamentoBancasTcc.Domains.Entities;
using Microsoft.AspNetCore.Identity;

namespace GerenciamentoBancasTcc.Controllers
{
    public class BancaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Usuario> _userManager;

        public BancaController(ApplicationDbContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Bancas
                .Include(x => x.Turma)
                .Include(x => x.Usuario)
                .ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banca = await _context.Bancas
                .Include(x => x.Turma)
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(m => m.BancaId == id);
            if (banca == null)
            {
                return NotFound();
            }

            return View(banca);
        }

        public IActionResult Create()
        {
            GetCursos();
            GetOrientador();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BancaId,TurmaId,Tema,UsuarioId,DataHora,Sala,Descricao")] Banca banca, string alunosBanca)
        {
            if (ModelState.IsValid)
            {
                banca.AlunosBancas = alunosBanca.Split(',').Select(x => new AlunosBancas { AlunoId = int.Parse(x) }).ToList();
                _context.Add(banca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            GetCursos(banca.BancaId);
            GetOrientador(banca.BancaId);
            ViewData["AlunosBanca"] = alunosBanca;

            return View(banca);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            Banca banca = null;

            if (id.HasValue)
            {
                banca = await _context.Bancas.Include(x => x.AlunosBancas).FirstOrDefaultAsync(x => x.BancaId == id.Value);
            }

            if (banca == null)
            {
                return NotFound();
            }

            GetOrientador(banca.BancaId);
            GetTurmasEdit(banca.BancaId);
            ViewData["AlunosBanca"] = string.Join(',', banca.AlunosBancas.Select(x => x.AlunoId));

            return View(banca);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BancaId,TurmaId,Tema,UsuarioId,DataHora,Sala,Descricao")] Banca banca, string alunosBanca)
        {
            if (id != banca.BancaId || !BancaExists(banca.BancaId))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.AlunosBancas.RemoveRange(_context.AlunosBancas.Where(x => x.BancaId == banca.BancaId));

                    if (!string.IsNullOrWhiteSpace(alunosBanca))
                    {
                        _context.AlunosBancas.AddRange(alunosBanca.Split(',').Select(x => new AlunosBancas { AlunoId = int.Parse(x), BancaId = banca.BancaId }));
                    }

                    _context.Update(banca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            GetOrientador(banca.BancaId);
            GetTurmasEdit(banca.BancaId);
            ViewData["AlunosBanca"] = alunosBanca;

            return View(banca);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banca = await _context.Bancas
                .Include(x => x.Turma)
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(m => m.BancaId == id);
            if (banca == null)
            {
                return NotFound();
            }

            return View(banca);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var banca = await _context.Bancas.FindAsync(id);
            _context.Bancas.Remove(banca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public JsonResult GetAlunos(int turmaId)
        {
            var alunos = from aluno in _context.Alunos
                         where aluno.TurmaId == turmaId && aluno.Ativo
                         select new
                         {
                             label = aluno.Nome,
                             value = aluno.AlunoId.ToString()
                         };

            return Json(alunos.ToArray());
        }

        [HttpGet]
        public JsonResult GetTurmas(int cursoId)
        {
            var turmas = from turma in _context.Turmas
                         where turma.CursoId == cursoId && turma.Ativo
                         select new
                         {
                             label = turma.Nome,
                             value = turma.TurmaId
                         };

            return Json(turmas.ToArray());
        }

        private bool BancaExists(int id)
        {
            return _context.Bancas.Any(e => e.BancaId == id);
        }

        private void GetCursos(int selectedItem = 0)
        {
            var cursos = _context.Cursos.Where(x => x.Ativo == true).ToList();
            var selectListItems = cursos.ToDictionary(x => x.CursoId.ToString(), y => y.Nome).ToList();
            selectListItems.Insert(0, new KeyValuePair<string, string>("", ""));
            ViewData["CursoId"] = new SelectList(selectListItems, "Key", "Value", selectedItem);
        }

        private void GetOrientador(int selectedItem = 0)
        {
            var orientadores = _userManager.Users.ToList();
            var selectListItems = orientadores.ToDictionary(x => x.Id.ToString(), y => y.Nome).ToList();
            selectListItems.Insert(0, new KeyValuePair<string, string>("", ""));
            ViewData["UsuarioId"] = new SelectList(selectListItems, "Key", "Value", selectedItem);
        }

        private void GetTurmasEdit(int selectedItem = 0)
        {
            var turmas = _context.Turmas.Where(x => x.Ativo == true).ToList();
            var selectListItems = turmas.ToDictionary(x => x.TurmaId.ToString(), y => y.Nome).ToList();
            selectListItems.Insert(0, new KeyValuePair<string, string>("", ""));
            ViewData["TurmaId"] = new SelectList(selectListItems, "Key", "Value", selectedItem);
        }
    }
}