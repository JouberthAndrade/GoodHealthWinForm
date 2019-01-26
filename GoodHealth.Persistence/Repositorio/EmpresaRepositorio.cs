using GoodHealth.Model.Entidades;
using GoodHealth.Persistence.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Persistence.Repositorio
{
    public class EmpresaRepositorio
    {
        private readonly Executor<Empresa> _executor = new Executor<Empresa>();

        public List<Empresa> GetAll()
        {
            Executor<Empresa> _exec = new Executor<Empresa>();
            var retorno = _exec.Ler(EmpresaSql.GetEmpresas);
            return retorno.ToList();
        }
    }
}
