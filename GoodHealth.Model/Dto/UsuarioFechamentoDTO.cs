using GoodHealth.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Model.Dto
{
    public class UsuarioFechamentoDTO
    {
        public int ID_USUARIO { get; set; }
        public string NOME  { get; set; }
        public string EMAIL { get; set; }
        public Empresa Empresa { get; set; }
        public DiaFechamentoDTO DiaFechamentoDTO { get; set; }
        
    }
}
