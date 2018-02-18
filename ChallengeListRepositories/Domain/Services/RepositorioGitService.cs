

using System;
using Domain.Interfaces.Services;
using Domain.Interfaces.Repositories;

namespace Domain.Services
{
    public class RepositorioGitService : IRepositorioGitService
    {
        private readonly IRepositorioGitRepository repositorioGitRepository;

        public RepositorioGitService(IRepositorioGitRepository repositorioGitRepository)
        {
            this.repositorioGitRepository = repositorioGitRepository;
        }


        /// <summary>
        /// Logica para ser validada atraves de um serviço disponibilizado pelo git
        /// </summary>
        /// <param name="usuarioGit"></param>
        /// <returns></returns>
        public bool RepositorioExisteNoGitHub(string repositorioGit)
        {
            return true;
        }
    }
}
