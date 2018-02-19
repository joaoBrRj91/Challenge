using System.Collections.Generic;

namespace Domain.Entities
{
    public class UsuarioGit
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<RepositorioGit> RepositioriosGit { get; set; }

    }
}
