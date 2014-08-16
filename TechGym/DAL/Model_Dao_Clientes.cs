using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Academia.Model.Vo.Cliente;
using System.Data.SqlClient;
using System.Data;

using Npgsql;
using SqlCommand = Npgsql.NpgsqlCommand;
using SqlConnection = Npgsql.NpgsqlConnection;
using SqlDataAdapter = Npgsql.NpgsqlDataAdapter;

namespace Academia.Model.Dao.Clientes
{
    public class Model_Dao_Clientes
    {
        public void Incluir(Model_Vo_Cliente pCliente)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao();
                //command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = (@"insert into cliente(nome,cpf,rg,telefone,email,rua,numero,bairro," +
                                   @"complemento,cidade,cep,uf, Nascimento, ValorMensalidade, Observacao, Ativo) " +
                                   @"values " +
                                   @" (@nome,@cpf,@rg,@telefone,@email,@rua,@numero,@bairro," +
                                   @"  @complemento,@cidade,@cep,@uf, @Nascimento, @ValorMensalidade, @Observacao, @Ativo);");
                cmd.Parameters.AddWithValue("@nome", pCliente.Nome);
                cmd.Parameters.AddWithValue("@cpf", pCliente.Cpf);
                cmd.Parameters.AddWithValue("@rg", pCliente.Rg);
                cmd.Parameters.AddWithValue("@telefone", pCliente.Telefone);
                cmd.Parameters.AddWithValue("@email", pCliente.Email);
                cmd.Parameters.AddWithValue("@rua", pCliente.Rua);
                cmd.Parameters.AddWithValue("@numero", pCliente.Numero);
                cmd.Parameters.AddWithValue("@bairro", pCliente.Bairro);
                cmd.Parameters.AddWithValue("@complemento", pCliente.Complemento);
                cmd.Parameters.AddWithValue("@cidade", pCliente.Cidade);
                cmd.Parameters.AddWithValue("@cep", pCliente.CEP);
                cmd.Parameters.AddWithValue("@uf", pCliente.UF);
                cmd.Parameters.AddWithValue("@Nascimento", pCliente.Nascimento);
                cmd.Parameters.AddWithValue("@ValorMensalidade", pCliente.ValorMensalidade);
                cmd.Parameters.AddWithValue("@Observacao", pCliente.Observacao);
                cmd.Parameters.AddWithValue("@Ativo", pCliente.Ativo);

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

        public void Alterar(Model_Vo_Cliente pCliente)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = (@"update cliente set nome = @nome, cpf = @cpf, rg = @rg, telefone = @telefone, email = @email, rua = @rua, numero = @numero, bairro = @bairro, complemento = @complemento, cidade = @cidade, cep = @cep, uf = @uf, " +
                                   @"Nascimento = @Nascimento, " +
                                   @"ValorMensalidade = @ValorMensalidade, " +
                                   @"Observacao = @Observacao, " +
                                   @"Ativo = @Ativo " +
                                   @"where id = @id;");
                cmd.Parameters.AddWithValue("@id", pCliente.Id);
                cmd.Parameters.AddWithValue("@nome", pCliente.Nome);
                cmd.Parameters.AddWithValue("@cpf", pCliente.Cpf);
                cmd.Parameters.AddWithValue("@rg", pCliente.Rg);
                cmd.Parameters.AddWithValue("@telefone", pCliente.Telefone);
                cmd.Parameters.AddWithValue("@email", pCliente.Email);
                cmd.Parameters.AddWithValue("@rua", pCliente.Rua);
                cmd.Parameters.AddWithValue("@numero", pCliente.Numero);
                cmd.Parameters.AddWithValue("@bairro", pCliente.Bairro);
                cmd.Parameters.AddWithValue("@complemento", pCliente.Complemento);
                cmd.Parameters.AddWithValue("@cidade", pCliente.Cidade);
                cmd.Parameters.AddWithValue("@cep", pCliente.CEP);
                cmd.Parameters.AddWithValue("@uf", pCliente.UF);
                cmd.Parameters.AddWithValue("@Nascimento", pCliente.Nascimento);
                cmd.Parameters.AddWithValue("@ValorMensalidade", pCliente.ValorMensalidade);
                cmd.Parameters.AddWithValue("@Observacao", pCliente.Observacao);
                cmd.Parameters.AddWithValue("@Ativo", pCliente.Ativo);
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

     

        public Boolean Excluir(int pIdCliente)
        {
            //conexao
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao();
                //command
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "delete from cliente where id = " + Convert.ToString(pIdCliente);
                cn.Open();
                int resultado = cmd.ExecuteNonQuery();
                if (resultado != 1)
                {
                    throw new Exception("Não foi possível excluir o cliente " + Convert.ToString(pIdCliente));
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

        public DataTable GetCliente(int pid)
        {
            try
            {
                DataTable tabela = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from cliente where id = " + Convert.ToString(pid), Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
                da.Fill(tabela);
                return tabela;
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            return null;
        }

        public DataTable ListaDeClientes()
        {
            try
            {
                DataTable tabela = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from cliente", Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
                da.Fill(tabela);
                return tabela;
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            return null;
        }

        public DataTable Pesquisar(int idCliente)
        {
            DataTable tabela = new DataTable();

            string pesquisaSql = string.Format("select  * from cliente where id = {0}",idCliente);

            SqlDataAdapter da = new SqlDataAdapter(pesquisaSql, Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
            da.Fill(tabela);
            return tabela; 
        }

        public DataTable Pesquisar(Model_Vo_Cliente pCliente)
        {
            DataTable tabela = new DataTable();
            
            string pesquisaSql = String.Empty;
            int iIdCliente = 0;
            int.TryParse(pCliente.Nome, out iIdCliente);

            if (string.IsNullOrEmpty(pCliente.Nome))
                pesquisaSql = "select  * from cliente";
            else
                pesquisaSql = string.Format(@"select  * from cliente where id = " + Convert.ToString(iIdCliente) + " or lower(nome) like '%" + pCliente.Nome.ToLower() + "%' or lower(telefone) like '%" + pCliente.Nome.ToLower() + "%' or lower(Observacao) like '%" + pCliente.Nome.ToLower() + "%' ");

            SqlDataAdapter da = new SqlDataAdapter(pesquisaSql, Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
            da.Fill(tabela);
            return tabela;           
        }
    
           public DataTable ListaDeClientesCom(String psParamametro)
        {
            try
            {
                DataTable tabela = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from cliente where nome like '%" + psParamametro +"%' ", Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
                da.Fill(tabela);
                return tabela;
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
            }
            return null;
        }
           public DataTable pesquisaExtratos(Model.Vo.Cliente.Model_Vo_Cliente pCliente)
           {
               try
            {
                DataTable tabela = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select * from movimentacaoestoque where idclientesolicitante like '%" + pCliente.Id +"%' ", Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
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
