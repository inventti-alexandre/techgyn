using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Academia.Model.Bo;
using Academia.Model.Vo;
using Academia.Controller;

namespace Academia.View.Desktop
{
    public partial class View_Desktop_ExtratoClientes : Form
    {
        Model.Vo.Cliente.Model_Vo_Cliente clienteLocal = new Model.Vo.Cliente.Model_Vo_Cliente();
        Model.Bo.Clientes.Model_Bo_Clientes modelClient = new Model.Bo.Clientes.Model_Bo_Clientes();
        //Model.Bo.Clientes.Model_Bo_Clientes modelCliente = new Model.Bo.Clientes.Model_Bo_Clientes();
        Controller.Clientes.Controller_Clientes ctlCliente = new Controller.Clientes.Controller_Clientes();

        public View_Desktop_ExtratoClientes(Model.Vo.Cliente.Model_Vo_Cliente pClient)
        {
            InitializeComponent();
            txtNome.Text = Convert.ToString(pClient.Nome);
            //MessageBox.Show(Convert.ToString(pClient.Nome)); teste

        }

        private void listExtrato_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
      

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
                 

        }
        private void View_Desktop_ExtratoClientes_Load(object sender, EventArgs e)
        {
            Pesquisar();
        }
        private void Pesquisar()
        {
            List<Academia.Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque> clientes = modelClient.pesquisaExtratos(clienteLocal);
            //listExtato.Items.Clear();


            if (clientes == null) return;

            clientes.ForEach(delegate(Academia.Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque c)
            {
                // criar e preencher preencher listview com os valores        
                ListViewItem clienteItem = new ListViewItem(c.ValorUnitario.ToString());
                clienteItem.SubItems.Add(new ListViewItem.ListViewSubItem(clienteItem, c.Quantidade.ToString()));
                clienteItem.SubItems.Add(new ListViewItem.ListViewSubItem(clienteItem, c.ValorTotal.ToString()));
                clienteItem.Tag = c;

                //listExtato.Items.Add(clienteItem);
            });
        }

        private void View_Desktop_ExtratoClientes_Load_1(object sender, EventArgs e)
        {

        }

        private void listExtato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lsMovimentacaoEstoques_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
