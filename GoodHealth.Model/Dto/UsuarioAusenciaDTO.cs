using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Model.Dto
{
    public class UsuarioAusenciaDTO 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Id_Periodo { get; set; }
        public string Desc_Periodo { get; set; }
        public DateTime Data_Ausencia { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Motivo { get; set; }
    }
}
