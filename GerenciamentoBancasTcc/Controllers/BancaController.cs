using GerenciamentoBancasTcc.Data;
using GerenciamentoBancasTcc.Data.Migrations;
using GerenciamentoBancasTcc.Domains.Entities;
using GerenciamentoBancasTcc.Helpers;
using GerenciamentoBancasTcc.Models;
using GerenciamentoBancasTcc.Services.Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
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

        [Authorize(Roles = RolesHelper.COORDENADOR + "," + RolesHelper.ADMINISTRADOR + "," + RolesHelper.ORIENTADOR + "," + RolesHelper.PROFESSOR)]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bancas
                .Include(x => x.Turma)
                .Include(x => x.Usuario)
                .ToListAsync());
        }

        [Authorize(Roles = RolesHelper.COORDENADOR + "," + RolesHelper.ADMINISTRADOR + "," + RolesHelper.ORIENTADOR)]
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

        [Authorize(Roles = RolesHelper.COORDENADOR + "," + RolesHelper.ADMINISTRADOR + "," + RolesHelper.ORIENTADOR)]
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

        public async Task<IActionResult> DetalhesBanca(int? id)
        {
            var result = await (from banca in _context.Bancas
                                join orientador in _context.Users on banca.UsuarioId equals orientador.Id
                                join turma in _context.Turmas on banca.TurmaId equals turma.TurmaId
                                join curso in _context.Cursos on turma.CursoId equals curso.CursoId
                                where banca.BancaId == id
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
                                    Arquivos = banca.Arquivos.ToList()
                                }).FirstAsync();

            return View(result);
        }

        [Authorize(Roles = RolesHelper.COORDENADOR + "," + RolesHelper.ADMINISTRADOR)]
        public IActionResult Create()
        {
            SetViewData();
            return View();
        }

        [Authorize(Roles = RolesHelper.COORDENADOR + "," + RolesHelper.ADMINISTRADOR + "," + RolesHelper.ORIENTADOR)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Banca banca, string alunosBanca, string datasBanca)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(alunosBanca))
                    {
                        banca.AlunosBancas = alunosBanca.Split(',').Select(alunoId => new AlunosBancas { AlunoId = int.Parse(alunoId) }).ToList();
                    }

                    if (!string.IsNullOrWhiteSpace(datasBanca))
                    {
                        banca.BancaPossiveisDataHora = datasBanca.Split(',').Distinct().Select(datahora => new BancaPossivelDataHora { PossivelDataHora = DateTime.Parse(datahora) }).ToList();
                    }

                    _context.Add(banca);
                    await _context.SaveChangesAsync();

                    // TODO: remover filtro
                    var convites = _context.Users
                        .Where(x => x.Ativo)
                        .Select(x => new Convite { BancaId = banca.BancaId, UsuarioId = x.Id, ConviteId = Guid.NewGuid() }).ToList();

                    EnviarConvites(convites);

                    _context.Convites.AddRange(convites);
                    await _context.SaveChangesAsync();

                    TempData["mensagemSucesso"] = "Banca cadastrada com sucesso!";

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Erro ao cadastrar banca! " + ex.Message);
                }
            }

            SetViewData(banca, alunosBanca, datasBanca);

            return View(banca);
        }

        [Authorize(Roles = RolesHelper.COORDENADOR + "," + RolesHelper.ADMINISTRADOR + "," + RolesHelper.ORIENTADOR)]
        public async Task<IActionResult> Edit(int? id)
        {
            Banca banca = null;

            if (id.HasValue)
            {
                banca = await _context.Bancas
                    .Include(x => x.AlunosBancas)
                    .Include(x => x.BancaPossiveisDataHora)
                    .FirstOrDefaultAsync(x => x.BancaId == id.Value);
            }

            if (banca == null)
            {
                return NotFound();
            }

            SetViewData(banca,
                string.Join(',', banca.AlunosBancas.Select(x => x.AlunoId).ToArray()),
                string.Join(',', banca.BancaPossiveisDataHora.Select(x => x.PossivelDataHora.ToString("yyyy-MM-dd HH:mm")).ToArray()));

            return View(banca);
        }

        [Authorize(Roles = RolesHelper.COORDENADOR + "," + RolesHelper.ADMINISTRADOR + "," + RolesHelper.ORIENTADOR)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Banca banca, string alunosBanca, string datasBanca)
        {
            if (!BancaExists(banca.BancaId))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Attach(banca).State = EntityState.Modified;
                    _context.AlunosBancas.RemoveRange(_context.AlunosBancas.Where(x => x.BancaId == banca.BancaId));
                    _context.BancaPossiveisDataHora.RemoveRange(_context.BancaPossiveisDataHora.Where(x => x.BancaId == banca.BancaId));

                    if (!string.IsNullOrWhiteSpace(alunosBanca))
                    {
                        banca.AlunosBancas = alunosBanca.Split(',').Select(alunoId => new AlunosBancas { AlunoId = int.Parse(alunoId) }).ToList();
                    }

                    if (!string.IsNullOrWhiteSpace(datasBanca))
                    {
                        banca.BancaPossiveisDataHora = datasBanca.Split(',').Distinct().Select(datahora => new BancaPossivelDataHora { PossivelDataHora = DateTime.Parse(datahora) }).ToList();
                    }

                    await _context.SaveChangesAsync();

                    TempData["mensagemSucesso"] = "Banca atualizada com sucesso!";

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Erro ao atualizar banca! " + ex.Message);
                }
            }

            SetViewData(banca, alunosBanca, datasBanca);

            return View(banca);
        }

        [Authorize(Roles = RolesHelper.COORDENADOR + "," + RolesHelper.ADMINISTRADOR + "," + RolesHelper.ORIENTADOR)]
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

        [Authorize(Roles = RolesHelper.COORDENADOR + "," + RolesHelper.ADMINISTRADOR + "," + RolesHelper.ORIENTADOR)]
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
            }
            catch (Exception ex)
            {
                TempData["mensagemErro"] = "Erro ao excluir banca! " + ex.Message;
            }

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

        private void GetCursos(int? selectedItem = null)
        {
            var cursos = _context.Cursos.Where(x => x.Ativo == true).ToList();
            var selectListItems = cursos.ToDictionary(x => x.CursoId.ToString(), y => y.Nome).ToList();
            selectListItems.Insert(0, new KeyValuePair<string, string>("", ""));
            ViewData["CursoId"] = new SelectList(selectListItems, "Key", "Value", selectedItem);
        }

        private void GetOrientador(string selectedItem = null)
        {
            var orientadores = _userManager.Users.Where(x => x.Ativo).ToList();
            var selectListItems = orientadores.ToDictionary(x => x.Id, y => y.Nome).ToList();
            selectListItems.Insert(0, new KeyValuePair<string, string>("", ""));
            ViewData["UsuarioId"] = new SelectList(selectListItems, "Key", "Value", selectedItem);
        }

        private void GetTurmasEdit(int? cursoId, int? selectedItem = null)
        {
            var turmas = new List<Turma>();

            if (cursoId.HasValue && cursoId != 0)
            {
                turmas = _context.Turmas.Where(x => x.CursoId == cursoId && x.Ativo).ToList();
            }

            var selectListItems = turmas.ToDictionary(x => x.TurmaId.ToString(), y => y.Nome).ToList();
            selectListItems.Insert(0, new KeyValuePair<string, string>("", ""));
            ViewData["TurmaId"] = new SelectList(selectListItems, "Key", "Value", selectedItem);
        }

        private void SetViewData(Banca banca = null, string alunosBanca = null, string datasBanca = null)
        {
            var turma = banca != null && banca.TurmaId != 0 ? _context.Turmas.Find(banca.TurmaId) : null;

            GetCursos(turma?.CursoId);
            GetOrientador(banca?.UsuarioId);
            GetTurmasEdit(turma?.CursoId, banca?.TurmaId);
            ViewData["DatasBanca"] = datasBanca;
            ViewData["AlunosBanca"] = alunosBanca;
        }

        [HttpGet]
        public async Task<IActionResult> Professores()
        {
            var professores = await _context.Users.Where(x => x.Ativo).ToListAsync();
            return Json(professores);
        }

        [Authorize(Roles = RolesHelper.COORDENADOR + "," + RolesHelper.ADMINISTRADOR + "," + RolesHelper.ORIENTADOR)]
        [HttpPost]
        public IActionResult ConvidarProfessores(int idBanca, string[] idsProfessores)
        {
            try
            {
                var convites = idsProfessores.Select(x => new Convite { BancaId = idBanca, UsuarioId = x, ConviteId = Guid.NewGuid() }).ToList();

                _context.Convites.AddRange(convites);
                _context.SaveChanges();

                return Json(new { result = "Convites enviados" });
            }
            catch (Exception ex)
            {
                return Json(new { result = ex.Message });
            }
        }

        [Authorize(Roles = RolesHelper.COORDENADOR + "," + RolesHelper.ADMINISTRADOR + "," + RolesHelper.ORIENTADOR)]
        private void EnviarConvites(IList<Convite> convites)
        {
            string body = System.IO.File.ReadAllText(@"Views/Shared/EmailConvite.cshtml");

            foreach (var convite in convites)
            {
                var user = _context.Users.Find(convite.UsuarioId);

                if (_emailService.SendMail(user.Email, "Você está sendo convidado para participar de uma banca de TCC na UNIFACEAR Araucária", body))
                {
                    convite.EmailEnviado = true;
                }
            }
        }
    }
}