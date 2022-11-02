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
    [Migration("20221031224934_DeleteBehaviorNoActionFormularioId")]
    partial class DeleteBehaviorNoActionFormularioId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
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

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.Property<int?>("TurmaId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("AlunoId");

                    b.HasIndex("TurmaId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.AlunosBancas", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("BancaId")
                        .HasColumnType("int");

                    b.HasKey("AlunoId", "BancaId");

                    b.HasIndex("BancaId");

                    b.ToTable("AlunosBancas");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Arquivo", b =>
                {
                    b.Property<int>("ArquivosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BancaId")
                        .HasColumnType("int");

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Dados")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArquivosId");

                    b.HasIndex("BancaId");

                    b.ToTable("Arquivos");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Banca", b =>
                {
                    b.Property<int>("BancaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiasQueDevemOcorrerBanca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QtdProfBanca")
                        .HasColumnType("int");

                    b.Property<int>("Sala")
                        .HasColumnType("int");

                    b.Property<string>("Tema")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TurmaId")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BancaId");

                    b.HasIndex("TurmaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Bancas");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Convite", b =>
                {
                    b.Property<Guid>("ConviteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BancaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataHoraAcao")
                        .HasColumnType("datetime2");

                    b.Property<string>("DiaConvite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QtdPrimeiroDia")
                        .HasColumnType("int");

                    b.Property<int>("QtdSegundoDia")
                        .HasColumnType("int");

                    b.Property<int>("QtdTerceiroDia")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeAceites")
                        .HasColumnType("int");

                    b.Property<int>("StatusConvite")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ConviteId");

                    b.HasIndex("BancaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Convites");
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.Property<int>("Periodos")
                        .HasColumnType("int")
                        .HasColumnName("Periodos");

                    b.HasKey("CursoId");

                    b.HasIndex("FilialId");

                    b.ToTable("Cursos");
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Campus");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CNPJ");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Endereco");

                    b.Property<int>("InstituicaoId")
                        .HasColumnType("int");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Telefone");

                    b.HasKey("FilialId");

                    b.HasIndex("InstituicaoId");

                    b.ToTable("Filiais");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Formulario", b =>
                {
                    b.Property<int>("FormularioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("FormularioId");

                    b.HasIndex("CursoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Formularios");
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.HasKey("InstituicaoId");

                    b.ToTable("Instituicoes");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Questao", b =>
                {
                    b.Property<int>("QuestaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FormularioId")
                        .HasColumnType("int");

                    b.Property<string>("Pergunta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoQuestaoId")
                        .HasColumnType("int");

                    b.HasKey("QuestaoId");

                    b.HasIndex("FormularioId");

                    b.HasIndex("TipoQuestaoId");

                    b.ToTable("Questoes");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.TipoQuestao", b =>
                {
                    b.Property<int>("TipoQuestaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoQuestaoId");

                    b.ToTable("TipoQuestoes");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Turma", b =>
                {
                    b.Property<int>("TurmaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TurmaId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TurmaId");

                    b.HasIndex("CursoId");

                    b.ToTable("Turmas");
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

                    b.Property<string>("DiasDisponiveis")
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
                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Turma", "Turma")
                        .WithMany("Alunos")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.AlunosBancas", b =>
                {
                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Aluno", "Aluno")
                        .WithMany("AlunosBancas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Banca", "Banca")
                        .WithMany("AlunosBancas")
                        .HasForeignKey("BancaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Banca");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Arquivo", b =>
                {
                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Banca", "Banca")
                        .WithMany("Arquivos")
                        .HasForeignKey("BancaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Banca");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Banca", b =>
                {
                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Turma", "Turma")
                        .WithMany("Banca")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Usuario", "Usuario")
                        .WithMany("Bancas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Turma");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Convite", b =>
                {
                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Banca", "Banca")
                        .WithMany("Convites")
                        .HasForeignKey("BancaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Usuario", "Usuario")
                        .WithMany("Convites")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Banca");

                    b.Navigation("Usuario");
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

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Filial", b =>
                {
                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Instituicao", "Instituicao")
                        .WithMany("Filiais")
                        .HasForeignKey("InstituicaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instituicao");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Formulario", b =>
                {
                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Curso", "Curso")
                        .WithMany("Formularios")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Usuario", "Usuario")
                        .WithMany("Formularios")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Curso");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Questao", b =>
                {
                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Formulario", "Formulario")
                        .WithMany("Questoes")
                        .HasForeignKey("FormularioId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.TipoQuestao", "TipoQuestao")
                        .WithMany("Questoes")
                        .HasForeignKey("TipoQuestaoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Formulario");

                    b.Navigation("TipoQuestao");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Turma", b =>
                {
                    b.HasOne("GerenciamentoBancasTcc.Domains.Entities.Curso", "Curso")
                        .WithMany("Turmas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Curso");
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
                    b.Navigation("AlunosBancas");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Banca", b =>
                {
                    b.Navigation("AlunosBancas");

                    b.Navigation("Arquivos");

                    b.Navigation("Convites");

                    b.Navigation("UsuariosBancas");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Curso", b =>
                {
                    b.Navigation("Formularios");

                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Filial", b =>
                {
                    b.Navigation("Cursos");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Formulario", b =>
                {
                    b.Navigation("Questoes");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Instituicao", b =>
                {
                    b.Navigation("Filiais");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.TipoQuestao", b =>
                {
                    b.Navigation("Questoes");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Turma", b =>
                {
                    b.Navigation("Alunos");

                    b.Navigation("Banca");
                });

            modelBuilder.Entity("GerenciamentoBancasTcc.Domains.Entities.Usuario", b =>
                {
                    b.Navigation("Bancas");

                    b.Navigation("Convites");

                    b.Navigation("Formularios");

                    b.Navigation("UsuariosBancas");
                });
#pragma warning restore 612, 618
        }
    }
}
