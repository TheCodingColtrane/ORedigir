using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ORedigir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORedigir.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

     

        // GET: AccountController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }


   
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(ApplicationUser usuario)
        {
            if (usuario.Email is not null && usuario.Senha is not null)
            {
                var usuarioLogado = await _signInManager.PasswordSignInAsync(usuario.Email, usuario.Senha, true, true);
                if (usuarioLogado.Succeeded)
                {
                    if(User.IsInRole("Admin"))
                    {
                        return RedirectToAction("Intersticio", "MinhaArea");
                    }
                    else
                    {
                        return RedirectToAction("", "MinhaArea");
                    }
                }
                else
                {
                    ModelState.AddModelError("Valores errados", "E-mail ou Senha inválido(s)");
                    return View();
                }
            }

            else
            {
                ModelState.AddModelError(string.Empty, "Campos vazios!");
                return View();
            }

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Registrar()
        {
            return View();
        }

        // GET: AccountController/Create
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Registrar(ApplicationUser Usuario)
        {
            var novoUsuario = new ApplicationUser { UserName = Usuario.Email, Email = Usuario.Email, DataNascimento = Usuario.DataNascimento };
            var resultado = await _userManager.CreateAsync(novoUsuario, Usuario.Senha);

            if (resultado.Succeeded)
            {
                await _signInManager.SignInAsync(novoUsuario, true);
                return RedirectToAction("", "MinhaArea");
            }

            else
            {
                foreach(var erro in resultado.Errors)
                {
                    ModelState.AddModelError("", erro.Description);
                }
            }
            return View();
        }

        // POST: AccountController/Create
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

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
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

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
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
