using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model.Entity;

namespace Model.Dao
{
    public class VendaDao
    {
        private ConexaoDB objConexaoDB;
        private SqlCommand comando;

        public VendaDao()
        {
            objConexaoDB = ConexaoDB.OpenConn();

        }
       
        public string create(Venda objVenda)
        {
            string idVenda = "";
            string create = "insert into venda(total,idCliente,idVendedor,data,TAXA) values('" + objVenda.Total + "','" + objVenda.IdCliente + "','" + objVenda.IdVendedor + "','" + objVenda.Data + "','"+objVenda.Taxa+ "') SELECT SCOPE_IDENTITY();";
            try
            {
                comando = new SqlCommand(create, objConexaoDB.GetConn());
                objConexaoDB.GetConn().Open();

                //RECUPERAR O CODIGO AUTOGENERADO
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    idVenda = reader[0].ToString();
                }

            }
            catch (Exception e)
            {
                objVenda.Estado = 1;
            }
            finally
            {
                objConexaoDB.GetConn().Close();
                objConexaoDB.CloseConn();
            }
            return idVenda;

        }
        public void update(Venda objVenda)
        {
            string update = "update venda set total='" + objVenda.Total + "',idCliente='" + objVenda.IdCliente + "',idVendedor='" + objVenda.IdVendedor + "',data='" + objVenda.Data + "',TAXA='"+objVenda.Taxa+"' where idVenda='" + objVenda.IdVenda + "'";
            try
            {
                comando = new SqlCommand(update, objConexaoDB.GetConn());
                objConexaoDB.GetConn().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                objVenda.Estado = 1;
            }
            finally
            {
                objConexaoDB.GetConn().Close();
                objConexaoDB.CloseConn();
            }
        }
        public void delete(Venda objVenda)
        {
            string delete = "delete from venda where idVenda='" + objVenda.IdVenda + "'";
            try
            {
                comando = new SqlCommand(delete, objConexaoDB.GetConn());
                objConexaoDB.GetConn().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objVenda.Estado = 1;
            }
            finally
            {
                objConexaoDB.GetConn().Close();
                objConexaoDB.CloseConn();
            }

        }
        public bool find(Venda objVenda)
        {
            bool temRegistros;
            string find = "select*from venda where idVenda='" + objVenda.IdVenda + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.GetConn());
                objConexaoDB.GetConn().Open();
                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)//para pegar as iformações teria que ser um While no reader.Read() 
                {
                    //objVenda.Total = Convert.ToDouble(reader[1].ToString());
                    //objVenda.IdCliente = Convert.ToInt64(reader[2].ToString());
                    //objVenda.IdVendedor = reader[3].ToString();
                    //objVenda.Data = reader[4].ToString();
                    //objVenda.Taxa = Convert.ToDouble(reader[5].ToString());
                    //objVenda.Estado = 99;

                }
                else
                {
                    objVenda.Estado = 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objConexaoDB.GetConn().Close();
                objConexaoDB.CloseConn();
            }
            return temRegistros;
        }       
        public List<Venda> findAll()
        {
            List<Venda> listaVendas = new List<Venda>();
            string findAll = "select*from Venda";
            try
            {
                comando = new SqlCommand(findAll, objConexaoDB.GetConn());
                objConexaoDB.GetConn().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Venda objVenda = new Venda();
                    objVenda.IdVenda= Convert.ToInt64(reader[0].ToString());
                    objVenda.Total = Convert.ToDouble(reader[1].ToString());
                    objVenda.IdCliente = Convert.ToInt64(reader[2].ToString());
                    objVenda.IdVendedor = reader[3].ToString();
                    objVenda.Data = reader[4].ToString();
                    objVenda.Taxa =  Convert.ToDouble(reader["TAXA"].ToString());
                    listaVendas.Add(objVenda);

                }
            }
            catch (Exception e )
            {

                throw;
            }
            finally
            {
                objConexaoDB.GetConn().Close();
                objConexaoDB.CloseConn();
            }

            return listaVendas;

        }        
        public bool findVendaPorClienteId(Venda objVenda)
        {
            bool temRegistros;
            string find = "select*from venda where idCliente='" + objVenda.IdCliente + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.GetConn());
                objConexaoDB.GetConn().Open();
                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {                   
                    objVenda.Estado = 99;
                }
                else
                {
                    objVenda.Estado = 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexaoDB.GetConn().Close();
                objConexaoDB.CloseConn();
            }
            return temRegistros;
        }       
        public bool findVendaPorVendedorId(Venda objVenta)
        {
            bool temRegistros;
            string find = "select*from venda where idVendedor='" + objVenta.IdVendedor + "'";
            try
            {
                comando = new SqlCommand(find, objConexaoDB.GetConn());
                objConexaoDB.GetConn().Open();
                SqlDataReader reader = comando.ExecuteReader();
                temRegistros = reader.Read();
                if (temRegistros)
                {
                    objVenta.Estado = 99;
                }
                else
                {
                    objVenta.Estado = 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexaoDB.GetConn().Close();
                objConexaoDB.CloseConn();
            }
            return temRegistros;
        }

       


    }
}
