using System;
using System.Collections.Generic;
using System.Text;

namespace TopCandidates.Models
{
    public class Usuario
    {
        public string userId { get; set; }
        public string nomeCompleto { get; set; }
        public string cpf { get; set; }
        public string nomePai { get; set; }
        public string nomeMae { get; set; }
        public bool casado { get; set; }

        public List<Experiencia> experiencia { get; set; }

    }


    public class Profissao
    {
        public string profissaoId { get; set; }
        public string profissao { get; set; }

    }

    public class Experiencia
    {
        public string profissaoId { get; set; }
        public int anosDeExperiencia { get; set; }
    }
}
