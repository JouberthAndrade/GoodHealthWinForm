using GoodHealth.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Model.Dto
{
    public class UsuarioCadastroDTO
    {
        public Usuarios Usuario { get; set; }
        public Empresa Empresa { get; set; }
        public List<UsuarioDiaProduto> UsuarioProdutos { get; set; }

    }
}
