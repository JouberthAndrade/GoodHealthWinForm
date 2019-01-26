using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Model.Entidades
{
    public class DIA_SEMANA
    {
        public int ID { get; set; }

        public string FLAG   { get; set; }
        public string DESCRICAO { get; set; }

        public int WEEKDAY { get; set; }
    }
}
