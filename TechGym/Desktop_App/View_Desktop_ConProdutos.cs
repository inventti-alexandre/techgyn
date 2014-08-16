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
    public partial class View_Desktop_ConProdutos : Form
    {
        Model.Bo.Produtos.Model_Bo_Produtos modelProd = new Model.Bo.Produtos.Model_Bo_Produtos();
        Controller.Produtos.Controller_Produtos ctlProd = new Controller.Produtos.Controller_Produtos();

        public Model.Vo.Produto.Model_Vo_Produto ProdSelecionado { get; set; }

        public View_Desktop_ConProdutos()
        {
            InitializeComponent();
            ProdSelecionado = null;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void View_Desktop_ConProdutos_Load(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void txtSelCampo_TextChanged(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void Pesquisar()
        {
            DataTable dtProds = new DataTable();
            dtProds = modelProd.ListaDeProdutosCom(txtSelCampo.Text);
            List<Model.Vo.Produto.Model_Vo_Produto> lstProdutos = ctlProd.ListaDeProdutosVO(dtProds);

            lsProdutos.Items.Clear();
            if (lstProdutos != null)
            {
                for (int i = 0; i < lstProdutos.Count; i++)
                {

                    ListViewItem item1 = new ListViewItem(Convert.ToString(lstProdutos[i].Descricao));
                    item1.SubItems.Add(new ListViewItem.ListViewSubItem(item1, Convert.ToString(lstProdutos[i].Id)));
                    item1.SubItems.Add(new ListViewItem.ListViewSubItem(item1, Convert.ToString(lstProdutos[i].Estoque)));
                    item1.SubItems.Add(new ListViewItem.ListViewSubItem(item1, Convert.ToString(lstProdutos[i].ValorDeVenda)));
                    
                    //Tem que colocar aqui na tag cada vo
                    item1.Tag = lstProdutos[i];
                    lsProdutos.Items.Add(item1);
                }
            }
        }

        private void lsProdutos_DoubleClick(object sender, EventArgs e)
        {
            if (lsProdutos.SelectedItems.Count == 0)
                return;

            ProdSelecionado = lsProdutos.SelectedItems[0].Tag as Model.Vo.Produto.Model_Vo_Produto;

            this.Close();
        }

        private void lsProdutos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ProdSelecionado = null;

            if (!(lsProdutos.SelectedItems == null || lsProdutos.SelectedItems.Count <= 0))
                ProdSelecionado = lsProdutos.SelectedItems[0].Tag as Model.Vo.Produto.Model_Vo_Produto;

            this.Close();
        }
    }
}
