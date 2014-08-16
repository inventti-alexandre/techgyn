using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Academia.View.Desktop
{
    public partial class View_Desktop_ConContasAReceber : Form
    {
        Model.Bo.ContasARecebers.Model_Bo_ContasARecebers contLocal = new Model.Bo.ContasARecebers.Model_Bo_ContasARecebers();
        Model.Vo.ContasAReceber.Model_Vo_ContasAReceber ContRecebLocal = new Model.Vo.ContasAReceber.Model_Vo_ContasAReceber();
        Controller.Produtos.Controller_Produtos contProdutos = new Controller.Produtos.Controller_Produtos();
        Controller.Clientes.Controller_Clientes contClientes = new Controller.Clientes.Controller_Clientes();
        Controller.ContasARecebers.Controller_ContasARecebers contContasAReceb = new Controller.ContasARecebers.Controller_ContasARecebers();

        public Model.Vo.ContasAReceber.Model_Vo_ContasAReceber ContasAReceberSelecionado { get; set; }

        public View_Desktop_ConContasAReceber()
        {
            InitializeComponent();
            ContasAReceberSelecionado = null;
        }

        private void Pesquisar()
        {
            //List<Academia.Model.Vo.ContasAReceber.Model_Vo_ContasAReceber> movEstoq = contMovEstoque.ListaDeConContasARecebersDoPeriodo(Convert.ToDateTime(mskDataInicial.Text), Convert.ToDateTime(mskDataFinal.Text));
            List<Academia.Model.Vo.ContasAReceber.Model_Vo_ContasAReceber> contReceb = contContasAReceb.ListaDeContasAReceberPeriodo(Convert.ToDateTime(mskDataInicial.Text), Convert.ToDateTime(mskDataFinal.Text));
            lsMovimentacaoEstoques.Items.Clear();

            if (contReceb == null) return;


            foreach (var c in contReceb)
            {
                ListViewItem movItem = new ListViewItem(Convert.ToString(c.DataHoraCriacao));
                movItem.SubItems.Add(new ListViewItem.ListViewSubItem(movItem, c.Origem.ToString()));
                movItem.SubItems.Add(new ListViewItem.ListViewSubItem(movItem, Convert.ToString(contProdutos.GetProduto(c.IdProduto).Descricao)));
                movItem.SubItems.Add(new ListViewItem.ListViewSubItem(movItem, Convert.ToString(c.ValorAReceber)));
                movItem.SubItems.Add(new ListViewItem.ListViewSubItem(movItem, Convert.ToString(contClientes.GetCliente(c.IdCliente).Nome)));
                movItem.Tag = c;

                lsMovimentacaoEstoques.Items.Add(movItem);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void View_Desktop_ConConContasARecebers_Load(object sender, EventArgs e)
        {
            mskDataInicial.Text = Convert.ToString(DateTime.Now.AddDays(-7));
            mskDataFinal.Text = Convert.ToString(DateTime.Now.AddDays(7));

            Pesquisar();
        }

        private void txtSelCampo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void lsConContasARecebers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lsMovimentacaoEstoques.SelectedItems.Count == 0)
                return;

            ContasAReceberSelecionado = lsMovimentacaoEstoques.SelectedItems[0].Tag as Model.Vo.ContasAReceber.Model_Vo_ContasAReceber;

            this.Close();
        }

        private void lsConContasARecebers_DoubleClick(object sender, EventArgs e)
        {
            if (lsMovimentacaoEstoques.SelectedItems.Count == 0)
                return;

            ContasAReceberSelecionado = lsMovimentacaoEstoques.SelectedItems[0].Tag as Model.Vo.ContasAReceber.Model_Vo_ContasAReceber;

            this.Close();
        }
    }
}
