using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Model.Dto
{
    public class ProdutoTelaDTO
    {
        public int IdProduto { get; set; }
        public int IdDia { get; set; }
        public string NomeProduto { get; set; }
        public string DescricaoDia { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}
