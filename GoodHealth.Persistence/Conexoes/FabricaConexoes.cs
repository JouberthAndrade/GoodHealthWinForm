using GoodHealth.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Persistence.Conexoes
{
    public class FabricaConexao
    {
        private readonly static object sincronizador = new object();
        public IDbConnection Fabricar()
        {
            lock (sincronizador)
            {
                var conexao = Conexao.RetornaConexao();

                return new SqlConnection(conexao.StringConexaoLocal);
            }
        }
    }
}
