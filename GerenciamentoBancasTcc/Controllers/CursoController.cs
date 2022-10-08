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
    public class CursoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CursoController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cursos.Include(c => c.Filial);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos
                .Include(c => c.Filial)
                .FirstOrDefaultAsync(m => m.CursoId == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        public IActionResult Create()
        {
            ViewData["FilialId"] = new SelectList(_context.Filiais, "FilialId", "Campus");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CursoId,Nome,Periodos,Ativo,FilialId")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(curso);
                    await _context.SaveChangesAsync();
                    TempData["mensagemSucesso"] = string.Format("Curso {0} cadastrado com sucesso!", curso.Nome);
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    TempData["mensagemErro"] = "Erro ao cadastrar o curso! " + ex.Message;
                }
            }
            ViewData["FilialId"] = new SelectList(_context.Filiais, "FilialId", "Campus", curso.FilialId);
            return View(curso);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            ViewData["FilialId"] = new SelectList(_context.Filiais, "FilialId", "Campus", curso.FilialId);
            return View(curso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CursoId,Nome,Periodos,Ativo,FilialId")] Curso curso)
        {
            if (id != curso.CursoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                    TempData["mensagemSucesso"] = string.Format("Curso {0} atualizado com sucesso!", curso.Nome);
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!CursoExists(curso.CursoId))
                    {
                        TempData["mensagemErro"] = "Este curso não está o no sistema!";
                        return NotFound();
                    }
                    else
                    {
                        TempData["mensagemErro"] = "Erro ao atualizar o curso! " + ex.Message;
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilialId"] = new SelectList(_context.Filiais, "FilialId", "Campus", curso.FilialId);
            return View(curso);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos
                .Include(c => c.Filial)
                .FirstOrDefaultAsync(m => m.CursoId == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            try
            {
                _context.Cursos.Remove(curso);
                await _context.SaveChangesAsync();
                TempData["mensagemSucesso"] = string.Format("Curso {0} excluído com sucesso!", curso.Nome);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex) 
            {
                TempData["mensagemErro"] = "Erro ao excluir o curso! " + ex.Message;
            }
            return View(curso);
        }

        private bool CursoExists(int id)
        {
            return _context.Cursos.Any(e => e.CursoId == id);
        }
    }
}
