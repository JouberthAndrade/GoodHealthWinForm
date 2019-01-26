using GoodHealth.Model.Entidades;
using GoodHealth.Persistence.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Application
{
    public class DiasApplication
    {
        private static readonly DiasRepositorio diasRepositorio = new DiasRepositorio();

        public List<DIA_SEMANA> GetAll()
        {
            return diasRepositorio.GetAll();
        }
    }
}
