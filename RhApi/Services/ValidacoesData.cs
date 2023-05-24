using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RhApi.Services
{
    public static class ValidacoesData
    {
        public static bool DataNaoInformada(DateTime data)
        {
            return data == DateTime.MinValue;
        }

        public static bool DataAnteriorFundacaoDaEmpresa(DateTime data)
        {
            var dataFundacao = new DateTime(2020, 5, 30);

            return data < dataFundacao;
        }
    }
}