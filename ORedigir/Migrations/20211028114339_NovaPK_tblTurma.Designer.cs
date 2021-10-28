﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ORedigir.Data;

namespace ORedigir.Migrations
{
    [DbContext(typeof(ORedigirContext))]
    [Migration("20211028114339_NovaPK_tblTurma")]
    partial class NovaPK_tblTurma
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.HasData(
                        new
                        {
                            Id = "24cbb7d8-c116-4369-8242-17d94fa467e9",
                            ConcurrencyStamp = "7dcd39c5-cfbf-4c4c-9fe3-bd4fa0180031",
                            Name = "Admin",
                            NormalizedName = "Admin"
                        },
                        new
                        {
                            Id = "efc0fff4-9eab-4800-bf64-1074182a2e62",
                            ConcurrencyStamp = "94b8d91c-7739-4aba-b3ed-7c865b381d37",
                            Name = "Professor",
                            NormalizedName = "Professor"
                        },
                        new
                        {
                            Id = "48ee90b4-2201-48f8-a4ba-d7cc6cc56abd",
                            ConcurrencyStamp = "9ecf9304-dc8e-43cd-b9a7-9d8c245b39b4",
                            Name = "Aluno",
                            NormalizedName = "Aluno"
                        });
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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ORedigir.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NomeCompleto")
                        .HasColumnType("varchar(100)");

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

                    b.Property<string>("Senha")
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("TurmaID")
                        .HasColumnType("int");

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

                    b.HasIndex("TurmaID")
                        .IsUnique()
                        .HasFilter("[TurmaID] IS NOT NULL");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ORedigir.Models.Historico", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<byte>("Tipo")
                        .HasColumnType("tinyint");

                    b.Property<string>("UsuarioID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Historico");
                });

            modelBuilder.Entity("ORedigir.Models.LogUsuario", b =>
                {
                    b.Property<int>("LogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Criado")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("TipoLog")
                        .HasColumnType("smallint");

                    b.Property<string>("UsuarioID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LogID");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("ORedigir.Models.PropostaTextual", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("Text");

                    b.Property<DateTime>("DataFechamento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("NotaMaxima")
                        .HasColumnType("int");

                    b.Property<int>("RepoID")
                        .HasColumnType("int");

                    b.Property<int?>("SAID")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<int?>("TurmaID")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("UsuarioID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("SAID");

                    b.HasIndex("TurmaID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("PropostaTextual");
                });

            modelBuilder.Entity("ORedigir.Models.SA", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Formato")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<string>("NomeArquivo")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<string>("PastaNome")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.Property<int>("Tamanho")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Sa");
                });

            modelBuilder.Entity("ORedigir.Models.TextoProduzido", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("Nota")
                        .HasPrecision(3, 1)
                        .HasColumnType("decimal(3,1)");

                    b.Property<int>("PropostaTextualID")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("UsuarioID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("PropostaTextualID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("TextoProduzido");
                });

            modelBuilder.Entity("ORedigir.Models.Turma", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Numero")
                        .HasColumnType("tinyint");

                    b.Property<string>("Professor")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TurmaNome")
                        .IsRequired()
                        .HasColumnType("varchar(6)");

                    b.Property<byte>("Turno")
                        .HasColumnType("tinyint");

                    b.HasKey("ID");

                    b.ToTable("Turma");
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
                    b.HasOne("ORedigir.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ORedigir.Models.ApplicationUser", null)
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

                    b.HasOne("ORedigir.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ORedigir.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ORedigir.Models.ApplicationUser", b =>
                {
                    b.HasOne("ORedigir.Models.Turma", "Turma")
                        .WithOne("Usuario")
                        .HasForeignKey("ORedigir.Models.ApplicationUser", "TurmaID");

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("ORedigir.Models.Historico", b =>
                {
                    b.HasOne("ORedigir.Models.ApplicationUser", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ORedigir.Models.PropostaTextual", b =>
                {
                    b.HasOne("ORedigir.Models.SA", "SA")
                        .WithMany()
                        .HasForeignKey("SAID");

                    b.HasOne("ORedigir.Models.Turma", "Turma")
                        .WithMany()
                        .HasForeignKey("TurmaID");

                    b.HasOne("ORedigir.Models.ApplicationUser", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SA");

                    b.Navigation("Turma");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ORedigir.Models.TextoProduzido", b =>
                {
                    b.HasOne("ORedigir.Models.PropostaTextual", "PropostaTextual")
                        .WithMany()
                        .HasForeignKey("PropostaTextualID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ORedigir.Models.ApplicationUser", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PropostaTextual");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ORedigir.Models.Turma", b =>
                {
                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
