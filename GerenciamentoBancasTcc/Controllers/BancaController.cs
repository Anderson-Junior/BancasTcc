using GerenciamentoBancasTcc.Data;
using GerenciamentoBancasTcc.Domains.Entities;
using GerenciamentoBancasTcc.Models;
using GerenciamentoBancasTcc.Services.Email;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoBancasTcc.Controllers
{
    public class BancaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Usuario> _userManager;
        private readonly IEmailService _emailService;

        public BancaController(ApplicationDbContext context, UserManager<Usuario> userManager, IEmailService emailService)
        {
            _context = context;
            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Bancas
                .Include(x => x.Turma)
                .Include(x => x.Usuario)
                .ToListAsync());
        }

        [HttpPost]
        public IActionResult UploadImagem(IList<IFormFile> arquivos, int bancaId)
        {
            IFormFile imagemCarregada = arquivos.FirstOrDefault();

            if (imagemCarregada != null)
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    imagemCarregada.OpenReadStream().CopyTo(ms);

                    Arquivo arqui = new Arquivo()
                    {
                        Descricao = imagemCarregada.FileName,
                        Dados = ms.ToArray(),
                        ContentType = imagemCarregada.ContentType,
                        BancaId = bancaId
                    };

                    _context.Arquivos.Add(arqui);
                    _context.SaveChanges();
                    TempData["mensagemSucesso"] = "Arquivo enviado com sucesso!";
                }
                catch (Exception ex)
                {
                    TempData["mensagemErro"] = "Erro ao enviar arquivo! " + ex.Message;
                    return View("UploadArquivo");
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult Visualizar(int id)
        {
            var arquivosBanco = _context.Arquivos.FirstOrDefault(a => a.ArquivosId == id);
            return File(arquivosBanco.Dados, arquivosBanco.ContentType);
        }

        public async Task<IActionResult> UploadArquivo(int? id)
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

        public async Task<IActionResult> DetalhesBancaAvaliacoes(int? id)
        {
            var result = await (from banca in _context.Bancas
                                join orientador in _context.Users on banca.UsuarioId equals orientador.Id
                                join turma in _context.Turmas on banca.TurmaId equals turma.TurmaId
                                join curso in _context.Cursos on turma.CursoId equals curso.CursoId
                                //join arquivos in _context.Arquivos on banca.BancaId equals arquivos.BancaId
                                where banca.BancaId == id
                                orderby banca.DataHora
                                select new BancaViewModel
                                {
                                    BancaId = banca.BancaId,
                                    Curso = curso.Nome,
                                    DataHora = banca.DataHora,
                                    Orientador = orientador.Nome,
                                    Sala = banca.Sala,
                                    Tema = banca.Tema,
                                    Turma = turma.Nome,
                                    Alunos = banca.AlunosBancas.Select(x => x.Aluno).ToList(),
                                    Professores = banca.UsuariosBancas.Select(x => x.Usuarios.Nome).ToList(),
                                    //ArquivoId = arquivos.ArquivosId
                                    Arquivos = banca.Arquivos.ToList()
                                }).FirstAsync();

            return View(result);
        }

        public IActionResult Create()
        {
            GetCursos();
            GetOrientador();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BancaId,TurmaId,Tema,UsuarioId,Sala,Descricao,QtdProfBanca,DiasQueDevemOcorrerBanca")] Banca banca, string alunosBanca)
        {
            string[] diasBanca = banca.DiasQueDevemOcorrerBanca.Split(",");

            if (ModelState.IsValid)
            {
                try
                {
                    banca.AlunosBancas = alunosBanca.Split(',').Select(x => new AlunosBancas { AlunoId = int.Parse(x) }).ToList();
                    _context.Add(banca);
                    await _context.SaveChangesAsync();
                    TempData["mensagemSucesso"] = "Banca cadastrada com sucesso!";

                    var professores = await _context.Users.ToListAsync();
                        
                    foreach(var p in professores)
                    {
                        if(p.DiasDisponiveis != null)
                        {
                            string[] diasDisponiveisProfessor = p.DiasDisponiveis.Split(",");

                            foreach (var diaProfessor in diasDisponiveisProfessor)
                            {
                                foreach (var diaBanca in diasBanca)
                                {
                                    diaBanca.Trim();
                                    if (diaProfessor == diaBanca)
                                    {
                                        //var emailEnviado = _emailService.SendMail(p.Email, 
                                        //    "Você está sendo convidado para participar de uma banca de TCC na UNIFACEAR Araucária",
                                        //    );
                                        //if (emailEnviado)
                                        //{
                                        //    Convite convite = new()
                                        //    {
                                        //        UsuarioId = p.Id,
                                        //        BancaId = banca.BancaId,
                                        //        DiaConvite = diaBanca
                                        //    };
                                        //    _context.Convites.Add(convite);
                                        //    _context.SaveChanges();
                                        //}
                                    }
                                }
                            }
                        }
                    }

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData["mensagemErro"] = "Erro ao cadastrar banca! " + ex.Message;
                }
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
                banca = await _context.Bancas.Include(x => x.Turma).Include(x => x.AlunosBancas).FirstOrDefaultAsync(x => x.BancaId == id.Value);
            }

            if (banca == null)
            {
                return NotFound();
            }

            GetOrientador(banca.BancaId);
            GetCursos(banca.Turma.CursoId);
            GetTurmasEdit(banca.Turma.CursoId, banca.TurmaId);
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
                    TempData["mensagemSucesso"] = "Banca atualizada com sucesso!";
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    TempData["mensagemErro"] = "Erro ao atualizar a banca! " + ex.Message;
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
            try
            {
                _context.Bancas.Remove(banca);
                await _context.SaveChangesAsync();
                TempData["mensagemSucesso"] = "Banca excluída com sucesso!";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["mensagemErro"] = "Erro ao excluir banca! " + ex.Message;
            }
            return View(banca);
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

        private void GetTurmasEdit(int cursoId, int selectedItem = 0)
        {
            var turmas = _context.Turmas.Where(x => x.CursoId == cursoId && x.Ativo).ToList();
            var selectListItems = turmas.ToDictionary(x => x.TurmaId.ToString(), y => y.Nome).ToList();
            selectListItems.Insert(0, new KeyValuePair<string, string>("", ""));
            ViewData["TurmaId"] = new SelectList(selectListItems, "Key", "Value", selectedItem);
        }

        [HttpGet]
        public async Task<IActionResult> Professores()
        {
            var professores = await _context.Users.ToListAsync();
            return Json(professores);
        }

        [HttpPost]
        public async Task<IActionResult> ConvidarProfessores(string[] idsProfessores, int idBanca)
        {
            try
            {
                foreach (var id in idsProfessores)
                {
                    var professoresConvidados = await _context.Users.Where(x => x.Id == id).ToListAsync();

                    foreach (var professor in professoresConvidados)
                    {
                        //var emailEnviado = _emailService.SendMail(professor.Email);

                        //if (emailEnviado)
                        //{
                        //    Convite convite = new()
                        //    {
                        //        UsuarioId = professor.Id,
                        //        BancaId = idBanca
                        //    };
                        //    _context.Convites.Add(convite);
                        //    _context.SaveChanges();
                        //}
                    }
                }
                return Json(new { result = "Convites enviados" });
            }
            catch (Exception ex)
            {
                return Json(new { result = ex.Message });
            }
        }
    }
}