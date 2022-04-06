﻿// <auto-generated />
using System;
using GerenciamentoBancasTcc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GerenciamentoBancasTcc.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220405001557_RenomeandoPropriedadeOrientadorId")]
    partial class RenomeandoPropriedadeOrientadorId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Aluno", b =>
                {
                    b.Property<int>("AlunoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AlunoId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("Ativo");

                    b.Property<int?>("EquipeId")
                        .HasColumnType("int");

                    b.Property<string>("Matricula")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Matricula");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.HasKey("AlunoId");

                    b.HasIndex("EquipeId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Banca", b =>
                {
                    b.Property<int>("BancaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CursoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Orientador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sala")
                        .HasColumnType("int");

                    b.HasKey("BancaId");

                    b.HasIndex("CursoId");

                    b.ToTable("Bancas");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Curso", b =>
                {
                    b.Property<int>("CursoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CursoId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("Ativo");

                    b.Property<int>("FilialId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.Property<int>("Periodos")
                        .HasColumnType("int")
                        .HasColumnName("Periodos");

                    b.HasKey("CursoId");

                    b.HasIndex("FilialId");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.CursosAlunos", b =>
                {
                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.HasKey("CursoId", "AlunoId");

                    b.HasIndex("AlunoId");

                    b.ToTable("CursosAlunos");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.CursosUsuarios", b =>
                {
                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CursoId", "UsuarioId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("CursosUsuarios");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.DiasDisponiveis", b =>
                {
                    b.Property<int>("DiasDisponiveisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DiaDisponivel")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DiasDisponiveisId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("DiasDisponiveis");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Equipe", b =>
                {
                    b.Property<int>("EquipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BancaId")
                        .HasColumnType("int");

                    b.Property<int?>("CursoId")
                        .HasColumnType("int");

                    b.Property<int?>("OrientadorId")
                        .HasColumnType("int");

                    b.Property<string>("Tema")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EquipeId");

                    b.HasIndex("BancaId");

                    b.HasIndex("CursoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Equipe");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Filial", b =>
                {
                    b.Property<int>("FilialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("FilialId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("Ativo");

                    b.Property<string>("Campus")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Campus");

                    b.Property<string>("Cnpj")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CNPJ");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Endereco");

                    b.Property<int>("InstituicaoId")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Telefone");

                    b.HasKey("FilialId");

                    b.HasIndex("InstituicaoId");

                    b.ToTable("Filiais");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Instituicao", b =>
                {
                    b.Property<int>("InstituicaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("InstituicaoId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("Ativo");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.HasKey("InstituicaoId");

                    b.ToTable("Instituicoes");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit")
                        .HasColumnName("Ativo");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.UsuarioBanca", b =>
                {
                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("BancaId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId", "BancaId");

                    b.HasIndex("BancaId");

                    b.ToTable("UsuariosBancas");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Aluno", b =>
                {
                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Equipe", "Equipe")
                        .WithMany("Alunos")
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Equipe");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Banca", b =>
                {
                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Curso", "Curso")
                        .WithMany("Bancas")
                        .HasForeignKey("CursoId");

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Curso", b =>
                {
                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Filial", "Filial")
                        .WithMany("Cursos")
                        .HasForeignKey("FilialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filial");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.CursosAlunos", b =>
                {
                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Aluno", "Alunos")
                        .WithMany("CursosAlunos")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Curso", "Cursos")
                        .WithMany("CursosAlunos")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alunos");

                    b.Navigation("Cursos");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.CursosUsuarios", b =>
                {
                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Curso", "Cursos")
                        .WithMany("CursosUsuarios")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Usuario", "Usuarios")
                        .WithMany("CursosUsuarios")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cursos");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.DiasDisponiveis", b =>
                {
                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Usuario", "Usuario")
                        .WithMany("DiasDisponiveis")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Equipe", b =>
                {
                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Banca", "Banca")
                        .WithMany("Equipes")
                        .HasForeignKey("BancaId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Curso", "Curso")
                        .WithMany("Equipes")
                        .HasForeignKey("CursoId");

                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Usuario", "Usuario")
                        .WithMany("Equipes")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Banca");

                    b.Navigation("Curso");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Filial", b =>
                {
                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Instituicao", "Instituicao")
                        .WithMany("Filiais")
                        .HasForeignKey("InstituicaoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Instituicao");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.UsuarioBanca", b =>
                {
                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Banca", "Bancas")
                        .WithMany("UsuariosBancas")
                        .HasForeignKey("BancaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Usuario", "Usuarios")
                        .WithMany("UsuariosBancas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bancas");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Aluno", b =>
                {
                    b.Navigation("CursosAlunos");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Banca", b =>
                {
                    b.Navigation("Equipes");

                    b.Navigation("UsuariosBancas");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Curso", b =>
                {
                    b.Navigation("Bancas");

                    b.Navigation("CursosAlunos");

                    b.Navigation("CursosUsuarios");

                    b.Navigation("Equipes");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Equipe", b =>
                {
                    b.Navigation("Alunos");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Filial", b =>
                {
                    b.Navigation("Cursos");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Instituicao", b =>
                {
                    b.Navigation("Filiais");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Usuario", b =>
                {
                    b.Navigation("CursosUsuarios");

                    b.Navigation("DiasDisponiveis");

                    b.Navigation("Equipes");

                    b.Navigation("UsuariosBancas");
                });
#pragma warning restore 612, 618
        }
    }
}
