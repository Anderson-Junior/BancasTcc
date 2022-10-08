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
    public class FilialController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FilialController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Filiais.Include(f => f.Instituicao);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filial = await _context.Filiais
                .Include(f => f.Instituicao)
                .FirstOrDefaultAsync(m => m.FilialId == id);
            if (filial == null)
            {
                return NotFound();
            }

            return View(filial);
        }

        public IActionResult Create()
        {
            ViewData["InstituicaoId"] = new SelectList(_context.Instituicoes, "InstituicaoId", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FilialId,Email,Campus,Cnpj,Telefone,Endereco,Ativo,InstituicaoId")] Filial filial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstituicaoId"] = new SelectList(_context.Instituicoes, "InstituicaoId", "Nome", filial.InstituicaoId);
            return View(filial);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filial = await _context.Filiais.FindAsync(id);
            if (filial == null)
            {
                return NotFound();
            }
            ViewData["InstituicaoId"] = new SelectList(_context.Instituicoes, "InstituicaoId", "Nome", filial.InstituicaoId);
            return View(filial);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FilialId,Email,Campus,Cnpj,Telefone,Endereco,Ativo,InstituicaoId")] Filial filial)
        {
            if (id != filial.FilialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilialExists(filial.FilialId))
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
            ViewData["InstituicaoId"] = new SelectList(_context.Instituicoes, "InstituicaoId", "Nome", filial.InstituicaoId);
            return View(filial);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filial = await _context.Filiais
                .Include(f => f.Instituicao)
                .FirstOrDefaultAsync(m => m.FilialId == id);
            if (filial == null)
            {
                return NotFound();
            }

            return View(filial);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filial = await _context.Filiais.FindAsync(id);
            filial.Ativo = false;
            _context.Filiais.Update(filial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilialExists(int id)
        {
            return _context.Filiais.Any(e => e.FilialId == id);
        }
    }
}
