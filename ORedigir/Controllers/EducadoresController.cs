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
using System.Threading;
using System.Threading.Tasks;

namespace ORedigir.Controllers
{
    [Authorize("Admin,Professor")]
    public class EducadoresController : Controller
    {
        private readonly ORedigirContext _ctx;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private string _userId;
        public EducadoresController(ORedigirContext ctx, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _ctx = ctx;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        // GET: EducadoresController
        public async Task<ActionResult> Index(string id, CancellationToken cancelattionToken )
        {
            if(User.IsInRole("Professor"))
            {
                return View(await _ctx.Turma.AsNoTracking().Take(30).OrderBy(o => o.TurmaNome).Where(x => x.Professor == id).ToListAsync(cancelattionToken));
            }
            else
            {
                return View(await _ctx.Turma.AsNoTracking().Take(30).OrderBy(o => o.TurmaNome).ToListAsync(cancelattionToken));
            }

        }

        [HttpGet]
        [Route("[controller]/criar/turma")]
        public ActionResult Turma()
        {
            return View();
        }

        // GET: EducadoresController/Create
        [HttpPost]
        [Route("[controller]/criar/turma")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Turma([FromBody] Turma turma)
        {
            await _ctx.Turma.AddAsync(turma);
            await _ctx.SaveChangesAsync();
            return Ok(new { msg = "Turma criada com sucesso!" });
        }
        // POST: EducadoresController/Create
        [HttpGet]
        [ValidateAntiForgeryToken]
        [Route("[controller]/turma/{id}/matricular-alunos")]
        public ActionResult Matricular()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[controller]/turma/{id}/matricular-alunos")]
        public async Task<ActionResult> Matricular([FromBody] ApplicationUser usuario)
        {
            await _ctx.AddAsync(usuario);
            await _ctx.SaveChangesAsync();
            return Ok(new { msg = "Turma criada com sucesso!" });
        }


        // GET: EducadoresController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EducadoresController/Edit/5
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

        // GET: EducadoresController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EducadoresController/Delete/5
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
