using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Model.Dto
{
    public class PagamentosDTO
    {
        public int ID_PAGAMENTO { get; set; }
        public int ID_USUARIO { get; set; }
        public string NOME { get; set; }
        public string EMAIL { get; set; }
        public string EMPRESA { get; set; }
        public string PERIODO { get; set; }
        public decimal VALOR { get; set; }
        public int QTD_DIAS_TOTAL { get; set; }
        public int QTD_DIAS_AUSENCIA { get; set; }
    }
}
