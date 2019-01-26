using Dapper;
using GoodHealth.Model.Dto;
using GoodHealth.Model.Entidades;
using GoodHealth.Persistence.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Persistence.Repositorio
{
    public class UsuariosRepositorio
    {
        private readonly Executor<Usuarios> _executor = new Executor<Usuarios>();

        public int Inserir(Usuarios entidade)
        {
            var consulta = string.Format(UsuariosSql.Insert, entidade.NOME, entidade.EMAIL, entidade.TELEFONE);
            return _executor.Escreve(consulta);
        }

        public int InserirEmpresa(UsuarioEmpresa entidade)
        {
            Executor<UsuarioEmpresa> _exec = new Executor<UsuarioEmpresa>();
            var consulta = string.Format(UsuariosSql.InsertEmpresa, entidade.ID_EMPRESA, entidade.ID_USUARIO);
            return _exec.Escreve(consulta);
        }

        public IEnumerable<Usuarios> ObterPorEmpresa(int idEmpresa)
        {
            var consulta = string.Format(UsuariosSql.GetUsuariosEmpresa, idEmpresa);
            var retorno = _executor.LerDto<Usuarios>(consulta);
            return retorno;
        }

        public Usuarios ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuarios> ObterTodos()
        {
            return _executor.Ler(UsuariosSql.GetUsuariosAtivos);
        }

        public IEnumerable<Usuarios> Pesquisar(Expression<Func<Usuarios, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        public List<UsuarioAusenciaDTO> GetAusencias(int idUsuario)
        {
            Executor<UsuarioAusenciaDTO> _exec = new Executor<UsuarioAusenciaDTO>();
            var parametro = new DynamicParameters();
            parametro.Add("@ID_USUARIO", idUsuario, System.Data.DbType.Int32);

            var retorno = _exec.LerDto<UsuarioAusenciaDTO>(UsuariosSql.GetAusencia, parametro);

            return retorno.ToList();
        }

        public List<UsuarioAusenciaDTO> GetAusencias(int idUsuario, int idPeriodo)
        {
            Executor<UsuarioAusenciaDTO> _exec = new Executor<UsuarioAusenciaDTO>();
            var parametro = new DynamicParameters();
            parametro.Add("@ID_USUARIO", idUsuario, System.Data.DbType.Int32);
            parametro.Add("@ID_PERIODO", idPeriodo, System.Data.DbType.Int32);

            var retorno = _exec.LerDto<UsuarioAusenciaDTO>(UsuariosSql.GetAusenciaUsuario, parametro);

            return retorno.ToList();
        }

        public bool ExisteUsuarios()
        {
            var consulta = string.Format(UsuariosSql.GetQtdUsuariosAtivos);
            var qtd = _executor.ExecuteScalar(consulta);
   
            return qtd > 0;
        }

        public void InserirAusencia(UsuarioAusenciaDTO usuarioAusencia)
        {
            var parametro = new DynamicParameters();
            parametro.Add("@DATA_INICIO", usuarioAusencia.DataInicio);
            parametro.Add("@DATA_FIM", usuarioAusencia.DataFim);
            parametro.Add("@ID_USUARIO", usuarioAusencia.Id);
            parametro.Add("@MOTIVO", usuarioAusencia.Motivo);

            _executor.ExecuteProcedure("PR_INCLUIR_AUSENCIA", parametro);
        }

        public bool Salvar(UsuarioCadastroDTO usuario)
        {
            throw new NotImplementedException();
        }

        public void AtualizaUsuario(Usuarios usuario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PagamentosDTO> GetPagamentos(int idPeriodo)
        {
            Executor<PagamentosDTO> _exec = new Executor<PagamentosDTO>();
            var consulta = string.Format(PagamentosSql.GetPagamentos, idPeriodo);
            var retorno = _exec.LerDto<PagamentosDTO>(consulta);
            return retorno;
        }

        public IEnumerable<PagamentosDTO> GetUsuariosComunicado()
        {
            Executor<PagamentosDTO> _exec = new Executor<PagamentosDTO>();
            var consulta = string.Format(UsuariosSql.GetUsuariosComunicado);
            var retorno = _exec.LerDto<PagamentosDTO>(consulta);
            return retorno;
        }

        public List<PeriodoDTO> GetPeriodos()
        {
            Executor<PeriodoDTO> _exec = new Executor<PeriodoDTO>();
            var retorno = _exec.LerDto<PeriodoDTO>(UsuariosSql.GetPeriodos);
            return retorno.ToList();
        }

        public PeriodoDTO GetPeriodoAtual()
        {
            Executor<PeriodoDTO> _exec = new Executor<PeriodoDTO>();
            var retorno = _exec.LerRegistroUnicoDto<PeriodoDTO>(UsuariosSql.GetPeriodoAtual);
            return retorno;
        }
    }
}
