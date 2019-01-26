using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Model.Entidades
{
    public class Produtos
    {
        public int ID_PRODUTOS { get; set; }
        public int ID { get; set; }

        public string DESCRICAO { get; set; }

        public decimal VALOR { get; set; }
    }
}
