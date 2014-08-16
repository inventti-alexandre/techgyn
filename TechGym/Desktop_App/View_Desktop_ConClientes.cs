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
    public partial class View_Desktop_ConClientes : Form
    {
        Model.Vo.Cliente.Model_Vo_Cliente clienteLocal = new Model.Vo.Cliente.Model_Vo_Cliente();
        Model.Bo.Clientes.Model_Bo_Clientes modelClient = new Model.Bo.Clientes.Model_Bo_Clientes();        
        //Model.Bo.Clientes.Model_Bo_Clientes modelCliente = new Model.Bo.Clientes.Model_Bo_Clientes();
        Controller.Clientes.Controller_Clientes ctlCliente = new Controller.Clientes.Controller_Clientes();

        public Model.Vo.Cliente.Model_Vo_Cliente ClienteSelecionado { get; set; }
        public Boolean AbertoParaConsCadastro { get; set; }
       
        public View_Desktop_ConClientes()
        {
            InitializeComponent();
            ClienteSelecionado = null;
        }

        private void Pesquisar()
        {
            btnOk.Enabled = false;
            clienteLocal.Nome = txtSelCampo.Text;

            List<Academia.Model.Vo.Cliente.Model_Vo_Cliente> clientes = modelClient.Pesquisar(clienteLocal);
            lsCliente.Items.Clear();


            if (clientes == null) return;

            clientes.ForEach(delegate(Academia.Model.Vo.Cliente.Model_Vo_Cliente c)
            {
                ListViewItem clienteItem = new ListViewItem(c.Nome);
                clienteItem.SubItems.Add(new ListViewItem.ListViewSubItem(clienteItem, c.Telefone));
                clienteItem.SubItems.Add(new ListViewItem.ListViewSubItem(clienteItem, c.Id.ToString()));
                clienteItem.Tag = c;

                lsCliente.Items.Add(clienteItem);
            });
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void View_Desktop_ConClientes_Load(object sender, EventArgs e)
        {
            if ((AbertoParaConsCadastro))
            {
                btnOk.Text = "Alterar";
                btnOk.Enabled = false;
                btnExtrato.Visible = true;
                btnExtrato.Enabled = false;
                btnCancel.Text = "Fechar";
            }
            else
            {
                btnExtrato.Visible = false;
            }

            Pesquisar();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            Pesquisar();
        } 


        private void lsClientes_DoubleClick(object sender, EventArgs e)
        {
            if (lsCliente.SelectedItems.Count == 0)
                return;

            ClienteSelecionado = lsCliente.SelectedItems[0].Tag as Model.Vo.Cliente.Model_Vo_Cliente;

            if ((AbertoParaConsCadastro == false))
                this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ClienteSelecionado = null;

            if (!(lsCliente.SelectedItems == null || lsCliente.SelectedItems.Count <= 0))
                ClienteSelecionado = lsCliente.SelectedItems[0].Tag as Model.Vo.Cliente.Model_Vo_Cliente;

            if ((AbertoParaConsCadastro == false))
            {
                this.Close();
            }
            else
            {
                View.Desktop.View_Desktop_CadClientes cadcliente = new View.Desktop.View_Desktop_CadClientes();
                cadcliente.AbertoPorConsulta = true;
                cadcliente.ClienteSelecionadoPorConsulta = ClienteSelecionado;
                cadcliente.ShowDialog();
                Pesquisar();
            }
        }

        private void btnExtrato_Click(object sender, EventArgs e)
        {
            ClienteSelecionado = lsCliente.SelectedItems[0].Tag as Model.Vo.Cliente.Model_Vo_Cliente;
            clienteLocal.Nome = ClienteSelecionado.Nome;
            clienteLocal.Id = ClienteSelecionado.Id;
            new View.Desktop.View_Desktop_ExtratoClientes(clienteLocal).ShowDialog();   
           
        }

        private void lsCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSelCampo_TextChanged(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void lsCliente_MouseClick(object sender, MouseEventArgs e)
        {
            ClienteSelecionado = null;

            if (!(lsCliente.SelectedItems == null || lsCliente.SelectedItems.Count <= 0))
            {
                ClienteSelecionado = lsCliente.SelectedItems[0].Tag as Model.Vo.Cliente.Model_Vo_Cliente;
                btnOk.Enabled = true;
                btnExtrato.Enabled = true;
            }
            else
            {
                btnOk.Enabled = false;
                btnExtrato.Enabled = false;
            }
        }

        private void lsCliente_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((AbertoParaConsCadastro == false))
            {
                ClienteSelecionado = null;

                if (!(lsCliente.SelectedItems == null || lsCliente.SelectedItems.Count <= 0))
                    ClienteSelecionado = lsCliente.SelectedItems[0].Tag as Model.Vo.Cliente.Model_Vo_Cliente;

                this.Close();
            }
        }

        private void lsCliente_DoubleClick(object sender, EventArgs e)
        {
            if ((AbertoParaConsCadastro == false))
            {
                ClienteSelecionado = null;

                if (!(lsCliente.SelectedItems == null || lsCliente.SelectedItems.Count <= 0))
                    ClienteSelecionado = lsCliente.SelectedItems[0].Tag as Model.Vo.Cliente.Model_Vo_Cliente;

                this.Close();
            }
        }

  
         
     

    }
}