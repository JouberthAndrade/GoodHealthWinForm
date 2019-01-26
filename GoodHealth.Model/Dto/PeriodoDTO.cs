using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Model.Dto
{
    public class PeriodoDTO
    {
        public int ID { get; set; }
        public string NOME { get; set; }

        public DateTime DATA_INICIO { get; set; }
        public DateTime DATA_FIM { get; set; }

    }
}
