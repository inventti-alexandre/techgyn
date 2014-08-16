using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academia.Model.Vo.Produto;
using System.Data.SqlClient;
using System.Data;

using Npgsql;
using SqlCommand = Npgsql.NpgsqlCommand;
using SqlConnection = Npgsql.NpgsqlConnection;
using SqlDataAdapter = Npgsql.NpgsqlDataAdapter;

namespace Academia.Model.Dao.Produtos
{
    public class Model_Dao_Produtos
    {

        public void Incluir(Model_Vo_Produto pProduto)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao();
                //command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into produto(descricao,unidade,estoque,valordevenda,observacao) values (@descricao,@unidade,@estoque,@valordevenda,@observacao);";
                cmd.Parameters.AddWithValue("@descricao", pProduto.Descricao);
                cmd.Parameters.AddWithValue("@unidade", pProduto.Unidade);
                cmd.Parameters.AddWithValue("@estoque", pProduto.Estoque);
                cmd.Parameters.AddWithValue("@valordevenda", pProduto.ValorDeVenda);
                cmd.Parameters.AddWithValue("@observacao", pProduto.Observacao);
                cn.Open();
                pProduto.Id = Convert.ToInt32(cmd.ExecuteScalar());
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
        public void Alterar(Model_Vo_Produto pProduto)
        {
            // conexao
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update produto set descricao = @descricao, unidade = @unidade, estoque = @estoque, valordevenda = @valordevenda, observacao = @observacao where id = @id;";
                cmd.Parameters.AddWithValue("@descricao", pProduto.Descricao);
                cmd.Parameters.AddWithValue("@unidade", pProduto.Unidade);
                cmd.Parameters.AddWithValue("@estoque", pProduto.Estoque);
                cmd.Parameters.AddWithValue("@valordevenda", pProduto.ValorDeVenda);
                cmd.Parameters.AddWithValue("@observacao", pProduto.Observacao);
                cmd.Parameters.AddWithValue("@id", pProduto.Id);
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
                cmd.CommandText = "delete from produto where id = " + Convert.ToString(id);
                cn.Open();
                int resultado = cmd.ExecuteNonQuery();
                if (resultado != 1)
                {
                    throw new Exception("Não foi possível excluir a produto " + Convert.ToString(id));
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

        public DataTable ListaDeProdutos()
        {
            try
            {
                DataTable tabela = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from produto", Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
                da.Fill(tabela);
                return tabela;
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            return null;
        }

        public DataTable GetProduto(int pid)
        {
            try
            {
                DataTable tabela = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from produto where id = " + Convert.ToString(pid), Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
                da.Fill(tabela);
                return tabela;
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            return null;
        }

        public DataTable ListaDeProdutosCom(String psParamametro)
        {
            try
            {
                int Id = 0;
                int.TryParse(psParamametro, out Id);

                DataTable tabela = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from produto where id = " + Convert.ToString(Id) + " or lower(descricao) like '%" + Convert.ToString(psParamametro).ToLower() + "%' ", Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
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
