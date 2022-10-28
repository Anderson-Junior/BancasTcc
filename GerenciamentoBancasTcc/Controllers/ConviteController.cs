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
                .Where(x => x.UsuarioId == user.Id && (x.StatusConvite == 0 || x.StatusConvite == StatusConvite.Aceito))
                .Include(x => x.Banca)
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
                                       Tema = banca.Tema
                                   }).FirstAsync();

            return View(resultado);
        }

        public async Task<IActionResult> AceitarConvite(Guid idConvite, int statusConvite)
        {
            Usuario user = await _userManager.GetUserAsync(HttpContext.User);
            RetornoConviteDto retorno = new();
            try
            {
                var convite = await _context.Convites.SingleOrDefaultAsync(x => x.ConviteId == idConvite);
                var banca = await _context.Bancas.SingleOrDefaultAsync(x => x.BancaId == convite.BancaId);

                if (convite != null)
                {
                    if (statusConvite == 1) // 1 = aceito
                    {
                        if (banca.QtdProfBanca > convite.QuantidadeAceites)
                        {
                            convite.StatusConvite = StatusConvite.Aceito;
                            convite.DataHoraAcao = DateTime.Now;
                            convite.QuantidadeAceites += 1;

                            UsuarioBanca usuarioBanca = new()
                            {
                                BancaId = banca.BancaId,
                                UsuarioId = user.Id
                            };

                            await _context.UsuariosBancas.AddAsync(usuarioBanca);
                        }
                    }
                    else if (statusConvite == 2) // 2 = recusado
                    {
                        convite.StatusConvite = StatusConvite.Recusado;
                        convite.DataHoraAcao = DateTime.Now; // Data e hora que o professor recusou o convite

                        retorno.mensagem = "Convite recusado.";
                    }
                    else if (statusConvite == 3) // 3 = cancelado
                    {
                        var usuarioBanca = await _context.UsuariosBancas.FirstOrDefaultAsync(x => x.UsuarioId == user.Id && x.BancaId == banca.BancaId);
                        if (usuarioBanca != null)
                        {
                            _context.Remove(usuarioBanca);
                        }

                        convite.StatusConvite = StatusConvite.Cancelado;
                        convite.DataHoraAcao = DateTime.Now; // Data e hora que o professor cancelou a presença
                        convite.QuantidadeAceites -= 1;

                        retorno.mensagem = "Convite cancelado.";
                    }
    
                    await _context.SaveChangesAsync();
                }

                retorno.statusCode = 200;
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                retorno.statusCode = 400;
                retorno.mensagem = ex.Message;
                return BadRequest(retorno);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetStatusConvite(Guid idConvite)
        {
            Usuario user = await _userManager.GetUserAsync(HttpContext.User);
            var convitesRecebidos = await _context.Convites.FirstOrDefaultAsync(x => x.ConviteId == idConvite);
            var statusConvite = string.Empty;

            if (convitesRecebidos.StatusConvite == StatusConvite.Aceito)
            {
                statusConvite = "Aceito";  
            }

            if(convitesRecebidos.StatusConvite == StatusConvite.Recusado)
            {
                statusConvite = "Recusado";
            }

            if(convitesRecebidos.StatusConvite == StatusConvite.Cancelado)
            {
                statusConvite = "Cancelado";
            }

            return Json(statusConvite);
        }   
    }
}
