
using ConfiguracoesProjetos;
using ConsumoGitWebService.DTO;
using Octokit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ConsumoGitWebService
{
    public static class GitWebService
    {
        private static HttpClient httpCliente;
        private static GitHubClient gitHubClient;
        private static List<RepositorioGitDTO> repositoriosGitDTO;
        //private static bool CredenciaisForamAlteradas = false;

        public static List<RepositorioGitDTO>  ObterRepositoriosPorUsuarioAcesso(string usuarioGit,string senha)
        {
            Dispose();

            InicializarPropriedadesParaConsumoDeCliente(usuarioGit, senha);

            if (AcessoGitHubEhValido())
            {
                ObterRepositoriosGitDoUsuarioLogado();
            }

            return repositoriosGitDTO;

        }

        private static void InicializarPropriedadesParaConsumoDeCliente(string usuarioGit, string senha)
        {
            ConfigConsumoGitWebServices.UsuarioGit = usuarioGit;
            ConfigConsumoGitWebServices.SenhaGit = senha;
            httpCliente = new HttpClient();
            gitHubClient = new GitHubClient(new Octokit.ProductHeaderValue("octokit"));
        }

        private static bool AcessoGitHubEhValido()
        {
            Credentials credenciasGitHub = new Credentials(ConfigConsumoGitWebServices.UsuarioGit, ConfigConsumoGitWebServices.SenhaGit);
            gitHubClient.Credentials = credenciasGitHub;
            bool acessoEhValido = gitHubClient.User.Get(ConfigConsumoGitWebServices.UsuarioGit).Result != null ? true : false;
            return acessoEhValido;
        }

        //private static bool VerificarSeCredenciaisForamAlteradas(string usuarioGit, string senha)
        //{
        //    if (!String.IsNullOrEmpty(ConfigConsumoGitWebServices.UsuarioGit) && !ConfigConsumoGitWebServices.UsuarioGit.Equals(usuarioGit))
        //         CredenciaisForamAlteradas = true;
        //    if (!String.IsNullOrEmpty(ConfigConsumoGitWebServices.SenhaGit) && !ConfigConsumoGitWebServices.SenhaGit.Equals(senha))
        //         CredenciaisForamAlteradas = true;

        //    return CredenciaisForamAlteradas;

        //}

        private static List<RepositorioGitDTO> ObterRepositoriosGitDoUsuarioLogado()
        {
            repositoriosGitDTO  = new List<RepositorioGitDTO>();
            var buscaRepositoriosGitUsuario = new SearchRepositoriesRequest() { User = ConfigConsumoGitWebServices.UsuarioGit };
            SearchRepositoryResult repositoriosGitUsuario = gitHubClient.Search.SearchRepo(buscaRepositoriosGitUsuario).Result;

            foreach (var item in repositoriosGitUsuario.Items)
            {
                repositoriosGitDTO.Add(new RepositorioGitDTO { Id = item.Id, Nome = item.Name, CloneUrl = item.CloneUrl, Url = item.Url });
            }

            return repositoriosGitDTO;
        }

        private static void Dispose()
        {     
            repositoriosGitDTO.Clear();
            repositoriosGitDTO = null;
            httpCliente = null;
            gitHubClient = null;
        }

    }
}
