using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Model.Entidades
{
    public class UsuarioDiaProduto
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdProduto { get; set; }
        public int IdDia { get; set; }

        public string Dia { get; set; }
        public string Produto { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public List<Produtos> ListaProdutos { get; set; }
    }
}
