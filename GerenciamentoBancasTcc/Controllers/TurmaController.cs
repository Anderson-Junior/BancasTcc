using GerenciamentoBancasTcc.Data;
using GerenciamentoBancasTcc.Domains.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoBancasTcc.Controllers
{
    public class TurmaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TurmaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Turmas.Include(t => t.Curso);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turmas
                .Include(t => t.Curso)
                .FirstOrDefaultAsync(m => m.TurmaId == id);
            if (turma == null)
            {
                return NotFound();
            }

            return View(turma);
        }

        public IActionResult Create()
        {
            ViewData["CursoId"] = new SelectList(_context.Cursos, "CursoId", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TurmaId,Nome,Ativo,CursoId")] Turma turma)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(turma);
                    await _context.SaveChangesAsync();
                    TempData["mensagemSucesso"] = string.Format("Turma {0} cadastrada com sucesso!", turma.Nome);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["mensagemErro"] = "Erro ao cadastrar a turma! " + ex.Message;
                }
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "CursoId", "Nome", turma.CursoId);
            return View(turma);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turmas.FindAsync(id);
            if (turma == null)
            {
                return NotFound();
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "CursoId", "Nome", turma.CursoId);
            return View(turma);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TurmaId,Nome,Ativo,CursoId")] Turma turma)
        {
            if (id != turma.TurmaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turma);
                    await _context.SaveChangesAsync();
                    TempData["mensagemSucesso"] = string.Format("Turma {0} atualizada com sucesso!", turma.Nome);
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!TurmaExists(turma.TurmaId))
                    {
                        TempData["mensagemErro"] = "Esta turma não está cadastrada no sistema!";
                        return NotFound();
                    }
                    else
                    {
                        TempData["mensagemErro"] = "Erro ao atualizar a turma! " + ex.Message;
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "CursoId", "Nome", turma.CursoId);
            return View(turma);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turma = await _context.Turmas
                .Include(t => t.Curso)
                .FirstOrDefaultAsync(m => m.TurmaId == id);
            if (turma == null)
            {
                return NotFound();
            }

            return View(turma);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turma = await _context.Turmas.FindAsync(id);
            try
            {
                _context.Turmas.Remove(turma);
                await _context.SaveChangesAsync();
                TempData["mensagemSucesso"] = string.Format("Turma {0} excluída com sucesso!", turma.Nome);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                TempData["mensagemErro"] = "Erro ao excluir a turma! " + ex.Message;
            }
            return View(turma);
        }

        private bool TurmaExists(int id)
        {
            return _context.Turmas.Any(e => e.TurmaId == id);
        }
    }
}
