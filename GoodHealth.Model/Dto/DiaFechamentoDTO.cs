using GoodHealth.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Model.Dto
{
    public class DiaFechamentoDTO
    {
        public int ID_DiaFechamentoDTO { get; set; }
        public string DIA { get; set; }
        public DateTime DATA_FECHAMENTO { get; set; }

        public Produtos Produtos { get; set; }
    }
}
