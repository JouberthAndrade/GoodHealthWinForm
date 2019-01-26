using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Persistence.Consultas
{
    public class UsuariosSql
    {
        public const string GetUsuariosAtivos = @"SELECT * FROM USUARIOS WHERE ATIVO = 1";
        public const string GetQtdUsuariosAtivos = @"SELECT COUNT(*) FROM USUARIOS WHERE ATIVO = 1";

        public const string GetPeriodos = @"SELECT ID, DESCRICAO + '/'+ CONVERT(VARCHAR, ANO) AS NOME, * FROM PERIODO_PAGAMENTO WHERE ANO = 2019 OR ID IN(94,95)";

        public const string GetPeriodoAtual = @"SELECT ID, DESCRICAO AS NOME FROM PERIODO_PAGAMENTO WHERE GETDATE() BETWEEN DATA_INICIO AND DATA_FIM;";

        public const string GetUsuariosComunicado = @"SELECT U.ID AS ID_USUARIO, U.NOME, U.EMAIL, E.NOME AS EMPRESA
                                            FROM USUARIOS U
                                            INNER JOIN USUARIO_EMPRESA UE ON UE.ID_USUARIO = U.ID
                                            INNER JOIN EMPRESA E ON E.ID = UE.ID_EMPRESA
                                            WHERE U.EMAIL IS NOT NULL AND U.EMAIL <> ''
                                            AND E.ID = 1
                                            AND U.ATIVO = 1
                                            --AND U.ID = 19
                                            ORDER BY U.NOME";

        public const string Insert = @"INSERT INTO USUARIOS(NOME, EMAIL, TELEFONE) VALUES ('{0}', '{1}', '{2}') ";
        public const string InsertEmpresa = @"INSERT INTO USUARIO_EMPRESA(ID_EMPRESA, ID_USUARIO) VALUES ({0}, {1})";


        public const string GetUsuariosEmpresa = @"SELECT U.*
                                                    FROM USUARIOS U
                                                    INNER JOIN USUARIO_EMPRESA UE ON UE.ID_USUARIO = U.ID
                                                    WHERE U.ATIVO = 1
                                                    AND UE.ID_EMPRESA = {0} ORDER BY U.NOME";

        public const string GetAusenciaUsuario = @"SELECT U.ID, U.NOME, UA.ID_PERIODO, PA.DESCRICAO AS DESC_PERIODO, UA.DATA_AUSENCIA
                                                    FROM PERIODO_PAGAMENTO PA 
                                                    INNER JOIN USUARIO_AUSENCIA UA ON UA.ID_PERIODO = PA.ID
                                                    INNER JOIN USUARIOS U ON U.ID = UA.ID_USUARIO
                                                    WHERE UA.ID_USUARIO = @ID_USUARIO
                                                    AND PA.ID = @ID_PERIODO
                                                    ORDER BY UA.DATA_AUSENCIA";

        public const string GetAusencia = @"SELECT U.ID, U.NOME, UA.ID_PERIODO, PA.DESCRICAO AS DESC_PERIODO, UA.DATA_AUSENCIA
                                                    FROM PERIODO_PAGAMENTO PA 
                                                    INNER JOIN USUARIO_AUSENCIA UA ON UA.ID_PERIODO = PA.ID
                                                    INNER JOIN USUARIOS U ON U.ID = UA.ID_USUARIO
                                                    WHERE UA.ID_USUARIO = @ID_USUARIO
                                                   -- AND CONVERT(VARCHAR, GETDATE(), 23) BETWEEN CONVERT(VARCHAR, PA.DATA_INICIO, 23) AND CONVERT(VARCHAR, PA.DATA_FIM, 23)
                                                    ORDER BY UA.DATA_AUSENCIA";

    }
}
