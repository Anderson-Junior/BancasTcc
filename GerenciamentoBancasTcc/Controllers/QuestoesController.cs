using GerenciamentoBancasTcc.Data;
using GerenciamentoBancasTcc.Domains.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoBancasTcc.Controllers
{
    public class QuestoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Questoes
                .Include(q => q.Formulario)
                .Include(x => x.TipoQuestao);

            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questao = await _context.Questoes
                .Include(q => q.Formulario)
                .Include(x => x.TipoQuestao)
                .FirstOrDefaultAsync(m => m.QuestaoId == id);
            if (questao == null)
            {
                return NotFound();
            }

            return View(questao);
        }

        public IActionResult Create()
        {
            ViewData["TipoQuestaoId"] = new SelectList(_context.TipoQuestoes, "TipoQuestaoId", "Descricao");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuestaoId,Pergunta,TipoQuestaoId")] Questao questao)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(questao);
                    await _context.SaveChangesAsync();
                    TempData["mensagemSucesso"] = string.Format("Questão cadastrada com sucesso!");

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["mensagemErro"] = "Erro ao cadastrar a Questão! " + ex.Message;
                }
            }
            ViewData["TipoQuestaoId"] = new SelectList(_context.TipoQuestoes, "TipoQuestaoId", "Descricao", questao.TipoQuestaoId);
            return View(questao);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questao = await _context.Questoes.FindAsync(id);
            if (questao == null)
            {
                return NotFound();
            }
            ViewData["TipoQuestaoId"] = new SelectList(_context.TipoQuestoes, "TipoQuestaoId", "Descricao", questao.TipoQuestaoId);
            return View(questao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuestaoId,Pergunta,TipoQuestaoId")] Questao questao)
        {
            if (id != questao.QuestaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questao);
                    await _context.SaveChangesAsync();
                    TempData["mensagemSucesso"] = string.Format("Questão editada com sucesso!");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!QuestaoExists(questao.QuestaoId))
                    {
                        TempData["mensagemErro"] = "Esta questão não está cadastrada no sistema!";
                        return NotFound();
                    }
                    else
                    {
                        TempData["mensagemErro"] = "Erro ao atualizar questão! " + ex.Message;
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoQuestaoId"] = new SelectList(_context.TipoQuestoes, "TipoQuestaoId", "Descricao", questao.TipoQuestaoId);
            return View(questao);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questao = await _context.Questoes
                .Include(q => q.Formulario)
                .Include(x => x.TipoQuestao)
                .FirstOrDefaultAsync(m => m.QuestaoId == id);
            if (questao == null)
            {
                return NotFound();
            }

            return View(questao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questao = await _context.Questoes.FindAsync(id);
            try
            {
                _context.Questoes.Remove(questao);
                await _context.SaveChangesAsync();

                TempData["mensagemSucesso"] = string.Format("Questão excluída com sucesso!");
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                TempData["mensagemErro"] = "Erro ao excluir questão " + ex.Message;
            }
            return View(questao);
        }

        private bool QuestaoExists(int id)
        {
            return _context.Questoes.Any(e => e.QuestaoId == id);
        }
    }
}
