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

        // GET: Filial
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Filiais.Include(f => f.Instituicao);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Filial/Details/5
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

        // GET: Filial/Create
        public IActionResult Create()
        {
            ViewData["InstituicaoId"] = new SelectList(_context.Instituicoes, "InstituicaoId", "Nome");
            return View();
        }

        // POST: Filial/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Filial/Edit/5
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

        // POST: Filial/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Filial/Delete/5
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

        // POST: Filial/Delete/5
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
