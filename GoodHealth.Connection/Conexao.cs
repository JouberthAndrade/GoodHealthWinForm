using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Connection
{
    public static class Conexao
    {
        public static ConexaoModel RetornaConexao()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var instanciaDoAplicativo = appSettings.Get("InstanciaDoAplicativo");

            ConexaoModel conexaoAtual;

            switch (instanciaDoAplicativo)
            {
                case "PRD":
                    conexaoAtual = new ConexaoProducao();
                    break;

                default:
                    throw new Exception(
                        "Versão da Base de Dados não encontrada - necessário fornecer um Objeto Versão Valido.");
            }

            return conexaoAtual;
        }
    }
}
