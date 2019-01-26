using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Persistence.Consultas
{
    public class ProdutosSql
    {
        public const string GetProduto = @"SELECT * FROM PRODUTOS";

        public const string InsertUsrProd = @"INSERT INTO USUARIO_DIA_PRODUTO(ID_USUARIO, ID_PRODUTO, ID_DIA, DATA_CADASTRO, DATA_INICIO, DATA_FIM) 
                                            VALUES (@ID_USUARIO, @ID_PRODUTO, @ID_DIA, GETDATE(), @DATA_INICIO, @DATA_FIM)";

        public const string AtualizaUsuarioProd = @"UPDATE USUARIO_DIA_PRODUTO SET DATA_INICIO = @DATA_INICIO, DATA_FIM = @DATA_FIM WHERE ID = @ID ";


        public const string GetProdutoUsuario = @"SELECT UD.ID, U.ID AS IdUsuario, UD.ID_PRODUTO AS IdProduto, UD.ID_DIA AS IdDia,  
                                                        D.DESCRICAO AS DIA, P.DESCRICAO AS PRODUTO, ud.DATA_INICIO as DataInicio, ud.DATA_FIM as DataFim
                                                    FROM USUARIOS U
                                                    INNER JOIN USUARIO_DIA_PRODUTO UD ON UD.ID_USUARIO = U.ID
                                                    INNER JOIN DIA_SEMANA D ON D.ID = UD.ID_DIA
                                                    INNER JOIN PRODUTOS P ON P.ID = UD.ID_PRODUTO 
                                                    WHERE U.ID = @ID_USUARIO
                                                    ORDER BY UD.ID_DIA";
    }
}
