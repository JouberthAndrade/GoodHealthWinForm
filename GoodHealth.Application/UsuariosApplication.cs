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
    public class UsuariosApplication
    {
        private static readonly UsuariosRepositorio usuarioRepositorio = new UsuariosRepositorio();
        private static readonly ProdutoRepositorio produtoRepositorio = new ProdutoRepositorio();
        public bool ExisteUsuarios()
        {
            return usuarioRepositorio.ExisteUsuarios();
        }

        public List<Usuarios> GetUsuariosAtivos()
        {
            return usuarioRepositorio.ObterTodos().ToList();
        }

        public List<Usuarios> GetUsuariosAtivos(int idEmpresa)
        {
            return usuarioRepositorio.ObterPorEmpresa(idEmpresa).ToList();
        }

        public List<PagamentosDTO> GetPagamentos(int idPeriodo)
        {
            return usuarioRepositorio.GetPagamentos(idPeriodo).ToList();
        }

        public List<PagamentosDTO> GetUsuariosComunicado()
        {
            return usuarioRepositorio.GetUsuariosComunicado().ToList();
        }

        public List<PeriodoDTO> GetPeriodos()
        {
            return usuarioRepositorio.GetPeriodos();
        }

        public PeriodoDTO GetPeriodoAtual()
        {
            return usuarioRepositorio.GetPeriodoAtual();
        }

        public List<UsuarioAusenciaDTO> GetAusencias(int idUsuario)
        {
            return usuarioRepositorio.GetAusencias(idUsuario);
        }
        public List<UsuarioAusenciaDTO> GetAusencias(int idUsuario, int idPeriodo)
        {
            return usuarioRepositorio.GetAusencias(idUsuario, idPeriodo);
        }

        public int Salvar(UsuarioCadastroDTO usuario)
        {
            Usuarios user = new Usuarios();
            user = usuario.Usuario;
            user.ATIVO = true;

            int idUsuario = usuarioRepositorio.Inserir(user);
            UsuarioEmpresa userEmp = new UsuarioEmpresa();
            userEmp.ID_USUARIO = idUsuario;
            userEmp.ID_EMPRESA = usuario.Empresa.ID;

            var retornoEmp = usuarioRepositorio.InserirEmpresa(userEmp);
            
            return idUsuario;
        }

        public void InserirAusencia(UsuarioAusenciaDTO usuarioAusencia)
        {
            usuarioRepositorio.InserirAusencia(usuarioAusencia);
        }
    }
}
