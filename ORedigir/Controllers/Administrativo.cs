using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ORedigir.Data;
using ORedigir.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Claims;

namespace ORedigir.Controllers
{


    [Authorize(Roles = "Admin")]
    public class Administrativo : Controller
    {
        private readonly ORedigirContext _ctx;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private string _userId;
        public Administrativo(ORedigirContext ctx, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _ctx = ctx;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        private enum Tipos
        {
            Admin,
            Professor,
            Aluno
        }

        private enum ComandosSql
        {
            Update = 0,
            Select = 1,
            Insert = 2,
            Delete = 3
        }


        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken cancellationToken, string query = "")
        {
            try
            {
                _userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                if (query == "")
                {
                    var dados = await _ctx.Usuario.AsNoTracking().Join(_ctx.UserRoles.AsNoTracking(), usuario => usuario.Id, papeisUsuario => papeisUsuario.UserId,
             (usuario, papeisUsuario) => new { usuario, papeisUsuario }).Join(_ctx.Roles.AsNoTracking(),
             _papeisUsuario => _papeisUsuario.papeisUsuario.RoleId, papeis => papeis.Id, (_papeisUsuario, papeis)
             => new { _papeisUsuario, papeis }).Select(dadosSelecionados => new PesquisasAdministrativas
             {
                 IDUsuario = dadosSelecionados._papeisUsuario.usuario.Id,
                 NomeCompleto = dadosSelecionados._papeisUsuario.usuario.NomeCompleto,
                 Email = dadosSelecionados._papeisUsuario.usuario.Email,
                 TurmaID = dadosSelecionados._papeisUsuario.usuario.TurmaID,
                 DataNascimento = dadosSelecionados._papeisUsuario.usuario.DataNascimento,
                 DataCadastro = dadosSelecionados._papeisUsuario.usuario.DataCadastro,
                 Name = dadosSelecionados.papeis.Name,
                 IdPapel = dadosSelecionados.papeis.Id
             }).ToListAsync(cancellationToken);
                    LogUsuario log = new LogUsuario { UsuarioID = _userId, TipoLog = (short)ComandosSql.Select, Mensagem = $"{_userId} buscou alguns para visualização", Criado = DateTime.Now };
                    await _ctx.Log.AddAsync(log);
                    await _ctx.SaveChangesAsync();
                    return View(dados);
                }

                else
                {
                    var dados = await _ctx.Usuario.AsNoTracking().Join(_ctx.UserRoles.AsNoTracking(), usuario => usuario.Id, papeisUsuario => papeisUsuario.UserId,
               (usuario, papeisUsuario) => new { usuario, papeisUsuario }).Join(_ctx.Roles.AsNoTracking(),
               _papeisUsuario => _papeisUsuario.papeisUsuario.RoleId, papeis => papeis.Id, (_papeisUsuario, papeis)
               => new { _papeisUsuario, papeis }).Where(dado => dado._papeisUsuario.usuario.Email.Contains(query) ||
               dado._papeisUsuario.usuario.NomeCompleto.Contains(query)).Select(dadosSelecionados => new PesquisasAdministrativas
               {
                   IDUsuario = dadosSelecionados._papeisUsuario.usuario.Id,
                   NomeCompleto = dadosSelecionados._papeisUsuario.usuario.NomeCompleto,
                   Email = dadosSelecionados._papeisUsuario.usuario.Email,
                   TurmaID = dadosSelecionados._papeisUsuario.usuario.TurmaID,
                   DataNascimento = dadosSelecionados._papeisUsuario.usuario.DataNascimento,
                   DataCadastro = dadosSelecionados._papeisUsuario.usuario.DataCadastro,
                   Name = dadosSelecionados.papeis.Name,
                   IdPapel = dadosSelecionados.papeis.Id
               }).ToListAsync(cancellationToken);
                    LogUsuario log = new LogUsuario { UsuarioID = _userId, TipoLog = (short)ComandosSql.Select, Mensagem = $"{_userId} buscou alguns para visualização", Criado = DateTime.Now };
                    await _ctx.Log.AddAsync(log);
                    await _ctx.SaveChangesAsync();
                    return View(dados);
                }

            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        //[HttpGet]
        //public IActionResult Detalhes(/*string id*/)
        //{
        //    return View();
        //}

        [HttpGet]
        [Route("[controller]/detalhes/{id}/{nome}")]
        public async Task<IActionResult> Detalhes(string id, string nome, CancellationToken cancellationToken)
        {
            if (id is null)
            {
                return NotFound();
            }
            _userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var resultado = await _ctx.Usuario.AsNoTracking().Join(_ctx.UserRoles.AsNoTracking(), usuario => usuario.Id, papeisUsuario => papeisUsuario.UserId,
               (usuario, papeisUsuario) => new { usuario, papeisUsuario }).Join(_ctx.Roles.AsNoTracking(),
               _papeisUsuario => _papeisUsuario.papeisUsuario.RoleId, papeis => papeis.Id, (_papeisUsuario, papeis)
               => new { _papeisUsuario, papeis }).Where(dado => dado._papeisUsuario.usuario.Id == id).
               Select(dadosSelecionados => new PesquisasAdministrativas
               {
                   IDUsuario = dadosSelecionados._papeisUsuario.usuario.Id,
                   NomeCompleto = dadosSelecionados._papeisUsuario.usuario.NomeCompleto,
                   Email = dadosSelecionados._papeisUsuario.usuario.Email,
                   TurmaID = dadosSelecionados._papeisUsuario.usuario.TurmaID,
                   DataNascimento = dadosSelecionados._papeisUsuario.usuario.DataNascimento,
                   DataCadastro = dadosSelecionados._papeisUsuario.usuario.DataCadastro,
                   Name = dadosSelecionados.papeis.Name,
                   IdPapel = dadosSelecionados.papeis.Id
               }).ToListAsync(cancellationToken);
            LogUsuario log = new LogUsuario { UsuarioID = _userId, TipoLog = (short) ComandosSql.Select, Mensagem = $"{_userId} buscou alguns dados para visualização", Criado = DateTime.Now };
            await _ctx.Log.AddAsync(log);
            await _ctx.SaveChangesAsync();


            if (resultado.Count > 0)
            {
                return View(resultado);
            }

            else
            {
                return NotFound();
            }
        }



        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }


        [HttpPost]
        [Consumes("application/json")]
        public async Task<ActionResult> Registrar([FromBody] ApplicationUser Usuario)
        {
            if (Usuario.TipoUsuario > 2)
            {
                return BadRequest("Houve um erro no sistema em que ele não pôde compreender. Contacte o respectivo administrador para mmais detalhes");
            }

            var papelUsuario = Usuario.TipoUsuario switch
            {
                0 => Tipos.Admin,
                1 => Tipos.Professor,
                2 => Tipos.Aluno,
                _ => throw new ArgumentOutOfRangeException("O valor fornecedo é é maior do que o intervalo permitido"),
            };
            _userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var dadosUsuario = new ApplicationUser { NomeCompleto = Usuario.NomeCompleto, UserName = Usuario.Email, Email = Usuario.Email, DataNascimento = Usuario.DataNascimento };
            var novoUsuario = await _userManager.CreateAsync(dadosUsuario, Usuario.Senha);
            LogUsuario log = new LogUsuario { UsuarioID = _userId, TipoLog = (short) ComandosSql.Insert, Mensagem = $"{_userId} inseriu um novo usuário", Criado = DateTime.Now };
            await _ctx.Log.AddAsync(log);
            await _ctx.SaveChangesAsync();

            var papelAdicionado = await _userManager.AddToRoleAsync(dadosUsuario, $"{papelUsuario}");
            log = new LogUsuario { UsuarioID = _userId, TipoLog = (short) ComandosSql.Insert, Mensagem = $"{_userId} inseriu um papel a este último usuário", Criado = DateTime.Now };
            await _ctx.Log.AddAsync(log);
            await _ctx.SaveChangesAsync();


            if (novoUsuario.Succeeded && papelAdicionado.Succeeded)
            {
                return Ok(new { recursoCriado = $"Usuário criado com sucesso!" });
            }

            else
            {
                foreach (var erro in novoUsuario.Errors)
                {
                    ModelState.AddModelError("", erro.Description);
                }
            }
            return View();
        }


        [HttpGet]
        [Route("[controller]/atualizar/{id}/{nome}")]

        public async Task<IActionResult> Atualizar(string id, string nome, CancellationToken cancellationToken)
        {
            try
            {
                if (id is null)
                {
                    return NotFound();
                }

                var existeUsuario = await _userManager.FindByIdAsync(id);
                _userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

                LogUsuario log = new LogUsuario { UsuarioID = _userId, TipoLog = (short) ComandosSql.Select, Mensagem = $"{_userId} buscou alguns dados para atualização", Criado = DateTime.Now };
                await _ctx.Log.AddAsync(log);
                await _ctx.SaveChangesAsync();

                if (existeUsuario is null)
                {
                    return NotFound();
                }
                var dados = await _ctx.Usuario.AsNoTracking().Join(_ctx.UserRoles.AsNoTracking(), usuario => usuario.Id, papeisUsuario => papeisUsuario.UserId,
                   (usuario, papeisUsuario) => new { usuario, papeisUsuario }).Join(_ctx.Roles.AsNoTracking(),
                   _papeisUsuario => _papeisUsuario.papeisUsuario.RoleId, papeis => papeis.Id, (_papeisUsuario, papeis)
                   => new { _papeisUsuario, papeis }).Where(dado => dado._papeisUsuario.usuario.Id == id).
                   Select(dadosSelecionados => new PesquisasAdministrativas
                   {
                       IDUsuario = dadosSelecionados._papeisUsuario.usuario.Id,
                       NomeCompleto = dadosSelecionados._papeisUsuario.usuario.NomeCompleto,
                       Email = dadosSelecionados._papeisUsuario.usuario.Email,
                       TurmaID = dadosSelecionados._papeisUsuario.usuario.TurmaID,
                       DataNascimento = dadosSelecionados._papeisUsuario.usuario.DataNascimento,
                       DataCadastro = dadosSelecionados._papeisUsuario.usuario.DataCadastro,
                       Name = dadosSelecionados.papeis.Name,
                       IdPapel = dadosSelecionados.papeis.Id,
                   }).ToListAsync(cancellationToken);

                log = new LogUsuario { UsuarioID = _userId, TipoLog = (short)ComandosSql.Select, Mensagem = $"{_userId} buscou alguns dados para atualização", Criado = DateTime.Now };
                await _ctx.Log.AddAsync(log);
                await _ctx.SaveChangesAsync();

                return View(dados);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("[controller]/atualizar/{id}/{tipo}/{nome}")]


        public async Task<IActionResult> Atualizar([FromBody] PesquisasAdministrativas usuario, byte tipoPapelUsuario)
        {
            try
            {
                if (usuario.IDUsuario is null || usuario.IdPapel is null)
                {
                    return NotFound();
                }

                _userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var existeUsuario = await _userManager.FindByNameAsync(usuario.Email) as ApplicationUser;
                LogUsuario log = new LogUsuario { UsuarioID = _userId, TipoLog = (short)ComandosSql.Select, Mensagem = $"{usuario.NomeCompleto} buscou alguns dados para atualização", Criado = DateTime.Now };
                await _ctx.Log.AddAsync(log);
                await _ctx.SaveChangesAsync();

                if (existeUsuario.Id is null)
                {
                    return NotFound();
                }

                existeUsuario.NomeCompleto = usuario.NomeCompleto;
                existeUsuario.UserName = usuario.Email;
                existeUsuario.Email = usuario.Email;
                existeUsuario.DataNascimento = usuario.DataNascimento;
                existeUsuario.TipoUsuario = usuario.TipoUsuario;
                existeUsuario.Senha = usuario.Senha;
                existeUsuario.Id = usuario.IDUsuario;


                var usuarioAtualizado = await _userManager.UpdateAsync(existeUsuario);
                if (usuarioAtualizado.Succeeded)
                {
                    log = new LogUsuario { UsuarioID = _userId, TipoLog = (short)ComandosSql.Update, Mensagem = $"{_userId} atualizou alguns dados", Criado = DateTime.Now };
                    await _ctx.Log.AddAsync(log);
                    await _ctx.SaveChangesAsync();

                    var papelUsuario = usuario.TipoUsuario switch
                    {
                        0 => Tipos.Admin,
                        1 => Tipos.Professor,
                        2 => Tipos.Aluno,
                        _ => throw new ArgumentOutOfRangeException("O valor fornecedo é é maior do que o intervalo permitodo"),
                    };
                    var papelSelecionado = await _roleManager.FindByNameAsync($"{papelUsuario}");
                    if (papelSelecionado is null)
                    {
                        return NotFound();
                    }

                    papelSelecionado.Name = papelUsuario.ToString();
                    var papelRemovido = await _userManager.RemoveFromRoleAsync(existeUsuario, usuario.Name);


                    if (papelRemovido.Succeeded)
                    {
                        log = new LogUsuario { UsuarioID = _userId, TipoLog = (short)ComandosSql.Delete, Mensagem = $"{_userId} deletou alguns dados", Criado = DateTime.Now };
                        await _ctx.Log.AddAsync(log);
                        await _ctx.SaveChangesAsync();

                        var papelAtualizado = await _userManager.AddToRoleAsync(existeUsuario, papelUsuario.ToString());

                        if (papelAtualizado.Succeeded)
                        {
                            log = new LogUsuario { UsuarioID = _userId, TipoLog = (short)ComandosSql.Insert, Mensagem = $"{_userId} incluiu alguns dados", Criado = DateTime.Now };
                            await _ctx.Log.AddAsync(log);
                            await _ctx.SaveChangesAsync();
                            return Ok(new { msg = "Usuário atualizado com sucesso!" });
                        }

                    }
                    return BadRequest();



                }
                return BadRequest();

            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }

        }
        [HttpPost]
        public async Task<ActionResult> Deletar([FromBody] ApplicationUser usuario)
        {
            try
            {
                if (usuario.Id is null)
                {
                    return NotFound();
                }
                _userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var existeUsuario = await _userManager.FindByIdAsync(usuario.Id);
                if (existeUsuario is null)
                {
                    return NotFound();
                }

                //ApplicationUser usuario = new ApplicationUser { Id = pesquisas.IDUsuario };
                var usuarioApagado = await _userManager.DeleteAsync(existeUsuario);
                if (usuarioApagado.Succeeded)
                {
                    LogUsuario log = new LogUsuario { UsuarioID = _userId, TipoLog = (short)ComandosSql.Delete, Mensagem = $"{_userId} deletou alguns dados", Criado = DateTime.Now };
                    await _ctx.Log.AddAsync(log);
                    await _ctx.SaveChangesAsync();
                    return Ok(new { msg = "Usuário deletado com sucesso!" });
                }

                return BadRequest();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
