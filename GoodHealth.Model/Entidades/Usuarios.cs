using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Model.Entidades
{
    public class Usuarios
    {
        public int ID { get; set; }

        public string NOME { get; set; }

        public string EMAIL { get; set; }

        public string TELEFONE { get; set; }

        public bool? ATIVO { get; set; }
    }
}
