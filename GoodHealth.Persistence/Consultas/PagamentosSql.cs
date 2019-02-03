using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Persistence.Consultas
{
    public class PagamentosSql
    {
        public const string GetPeriodo = @"SELECT * 
                                            FROM PERIODO_PAGAMENTO
                                            WHERE ID = @ID_PERIODO";

        public const string GetPagamentos = @"SELECT U.ID AS ID_USUARIO, U.NOME, U.EMAIL, E.NOME AS EMPRESA, PP.DESCRICAO AS PERIODO, 
                                                P.VALOR, P.QTD_DIAS_TOTAL, P.QTD_DIAS_AUSENCIA
                                                FROM LOG_PAGAMENTO P
                                                INNER JOIN USUARIOS U ON U.ID = P.ID_USUARIO
                                                INNER JOIN USUARIO_EMPRESA UE ON UE.ID_USUARIO = U.ID
                                                INNER JOIN EMPRESA E ON E.ID = UE.ID_EMPRESA
                                                INNER JOIN PERIODO_PAGAMENTO PP ON PP.ID = P.ID_PERIODO
                                                WHERE U.EMAIL IS NOT NULL AND U.EMAIL <> ''
                                                AND P.ATIVO = 1 
                                                ANd PP.ID = {0}
                                                --AND E.ID = 1
                                                --AND U.ID IN (71)
                                                AND U.ATIVO = 1
                                                AND P.VALOR > 0
                                                ORDER BY E.NOME, U.NOME ";

        public const string GetPagamentosDetalhado = @"SELECT U.ID AS ID_USUARIO, U.NOME, U.EMAIL, 
                                                            E.NOME AS EMPRESA,  
                                                            D.DESCRICAO AS DIA, CONVERT(VARCHAR, L.DATA_FECHAMENTO, 23) as DATA_FECHAMENTO,
                                                            P.ID AS ID_PRODUTO, P.DESCRICAO AS DESCRICAO_PRODUTO, (P.VALOR - ISNULL(UPD.VALOR,0)) AS VALOR_PRODUTO
                                                        FROM LOG_FECHAMENTO_DETALHADO L
                                                        INNER JOIN USUARIOS U ON U.ID = L.ID_USUARIO
                                                        INNER JOIN PRODUTOS P ON P.ID = L.ID_PRODUTO
                                                        INNER JOIN DIA_SEMANA D ON D.ID = L.ID_DIA
                                                        INNER JOIN USUARIO_EMPRESA UE ON UE.ID_USUARIO = U.ID
                                                        INNER JOIN EMPRESA E ON E.ID = UE.ID_EMPRESA
                                                        LEFT JOIN USUARIO_PRODUTO_DESCONTO UPD ON UPD.ID_USUARIO = U.ID AND UPD.ID_PRODUTO = P.ID
                                                        WHERE L.ID_PERIODO = @ID_PERIODO
                                                        AND L.ATIVO = 1
                                                        --AND L.ID_USUARIO in(71, 107)
                                                        AND NOT EXISTS (
	                                                        SELECT *
	                                                        FROM USUARIO_AUSENCIA UA
	                                                        WHERE UA.ID_PERIODO = L.ID_PERIODO
	                                                        AND CONVERT(VARCHAR, UA.DATA_AUSENCIA, 23) = CONVERT(VARCHAR, L.DATA_FECHAMENTO, 23)
	                                                        AND UA.ID_USUARIO = U.ID
                                                        )
                                                        --AND L.PAGO = 0
                                                        ORDER BY E.NOME, U.NOME, L.DATA_FECHAMENTO";


    }
}
