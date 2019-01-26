using GoodHealth.Persistence.Conexoes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Persistence
{
    public class Adaptador : IAdaptador
    {
        private readonly FabricaConexao _fabricaConexao;

        private IDbTransaction _transacao;

        private IDbConnection _conexao;
        private FabricaConexao fabricaConexao;

        public Adaptador(FabricaConexao fabricaConexao)
        {
            _fabricaConexao = fabricaConexao;
        }

        public IDbConnection FabricarConexao()
        {
            _conexao = _fabricaConexao.Fabricar();
            return _conexao;
        }

        public void IniciarTransacao()
        {
            if (_conexao == null || _conexao.State == ConnectionState.Closed)
            {
                _conexao = FabricarConexao();
            }

            _conexao.Open();
            _transacao = _conexao.BeginTransaction();
        }

        public void Reverter()
        {
            if (_transacao == null)
            {
                throw new OperationCanceledException("Não existe transação ativa para esta operação.");
            }

            try
            {
                if (_transacao.Connection.State != ConnectionState.Closed)
                    _transacao.Rollback();
            }
            finally
            {
                try
                {
                    _transacao.Dispose();
                }
                finally
                {
                    _transacao = null;
                }

                if (_conexao != null && _conexao.State == ConnectionState.Open)
                {
                    _conexao.Close();
                }
            }
        }

        public void Submeter()
        {
            if (_transacao == null)
            {
                throw new OperationCanceledException("Não existe transação ativa para esta operação.");
            }

            try
            {
                _transacao.Commit();
            }
            finally
            {
                try
                {
                    _conexao.Close();
                    _transacao.Dispose();
                }
                finally
                {
                    _transacao = null;
                }

                if (_conexao != null && _conexao.State == ConnectionState.Open)
                {
                    _conexao.Close();
                }
            }
        }

        public IDbTransaction Transacao()
        {
            return _transacao;
        }
    }
}
