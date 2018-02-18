using ConsumoGitWebService;
using Data.Repositories;
using Domain.Services;
using System;
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

        public ActionResult Index()
        {
            GitWebService.ListarRepositoriosPorUsuario("joaoBrRj91");
            return View();
        }

        public ActionResult ObterUsuarioRepositorios(string usuarioGit)
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }
    }
}