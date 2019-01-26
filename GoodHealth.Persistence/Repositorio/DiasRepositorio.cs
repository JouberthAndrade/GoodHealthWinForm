using GoodHealth.Model.Entidades;
using GoodHealth.Persistence.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Persistence.Repositorio
{
    public class DiasRepositorio
    {
        private readonly Executor<DIA_SEMANA> _executor = new Executor<DIA_SEMANA>();

        public List<DIA_SEMANA> GetAll()
        {
            var retorno = _executor.Ler(DiasSql.GetDias);
            return retorno.ToList();
        }
    }
}
