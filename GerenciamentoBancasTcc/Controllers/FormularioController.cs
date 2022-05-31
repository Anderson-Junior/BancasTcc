using GerenciamentoBancasTcc.Data;
using GerenciamentoBancasTcc.Domains.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoBancasTcc.Controllers
{
    public class FormularioController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Usuario> _userManager;


        public FormularioController(ApplicationDbContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Formulario
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Formularios.Include(f => f.Curso);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Formulario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulario = await _context.Formularios
                .Include(f => f.Curso)
                .FirstOrDefaultAsync(m => m.FormularioId == id);
            if (formulario == null)
            {
                return NotFound();
            }

            return View(formulario);
        }

        // GET: Formulario/Create
        public IActionResult Create()
        {
            TipoQuestao();
            ViewData["CursoId"] = new SelectList(_context.Cursos, "CursoId", "Nome");
            return View();
        }

        // POST: Formulario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FormularioId,Nome,CursoId")] Formulario formulario/*, List<Questao> questoes*/)
        {
            Usuario user = await _userManager.GetUserAsync(HttpContext.User);
            if (ModelState.IsValid)
            {
                formulario.UsuarioId = user.Id;
                _context.Add(formulario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "CursoId", "Nome", formulario.CursoId);
            return View(formulario);
        }

        // GET: Formulario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulario = await _context.Formularios.FindAsync(id);
            if (formulario == null)
            {
                return NotFound();
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "CursoId", "Nome", formulario.CursoId);
            return View(formulario);
        }

        // POST: Formulario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FormularioId,Nome,CursoId")] Formulario formulario)
        {
            if (id != formulario.FormularioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formulario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormularioExists(formulario.FormularioId))
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
            ViewData["CursoId"] = new SelectList(_context.Cursos, "CursoId", "Nome", formulario.CursoId);
            return View(formulario);
        }

        // GET: Formulario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formulario = await _context.Formularios
                .Include(f => f.Curso)
                .FirstOrDefaultAsync(m => m.FormularioId == id);
            if (formulario == null)
            {
                return NotFound();
            }

            return View(formulario);
        }

        // POST: Formulario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formulario = await _context.Formularios.FindAsync(id);
            _context.Formularios.Remove(formulario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormularioExists(int id)
        {
            return _context.Formularios.Any(e => e.FormularioId == id);
        }

        private void TipoQuestao(int selectedItem = 0)
        {
            var tipoQuestoes = _context.TipoQuestoes.ToList();
            var selectListItems = tipoQuestoes.ToDictionary(x => x.TipoQuestaoId.ToString(), y => y.Descricao).ToList();
            selectListItems.Insert(0, new KeyValuePair<string, string>("", ""));
            ViewData["TipoQuestaoId"] = new SelectList(selectListItems, "Key", "Value", selectedItem);
        }
    }
}
