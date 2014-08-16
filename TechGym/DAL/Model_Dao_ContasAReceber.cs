using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academia.Model.Vo.ContasAReceber;
using System.Data.SqlClient;
using System.Data;

using Npgsql;
using SqlCommand = Npgsql.NpgsqlCommand;
using SqlConnection = Npgsql.NpgsqlConnection;
using SqlDataAdapter = Npgsql.NpgsqlDataAdapter;

namespace Academia.Model.Dao.ContasARecebers
{
    public class Model_Dao_ContasARecebers
    {

        public void Incluir(Model_Vo_ContasAReceber pContasAReceber)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao();
                //command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into contasareceber(datahoracriacao,descricao,idcliente,idproduto,idreservaorigem,origem,recebido,valorareceber) values (@datahoracriacao,@descricao,@idcliente,@idproduto,@idreservaorigem,@origem,@recebido,@valorareceber);";
                cmd.Parameters.AddWithValue("@datahoracriacao", Dados.Model_Dao_Dados.ConverterDataToStr(pContasAReceber.DataHoraCriacao, false));
                cmd.Parameters.AddWithValue("@descricao", pContasAReceber.Descricao);
                cmd.Parameters.AddWithValue("@idcliente", pContasAReceber.IdCliente);
                cmd.Parameters.AddWithValue("@idproduto", pContasAReceber.IdProduto);
                cmd.Parameters.AddWithValue("@idreservaorigem", pContasAReceber.IdReservaOrigem);
                cmd.Parameters.AddWithValue("@origem", pContasAReceber.Origem.ToString());
                cmd.Parameters.AddWithValue("@recebido", pContasAReceber.Recebido);
                cmd.Parameters.AddWithValue("@valorareceber", pContasAReceber.ValorAReceber);

                cn.Open();
                pContasAReceber.Id = Convert.ToInt32(cmd.ExecuteScalar());
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

        public void Alterar(Model_Vo_ContasAReceber pContasAReceber)
        {
            // conexao
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update contasareceber set datahoracriacao = @datahoracriacao, descricao = @descricao ,idcliente = @idcliente ,idproduto = @idproduto ,idreservaorigem = @idreservaorigem ,origem = @origem ,recebido = @recebido ,valorareceber = @valorareceber where id = @id;";
                cmd.Parameters.AddWithValue("@datahoracriacao", Dados.Model_Dao_Dados.ConverterDataToStr(pContasAReceber.DataHoraCriacao, false));
                cmd.Parameters.AddWithValue("@id", pContasAReceber.Id);
                cmd.Parameters.AddWithValue("@descricao", pContasAReceber.Descricao);
                cmd.Parameters.AddWithValue("@idcliente", pContasAReceber.IdCliente);
                cmd.Parameters.AddWithValue("@idproduto", pContasAReceber.IdProduto);
                cmd.Parameters.AddWithValue("@idreservaorigem", pContasAReceber.IdReservaOrigem);
                cmd.Parameters.AddWithValue("@origem", pContasAReceber.Origem.ToString());
                cmd.Parameters.AddWithValue("@recebido", pContasAReceber.Recebido);
                cmd.Parameters.AddWithValue("@valorareceber", pContasAReceber.ValorAReceber);
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

        public void FecharContasAReceber(Model_Vo_ContasAReceber pContasAReceber)
        {
            // conexao
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update contasareceber set recebido = @recebido  where idreservaorigem = @idreservaorigem;";
                cmd.Parameters.AddWithValue("@idreservaorigem", pContasAReceber.IdReservaOrigem);
                cmd.Parameters.AddWithValue("@recebido", pContasAReceber.Recebido);
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
                cmd.CommandText = "delete from contasareceber where id = " + Convert.ToString(id);
                cn.Open();
                int resultado = cmd.ExecuteNonQuery();
                if (resultado != 1)
                {
                    throw new Exception("Não foi possível excluir a ContasAReceber " + Convert.ToString(id));
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

        public DataTable ListaDeContasARecebers()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from contasareceber", Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
            da.Fill(tabela);
            return tabela;
        }

        public DataTable ListaDeContasARecebersPeriodo(DateTime dtIni, DateTime dtFim)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from contasareceber where datahoracriacao >= '" + Dao.Dados.Model_Dao_Dados.ConverterDataToStr(dtIni, false) + "' and datahoracriacao <= '" + Dao.Dados.Model_Dao_Dados.ConverterDataToStr(dtFim, true) + "' ", Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
            da.Fill(tabela);
            return tabela;
        }

        public int ExisteContasAReceberdaReserva(int pIdReserva)
        {
            try
            {
                DataTable tabela = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from contasareceber where idreservaorigem = " + Convert.ToString(pIdReserva), Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
                da.Fill(tabela);

                if ((tabela != null) &&
                    (tabela.Rows.Count > 0) &&
                    (tabela.Rows[0]["id"] != DBNull.Value))
                    return Convert.ToInt32(tabela.Rows[0]["id"]);
                else
                    return 0;
            }
            catch
            {
                return 0;
            }
        }

    }
}
