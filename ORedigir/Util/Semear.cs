using Microsoft.AspNetCore.Identity;
using ORedigir.Models;
using System;
using System.Threading.Tasks;

namespace ORedigir.Util
{
    public class Semear
    {
        public static Task Dados (UserManager<ApplicationUser> userManager)
        {
            try
            {
                var existeAdm = userManager.FindByEmailAsync("admin@admin.com.br").Result;

                if (existeAdm is null)
                {
                    ApplicationUser user = new()
                    {
                        UserName = "admin@admin.com.br",
                        Email = "admin@admin.com.br",
                        NomeCompleto = "admin@admin",
                        DataNascimento = DateTime.Now
                    };

                    var result = userManager.CreateAsync(user, "Admin*123").Result;

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, "Admin").Wait();
                    }

                    else
                    {
                        throw new Exception("Houve um erro na atualização dos dados");
                    }

                    var existeProfessor = userManager.FindByEmailAsync("prof@prof.com.br").Result;

                    if (existeProfessor is null)
                    {
                        user = new()
                        {
                            UserName = "prof@prof.com.br",
                            Email = "prof@prof.com.br",
                            NomeCompleto = "prof@prof",
                            DataNascimento = DateTime.Now
                    };

                        result = userManager.CreateAsync(user, "Prof*123").Result;

                        if (result.Succeeded)
                        {
                            userManager.AddToRoleAsync(user, "Professor").Wait();
                        }

                        else
                        {
                            throw new Exception("Houve um erro na atualização dos dados");
                        }
                    }

                    var existeAluno = userManager.FindByEmailAsync("aluno@aluno.com.br").Result;

                    if (existeProfessor is null)
                    {
                        user = new()
                        {
                            UserName = "aluno@aluno.com.br",
                            Email = "aluno@aluno.com.br",
                            NomeCompleto = "Aluno@Aluno",
                            DataNascimento = DateTime.Now
                        };

                        result = userManager.CreateAsync(user, "Aluno*123").Result;

                        if (result.Succeeded)
                        {
                            userManager.AddToRoleAsync(user, "Aluno").Wait();
                        }

                        else
                        {
                            throw new Exception("Houve um erro na atualização dos dados");
                        }
                    }

                }

                return Task.CompletedTask;
            }

            catch (Exception ex)
            {
                throw ex;
            }
          

        }

    }
}
