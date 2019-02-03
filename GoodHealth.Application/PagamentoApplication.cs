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
    public class PagamentoApplication
    {
        private static readonly PagamentoRepositorio pagamentoRepositorio = new PagamentoRepositorio();

        public List<PagamentosDTO> GetPagamentos(int idPeriodo)
        {
            return pagamentoRepositorio.GetPagamentos(idPeriodo).ToList();
        }

        public List<PagamentoDetalhadoDTO> GetPagamentosDetalhado(int idPeriodo)
        {
            var retorno = pagamentoRepositorio.GetPagamentoDetalhado(idPeriodo).ToList();

            var listaGroup = retorno.GroupBy(item => new { item.ID_USUARIO, item.NOME, item.EMAIL, item.EMPRESA })
                  .Select(group => new PagamentoDetalhadoDTO {
                      ID_USUARIO = group.Key.ID_USUARIO,
                      NOME = group.Key.NOME,
                      EMAIL = group.Key.EMAIL,
                      EMPRESA = group.Key.EMPRESA,

                      Datas = group.GroupBy(grp => new { grp.ID_USUARIO, grp.DATA_FECHAMENTO }).Select(grpDatas => new DataFechamentoDetalhadoDTO {
                          DATA_FECHAMENTO = grpDatas.Key.DATA_FECHAMENTO,
                          Produtos = grpDatas.Select(p => new ProdutoFechamentoDetalhadoDTO {
                              ID_PRODUTO = p.ID_PRODUTO,
                              DESCRICAO_PRODUTO = p.DESCRICAO_PRODUTO,
                              VALOR_PRODUTO = p.VALOR_PRODUTO
                          }).ToList()
                      }).ToList()
                  }).ToList();


            return listaGroup;
        }

    }
}
