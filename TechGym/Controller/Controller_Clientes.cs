using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Academia.Controller.Clientes
{
    public class Controller_Clientes
    {
        Model.Bo.Clientes.Model_Bo_Clientes objBoClientes = new Model.Bo.Clientes.Model_Bo_Clientes();
        DataTable dtClienteLocal = new DataTable();
     
        

        public void Incluir(Model.Vo.Cliente.Model_Vo_Cliente pClienteLocal)
        {
            if ((Validar(pClienteLocal)))
                objBoClientes.Incluir(pClienteLocal);
        }

        public void Alterar(Model.Vo.Cliente.Model_Vo_Cliente pClienteLocal)
        {
            if ((Validar(pClienteLocal)))
                objBoClientes.Alterar(pClienteLocal);
        }

        public Boolean Excluir(int piIdCliente)
        {
            return objBoClientes.Excluir(piIdCliente);
        }

        public Model.Vo.Cliente.Model_Vo_Cliente GetCliente(int pIdCliente)
        {
            Model.Vo.Cliente.Model_Vo_Cliente ClienteLocal = new Model.Vo.Cliente.Model_Vo_Cliente();
            dtClienteLocal = objBoClientes.GetCliente(pIdCliente);
            if ((dtClienteLocal.Rows.Count > 0))
            {
                DataTableToVO(ClienteLocal, dtClienteLocal, ClienteLocal.RegistroNro);
            }

            return ClienteLocal;
        }

        public Model.Vo.Cliente.Model_Vo_Cliente CarregarCliente(Int32 piNumRegistro)
        {
            Model.Vo.Cliente.Model_Vo_Cliente clienteLocal = new Model.Vo.Cliente.Model_Vo_Cliente();

            dtClienteLocal = objBoClientes.ListaDeClientes();

            if (dtClienteLocal.Rows.Count > 0)
            {
                if ((piNumRegistro >= 0) &&
                    (dtClienteLocal.Rows.Count > piNumRegistro))
                    clienteLocal.RegistroNro = piNumRegistro;
                else
                    clienteLocal.RegistroNro = dtClienteLocal.Rows.Count - 1;

                DataTableToVO(clienteLocal, dtClienteLocal, clienteLocal.RegistroNro);
            }
            else
            {
                clienteLocal.Id = 0;
                clienteLocal.Nome = String.Empty;
                clienteLocal.Cpf = String.Empty;
                clienteLocal.Email = String.Empty;
                clienteLocal.Rua = String.Empty;
                clienteLocal.Rg = String.Empty;
                clienteLocal.Telefone = String.Empty;
                clienteLocal.Bairro = String.Empty;
                clienteLocal.CEP = String.Empty;
                clienteLocal.Cidade = String.Empty;
                clienteLocal.Complemento = String.Empty;
                clienteLocal.Numero = String.Empty;
                clienteLocal.UF = String.Empty;
                clienteLocal.Nascimento = DateTime.MinValue;
                clienteLocal.ValorMensalidade = 0.0f;
                clienteLocal.Observacao = String.Empty;
                clienteLocal.Ativo = true;
            }

            return clienteLocal;
        }

        private void DataTableToVO(Model.Vo.Cliente.Model_Vo_Cliente clienteLocal, DataTable dtClienteLocal, Int32 piRegNum)
        {
            clienteLocal.Id = Convert.ToInt32(dtClienteLocal.Rows[piRegNum]["id"]);
            clienteLocal.Nome = Convert.ToString(dtClienteLocal.Rows[piRegNum]["nome"]);
            clienteLocal.Cpf = Convert.ToString((dtClienteLocal.Rows[piRegNum]["cpf"]));
            clienteLocal.Email = Convert.ToString((dtClienteLocal.Rows[piRegNum]["email"]));
            clienteLocal.Rua = Convert.ToString((dtClienteLocal.Rows[piRegNum]["rua"]));
            clienteLocal.Rg = Convert.ToString((dtClienteLocal.Rows[piRegNum]["rg"]));
            clienteLocal.Telefone = Convert.ToString((dtClienteLocal.Rows[piRegNum]["telefone"]));
            clienteLocal.Bairro = Convert.ToString((dtClienteLocal.Rows[piRegNum]["bairro"]));
            clienteLocal.CEP = Convert.ToString((dtClienteLocal.Rows[piRegNum]["cep"]));
            clienteLocal.Cidade = Convert.ToString((dtClienteLocal.Rows[piRegNum]["cidade"]));
            clienteLocal.Complemento = Convert.ToString((dtClienteLocal.Rows[piRegNum]["complemento"]));
            clienteLocal.Numero = Convert.ToString((dtClienteLocal.Rows[piRegNum]["numero"]));
            clienteLocal.UF = Convert.ToString((dtClienteLocal.Rows[piRegNum]["uf"]));

            if ((dtClienteLocal.Rows[piRegNum]["Nascimento"] != DBNull.Value))
                clienteLocal.Nascimento = Convert.ToDateTime((dtClienteLocal.Rows[piRegNum]["Nascimento"]));

            if ((dtClienteLocal.Rows[piRegNum]["ValorMensalidade"] != DBNull.Value))
                clienteLocal.ValorMensalidade = float.Parse(Convert.ToString(dtClienteLocal.Rows[piRegNum]["ValorMensalidade"]));

            clienteLocal.Observacao = Convert.ToString((dtClienteLocal.Rows[piRegNum]["Observacao"]));

            if ((dtClienteLocal.Rows[piRegNum]["Ativo"] != DBNull.Value))
                clienteLocal.Ativo = Convert.ToBoolean(dtClienteLocal.Rows[piRegNum]["Ativo"]);
        }

        public List<Model.Vo.Cliente.Model_Vo_Cliente> ListaDeClientesVO(DataTable dtClienteLocal)
        {
            List<Model.Vo.Cliente.Model_Vo_Cliente> list = new List<Model.Vo.Cliente.Model_Vo_Cliente>();
            if ((dtClienteLocal != null))
            {
                for (int i = 0; i < dtClienteLocal.Rows.Count; i++)
                {
                    Model.Vo.Cliente.Model_Vo_Cliente ClienteLocal = new Model.Vo.Cliente.Model_Vo_Cliente();
                    DataTableToVO(ClienteLocal, dtClienteLocal, i);

                    list.Add(ClienteLocal);
                }
            }

            return list;
        }

        public List<Model.Vo.Cliente.Model_Vo_Cliente> ListaDeClientes()
        {
            DataTable dtTemp = objBoClientes.ListaDeClientes();
            return ListaDeClientesVO(dtTemp);
        }

        private Boolean Validar(Model.Vo.Cliente.Model_Vo_Cliente pClienteLocal)
        {
            return objBoClientes.Validar(pClienteLocal);
        }

        public Model.Vo.Cliente.Model_Vo_Cliente DevolveValorInicial()
        {

            Model.Vo.Cliente.Model_Vo_Cliente retorno = new Model.Vo.Cliente.Model_Vo_Cliente();
            retorno.Nome = String.Empty;
            retorno.Cpf = String.Empty;
            retorno.Email = String.Empty;
            retorno.Rua = String.Empty;
            retorno.Rg = String.Empty;
            retorno.Telefone = String.Empty;
            retorno.Bairro = String.Empty;
            retorno.CEP = String.Empty;
            retorno.Cidade = String.Empty;
            retorno.Complemento = String.Empty;
            retorno.Numero = String.Empty;
            retorno.UF = String.Empty;
            retorno.Nascimento = DateTime.MinValue;
            retorno.ValorMensalidade = 0.0f;
            retorno.Observacao = String.Empty;
            retorno.Ativo = true;

            return retorno;
        }

        public int getNumRegistros()
        {
            return dtClienteLocal.Rows.Count;
        }

        public List<Academia.Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque> pesquisaExtratos(Model.Vo.Cliente.Model_Vo_Cliente pCliente)
        {
            List<Academia.Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque> extratos = new List<Academia.Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque>();
            extratos = objBoClientes.pesquisaExtratos(pCliente);
            return extratos;
        }

        public Model.Vo.Cliente.Model_Vo_Cliente PesquisarCliente(int idCliente)
        {
            Model.Vo.Cliente.Model_Vo_Cliente voClientes = objBoClientes.Pesquisar(idCliente);

            return voClientes;
        }
     

    }


}
