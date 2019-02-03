using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoodHealth.Model.Enum.Enums;

namespace GoodHealth.Model.Dto
{
    public class PagamentoDetalhadoDTO
    {
       
        public int ID_USUARIO { get; set; }
        public string NOME { get; set; }
        public string EMAIL { get; set; }
        public string EMPRESA { get; set; }
        public int ID_PRODUTO { get; set; }
        public string DESCRICAO_PRODUTO { get; set; }
        public decimal VALOR_PRODUTO { get; set; }
        public string DIA { get; set; }
        public DateTime DATA_FECHAMENTO { get; set; }

        public List<DataFechamentoDetalhadoDTO> Datas { get; set; }
        
    }


    public class DataFechamentoDetalhadoDTO
    {
        public DateTime DATA_FECHAMENTO { get; set; }
        public string DIA { get; set; }
        public List<ProdutoFechamentoDetalhadoDTO> Produtos { get; set; }

    }

    public class ProdutoFechamentoDetalhadoDTO
    {
        public int ID_PRODUTO { get; set; }
        public decimal VALOR_PRODUTO { get; set; }
        public string DESCRICAO_PRODUTO { get; set; }

        public eProdutos TIPO { get { return (eProdutos)ID_PRODUTO; } }

    }
}
