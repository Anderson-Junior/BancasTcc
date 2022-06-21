using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciamentoBancasTcc.Data;
using GerenciamentoBancasTcc.Domains.Entities;

namespace GerenciamentoBancasTcc.Controllers
{
    public class AlunoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlunoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Aluno
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Alunos.Include(a => a.Turma);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Aluno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .Include(a => a.Turma)
                .FirstOrDefaultAsync(m => m.AlunoId == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // GET: Aluno/Create
        public IActionResult Create()
        {
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "TurmaId", "Nome");
            GetCursos();
            return View();
        }

        // POST: Aluno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlunoId,Nome,Matricula,Ativo,TurmaId")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                TempData["mensagemSucesso"] = "Aluno cadastrado com sucesso!";

                return RedirectToAction(nameof(Index));
            }
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "TurmaId", "Nome", aluno.TurmaId);
            GetCursos(aluno.AlunoId);
            TempData["mensagemErro"] = "Erro ao cadastrar o aluno!";

            return View(aluno);
        }

        // GET: Aluno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "TurmaId", "Nome", aluno.TurmaId);
            return View(aluno);
        }

        // POST: Aluno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlunoId,Nome,Matricula,Ativo,TurmaId")] Aluno aluno)
        {
            if (id != aluno.AlunoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.AlunoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TurmaId"] = new SelectList(_context.Turmas, "TurmaId", "Nome", aluno.TurmaId);
            return View(aluno);
        }

        // GET: Aluno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Alunos
                .Include(a => a.Turma)
                .FirstOrDefaultAsync(m => m.AlunoId == id);
            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        // POST: Aluno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoExists(int id)
        {
            return _context.Alunos.Any(e => e.AlunoId == id);
        }

        private void GetCursos(int selectedItem = 0)
        {
            var cursos = _context.Cursos.Where(x => x.Ativo == true).ToList();
            var selectListItems = cursos.ToDictionary(x => x.CursoId.ToString(), y => y.Nome).ToList();
            selectListItems.Insert(0, new KeyValuePair<string, string>("", ""));
            ViewData["CursoId"] = new SelectList(selectListItems, "Key", "Value", selectedItem);
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
    }
}
