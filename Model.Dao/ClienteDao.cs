using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class ClienteDao : IMetodosDb<Cliente>
    {
        private ConexaoDB _conexaoDB;
        private SqlCommand _sqlcommad;

        public ClienteDao()
        {
            _conexaoDB = ConexaoDB.OpenConn();
        }

        public void Create(Cliente obj)
        {
            try
            {
                _sqlcommad = new SqlCommand();
                _sqlcommad.Connection = _conexaoDB.GetConn();
                _sqlcommad.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlcommad.CommandText = "sp_CreateCliente";

                _sqlcommad.Parameters.AddWithValue("@Nome",      obj.Nome);
                _sqlcommad.Parameters.AddWithValue("@Endereco",  obj.Endereco);
                _sqlcommad.Parameters.AddWithValue("@Telefone",  obj.Telefone);
                _sqlcommad.Parameters.AddWithValue("@CPF",       obj.CPF);

                _sqlcommad.Connection.Open();

                _sqlcommad.ExecuteNonQuery();
            }
            catch (System.Exception e)
            {
                obj.Estado = 999;
            }
            finally
            {
                _conexaoDB.GetConn().Close();
                _conexaoDB.GetConn().Dispose();
            }
        }

        public void Delete(Cliente obj)
        {
            try
            {
                _sqlcommad = new SqlCommand();
                _sqlcommad.Connection = _conexaoDB.GetConn();
                _sqlcommad.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlcommad.CommandText = "sp_DeleteCliente";

                _sqlcommad.Parameters.AddWithValue("@IdCliente", obj.IdCliente);

                _conexaoDB.GetConn().Open();

                _sqlcommad.ExecuteNonQuery();
            }
            catch (System.Exception e)
            {
                obj.Estado = 999;
            }
            finally
            {
                _conexaoDB.GetConn().Close();
                _conexaoDB.GetConn().Dispose();
            }
        }

        public bool Find(Cliente obj)
        {
            try
            {
                _sqlcommad = new SqlCommand();
                _sqlcommad.Connection = _conexaoDB.GetConn();
                _sqlcommad.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlcommad.CommandText = "sp_FindCliente";

                _sqlcommad.Parameters.AddWithValue("@IdCliente", obj.IdCliente);

                _sqlcommad.Connection.Open();

                SqlDataReader reader = _sqlcommad.ExecuteReader();
                while (reader.Read())
                {
                    obj.Nome = reader["Nome"].ToString();
                    obj.Endereco = reader["Endereco"].ToString();
                    obj.Telefone = reader["Telefone"].ToString();
                    obj.CPF = reader["CPF"].ToString();
                }
            }
            catch (System.Exception e)
            {
                obj.Estado = 999;
            }
            finally
            {
                _conexaoDB.GetConn().Close();
                _conexaoDB.GetConn().Dispose();
            }

            return true;
        }

        public List<Cliente> FindAll()
        {
            List<Cliente> lstClientes = new List<Cliente>();
            Cliente cli;
            try
            {
                _sqlcommad = new SqlCommand();
                _sqlcommad.Connection = _conexaoDB.GetConn();
                _sqlcommad.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlcommad.CommandText = "sp_FindAllClintes";

                _sqlcommad.Connection.Open();

                SqlDataReader reader = _sqlcommad.ExecuteReader();
                while (reader.Read())
                {
                    cli = new Cliente()
                    {
                        IdCliente = Convert.ToInt64(reader["IdCliente"].ToString()),
                        Nome = reader["Nome"].ToString(),
                        Endereco = reader["Endereco"].ToString(),
                        Telefone = reader["Telefone"].ToString(),
                        CPF = reader["CPF"].ToString()
                    };
                    lstClientes.Add(cli);
                }

            }
            catch (System.Exception e)
            {
                cli = new Cliente { Estado = 999 };
            }
            finally
            {
                _conexaoDB.GetConn().Close();
                _conexaoDB.GetConn().Dispose();
            }

            return lstClientes;
        }

        public void Update(Cliente obj)
        {
            try
            {
                _sqlcommad = new SqlCommand();
                _sqlcommad.Connection = _conexaoDB.GetConn();
                _sqlcommad.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlcommad.CommandText = "sp_UpdateCliente";

                _sqlcommad.Parameters.AddWithValue("@IdClienteAlte", obj.IdCliente);
                _sqlcommad.Parameters.AddWithValue("@Nome",      obj.Nome);
                _sqlcommad.Parameters.AddWithValue("@Endereco",  obj.Endereco);
                _sqlcommad.Parameters.AddWithValue("@Telefone",  obj.Telefone);
                _sqlcommad.Parameters.AddWithValue("@CPF",       obj.CPF);

                _sqlcommad.Connection.Open();

                _sqlcommad.ExecuteNonQuery();
            }
            catch (System.Exception e)
            {
                obj.Estado = 999;
            }
            finally
            {
                _conexaoDB.GetConn().Close();
                _conexaoDB.GetConn().Dispose();
            }
        }

        public long FindClienteCPF(Cliente obj)
        {
            long qdt = 0;
            try
            {
                _sqlcommad = new SqlCommand();
                _sqlcommad.Connection = _conexaoDB.GetConn();
                _sqlcommad.CommandType = System.Data.CommandType.StoredProcedure;
                _sqlcommad.CommandText = "sp_FindClientePorCPF";

                _sqlcommad.Parameters.AddWithValue("@CPF", obj.CPF);

                _sqlcommad.Connection.Open();

                SqlDataReader reader = _sqlcommad.ExecuteReader();
                while (reader.Read())
                {
                    obj.Nome = reader["Nome"].ToString();
                    obj.Endereco = reader["Endereco"].ToString();
                    obj.Telefone = reader["Telefone"].ToString();
                    obj.CPF = reader["CPF"].ToString();

                    qdt = Convert.ToInt64(obj.IdCliente);
                }
            }
            catch (System.Exception e)
            {
                obj.Estado = 999;
            }
            finally
            {
                _conexaoDB.GetConn().Close();
                _conexaoDB.GetConn().Dispose();
            }

            return qdt;
            
        }
    }
}
