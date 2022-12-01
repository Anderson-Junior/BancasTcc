using GerenciamentoBancasTcc.Data;
using GerenciamentoBancasTcc.Domains.Entities;
using GerenciamentoBancasTcc.Domains.Enums;
using GerenciamentoBancasTcc.Helpers;
using GerenciamentoBancasTcc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoBancasTcc.Controllers
{
    public class ConviteController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Usuario> _userManager;

        public ConviteController(ApplicationDbContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = RolesHelper.COORDENADOR + "," + RolesHelper.ORIENTADOR + "," + RolesHelper.PROFESSOR + "," + RolesHelper.ADMINISTRADOR)]
        [HttpGet]
        public async Task<IActionResult> MeusConvites()
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            var convitesRecebidos = await _context.Convites
                .Where(x => x.UsuarioId == userId)
                .Include(x => x.Banca)
                .Include(x => x.ConviteAceites)
                .Include(x => x.Banca.BancaPossiveisDataHora)
                .ToListAsync();

            return View(convitesRecebidos);
        }

        [Authorize(Roles = RolesHelper.COORDENADOR + "," + RolesHelper.ORIENTADOR + "," + RolesHelper.ADMINISTRADOR)]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var convitesEnviados = await _context.Convites
                .Include(x => x.Banca)
                .Include(x => x.ConviteAceites)
                .Include(x => x.Banca.BancaPossiveisDataHora)
                .Include(x => x.Usuario)
                .ToListAsync();

            return View(convitesEnviados);
        }

        [Authorize(Roles = RolesHelper.COORDENADOR + "," + RolesHelper.ORIENTADOR + "," + RolesHelper.ADMINISTRADOR)]
        [HttpGet]
        public async Task<IActionResult> Details(Guid? id)
        {
            var resultado = await (from convite in _context.Convites
                                   join banca in _context.Bancas on convite.BancaId equals banca.BancaId
                                   join usuario in _context.Users on convite.UsuarioId equals usuario.Id
                                   join turma in _context.Turmas on banca.TurmaId equals turma.TurmaId
                                   join curso in _context.Cursos on turma.CursoId equals curso.CursoId
                                   where convite.ConviteId == id
                                   select new ConviteViewModel
                                   {
                                       ConviteId = convite.ConviteId,
                                       StatusConvite = convite.StatusConvite,
                                       Curso = curso.Nome,
                                       Turma = turma.Nome,
                                       Orientador = usuario.Nome,
                                       Alunos = banca.AlunosBancas.Select(x => x.Aluno.Nome).ToList(),
                                       Tema = banca.Tema,
                                       BancaPossiveisDataHora = banca.BancaPossiveisDataHora.Select(x => x.PossivelDataHora).ToList(),
                                       ConviteAceites = convite.ConviteAceites.Select(x => x.PossivelDataHora).ToList()
                                   }).FirstAsync();

            return View(resultado);
        }

        [Authorize(Roles = RolesHelper.COORDENADOR + "," + RolesHelper.ORIENTADOR + "," + RolesHelper.PROFESSOR + "," + RolesHelper.ADMINISTRADOR)]
        [HttpGet]
        public async Task<IActionResult> DetalhesConvite(Guid? id)
        {
            var resultado = await (from convite in _context.Convites
                                   join banca in _context.Bancas on convite.BancaId equals banca.BancaId
                                   join usuario in _context.Users on convite.UsuarioId equals usuario.Id
                                   join turma in _context.Turmas on banca.TurmaId equals turma.TurmaId
                                   join curso in _context.Cursos on turma.CursoId equals curso.CursoId
                                   where convite.ConviteId == id
                                   select new ConviteViewModel
                                   {
                                       ConviteId = convite.ConviteId,
                                       StatusConvite = convite.StatusConvite,
                                       Curso = curso.Nome,
                                       Turma = turma.Nome,
                                       Orientador = usuario.Nome,
                                       Alunos = banca.AlunosBancas.Select(x => x.Aluno.Nome).ToList(),
                                       Tema = banca.Tema,
                                       BancaPossiveisDataHora = banca.BancaPossiveisDataHora.Select(x => x.PossivelDataHora).ToList(),
                                       ConviteAceites = convite.ConviteAceites.Select(x => x.PossivelDataHora).ToList()
                                   }).FirstAsync();

            ViewData["AcceptButtonLabel"] = resultado.StatusConvite != StatusConvite.Aceito ? "Aceitar" : "Alterar aceite";
            ViewData["RejectButtonLabel"] = resultado.StatusConvite != StatusConvite.Aceito ? "Recusar" : "Cancelar aceite";

            return View(resultado);
        }

        [Authorize(Roles = RolesHelper.COORDENADOR + "," + RolesHelper.ORIENTADOR + "," + RolesHelper.PROFESSOR + "," + RolesHelper.ADMINISTRADOR)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AceitarConvite(Guid id, string datasSelecionadas)
        {
            try
            {
                var convite = _context.Convites
                    .Include(x => x.Banca)
                    .Include(x => x.ConviteAceites)
                    .Include(x => x.Banca.UsuariosBancas)
                    .FirstOrDefault(x => x.ConviteId == id);

                if (convite.UsuarioId != _userManager.GetUserId(HttpContext.User))
                {
                    throw new Exception("Convite não pertence ao usuário logado.");
                }

                var banca = convite.Banca;

                if (banca.DataHora.HasValue && !banca.UsuariosBancas.Any(x => x.UsuarioId == convite.UsuarioId))
                {
                    throw new Exception("Não é mais possível aceitar este convite, a banca já está completa.");
                }

                var diasSelecionados = datasSelecionadas.Split(',').Select(x => new ConviteAceite { PossivelDataHora = DateTime.Parse(x) }).ToList();
                foreach (var dia in diasSelecionados)
                {
                    if (dia.PossivelDataHora < DateTime.Now)
                    {
                        throw new Exception($"Não é mais possível aceitar o convite para o dia {dia.PossivelDataHora}, pois esta data já passou.");
                    }

                    var usuarioBanca =_context.UsuariosBancas.FirstOrDefault(x => x.UsuarioId == _userManager.GetUserId(HttpContext.User));
                    
                    if (usuarioBanca != null)
                    {
                        var banc = _context.Bancas.FirstOrDefault(x => x.BancaId == usuarioBanca.BancaId);
                        if (banc.DataHora == dia.PossivelDataHora)
                        {
                            throw new Exception($"Não é possível aceitar o convite para o dia {dia.PossivelDataHora}, pois já esta participando de uma banca neste mesmo dia e horário.");
                        }
                    }
                }

                // Deve recalcular a data da banca caso o convite tenha sido aceito anteriormente e o aceite foi alterado removendo ou adicionando alguma data.
                banca.DataHora = null;
                banca.UsuariosBancas.Clear();

                convite.ConviteAceites.Clear();
                convite.StatusConvite = StatusConvite.Aceito;
                convite.ConviteAceites = datasSelecionadas.Split(',').Select(x => new ConviteAceite { PossivelDataHora = DateTime.Parse(x) }).ToList();

                await _context.SaveChangesAsync();

                var bancaDataHora = (from aceite in _context.ConviteAceites
                                        where aceite.Convite.BancaId == banca.BancaId
                                        group aceite by aceite.PossivelDataHora into g
                                        where g.Count() >= banca.QtdProfBanca
                                        orderby g.Key
                                        select g.Key).FirstOrDefault();

                if (bancaDataHora != DateTime.MinValue)
                {
                    banca.DataHora = bancaDataHora;

                    // Somente vincular professores à banca quando a data da banca tiver sido definida
                    foreach (var conviteAceito in _context.Convites.Where(x => x.BancaId == banca.BancaId && x.ConviteAceites.Any(x => x.PossivelDataHora == bancaDataHora)))
                    {
                        banca.UsuariosBancas.Add(new UsuarioBanca
                        {
                            UsuarioId = conviteAceito.UsuarioId
                        });
                    }

                    await _context.SaveChangesAsync();
                }

                TempData["mensagemSucesso"] = "Convite aceito com sucesso!";
            }
            catch (Exception ex)
            {
                TempData["mensagemErro"] = ex.Message;
            }

            return RedirectToAction(nameof(MeusConvites));
        }

        [Authorize(Roles = RolesHelper.COORDENADOR + "," + RolesHelper.ORIENTADOR + "," + RolesHelper.PROFESSOR + "," + RolesHelper.ADMINISTRADOR)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RecusarConvite(Guid id)
        {
            try
            {
                var convite = _context.Convites
                    .Include(x => x.Banca)
                    .Include(x => x.ConviteAceites)
                    .Include(x => x.Banca.UsuariosBancas)
                    .FirstOrDefault(x => x.ConviteId == id);

                if (convite.UsuarioId != _userManager.GetUserId(HttpContext.User))
                {
                    throw new Exception("Convite não pertence ao usuário logado!");
                }

                convite.ConviteAceites.Clear();
                convite.StatusConvite = StatusConvite.Recusado;

                // Se o convite havia sido aceito anteriormente e o professor estava confirmado na banca, é necessário reverter.
                if (convite.Banca.UsuariosBancas.Any(x => x.UsuarioId == convite.UsuarioId))
                {
                    convite.Banca.DataHora = null;
                    convite.Banca.UsuariosBancas.Clear();
                }

                await _context.SaveChangesAsync();

                TempData["mensagemSucesso"] = "Convite recusado!";
            }
            catch (Exception ex)
            {
                TempData["mensagemErro"] = ex.Message;
            }

            return RedirectToAction(nameof(MeusConvites));
        }
    }
}
