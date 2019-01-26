using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Model.Entidades
{
    public class PERIODO_PAGAMENTO
    {
        public int ID { get; set; }

        public string DESCRICAO { get; set; }

        public int ANO { get; set; }

        public DateTime DATA_INICIO { get; set; }

        public DateTime DATA_FIM { get; set; }

        public int? QTD_DIAS { get; set; }
    
    }
}
