namespace Domain.Entities
{
    public class RepositorioGit
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public UsuarioGit UsuarioGit { get; set; }

    }
}
