using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academia.Model.Vo.LivroCaixa;
using System.Data.SqlClient;
using System.Data;

using Npgsql;
using SqlCommand = Npgsql.NpgsqlCommand;
using SqlConnection = Npgsql.NpgsqlConnection;
using SqlDataAdapter = Npgsql.NpgsqlDataAdapter;

namespace Academia.Model.Dao.LivroCaixas
{
    public class Model_Dao_LivroCaixas
    {

        public void Incluir(Model_Vo_LivroCaixa pLivroCaixa)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao();
                //command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into livrocaixa(datahora,descricao,idcontasareceber,tipodemovimento,valor) values (@datahora,@descricao,@idcontasareceber,@tipodemovimento,@valor);";
                cmd.Parameters.AddWithValue("@datahora", Dados.Model_Dao_Dados.ConverterDataToStr((pLivroCaixa.DataHora), false));
                cmd.Parameters.AddWithValue("@descricao", pLivroCaixa.Descricao);
                cmd.Parameters.AddWithValue("@idcontasareceber", pLivroCaixa.IdContasAReceber);
                cmd.Parameters.AddWithValue("@tipodemovimento", pLivroCaixa.TipoDeMovimento.ToString());
                cmd.Parameters.AddWithValue("@valor", pLivroCaixa.Valor);
                cn.Open();
                pLivroCaixa.Id = Convert.ToInt32(cmd.ExecuteScalar());
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
        public void Alterar(Model_Vo_LivroCaixa pLivroCaixa)
        {
            // conexao
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update livrocaixa set datahora = @datahora, descricao = @descricao, idcontasareceber = @idcontasareceber, tipodemovimento = @tipodemovimento, valor = @valor   where id = @id;";
                cmd.Parameters.AddWithValue("@id", pLivroCaixa.Id);
                cmd.Parameters.AddWithValue("@datahora", Dados.Model_Dao_Dados.ConverterDataToStr(pLivroCaixa.DataHora, false));
                cmd.Parameters.AddWithValue("@descricao", pLivroCaixa.Descricao);
                cmd.Parameters.AddWithValue("@idcontasareceber", pLivroCaixa.IdContasAReceber);
                cmd.Parameters.AddWithValue("@tipodemovimento", pLivroCaixa.TipoDeMovimento.ToString());
                cmd.Parameters.AddWithValue("@valor", pLivroCaixa.Valor);
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
        public Boolean Excluir(int id, int piCtaReceb)
        {
            //conexao
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao();
                //command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                if ((piCtaReceb > 0))
                    cmd.CommandText = "delete from livrocaixa where idcontasareceber = " + Convert.ToString(piCtaReceb);
                else
                    cmd.CommandText = "delete from livrocaixa where id = " + Convert.ToString(id);
                cn.Open();
                int resultado = cmd.ExecuteNonQuery();
                if (resultado != 1)
                {
                    //throw new Exception("Não foi possível excluir a LivroCaixa " + Convert.ToString(id));
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

        public DataTable ListaDeLivroCaixas()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from livrocaixa", Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
            da.Fill(tabela);
            return tabela;
        }

        public DataTable ListaDeLivroCaixasPeriodo(DateTime dtIni, DateTime dtFim)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from livrocaixa where datahora >= '" + Dao.Dados.Model_Dao_Dados.ConverterDataToStr(dtIni, false) + "' and datahora <= '" + Dao.Dados.Model_Dao_Dados.ConverterDataToStr(dtFim, true) + "' ", Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
            da.Fill(tabela);
            return tabela;
        }     

    }
}
