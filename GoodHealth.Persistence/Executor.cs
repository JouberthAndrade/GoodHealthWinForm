using Dapper;
using GoodHealth.Persistence.Conexoes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Persistence
{
    public class Executor<TEntidade>
    {
        private readonly Adaptador _adaptadorDados = new Adaptador(new FabricaConexao());

        public int Escreve(string comando, object parametro = null, IDbTransaction transacao = null, int? tempoEspera = null,
            CommandType? tipoComando = null)
        {
            try
            {
                var id = 0;
                _adaptadorDados.IniciarTransacao();

                transacao = transacao ?? _adaptadorDados.Transacao();
                if (comando.IndexOf("UPDATE") == 0)
                {   
                    transacao.Connection.Query<int>(comando, parametro, transacao, true, tempoEspera, tipoComando);
                }
                else
                {
                    comando += " SELECT CAST(SCOPE_IDENTITY() as int) ";
                    
                    id = transacao.Connection.Query<int>(comando, parametro, transacao, true, tempoEspera, tipoComando).Single();
                }
                _adaptadorDados.Submeter();

                return id;
            }
            catch (Exception ex)
            {
                _adaptadorDados.Reverter();
                throw;
            }
        }

        public void ExecuteProcedure(string nomeProcedure, DynamicParameters parametros)
        {
            try
            {
                using (var conexao = _adaptadorDados.FabricarConexao())
                {
                    conexao.Open();
                    conexao.Execute(nomeProcedure, parametros, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _adaptadorDados.Reverter();
                throw;
            }
        }

        public void ExecuteProcedure(string nomeProcedure)
        {
            try
            {
                using (var conexao = _adaptadorDados.FabricarConexao())
                {
                    conexao.Open();
                    
                    conexao.Execute(nomeProcedure, null, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                _adaptadorDados.Reverter();
                throw;
            }
        }

        public void EscreveNaoTransacionado(string comando, object parametro = null)
        {
            try
            {
                using (var conexao = _adaptadorDados.FabricarConexao())
                {
                    conexao.Open();
                    conexao.Execute(comando, parametro);
                }
            }
            catch (Exception)
            {
                _adaptadorDados.Reverter();
                throw;
            }
        }
        public IEnumerable<TEntidade> Ler(string comando, object parametro = null)
        {
            try
            {
                using (var conexao = _adaptadorDados.FabricarConexao())
                {
                    conexao.Open();

                    var resultado = conexao.Query<TEntidade>(comando, parametro, null, true, 180);

                    conexao.Close();
                    conexao.Dispose();
                    return resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TEntidade LerRegistroQueryMultiple<TChild>(string comando, object parametro = null)
        {
            try
            {
                using (var conexao = _adaptadorDados.FabricarConexao())
                {
                    conexao.Open();

                    var resultado = conexao.QueryMultiple(comando, parametro);
                    var _retorno = resultado.Read<TEntidade>().SingleOrDefault();
                    var _lista = resultado.Read<TChild>().ToList();
                    _retorno.GetType().GetProperty(typeof(TChild).Name + "Lista").SetValue(_retorno, _lista);


                    conexao.Close();
                    conexao.Dispose();
                    return _retorno;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public IEnumerable<TEntidade> LerComMultiplos<TChild, TChild2, TChild3>(string comando, object parametro = null)
        {
            try
            {
                using (var conexao = _adaptadorDados.FabricarConexao())
                {
                    conexao.Open();

                    var resultado = conexao.QueryMultiple(comando, parametro);
                    var _retorno = resultado.Read<TEntidade>().ToList<TEntidade>();
                    var _lista = resultado.Read<TChild>().ToList();
                    _retorno.GetType().GetProperty(typeof(TChild).Name + "Lista").SetValue(_retorno, _lista);


                    conexao.Close();
                    conexao.Dispose();
                    return _retorno;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TEntidade LerRegistroUnico(string comando, object parametro = null)
        {
            try
            {
                using (var conexao = _adaptadorDados.FabricarConexao())
                {
                    conexao.Open();

                    var resultado = conexao.Query<TEntidade>(comando, parametro);

                    conexao.Close();
                    conexao.Dispose();
                    return resultado.SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> LerDto<T>(string comando, object parametro = null)
        {
            try
            {
                using (var conexao = _adaptadorDados.FabricarConexao())
                {
                    conexao.Open();

                    var resultado = conexao.Query<T>(comando, parametro);

                    conexao.Close();
                    return (IEnumerable<T>)resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T LerRegistroUnicoDto<T>(string comando, object parametro = null)
        {
            try
            {
                using (var conexao = _adaptadorDados.FabricarConexao())
                {
                    conexao.Open();

                    var resultado = conexao.Query<T>(comando, parametro);

                    conexao.Close();
                    return (T)resultado.SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TEntidade> LerSplitOn<TEntidade, TChild>(string comando, object parametro = null)
        {
            try
            {
                using (var conexao = _adaptadorDados.FabricarConexao())
                {
                    conexao.Open();
                    var resultado = conexao.Query<TEntidade, TChild, TEntidade>(comando, (e1, e2) =>
                    {
                        e1.GetType().GetProperty(typeof(TChild).Name).SetValue(e1, e2);
                        return e1;
                    },
                        param: parametro,
                        splitOn: "ID_" + typeof(TChild).Name
                    );

                    return (IEnumerable<TEntidade>)resultado;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<TEntidade> LerSplitOn<TEntidade, TChild, TChild2>(string comando, object parametro = null)
        {
            try
            {
                using (var conexao = _adaptadorDados.FabricarConexao())
                {
                    conexao.Open();
                    var resultado = conexao.Query<TEntidade, TChild, TChild2, TEntidade>(comando, (e, c1, c2) =>
                    {
                        e.GetType().GetProperty(typeof(TChild).Name).SetValue(e, c1);

                        if (e.GetType().GetProperty(typeof(TChild2).Name) != null)
                        {
                            e.GetType().GetProperty(typeof(TChild2).Name).SetValue(e, c2);
                        }
                        else
                        {
                            if (c1 != null && c1.GetType().GetProperty(typeof(TChild2).Name) != null)
                            {
                                c1.GetType().GetProperty(typeof(TChild2).Name).SetValue(c1, c2);
                            }
                        }

                        return e;
                    },
                        param: parametro,
                        splitOn: "ID_" + typeof(TChild).Name + "," + "ID_" + typeof(TChild2).Name
                    );

                    //var resultado = conexao.Query<TEntidade, TChild, TChild2, TEntidade>(comando, (e1, e2, e3) =>
                    //{
                    //    e1.GetType().GetProperty(typeof(TChild).Name).SetValue(e1, e2);

                    //    if (e2.GetType().GetProperty(typeof(TChild2).Name) == null)
                    //    {
                    //        e1.GetType().GetProperty(typeof(TChild2).Name).SetValue(e1, e3);    
                    //    }
                    //    else
                    //    {
                    //        e2.GetType().GetProperty(typeof(TChild2).Name).SetValue(e2, e3);
                    //    }

                    //    return e1;
                    //},
                    //    param: parametro,
                    //    splitOn: "ID_" + typeof(TChild).Name + "," + "ID_" + typeof(TChild2).Name
                    //);

                    return (IEnumerable<TEntidade>)resultado;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public IEnumerable<TEntidade> LerSplitOn<TEntidade, TChild, TChild2, TChild3>(string comando, object parametro = null)
        {
            try
            {
                using (var conexao = _adaptadorDados.FabricarConexao())
                {
                    conexao.Open();
                    var resultado = conexao.Query<TEntidade, TChild, TChild2, TChild3, TEntidade>(comando, (e, c1, c2, c3) =>
                    {
                        e.GetType().GetProperty(typeof(TChild).Name).SetValue(e, c1);

                        if (e.GetType().GetProperty(typeof(TChild2).Name) != null)
                        {
                            e.GetType().GetProperty(typeof(TChild2).Name).SetValue(e, c2);   
                        }
                        else
                        {
                            if (c1 != null)
                            {
                                if (c1.GetType().GetProperty(typeof(TChild2).Name) != null)
                                    c1.GetType().GetProperty(typeof(TChild2).Name).SetValue(c1, c2);
                                if (c1.GetType().GetProperty(typeof(TChild3).Name) != null)
                                    c1.GetType().GetProperty(typeof(TChild3).Name).SetValue(c1, c3);
                            }
                            if (c2 != null)
                            {
                                if (c2.GetType().GetProperty(typeof(TChild3).Name) != null)
                                    c2.GetType().GetProperty(typeof(TChild3).Name).SetValue(c2, c3);
                            }
                        }

                        if (e.GetType().GetProperty(typeof(TChild3).Name) != null)
                        {
                            e.GetType().GetProperty(typeof(TChild3).Name).SetValue(e, c2);
                        }
                        else
                        {
                            if (c1 != null)
                            {
                                if (c1.GetType().GetProperty(typeof(TChild2).Name) != null)
                                    c1.GetType().GetProperty(typeof(TChild2).Name).SetValue(c1, c2);
                                if (c1.GetType().GetProperty(typeof(TChild3).Name) != null)
                                    c1.GetType().GetProperty(typeof(TChild3).Name).SetValue(c1, c3);
                            }
                            if (c2 != null)
                            {
                                if (c2.GetType().GetProperty(typeof(TChild3).Name) != null)
                                    c2.GetType().GetProperty(typeof(TChild3).Name).SetValue(c2, c3);
                            }
                        }

                        return e;
                    },
                        param: parametro,
                        splitOn: "ID_" + typeof(TChild).Name + "," + "ID_" + typeof(TChild2).Name + "," + "ID_" + typeof(TChild3).Name
                    );

                    return (IEnumerable<TEntidade>)resultado;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public TEntidade LerRegistroSplitOn<TEntidade, TChild>(string comando, object parametro = null)
        {
            try
            {
                using (var conexao = _adaptadorDados.FabricarConexao())
                {
                    conexao.Open();
                    var resultado = conexao.Query<TEntidade, TChild, TEntidade>(comando, (e1, e2) =>
                    {
                        e1.GetType().GetProperty(typeof(TChild).Name).SetValue(e1, e2);
                        return e1;
                    },
                        param: parametro,
                        splitOn: "ID_" + typeof(TChild).Name
                    ).FirstOrDefault();

                    return resultado;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public TEntidade LerRegistroSplitOn<TEntidade, TChild, TChild2>(string comando, object parametro = null)
        {
            try
            {
                using (var conexao = _adaptadorDados.FabricarConexao())
                {
                    conexao.Open();
                    var resultado = conexao.Query<TEntidade, TChild, TChild2, TEntidade>(comando, (e1, e2, e3) =>
                    {
                        e1.GetType().GetProperty(typeof(TChild).Name).SetValue(e1, e2);
                        if (e2.GetType().GetProperty(typeof(TChild2).Name) == null)
                        {
                            e1.GetType().GetProperty(typeof(TChild2).Name).SetValue(e1, e3);
                        }
                        else
                        {
                            e2.GetType().GetProperty(typeof(TChild2).Name).SetValue(e2, e3);
                        }

                        return e1;
                    },
                        param: parametro,
                        splitOn: "ID_" + typeof(TChild).Name + "," + "ID_" + typeof(TChild2).Name
                    ).FirstOrDefault();

                    return resultado;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ExecuteScalar(string comando, object parametro = null)
        {

            try
            {
                using (var conexao = _adaptadorDados.FabricarConexao())
                {
                    conexao.Open();

                    int qtdRetono = int.MinValue;
                    var resultado = conexao.ExecuteScalar(comando, parametro);
                    conexao.Close();

                    if (int.TryParse(resultado.ToString(), out qtdRetono))
                        return qtdRetono;

                    return 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
