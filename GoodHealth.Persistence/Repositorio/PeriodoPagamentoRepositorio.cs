using System;
using Dapper;
using GoodHealth.Model.Dto;
using GoodHealth.Model.Entidades;
using GoodHealth.Persistence.Consultas;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Persistence.Repositorio
{
    public class PeriodoPagamentoRepositorio
    {
        private readonly Executor<PERIODO_PAGAMENTO> _executor = new Executor<PERIODO_PAGAMENTO>();

        public IEnumerable<PERIODO_PAGAMENTO> GetPeriodos()
        {
            var consulta = string.Format(PagamentosSql.GetPagamentos);

            return null;
        }

        public IEnumerable<PERIODO_PAGAMENTO> GetPeriodo(int idPeriodo)
        {
            Executor<PagamentoDetalhadoDTO> _exec = new Executor<PagamentoDetalhadoDTO>();
            var parametro = new DynamicParameters();
            parametro.Add("@ID_PERIODO", idPeriodo, System.Data.DbType.Int32);

            var retorno = _exec.LerDto<PERIODO_PAGAMENTO>(PagamentosSql.GetPeriodo, parametro);
            // var teste = _exec.LerSplitOn<UsuarioFechamentoDTO, Empresa, DiaFechamentoDTO, Produtos>(PagamentosSql.GetPagamentosDetalhado, parametro);
            return retorno;
        }

        public void ExecutaFechamento()
        {
            _executor.ExecuteProcedure("PR_CALCULA_PAG_DETALHADO");
        }
    }
}
