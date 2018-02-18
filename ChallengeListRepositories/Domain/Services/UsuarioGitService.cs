
using System;
using Domain.Interfaces.Services;
using Domain.Interfaces.Repositories;

namespace Domain.Services
{
    public class UsuarioGitService : IUsuarioGitService
    {

        private readonly IUsuarioGitRepository usuarioGitRepository;


        public UsuarioGitService(IUsuarioGitRepository usuarioGitRepository)
        {
            this.usuarioGitRepository = usuarioGitRepository;
        }

        /// <summary>
        /// Logica para ser validada atraves de um serviço disponibilizado pelo git
        /// </summary>
        /// <param name="usuarioGit"></param>
        /// <returns></returns>
        public bool UsuarioEhCadastradoNoGitHub(string usuarioGit)
        {
            return true;
        }
    }
}
