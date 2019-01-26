using GoodHealth.Model.Entidades;
using GoodHealth.Persistence.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Application
{
    public class ProdutoApplication
    {
        private static readonly ProdutoRepositorio produtoRepositorio = new ProdutoRepositorio();

        public List<Produtos> GetAll()
        {
            return produtoRepositorio.GetAll();
        }

        public bool Salvar(UsuarioDiaProduto objUsuarioProduto)
        {
            try
            {
                foreach (var item in objUsuarioProduto.ListaProdutos)
                {
                    UsuarioDiaProduto entidade = new UsuarioDiaProduto();
                    entidade.IdUsuario = objUsuarioProduto.IdUsuario;
                    entidade.IdDia = objUsuarioProduto.IdDia;
                    entidade.IdProduto = item.ID;
                    entidade.DataInicio = objUsuarioProduto.DataInicio;
                    entidade.DataFim = objUsuarioProduto.DataFim;

                    
                    produtoRepositorio.InserirProdutoUser(entidade);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public List<UsuarioDiaProduto> GetProdutosUsuario(int idUsuario)
        {
            return produtoRepositorio.GetProdutosUsuario(idUsuario);
        }

        public bool Atualizar(UsuarioDiaProduto objUsuarioProduto)
        {
            try
            {
                UsuarioDiaProduto entidade = new UsuarioDiaProduto();
                entidade.Id = objUsuarioProduto.Id;
                entidade.IdProduto = objUsuarioProduto.ListaProdutos.FirstOrDefault().ID;
                entidade.DataInicio = objUsuarioProduto.DataInicio;
                entidade.DataFim = objUsuarioProduto.DataFim;
                    
                produtoRepositorio.AtualizarProdutoUsuario(entidade);

                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
