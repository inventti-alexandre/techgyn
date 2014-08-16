using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using Npgsql;
using SqlCommand = Npgsql.NpgsqlCommand;
using SqlConnection = Npgsql.NpgsqlConnection;
using SqlDataAdapter = Npgsql.NpgsqlDataAdapter;

namespace Academia.Model.Dao.ExtratoDeSalas
{
    public class Model_Dao_ExtratoDeSalas
    {
        private static String queryBase=
            "SELECT agenda.datahorareserva, cliente.nome, contasareceber.valorareceber, contasareceber.recebido" +
            " FROM agenda"+
            " LEFT JOIN sala ON agenda.idsala = sala.id"+
            " LEFT JOIN cliente ON agenda.idcliente = cliente.id"+
            " LEFT JOIN contasareceber ON sala.idproduto = contasareceber.idproduto"+
            " WHERE agenda.datahorareserva LIKE 'D@data%' ";

        /**
         * Pega o extrato de todas salas para a data solicitada, no formado yyyy-mm-yy, ou yyyy-mm, ou yyyy
         * 
         * String sala com nome da sala ou null para todas as salas
         **/
        public static DataTable getExtrato(String data,String sala)
        {
            String q = queryBase.Replace("@data", data);
            if (sala!=null) q += " AND sala.nome='"+sala+"'";
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(q, Academia.Model.Dao.Dados.Model_Dao_Dados.getStringDeConexao());
            da.Fill(tabela);
            return tabela;
        }

    }
}
