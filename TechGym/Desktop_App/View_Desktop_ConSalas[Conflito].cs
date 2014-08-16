using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/* namespace Desktop_App
{
    public partial class View_Desktop_ConSalas : Form
    {
        public View_Desktop_ConSalas()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void View_Desktop_ConSalas_Load(object sender, EventArgs e)
        {
            cmbSelCampo.Items.Clear();
            cmbSelCampo.Items.Add(Academia.Model.Vo.eTipoSala.Model_Vo_eTipoSala.Quadra);
            cmbSelCampo.Items.Add(Academia.Model.Vo.eTipoSala.Model_Vo_eTipoSala.Sauna);
        }
    }
}
*/

namespace Desktop_App.View_Desktop_ConSalas
{
    public partial class View_Desktop_ConSalas : Form
    {
        Model.Bo.Salas.Model_Bo_Salas modelSala = new Model.Bo.Salas.Model_Bo_Salas();
        Controller.Salas.Controller_Salas ctlSala = new Controller.Salas.Controller_Salas();

        public Model.Vo.Sala.Model_Vo_Sala SalaSelecionada { get; set; }

        public View_Desktop_ConSalas()
        {
            InitializeComponent();
            SalaSelecionada = null;
        }

            private void listView1_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

        private void View_Desktop_ConSalas_Load(object sender, EventArgs e)
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
            DataTable dtSalas = new DataTable();
            dtSalas = modelSala.ListaDeSalasReserv(txtSelCampo.Text);
            List<Model.Vo.Salas.Model_Vo_Salas> lstSalas = ctlSala.ListaDeSalasReserv_VO(dtSalas);

            lsSalas.Items.Clear();
            if (lstSalas != null)
            {
                for (int i = 0; i < lstSalas.Count; i++)
                {

                    ListViewItem item1 = new ListViewItem(Convert.ToString(lstSalas[i].Descricao));
                    item1.SubItems.Add(new ListViewItem.ListViewSubItem(item1, Convert.ToString(lstProdutos[i].Nome)));
                    
                    //Tem que colocar aqui na tag cada vo
                    item1.Tag = lstProdutos[i];
                    lsProdutos.Items.Add(item1);
                }
            }
        }

        private void lsSalas_DoubleClick(object sender, EventArgs e)
        {
            if (lsSalas.SelectedItems.Count == 0)
                return;

            SalaSelecionada = lsProdutos.SelectedItems[0].Tag as Model.Vo.Sala.Model_Vo_Sala;

            this.Close();
        }
    }
}










