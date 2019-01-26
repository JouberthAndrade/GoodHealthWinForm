using GoodHealth.Model.Dto;
using GoodHealth.Model.Entidades;
using GoodHealth.Persistence.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Application
{
    public class PeriodoPagamentoApplication
    {
        private static readonly PeriodoPagamentoRepositorio periodoRepositorio = new PeriodoPagamentoRepositorio();

        public List<PeriodoDTO> GetPeriodos()
        {
            return null;
        }

        public PeriodoDTO GetPeriodo(int idPeriodo)
        {
            var retorno = periodoRepositorio.GetPeriodo(idPeriodo).FirstOrDefault();
            if (retorno == null)
                return null;
            else
            {
                return new PeriodoDTO() {
                    ID = retorno.ID,
                    NOME = retorno.DESCRICAO,
                    DATA_INICIO = retorno.DATA_INICIO,
                    DATA_FIM = retorno.DATA_FIM
                };
            }
        }

        public bool ExecutaFechamento()
        {
            try
            {
                periodoRepositorio.ExecutaFechamento();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
