﻿using GerenciamentoBancasTcc.Domains.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GerenciamentoBancasTcc.Data
{
    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<AlunosBancas> AlunosBancas { get; set; }
        public DbSet<Banca> Bancas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Filial> Filiais { get; set; }
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<UsuarioBanca> UsuariosBancas { get; set; }
        public DbSet<Formulario> Formularios { get; set; }
        public DbSet<Convite> Convites { get; set; }
        public DbSet<Questao> Questoes { get; set; }
        public DbSet<TipoQuestao> TipoQuestoes { get; set; }
        public DbSet<Arquivo> Arquivos { get; set; }
        public DbSet<BancaPossivelDataHora> BancaPossiveisDataHora { get; set; }
        public DbSet<ConviteAceite> ConviteAceites { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
