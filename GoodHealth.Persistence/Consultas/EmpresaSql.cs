using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Persistence.Consultas
{
    public class EmpresaSql
    {
        public const string GetEmpresas = @"SELECT * FROM EMPRESA ORDER BY NOME";
    }
}
