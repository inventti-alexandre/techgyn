using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academia.Model.Vo.Sala;
using System.Data.SqlClient;
using System.Data;

using Npgsql;
using SqlCommand = Npgsql.NpgsqlCommand;
using SqlConnection = Npgsql.NpgsqlConnection;
using SqlDataAdapter = Npgsql.NpgsqlDataAdapter;

namespace Academia.Model.Dao.Salas
{
    public class Model_Dao_Salas
    {

        public void Incluir(Model_Vo_Sala pSala)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao();
                //command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into sala(nome,capacidade,tipo,idproduto) values (@nome,@capacidade,@tipo,@idproduto);";
                cmd.Parameters.AddWithValue("@nome", pSala.Nome);
                cmd.Parameters.AddWithValue("@capacidade", pSala.Capacidade);
                cmd.Parameters.AddWithValue("@tipo", pSala.Tipo.ToString());
                cmd.Parameters.AddWithValue("@idproduto", Convert.ToString(pSala.IdProduto));
                cn.Open();
                pSala.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL Erro:" + ex.Number);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public void Alterar(Model_Vo_Sala pSala)
        {
            // conexao
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update sala set nome = @nome, capacidade = @capacidade, tipo = @tipo, idproduto = @idproduto where id = @id;";
                cmd.Parameters.AddWithValue("@id", pSala.Id);
                cmd.Parameters.AddWithValue("@nome", pSala.Nome);
                cmd.Parameters.AddWithValue("@capacidade", pSala.Capacidade);
                cmd.Parameters.AddWithValue("@tipo", pSala.Tipo.ToString().ToString());
                cmd.Parameters.AddWithValue("@idproduto", Convert.ToString(pSala.IdProduto));
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL Erro:" + ex.Number);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        public Boolean Excluir(int id)
        {
            //conexao
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao();
                //command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "delete from sala where id = " + Convert.ToString(id);
                cn.Open();
                int resultado = cmd.ExecuteNonQuery();
                if (resultado != 1)
                {
                    throw new Exception("Não foi possível excluir a sala " + Convert.ToString(id));
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL Erro:" + ex.Number);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }

            return true;
        }

        public DataTable ListaSauna()
        {
            try
            {
                DataTable tabela = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from sala where tipo = 'Sauna'", Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
                da.Fill(tabela);
                return tabela;
            }
            catch (Exception ex)
            {
                //throw new Exception
            }
            return null;
        }

        public DataTable ListaDeSalas()
        {
            try
            {
                DataTable tabela = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from sala", Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
                da.Fill(tabela);
                return tabela;
            }        
            catch (Exception ex)
            {   
                //throw new Exception
            }     
            return null;
        }

        public DataTable GetSala(int pid)
        {
            try
            {
                DataTable tabela = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from sala where id = " + Convert.ToString(pid), Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
                da.Fill(tabela);
                return tabela;
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            return null;
        }
        

        public DataTable ListaDeSalasCom(String psParametro)
        {
            try
            {
                DataTable tabela = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from sala where cao like '%" + psParametro + "%' ", Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
                da.Fill(tabela);
                return tabela;
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            return null;
        }  

    }
}
