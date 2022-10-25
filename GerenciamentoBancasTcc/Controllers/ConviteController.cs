using GerenciamentoBancasTcc.Data;
using GerenciamentoBancasTcc.Domains.Entities;
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
            var convitesRecebidos = await _context.Convites.Where(x => x.UsuarioId == user.Id).ToListAsync();

            return View(convitesRecebidos);
        }

        public async Task<IActionResult> Convite(int? id)
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
    }
}
