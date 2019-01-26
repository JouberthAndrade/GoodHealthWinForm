using GoodHealth.Model.Entidades;
using GoodHealth.Persistence.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Application
{
    public class EmpresaApplication
    {
        private static readonly EmpresaRepositorio empresaRepositorio = new EmpresaRepositorio();

        public List<Empresa> GetAll()
        {
            return empresaRepositorio.GetAll();
        }
    }
}
