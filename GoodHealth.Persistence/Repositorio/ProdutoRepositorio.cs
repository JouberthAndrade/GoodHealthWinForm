using Dapper;
using GoodHealth.Model.Entidades;
using GoodHealth.Persistence.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Persistence.Repositorio
{
    public class ProdutoRepositorio
    {
        private readonly Executor<Produtos> _executor = new Executor<Produtos>();

        public int InserirProdutoUser(UsuarioDiaProduto entidade)
        {
            Executor<UsuarioDiaProduto> _executorUsuarioProduto = new Executor<UsuarioDiaProduto>();
            //var consulta = string.Format(ProdutosSql.InsertUsrProd, entidade.IdUsuario, entidade.IdProduto, entidade.IdDia, entidade.DataInicio.ToString(), entidade.DataFim.ToString());

            var parametro = new DynamicParameters();
            parametro.Add("@DATA_INICIO", entidade.DataInicio, System.Data.DbType.DateTime);
            parametro.Add("@DATA_FIM", entidade.DataFim, System.Data.DbType.DateTime);
            parametro.Add("@ID_USUARIO", entidade.IdUsuario, System.Data.DbType.Int32);
            parametro.Add("@ID_DIA", entidade.IdDia, System.Data.DbType.Int32);
            parametro.Add("@ID_PRODUTO", entidade.IdProduto, System.Data.DbType.Int32);

            return _executorUsuarioProduto.Escreve(ProdutosSql.InsertUsrProd, parametro);
        }

        public List<Produtos> GetAll()
        {
            Executor<Produtos> _exec = new Executor<Produtos>();
            var retorno = _exec.Ler(ProdutosSql.GetProduto);
            return retorno.ToList();
        }

        public List<UsuarioDiaProduto> GetProdutosUsuario(int idUsuario)
        {
            Executor<UsuarioDiaProduto> _executorUsuarioProduto = new Executor<UsuarioDiaProduto>();

            var parametro = new DynamicParameters();
            parametro.Add("@ID_USUARIO", idUsuario, System.Data.DbType.Int32);

            var retorno = _executorUsuarioProduto.LerDto<UsuarioDiaProduto>(ProdutosSql.GetProdutoUsuario, parametro);
            return retorno.ToList();

        }

        public int AtualizarProdutoUsuario(UsuarioDiaProduto entidade)
        {
            Executor<UsuarioDiaProduto> _executorUsuarioProduto = new Executor<UsuarioDiaProduto>();
            
            var parametro = new DynamicParameters();
            parametro.Add("@ID", entidade.Id, System.Data.DbType.Int32);
            parametro.Add("@DATA_INICIO", entidade.DataInicio, System.Data.DbType.DateTime);
            parametro.Add("@DATA_FIM", entidade.DataFim, System.Data.DbType.DateTime);
            return _executorUsuarioProduto.Escreve(ProdutosSql.AtualizaUsuarioProd, parametro);
        }
    }
}
