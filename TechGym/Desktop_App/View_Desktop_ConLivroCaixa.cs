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
    public partial class View_Desktop_ConLivroCaixa : Form
    {
        Model.Bo.LivroCaixas.Model_Bo_LivroCaixas contLocal = new Model.Bo.LivroCaixas.Model_Bo_LivroCaixas();
        Model.Vo.LivroCaixa.Model_Vo_LivroCaixa LivroCaixaLocal = new Model.Vo.LivroCaixa.Model_Vo_LivroCaixa();
        Controller.Produtos.Controller_Produtos contProdutos = new Controller.Produtos.Controller_Produtos();
        Controller.LivroCaixas.Controller_LivroCaixas contLivroCaixa = new Controller.LivroCaixas.Controller_LivroCaixas();

        public Model.Vo.LivroCaixa.Model_Vo_LivroCaixa LivroCaixaSelecionado { get; set; }

        public View_Desktop_ConLivroCaixa()
        {
            InitializeComponent();
            LivroCaixaSelecionado = null;
        }

        private void Pesquisar()
        {
            List<Academia.Model.Vo.LivroCaixa.Model_Vo_LivroCaixa> livCaixa = contLivroCaixa.ListaLivroCaixaPeriodo(Convert.ToDateTime(mskDataInicial.Text), Convert.ToDateTime(mskDataFinal.Text));
            lsLivroCaixa.Items.Clear();

            if (livCaixa == null) return;


            foreach (var c in livCaixa)
            {
                ListViewItem movItem = new ListViewItem(Convert.ToString(c.DataHora));
                movItem.SubItems.Add(new ListViewItem.ListViewSubItem(movItem, c.TipoDeMovimento.ToString()));                
                movItem.SubItems.Add(new ListViewItem.ListViewSubItem(movItem, Convert.ToString(c.Valor)));
                movItem.SubItems.Add(new ListViewItem.ListViewSubItem(movItem, Convert.ToString(c.Descricao)));
                movItem.Tag = c;

                lsLivroCaixa.Items.Add(movItem);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void View_Desktop_ConLivroCaixa_Load(object sender, EventArgs e)
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

        private void lsLivroCaixa_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lsLivroCaixa.SelectedItems.Count == 0)
                return;

            LivroCaixaSelecionado = lsLivroCaixa.SelectedItems[0].Tag as Model.Vo.LivroCaixa.Model_Vo_LivroCaixa;

            this.Close();
        }

        private void lsLivroCaixa_DoubleClick(object sender, EventArgs e)
        {
            if (lsLivroCaixa.SelectedItems.Count == 0)
                return;

            LivroCaixaSelecionado = lsLivroCaixa.SelectedItems[0].Tag as Model.Vo.LivroCaixa.Model_Vo_LivroCaixa;

            this.Close();
        }
    }
}
