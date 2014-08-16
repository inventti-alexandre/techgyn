using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academia.Model.Vo.Agenda;
using System.Data.SqlClient;
using System.Data;

using Npgsql;
using SqlCommand = Npgsql.NpgsqlCommand;
using SqlConnection = Npgsql.NpgsqlConnection;
using SqlDataAdapter = Npgsql.NpgsqlDataAdapter;

namespace Academia.Model.Dao.Agendas
{
    public class Model_Dao_Agendas
    {

        public void Incluir(Model_Vo_Agenda pAgenda)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao();
                //command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into agenda(datahorareserva,idcliente,idsala) values (@datahorareserva,@idcliente,@idsala);";
                cmd.Parameters.AddWithValue("@datahorareserva", Dados.Model_Dao_Dados.ConverterDataToStr(pAgenda.DataHoraReserva, false));
                cmd.Parameters.AddWithValue("@idcliente", pAgenda.IdCliente);
                cmd.Parameters.AddWithValue("@idsala", pAgenda.IdSala);
                cn.Open();
                pAgenda.Id = Convert.ToInt32(cmd.ExecuteScalar());
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
        public void Alterar(Model_Vo_Agenda pAgenda)
        {
            // conexao
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update agenda set datahorareserva = @datahorareserva, idcliente = @idcliente, idsala = @idsala where id = @id;";
                cmd.Parameters.AddWithValue("@id", pAgenda.Id);
                cmd.Parameters.AddWithValue("@datahorareserva", Dados.Model_Dao_Dados.ConverterDataToStr(pAgenda.DataHoraReserva, false));
                cmd.Parameters.AddWithValue("@idcliente", pAgenda.IdCliente);
                cmd.Parameters.AddWithValue("@idsala", pAgenda.IdSala);
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
                cmd.CommandText = "delete from agenda where id = " + Convert.ToString(id);
                cn.Open();
                int resultado = cmd.ExecuteNonQuery();
                if (resultado != 1)
                {
                    throw new Exception("Não foi possível excluir a Agenda " + Convert.ToString(id));
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

        public DataTable ListaDeAgendas()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from agenda", Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
            da.Fill(tabela);
            return tabela;
        }

        public DataTable ListaDeAgendasDoPeriodo(DateTime DataHoraIni, DateTime DataHoraFim)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from agenda where datahorareserva >= \'" + Dados.Model_Dao_Dados.ConverterDataToStr(DataHoraIni, false) + "\' and datahorareserva <= \'" + Dados.Model_Dao_Dados.ConverterDataToStr(DataHoraFim, true) + "\' ", Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());            
            da.Fill(tabela);
            return tabela;
        }

        public DataTable ListaDeAgendasDoCliente(int IdCliente)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from agenda where idcliente = " + Convert.ToString(IdCliente), Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
            da.Fill(tabela);
            return tabela;
        }

        public DataTable ListaDeAgendasDaSala(int IdSala)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from agenda where idsala = " + Convert.ToString(IdSala), Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
            da.Fill(tabela);
            return tabela;
        }

        public DataTable GetAgendaPorDados(int pIdCliente, int pIdSala, DateTime pdDataHora)
        {
            try
            {
                DataTable tabela = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from agenda where idcliente = " + Convert.ToString(pIdCliente) + " and idsala = " + Convert.ToString(pIdSala) + " and datahorareserva = '" + Dados.Model_Dao_Dados.ConverterDataToStr(pdDataHora, false) + "' ", Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
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
