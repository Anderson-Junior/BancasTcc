using GerenciamentoBancasTcc.Data;
using GerenciamentoBancasTcc.Domains.Dtos;
using GerenciamentoBancasTcc.Domains.Entities;
using GerenciamentoBancasTcc.Domains.Enums;
using GerenciamentoBancasTcc.Models;
using GerenciamentoBancasTcc.Services.Email;
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
        private readonly IEmailService _emailService;

        public ConviteController(ApplicationDbContext context, UserManager<Usuario> userManager, IEmailService emailService)
        {
            _context = context;
            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task<IActionResult> MeusConvites()
        {
            Usuario user = await _userManager.GetUserAsync(HttpContext.User);
            var convitesRecebidos = await _context.Convites
                .Where(x => x.UsuarioId == user.Id)
                .Include(x => x.Banca)
                .Include(x => x.DiaQueDeveOcorrerBancas)
                .ToListAsync();

            return View(convitesRecebidos);
        }

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
                                       DataHoraAcao = convite.DataHoraAcao,
                                       Professor = convite.Usuario.Nome,
                                       Banca = convite.Banca.Tema,
                                       StatusConvite = convite.StatusConvite,
                                       Curso = curso.Nome,
                                       Turma = turma.Nome,
                                       Orientador = usuario.Nome,
                                       Alunos = banca.AlunosBancas.Select(x => x.Aluno).ToList(),
                                       Sala = banca.Sala,
                                       Tema = banca.Tema,
                                       DiaQueDeveOcorrerBancas = banca.DiaQueDeveOcorrerBancas
                                   }).FirstAsync();

            return View(resultado);
        }

        public async Task<IActionResult> AceitarConvite(Guid idConvite, int statusConvite, string idDiasSelecionados)
        {
            Usuario user = await _userManager.GetUserAsync(HttpContext.User);
            RetornoConviteDto retorno = new();

            string[] _IdsDiaSelecionados = idDiasSelecionados.Split(",");
            try
            {
                var convite = await _context.Convites.SingleOrDefaultAsync(x => x.ConviteId == idConvite);
                var banca = await _context.Bancas.SingleOrDefaultAsync(x => x.BancaId == convite.BancaId);
                var diaQueDeveOcorrerBancas = await _context.DiaQueDeveOcorrerBancas.Where(x => x.BancaId == banca.BancaId).ToListAsync();

                if (convite != null)
                {
                    if (statusConvite == 1) // 1 = aceito
                    {
                        foreach (var possiveisDiasBanca in diaQueDeveOcorrerBancas)
                        {
                            if (possiveisDiasBanca.QtdAceites < banca.QtdProfBanca)
                            {
                                foreach (var idDiaSelecionado in _IdsDiaSelecionados)
                                {
                                    var diaSelecProf = _context.DiaQueDeveOcorrerBancas.SingleOrDefault(x => x.DiaQueDeveOcorrerBancaId == Int32.Parse(idDiaSelecionado));
                                    if (possiveisDiasBanca.DiaQueDeveOcorrerBancaId == diaSelecProf.DiaQueDeveOcorrerBancaId)
                                    {
                                        convite.StatusConvite = StatusConvite.Aceito;
                                        convite.DataHoraAcao = DateTime.Now;
                                        possiveisDiasBanca.QtdAceites += 1;
                                    }
                                }
                            }
                        }

                        var usuariosBancas = await _context.UsuariosBancas.FirstOrDefaultAsync(x => x.UsuarioId == user.Id && x.BancaId == banca.BancaId);
                        if (usuariosBancas == null)
                        {
                            UsuarioBanca usuarioBanca = new()
                            {
                                BancaId = banca.BancaId,
                                UsuarioId = user.Id
                            };
                            await _context.UsuariosBancas.AddAsync(usuarioBanca);
                            TempData["mensagemSucesso"] = "Convite aceito com sucesso!";

                            await _context.SaveChangesAsync();

                            return Ok();
                        }
                        else
                        {
                            TempData["mensagemErro"] = "Este convite já foi aceito!";
                            return Ok();
                        }
                    }
                }
                if (statusConvite == 2) // 2 = recusado
                {
                    convite.StatusConvite = StatusConvite.Recusado;
                    convite.DataHoraAcao = DateTime.Now; // Data e hora que o professor recusou o convite

                    await _context.SaveChangesAsync();

                    TempData["mensagemSucesso"] = "Convite recusado!";
                    return Ok();
                }
                if (statusConvite == 3) // 3 = cancelado
                {
                    var usuarioBanca = await _context.UsuariosBancas.FirstOrDefaultAsync(x => x.UsuarioId == user.Id && x.BancaId == banca.BancaId);
                    if (usuarioBanca != null)
                    {
                        _context.Remove(usuarioBanca);
                    }

                    foreach (var possiveisDiasBanca in banca.DiaQueDeveOcorrerBancas)
                    {
                        foreach (var idDiaSelecionado in _IdsDiaSelecionados)
                        {
                            var diaSelecProf = _context.DiaQueDeveOcorrerBancas.SingleOrDefault(x => x.DiaQueDeveOcorrerBancaId == Int32.Parse(idDiaSelecionado));
                            if (possiveisDiasBanca.DiaQueDeveOcorrerBancaId == diaSelecProf.DiaQueDeveOcorrerBancaId)
                            {
                                convite.StatusConvite = StatusConvite.Cancelado;
                                convite.DataHoraAcao = DateTime.Now;
                                possiveisDiasBanca.QtdAceites -= 1;
                            }
                        }
                    }

                    await _context.SaveChangesAsync();

                    TempData["mensagemSucesso"] = "Convite cancelado!";
                    return Ok();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                TempData["mensagemErro"] = "Ocorreu um erro no processamento. " + ex.Message;
                return BadRequest(retorno);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetStatusConvite(Guid idConvite)
        {
            Usuario user = await _userManager.GetUserAsync(HttpContext.User);
            var convitesRecebidos = await _context.Convites.FirstOrDefaultAsync(x => x.ConviteId == idConvite);
            var statusConvite = 0;

            if (convitesRecebidos.StatusConvite == StatusConvite.Aceito)
            {
                statusConvite = 1;
            }

            if (convitesRecebidos.StatusConvite == StatusConvite.Recusado)
            {
                statusConvite = 2;
            }

            if (convitesRecebidos.StatusConvite == StatusConvite.Cancelado)
            {
                statusConvite = 3;
            }

            return Json(statusConvite);
        }
    }
}
