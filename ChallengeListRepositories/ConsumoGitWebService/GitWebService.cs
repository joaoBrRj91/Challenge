
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

        public static List<RepositorioGitDTO> ObterRepositoriosPorUsuarioAcesso(string usuarioGit, string senha)
        {
            InicializarWebService(usuarioGit, senha);

            ObterRepositoriosGitDoUsuarioLogado();

            return repositoriosGitDTO;

        }

        public static bool AcessoGitHubEhValido(string usuarioGit, string senhaGit)
        {

            InicializarWebService(usuarioGit, senhaGit);

            bool acessoEhValido = false;

            if (!String.IsNullOrEmpty(usuarioGit) && !String.IsNullOrEmpty(senhaGit))
            {
                ConfigConsumoGitWebServices.UsuarioGit = usuarioGit;
                ConfigConsumoGitWebServices.SenhaGit = senhaGit;
                Credentials credenciasGitHub = new Credentials(ConfigConsumoGitWebServices.UsuarioGit, ConfigConsumoGitWebServices.SenhaGit);
                gitHubClient.Credentials = credenciasGitHub;
                try
                {
                    acessoEhValido = gitHubClient.User.Get(ConfigConsumoGitWebServices.UsuarioGit).Result != null ? true : false;

                }
                catch (AggregateException)
                {
                    //TODO: Criar um validateHelper que irá conter a lista de mensagens de erro e a causa dos mesmos

                }
                catch (Exception e)
                {
                }
                finally
                {
                    Dispose();
                }

            }

            return acessoEhValido;

        }

        private static void InicializarPropriedadesParaConsumoDeCliente(string usuarioGit, string senha)
        {
            ConfigConsumoGitWebServices.UsuarioGit = usuarioGit;
            ConfigConsumoGitWebServices.SenhaGit = senha;
            repositoriosGitDTO = new List<RepositorioGitDTO>();
            httpCliente = new HttpClient();
            gitHubClient = new GitHubClient(new Octokit.ProductHeaderValue("octokit"));
        }

        

        private static List<RepositorioGitDTO> ObterRepositoriosGitDoUsuarioLogado()
        {
            repositoriosGitDTO = new List<RepositorioGitDTO>();
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
            httpCliente = null;
            gitHubClient = null;
            repositoriosGitDTO = null;
        }

        private static void InicializarWebService(string usuarioGit,string senha)
        {
            Dispose();
            InicializarPropriedadesParaConsumoDeCliente(usuarioGit, senha);
        }

    }
}
