using ChallengeListRepositories.Models;
using ConsumoGitWebService;
using ConsumoGitWebService.DTO;
using Data.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ChallengeListRepositories.Controllers
{
    public class GitHubController : Controller
    {

        public GitHubController()
        {
            UsuarioGitRepository UsuarioGitRepository = new UsuarioGitRepository();
            UsuarioGitService UsuarioGitService = new UsuarioGitService(UsuarioGitRepository);
        }

       
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            return RedirectToAction("ObterUsuarioRepositorios", login);
        }

        [HttpGet]
        public ActionResult ObterUsuarioRepositorios(LoginModel login)
        {
            ViewBag.UsuarioGit = login.UsuarioGit;
            List<RepositorioGitDTO> repositorios = GitWebService.ObterRepositoriosPorUsuarioAcesso(login.UsuarioGit,login.SenhaGit);
            return View(repositorios);
        }

      
    }
}