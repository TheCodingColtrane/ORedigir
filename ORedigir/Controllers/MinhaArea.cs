using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ORedigir.Data;
using ORedigir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ORedigir.Controllers
{
    [Authorize]
    public class MinhaArea : Controller
    {
        private readonly ORedigirContext _ctx;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ClaimsPrincipal _usuarioAtual;

        private enum Tipos
        {
            Admin,
            Professor,
            Aluno

        }
        public MinhaArea(ORedigirContext ctx, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _ctx = ctx;
            _userManager = userManager;
            _roleManager = roleManager;
            _usuarioAtual = User;

        }
        // GET: MinhaArea
        public async Task<ActionResult> Index()
        {

            if (User.IsInRole("Admin"))
            {
                return View(await _ctx.PropostaTextual.AsNoTracking().Join(_ctx.Sa.AsNoTracking(), 
                dadosPropostaTextual => dadosPropostaTextual.RepoID, dadosSA => dadosSA.ID,
                (dadosPropostaTextual, dadosSA) => new { dadosPropostaTextual, dadosSA })
                .Join(_ctx.Turma.AsNoTracking(), dados => dados.dadosPropostaTextual.TurmaID,
                _dados => _dados.ID, (dados, _dados) => new { dados, _dados }).Take(30).OrderBy(data => data.dados.dadosPropostaTextual.DataInicio).
                Where(t => t.dados.dadosPropostaTextual.DataInicio >= DateTime.Now
                & t.dados.dadosPropostaTextual.TurmaID == null || t.dados.dadosPropostaTextual.TurmaID > 0).ToListAsync());
            }
            else if (User.IsInRole("Professor"))
            {
                return View(await _ctx.PropostaTextual.AsNoTracking().Join(_ctx.Sa.AsNoTracking(),
               dadosPropostaTextual => dadosPropostaTextual.RepoID, dadosSA => dadosSA.ID,
               (dadosPropostaTextual, dadosSA) => new { dadosPropostaTextual, dadosSA })
               .Join(_ctx.Turma.AsNoTracking(), dados => dados.dadosPropostaTextual.TurmaID,
               _dados => _dados.ID, (dados, _dados) => new { dados, _dados }).Join(_ctx.Usuario.AsNoTracking(),
               _dadosPropostaTextual => _dadosPropostaTextual.dados.dadosPropostaTextual.UsuarioID, dadosUsuario => dadosUsuario.Id,
               (_dadosPropostaTextual, dadosUsuario) => new { _dadosPropostaTextual, dadosUsuario })
               .Take(30).OrderBy(data => data._dadosPropostaTextual.dados.dadosPropostaTextual.DataInicio).
                Where(t => t.dadosUsuario.Id == _userManager.GetUserId(User)).ToListAsync());
            }
            else
            {
                return View(await _ctx.PropostaTextual.AsNoTracking().Join(_ctx.Sa.AsNoTracking(),
            dadosPropostaTextual => dadosPropostaTextual.RepoID, dadosSA => dadosSA.ID,
            (dadosPropostaTextual, dadosSA) => new { dadosPropostaTextual, dadosSA })
            .Join(_ctx.Turma.AsNoTracking(), dados => dados.dadosPropostaTextual.TurmaID,
            _dados => _dados.ID, (dados, _dados) => new { dados, _dados }).Join(_ctx.Usuario.AsNoTracking(),
            _dadosPropostaTextual => _dadosPropostaTextual.dados.dadosPropostaTextual.UsuarioID, dadosUsuario => dadosUsuario.Id,
            (_dadosPropostaTextual, dadosUsuario) => new { _dadosPropostaTextual, dadosUsuario })
            .Take(30).OrderBy(data => data._dadosPropostaTextual.dados.dadosPropostaTextual.DataInicio).
            Where(t => t.dadosUsuario.Id == _userManager.GetUserId(User)).ToListAsync());
            }




        }

        // GET: MinhaArea/Details/5
        [HttpGet]
        [Route("[controller]/propostatextual/{id}/{titulo}")]
        public ActionResult PropostaTextual(string id, string titulo)
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Professor")]
        public ActionResult Intersticio()
        {
            return View();
        }

        // POST: MinhaArea/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MinhaArea/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MinhaArea/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MinhaArea/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MinhaArea/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
