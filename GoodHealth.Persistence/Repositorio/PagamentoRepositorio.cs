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
    public class PagamentoRepositorio
    {
        private readonly Executor<PagamentosDTO> _executor = new Executor<PagamentosDTO>();

        public IEnumerable<PagamentosDTO> GetPagamentos(int idPeriodo)
        {
            var consulta = string.Format(PagamentosSql.GetPagamentos, idPeriodo);
            var retorno = _executor.LerDto<PagamentosDTO>(consulta);
            return retorno;
        }

        public IEnumerable<PagamentoDetalhadoDTO> GetPagamentoDetalhado(int idPeriodo)
        {
            Executor<PagamentoDetalhadoDTO> _exec = new Executor<PagamentoDetalhadoDTO>();
            var parametro = new DynamicParameters();
            parametro.Add("@ID_PERIODO", idPeriodo, System.Data.DbType.Int32);
            
            var retorno = _exec.LerDto<PagamentoDetalhadoDTO>(PagamentosSql.GetPagamentosDetalhado, parametro);
            // var teste = _exec.LerSplitOn<UsuarioFechamentoDTO, Empresa, DiaFechamentoDTO, Produtos>(PagamentosSql.GetPagamentosDetalhado, parametro);
            return retorno;
        }

    }
}
