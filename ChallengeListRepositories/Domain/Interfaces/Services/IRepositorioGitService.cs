using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces.Services
{
    public interface IRepositorioGitService
    {
        bool RepositorioExisteNoGitHub(string repositorioGit);
        List<RepositorioGit> PreencherRepositoriosGit(IReadOnlyList<object> Items);
    }
}
