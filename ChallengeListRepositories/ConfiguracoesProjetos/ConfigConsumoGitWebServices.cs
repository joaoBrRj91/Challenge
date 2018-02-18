namespace ConfiguracoesProjetos
{
    public static class ConfigConsumoGitWebServices
    {

        #region Configuração, das constantes, de acesso ao web service do github
        public const string ENDERECO_BASE = "https://api.github.com";

        public const string HEADER_API_GIT = "application/vnd.github.v3+json";

        #endregion

        #region Propriedades
        private static string usuarioGit = string.Empty;

        public static string UsuarioGit
        {
            get
            {
                return usuarioGit;
            }
            set
            {
                usuarioGit = value;
                uriUsuarioRepositorios = string.Empty;
            }
        }

        private static string uriUsuarioRepositorios = string.Empty;

        public  static string UriUsuarioRepositorios
        {
            get
            {
                if (string.IsNullOrEmpty(uriUsuarioRepositorios))
                    uriUsuarioRepositorios = ObterUriRepositoriosUsuario();

                return uriUsuarioRepositorios;
            }
            
        }
        #endregion

        #region Metodos auxiliares
        private static string ObterUriRepositoriosUsuario() => string.Format("{0}/{1}", UsuarioGit, "repos");
        #endregion

    }
}
