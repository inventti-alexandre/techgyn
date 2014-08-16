using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Data;

using Npgsql;
using SqlCommand = Npgsql.NpgsqlCommand;
using SqlConnection = Npgsql.NpgsqlConnection;
using SqlDataAdapter = Npgsql.NpgsqlDataAdapter;



namespace INSTALLER
{
    public partial class Instalador : Form
    {

        private string tableClientes = "cliente";
        private string tableSalas    = "sala";
        private string tableProdutos = "produto";
        private string tableAgenda = "agenda";
        private string tableContasAReceber = "contasareceber";
        private string tableLivroCaixa = "livrocaixa";
        private string tableMovimentacaoEstoque = "movimentacaoestoque";
        private string bancoDeDados = "techgymdb";  // houve problemas com maiusculas
        private string usuario = "techgym"; // houve problemas com maiusculas
        private string senha = "#$TechGym-0166ac48ebb5b2";
        private NpgsqlConnection conn=null;
        private string csNomePadraoSeq1 = "seq";
        private string csNomePadraoSeq2 = "_id";

        public Instalador()
        {
            InitializeComponent();
        }

        private string GetStringConexao(Int32 piUrl)
        {
            if ((piUrl == 1))
            {
                return "Server=" + this.tHost.Text + ";Port=" + this.tPort.Text +
                    ";UserId=" + this.tUser.Text + ";Password=" + this.tSenha.Text + ";Database=postgres;"; // +this.bancoDeDados+";"
            }
            else
            {
                return "Server=localhost;Port=5432" +
                    ";UserId=" + this.usuario + ";Password=" + this.senha + ";Database=" + this.bancoDeDados + ";";
            }
            //string url = "Server=localhost;Port=5432;UserId=postgres;Password=TechGym;Database=postgres;";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            // Testa conexão com dados informados
            listLog.Items.Add(this.testeConexao(GetStringConexao(1)) + " - Usuario informado.");
            

            if (this.conn != null)
            {

                /*
                 * Referencias para trabalhar com Npgsql
                 * http://www.devmedia.com.br/forum/conexao-c-com-postgresql/134298
                 * http://cplus.about.com/od/howtodothingsinc/a/How-To-access-PostgreSQL-from-Csharp.htm
                 */


                int rows = 0;
                NpgsqlCommand sqlCmd;

                // Criar Banco e reportar ao usuario
                try
                {
                    if ((chkCriarBancoDeDados.Checked))
                    {
                        sqlCmd = new NpgsqlCommand(this.CreateDataBase, this.conn);
                        rows = sqlCmd.ExecuteNonQuery();
                        listLog.Items.Add("Banco de dados " + this.bancoDeDados + " criado " + rows);
                        
                    }

                }
                catch (Exception ex)
                {

                    listLog.Items.Add("Banco de dados não foi criado provavel existencia" + rows + ". Erro: " + ex.Message);
                }

                this.conn.ChangeDatabase(this.bancoDeDados);

                // Criar Sequencias para indices e reportar ao usuario
                try
                {

                    if ((!SequenciaExiste(this.tableClientes)))
                    {
                        sqlCmd = new NpgsqlCommand(this.CreateSequenceClientes, this.conn);
                        rows = sqlCmd.ExecuteNonQuery();
                        listLog.Items.Add("Sequence clientes criado ");
                    }

                    if ((!SequenciaExiste(this.tableSalas)))
                    {
                        sqlCmd = new NpgsqlCommand(this.CreateSequenceSalas, this.conn);
                        rows = sqlCmd.ExecuteNonQuery();
                        listLog.Items.Add("Sequence salas criado ");
                    }

                    if ((!SequenciaExiste(this.tableProdutos)))
                    {
                        sqlCmd = new NpgsqlCommand(this.CreateSequenceProdutos, this.conn);
                        rows = sqlCmd.ExecuteNonQuery();
                        listLog.Items.Add("Sequence produtos criado ");
                    }

                    if ((!SequenciaExiste(this.tableAgenda)))
                    {
                        sqlCmd = new NpgsqlCommand(this.CreateSequenceAgenda, this.conn);
                        rows = sqlCmd.ExecuteNonQuery();
                        listLog.Items.Add("Sequence Agenda criado ");
                    }

                    if ((!SequenciaExiste(this.tableContasAReceber)))
                    {
                        sqlCmd = new NpgsqlCommand(this.CreateSequenceContasAReceber, this.conn);
                        rows = sqlCmd.ExecuteNonQuery();
                        listLog.Items.Add("Sequence Contas a Receber criado ");
                    }

                    if ((!SequenciaExiste(this.tableLivroCaixa)))
                    {
                        sqlCmd = new NpgsqlCommand(this.CreateSequenceLivroCaixa, this.conn);
                        rows = sqlCmd.ExecuteNonQuery();
                        listLog.Items.Add("Sequence Livro Caixa criado ");
                    }

                    if ((!SequenciaExiste(this.tableMovimentacaoEstoque)))
                    {
                        sqlCmd = new NpgsqlCommand(this.CreateSequenceMovimentacaoEstoque, this.conn);
                        rows = sqlCmd.ExecuteNonQuery();
                        listLog.Items.Add("Sequence Movimentação Estoque criado ");
                    }
                }
                catch (Exception ex)
                {
                    listLog.Items.Add("Sequencias não criadas possivel existencia. Erro: " + ex);
                }

                // Criar tabelas e reportar ao usuario
                sqlCmd = new NpgsqlCommand(this.CreateClientes, this.conn);
                rows = sqlCmd.ExecuteNonQuery();
                listLog.Items.Add("Tabela "+this.tableClientes+" criado " );

                sqlCmd = new NpgsqlCommand(this.CreateSalas, this.conn);
                rows = sqlCmd.ExecuteNonQuery();
                listLog.Items.Add("Tabela " + this.tableSalas + " criado " );

                sqlCmd = new NpgsqlCommand(this.CreateProdutos, this.conn);
                rows = sqlCmd.ExecuteNonQuery();
                listLog.Items.Add("Tabela " + this.tableProdutos + " criado ");

                sqlCmd = new NpgsqlCommand(this.CreateAgenda, this.conn);
                rows = sqlCmd.ExecuteNonQuery();
                listLog.Items.Add("Tabela " + this.tableAgenda + " criado ");

                sqlCmd = new NpgsqlCommand(this.CreateContasARececeber, this.conn);
                rows = sqlCmd.ExecuteNonQuery();
                listLog.Items.Add("Tabela " + this.tableContasAReceber + " criado ");

                sqlCmd = new NpgsqlCommand(this.CreateContasLivroCaixa, this.conn);
                rows = sqlCmd.ExecuteNonQuery();
                listLog.Items.Add("Tabela " + this.tableLivroCaixa + " criado ");

                sqlCmd = new NpgsqlCommand(this.CreateContasMovimentacaoEstoque, this.conn);
                rows = sqlCmd.ExecuteNonQuery();
                listLog.Items.Add("Tabela " + this.tableMovimentacaoEstoque + " criado ");

                // Atualizar Sequencias dos indices e reportar ao usuario
                sqlCmd = new NpgsqlCommand(this.AlterSequeneClientes, this.conn);
                rows = sqlCmd.ExecuteNonQuery();
                listLog.Items.Add("Sequence clientes atualizadas " );

                sqlCmd = new NpgsqlCommand(this.AlterSequeneSalas, this.conn);
                rows = sqlCmd.ExecuteNonQuery();
                listLog.Items.Add("Sequence salas atualizadas ");

                sqlCmd = new NpgsqlCommand(this.AlterSequeneProdutos, this.conn);
                rows = sqlCmd.ExecuteNonQuery();
                listLog.Items.Add("Sequence produtos atualizadas ");

                sqlCmd = new NpgsqlCommand(this.AlterSequenceAgenda, this.conn);
                rows = sqlCmd.ExecuteNonQuery();
                listLog.Items.Add("Sequence Agenda atualizadas ");

                sqlCmd = new NpgsqlCommand(this.AlterSequenceContasAReceber, this.conn);
                rows = sqlCmd.ExecuteNonQuery();
                listLog.Items.Add("Sequence Contas A Receber atualizadas ");

                sqlCmd = new NpgsqlCommand(this.AlterSequenceLivroCaixa, this.conn);
                rows = sqlCmd.ExecuteNonQuery();
                listLog.Items.Add("Sequence Livro Caixa atualizadas ");

                sqlCmd = new NpgsqlCommand(this.AlterSequenceMovimentacaoEstoque, this.conn);
                rows = sqlCmd.ExecuteNonQuery();
                listLog.Items.Add("Sequence Movimentações Estoque atualizadas ");
                
                try
                {
                    // Criar usuário e reportar ao usuario
                    sqlCmd = new NpgsqlCommand(this.CreateUser, this.conn);
                    rows = sqlCmd.ExecuteNonQuery();
                    listLog.Items.Add("Usuario " + this.usuario + " criado ");
                    
                }
                catch (Exception)
                {

                    listLog.Items.Add("Usuario não criado possivel existencia.");
                }

                try
                {
                // Dar permissão ao usuário e reportar ao usuario
                sqlCmd = new NpgsqlCommand(this.GrantPrivileges, this.conn);
                rows = sqlCmd.ExecuteNonQuery();
                listLog.Items.Add("Permissões de acesso ao usuário consedidas ");
                }
                catch (Exception)
                {

                    listLog.Items.Add("Nao consedidas permissoes.");
                }
                /*
                string q = "INSERT INTO " + this.tableSalas + " (nome,capacidade) VALUES ('teste instalador',4);";
                try
                {
                    NpgsqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = q;
                    cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                */

                // Testa conexão com dados de uso do programa
                this.conn.Close();
                listLog.Items.Add(this.testeConexao(GetStringConexao(2)) + " - Usuario do sistema.");
                if (this.conn != null)
                    this.conn.Close();
            }
        }

        private string testeConexao(string url)
        {
            string ret;
            try
            {
                this.conn = new NpgsqlConnection(url);
                conn.Open();
                ret = "Versão do servidor: "+conn.ServerVersion;
                //conn.Close();
            }
            catch (Exception ex)
            {
                ret = "Falha na conexao do banco.Erro: " + ex.Message;
                this.conn = null;
            }

            return ret;
        }

        public string CreateDataBase
        {
            get
            {
                return "CREATE DATABASE " + this.bancoDeDados ; /*+
                    "WITH OWNER = postgres" +
                    "ENCODING = 'UTF8'" +
                    "TABLESPACE = pg_default" +
                    "LC_COLLATE = 'Portuguese_Brazil.1252'" +
                    "LC_CTYPE = 'Portuguese_Brazil.1252'" +
                    "CONNECTION LIMIT = -1;";
                                                                     */
            }
        }

        public string CreateUser
        {
            get
            {
                return "CREATE USER "+this.usuario+" WITH PASSWORD '"+this.senha+"';";
            }
        }
        public string GrantPrivileges
        {
            get
            {
                return "GRANT ALL PRIVILEGES ON DATABASE "+this.bancoDeDados+" TO "+this.usuario+";";
            }
        }


        public string AlterSequeneSalas
        {
            get
            {
                return "ALTER SEQUENCE " + this.csNomePadraoSeq1 + this.tableSalas + this.csNomePadraoSeq2 + " OWNED BY " + this.tableSalas + ".id;";
            }
        }


        public string AlterSequeneClientes
        {
            get
            {
                return "ALTER SEQUENCE " + this.csNomePadraoSeq1 + this.tableClientes + this.csNomePadraoSeq2 + " OWNED BY " + this.tableClientes + ".id;";
            }
        }

        public string AlterSequeneProdutos
        {
            get
            {
                return "ALTER SEQUENCE " + this.csNomePadraoSeq1 + this.tableProdutos + this.csNomePadraoSeq2 + " OWNED BY " + this.tableProdutos + ".id;";
            }
        }

        public string AlterSequenceAgenda
        {
            get
            {
                return "ALTER SEQUENCE " + this.csNomePadraoSeq1 + this.tableAgenda + this.csNomePadraoSeq2 + " OWNED BY " + this.tableAgenda + ".id;";
            }
        }

        public string AlterSequenceContasAReceber
        {
            get
            {
                return "ALTER SEQUENCE " + this.csNomePadraoSeq1 + this.tableContasAReceber + this.csNomePadraoSeq2 + " OWNED BY " + this.tableContasAReceber + ".id;";
            }
        }

        public string AlterSequenceLivroCaixa
        {
            get
            {
                return "ALTER SEQUENCE " + this.csNomePadraoSeq1 + this.tableLivroCaixa + this.csNomePadraoSeq2 + " OWNED BY " + this.tableLivroCaixa + ".id;";
            }
        }

        public string AlterSequenceMovimentacaoEstoque
        {
            get
            {
                return "ALTER SEQUENCE " + this.csNomePadraoSeq1 + this.tableMovimentacaoEstoque + this.csNomePadraoSeq2 + " OWNED BY " + this.tableMovimentacaoEstoque + ".id;";
            }
        }

        public string CreateSequenceClientes
        {
            get
            {
                return "CREATE SEQUENCE " + this.csNomePadraoSeq1 + this.tableClientes + this.csNomePadraoSeq2 + " INCREMENT 1 START 1;";
            }
        }

        public string CreateSequenceSalas
        {
            get
            {
                return "CREATE SEQUENCE " + this.csNomePadraoSeq1 + this.tableSalas + this.csNomePadraoSeq2 + " INCREMENT 1 START 1;";
            }
        }

        public string CreateSequenceProdutos
        {
            get
            {
                return "CREATE SEQUENCE " + this.csNomePadraoSeq1 + this.tableProdutos + this.csNomePadraoSeq2 + " INCREMENT 1 START 1;";
            }
        }

        public string CreateSequenceAgenda
        {
            get
            {
                return "CREATE SEQUENCE " + this.csNomePadraoSeq1 + this.tableAgenda + this.csNomePadraoSeq2 + " INCREMENT 1 START 1;";
            }
        }
        public string CreateSequenceContasAReceber
        {
            get
            {
                return "CREATE SEQUENCE " + this.csNomePadraoSeq1 + this.tableContasAReceber + this.csNomePadraoSeq2 + " INCREMENT 1 START 1;";
            }
        }
        public string CreateSequenceLivroCaixa
        {
            get
            {
                return "CREATE SEQUENCE " + this.csNomePadraoSeq1 + this.tableLivroCaixa + this.csNomePadraoSeq2 + " INCREMENT 1 START 1;";
            }
        }
        public string CreateSequenceMovimentacaoEstoque
        {
            get
            {
                return "CREATE SEQUENCE " + this.csNomePadraoSeq1 + this.tableMovimentacaoEstoque + this.csNomePadraoSeq2 + " INCREMENT 1 START 1;";
            }
        }

        private Boolean SequenciaExiste(String psNomeSeq)
        {
            try
            {
                String sSql = @"SELECT c.relname
                                FROM   pg_class c
                                JOIN   pg_namespace n ON n.oid = c.relnamespace
                                WHERE  c.relname = '" + this.csNomePadraoSeq1 + psNomeSeq  + this.csNomePadraoSeq2 + @"'
                                AND    n.nspname = 'public'";

                var sqlCmd = new NpgsqlCommand(sSql, this.conn);
                var rows = sqlCmd.ExecuteReader();

                try
                {
                    if ((rows != null) &&
                        (rows.HasRows))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                finally
                {
                    if ((rows != null))
                        rows.Close();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public string CreateClientes
        {
            get
            {
                return "CREATE TABLE IF NOT EXISTS " + this.tableClientes + "(" +
                " id bigint NOT NULL PRIMARY KEY DEFAULT nextval('" + this.csNomePadraoSeq1 + this.tableClientes + "_id')," +
                " nome varchar (250), " +
                " cpf varchar (15),"+
                " rg varchar (20),"+
                " telefone varchar (15),"+
                " email varchar(100),"+
                " rua varchar(250),"+
                " numero varchar(30)," +
                " complemento varchar(100),"+
                " bairro varchar(100),"+
                " cidade varchar(250),"+
                " uf char(2),"+
                " cep char(9),"+
                " Nascimento timestamp with time zone," +
                " ValorMensalidade NUMERIC(10,2)," +
                " Observacao varchar(250)," +
                " Ativo Boolean " +
                " );";
            }
        }

        public string CreateSalas
        {
            get
            {
                return "CREATE TABLE IF NOT EXISTS " + this.tableSalas + " (" +
                        " id bigint NOT NULL PRIMARY KEY DEFAULT nextval('" + this.csNomePadraoSeq1 + this.tableSalas + "_id')," +
                        " nome varchar(100)," +
                        " capacidade integer, " +
                        " tipo varchar(20), " +
                        " idproduto bigint " +
                        ");";
            }
        }

        public string CreateProdutos
        {
            get
            {
                return "CREATE TABLE IF NOT EXISTS " + this.tableProdutos + " (" +
                        " id bigint NOT NULL PRIMARY KEY DEFAULT nextval('" + this.csNomePadraoSeq1 + this.tableProdutos + "_id')," +
                        " descricao varchar(100)," +
                        " unidade varchar(10), " +
                        " estoque NUMERIC(10,4), " +
                        " valordevenda NUMERIC(10,4), " +
                        " observacao varchar(250) " +
                        ");";
            }
        }

        public string CreateAgenda
        {
            get
            {
                return "CREATE TABLE IF NOT EXISTS " + this.tableAgenda + " (" +
                        " id bigint NOT NULL PRIMARY KEY DEFAULT nextval('" + this.csNomePadraoSeq1 + this.tableAgenda + "_id')," +
                        " datahorareserva varchar(30)," +
                        " idcliente bigint, " +
                        " idsala bigint " +
                        ");";
            }
        }

        public string CreateContasARececeber
        {
            get
            {
                return "CREATE TABLE IF NOT EXISTS " + this.tableContasAReceber + " (" +
                        " id bigint NOT NULL PRIMARY KEY DEFAULT nextval('" + this.csNomePadraoSeq1 + this.tableContasAReceber + "_id')," +
                        " datahoracriacao varchar(30)," +
                        " descricao varchar(255)," +
                        " idcliente bigint, " +
                        " idproduto bigint, " +
                        " idreservaorigem bigint, " +
                        " origem varchar(50)," +
                        " recebido boolean," +
                        " valorareceber NUMERIC(10,2) " +
                        ");";
            }
        }
        public string CreateContasLivroCaixa
        {
            get
            {
                return "CREATE TABLE IF NOT EXISTS " + this.tableLivroCaixa + " (" +
                        " id bigint NOT NULL PRIMARY KEY DEFAULT nextval('" + this.csNomePadraoSeq1 + this.tableLivroCaixa + "_id')," +
                        " datahora varchar(30)," +
                        " descricao varchar(255)," +
                        " idcontasareceber bigint, " +
                        " tipodemovimento varchar(50)," +
                        " valor NUMERIC(10,2) " +
                        ");";
            }
        }
        public string CreateContasMovimentacaoEstoque
        {
            get
            {
                return "CREATE TABLE IF NOT EXISTS " + this.tableMovimentacaoEstoque + " (" +
                        " id bigint NOT NULL PRIMARY KEY DEFAULT nextval('" + this.csNomePadraoSeq1 + this.tableMovimentacaoEstoque + "_id')," +
                        " datahora varchar(30)," +
                        " idclientesolicitante bigint, " +
                        " idproduto bigint, " +
                        " idreservaorigem bigint, " +
                        " quantidade NUMERIC(10,4), " +
                        " valorunitario NUMERIC(10,2), " +
                        " valortotal NUMERIC(10,4), " +
                        " tipodemovimento varchar(50)" +
                        ");";
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tSenha_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
