using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RhApi.Models
{
    public sealed class Funcionario : Pessoa
    {
        public string Ranal { get; set; }
        public string EmailProfissional { get; set; }
        public string Departamento { get; set; }
        public decimal Salario { get; set; }
        public DateTime DataAdmissao { get; set; }
        public EnumStatusFuncionario Status { get; set; }
    }
}