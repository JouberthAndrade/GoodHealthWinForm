using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Persistence.Consultas
{
    public class DiasSql
    {
        public const string GetDias = @"SELECT * FROM DIA_SEMANA where WEEKDAY not in (7,1)";
    }
}
