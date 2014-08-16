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
    public partial class View_Desktop_ConMovimentacaoEstoques : Form
    {
        Model.Bo.MovimentacaoEstoques.Model_Bo_MovimentacaoEstoques contLocal = new Model.Bo.MovimentacaoEstoques.Model_Bo_MovimentacaoEstoques();
        Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque MovEstoqueLocal = new Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque();
        Controller.Produtos.Controller_Produtos contProdutos = new Controller.Produtos.Controller_Produtos();
        Controller.MovimentacaoEstoques.Controller_MovimentacaoEstoques contMovEstoque = new Controller.MovimentacaoEstoques.Controller_MovimentacaoEstoques();

        public Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque MovEstoqueSelecionado { get; set; }

        public View_Desktop_ConMovimentacaoEstoques()
        {
            InitializeComponent();
            MovEstoqueSelecionado = null;
        }

        private void Pesquisar()
        {
            List<Academia.Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque> movEstoq = contMovEstoque.ListaDeMovimentacaoEstoquesDoPeriodo(Convert.ToDateTime(mskDataInicial.Text), Convert.ToDateTime(mskDataFinal.Text));
            lsMovimentacaoEstoques.Items.Clear();

            if (movEstoq == null) return;


            foreach (var c in movEstoq)
            {
                ListViewItem movItem = new ListViewItem(Convert.ToString(c.DataHora));
                movItem.SubItems.Add(new ListViewItem.ListViewSubItem(movItem, c.TipoDeMovimento.ToString()));
                movItem.SubItems.Add(new ListViewItem.ListViewSubItem(movItem, Convert.ToString(contProdutos.GetProduto(c.IdProduto).Descricao)));
                movItem.SubItems.Add(new ListViewItem.ListViewSubItem(movItem, Convert.ToString(c.Quantidade)));
                movItem.SubItems.Add(new ListViewItem.ListViewSubItem(movItem, Convert.ToString(c.ValorUnitario)));
                movItem.SubItems.Add(new ListViewItem.ListViewSubItem(movItem, Convert.ToString(c.ValorTotal)));
                movItem.Tag = c;

                lsMovimentacaoEstoques.Items.Add(movItem);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void View_Desktop_ConMovimentacaoEstoques_Load(object sender, EventArgs e)
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

        private void lsMovimentacaoEstoques_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lsMovimentacaoEstoques.SelectedItems.Count == 0)
                return;

            MovEstoqueSelecionado = lsMovimentacaoEstoques.SelectedItems[0].Tag as Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque;

            this.Close();
        }

        private void lsMovimentacaoEstoques_DoubleClick(object sender, EventArgs e)
        {
            if (lsMovimentacaoEstoques.SelectedItems.Count == 0)
                return;

            MovEstoqueSelecionado = lsMovimentacaoEstoques.SelectedItems[0].Tag as Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque;

            this.Close();
        }
    }
}
