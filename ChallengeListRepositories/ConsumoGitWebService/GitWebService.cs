
using ConfiguracoesProjetos;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ConsumoGitWebService
{
    public static class GitWebService
    {

        public  static void ListarRepositoriosPorUsuario()
        {
            HttpClient httpCliente = new HttpClient();
            httpCliente.BaseAddress = new Uri(ConfigConsumoGitWebServices.ENDERECO_BASE);
            httpCliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ConfigConsumoGitWebServices.HEADER_API_GIT));
            HttpResponseMessage response =  httpCliente.GetAsync(ConfigConsumoGitWebServices.UriUsuarioRepositorios).Result;

            if (response.IsSuccessStatusCode)
            {
                var repositoriosJsonString = response.Content.ReadAsStringAsync();

            }

        }
    }
}
