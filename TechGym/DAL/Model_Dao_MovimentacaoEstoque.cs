using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academia.Model.Vo.MovimentacaoEstoque;
using System.Data.SqlClient;
using System.Data;

using Npgsql;
using SqlCommand = Npgsql.NpgsqlCommand;
using SqlConnection = Npgsql.NpgsqlConnection;
using SqlDataAdapter = Npgsql.NpgsqlDataAdapter;

namespace Academia.Model.Dao.MovimentacaoEstoques
{
    public class Model_Dao_MovimentacaoEstoques
    {

        public void Incluir(Model_Vo_MovimentacaoEstoque pMovimentacaoEstoque)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao();
                //command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "insert into movimentacaoestoque(datahora,idclientesolicitante,idproduto,idreservaorigem,quantidade,valorunitario,valortotal,tipodemovimento) values (@datahora,@idclientesolicitante,@idproduto,@idreservaorigem,@quantidade,@valorunitario,@valortotal,@tipodemovimento);";
                cmd.Parameters.AddWithValue("@datahora", Dados.Model_Dao_Dados.ConverterDataToStr(pMovimentacaoEstoque.DataHora, false));
                cmd.Parameters.AddWithValue("@idclientesolicitante", pMovimentacaoEstoque.IdClienteSolicitante);
                cmd.Parameters.AddWithValue("@idproduto", pMovimentacaoEstoque.IdProduto);
                cmd.Parameters.AddWithValue("@idreservaorigem", pMovimentacaoEstoque.IdReservaOrigem);
                cmd.Parameters.AddWithValue("@quantidade", pMovimentacaoEstoque.Quantidade);
                cmd.Parameters.AddWithValue("@valorunitario", pMovimentacaoEstoque.ValorUnitario);
                cmd.Parameters.AddWithValue("@valortotal", pMovimentacaoEstoque.ValorTotal);
                cmd.Parameters.AddWithValue("@tipodemovimento", pMovimentacaoEstoque.TipoDeMovimento.ToString());
                cn.Open();
                pMovimentacaoEstoque.Id = Convert.ToInt32(cmd.ExecuteScalar());
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
        public void Alterar(Model_Vo_MovimentacaoEstoque pMovimentacaoEstoque)
        {
            // conexao
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update movimentacaoestoque set datahora = @datahora, idclientesolicitante = @idclientesolicitante, idproduto = @idproduto, idreservaorigem = @idreservaorigem, quantidade = @quantidade, valorunitario = @valorunitario, valortotal = @valortotal, tipodemovimento = @tipodemovimento where id = @id;";
                cmd.Parameters.AddWithValue("@id", pMovimentacaoEstoque.Id);
                cmd.Parameters.AddWithValue("@datahora", Dados.Model_Dao_Dados.ConverterDataToStr(pMovimentacaoEstoque.DataHora, false));
                cmd.Parameters.AddWithValue("@idclientesolicitante", pMovimentacaoEstoque.IdClienteSolicitante);
                cmd.Parameters.AddWithValue("@idproduto", pMovimentacaoEstoque.IdProduto);
                cmd.Parameters.AddWithValue("@idreservaorigem", pMovimentacaoEstoque.IdReservaOrigem);
                cmd.Parameters.AddWithValue("@quantidade", pMovimentacaoEstoque.Quantidade);
                cmd.Parameters.AddWithValue("@valorunitario", pMovimentacaoEstoque.ValorUnitario);
                cmd.Parameters.AddWithValue("@valortotal", pMovimentacaoEstoque.ValorTotal);
                cmd.Parameters.AddWithValue("@tipodemovimento", pMovimentacaoEstoque.TipoDeMovimento.ToString());
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

        public Boolean Excluir(int idMovimentacaoEstoque, int idAgenda)
        {
            //conexao
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao();
                //command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                if ((idMovimentacaoEstoque > 0))
                    cmd.CommandText = "delete from movimentacaoestoque where id = " + Convert.ToString(idMovimentacaoEstoque);
                else
                    cmd.CommandText = "delete from movimentacaoestoque where idreservaorigem = " + Convert.ToString(idAgenda);                

                cn.Open();
                int resultado = cmd.ExecuteNonQuery();
                if (resultado != 1)
                {
                    if ((idAgenda > 0))
                        throw new Exception("Não foi possível excluir a MovimentacaoEstoque da Agenda: " + Convert.ToString(idAgenda));
                    else
                        throw new Exception("Não foi possível excluir a MovimentacaoEstoque " + Convert.ToString(idMovimentacaoEstoque));
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

        public DataTable MovimentacaoEstoqueAgenda(int idAgenda)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from movimentacaoestoque where idreservaorigem = " + Convert.ToString(idAgenda) + " ", Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
            da.Fill(tabela);
            return tabela;
        }

        public DataTable ListaDeMovimentacaoEstoques()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from movimentacaoestoque", Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
            da.Fill(tabela);
            return tabela;
        }

        public DataTable ListaDeMovimentacaoEstoquesDoPeriodo(DateTime DataHoraIni, DateTime DataHoraFim)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from movimentacaoestoque where datahora >= '" + Dados.Model_Dao_Dados.ConverterDataToStr(DataHoraIni, false) + "' and datahora <= '" + Dados.Model_Dao_Dados.ConverterDataToStr(DataHoraFim, true) + "' ", Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());            
            da.Fill(tabela);
            return tabela;
        }

        public DataTable ListaDeMovimentacaoEstoquesDoCliente(int IdCliente)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from movimentacaoestoque where idclientesolicitante = " + Convert.ToString(IdCliente), Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
            da.Fill(tabela);
            return tabela;
        }

        public DataTable ListaDeMovimentacaoEstoquesDaReserva(int IdReserva)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from movimentacaoestoque where idreservaorigem = " + Convert.ToString(IdReserva), Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
            da.Fill(tabela);
            return tabela;
        }

        public DataTable ListaDeMovimentacaoEstoquesDoProduto(int IdProduto)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from movimentacaoestoque where idproduto = " + Convert.ToString(IdProduto), Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
            da.Fill(tabela);
            return tabela;
        }  

    }
}
