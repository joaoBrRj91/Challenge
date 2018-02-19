using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChallengeListRepositories.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Informe Login de Acesso")]
        [Display(Name = "Login*")]
        public string UsuarioGit { get; set; }

        [Required(ErrorMessage = "Informe a Senha de Acesso")]
        [Display(Name = "Senha*")]
        [DataType(DataType.Password)]
        public string SenhaGit { get; set; }

    }
}