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
    public partial class View_Desktop_ConSalas : Form
    {
        Model.Bo.Salas.Model_Bo_Salas modelSala = new Model.Bo.Salas.Model_Bo_Salas();
        Controller.Salas.Controller_Salas ctlSala = new Controller.Salas.Controller_Salas();
        //public View_Desktop_ConSalas()
        //{
        //    InitializeComponent();
        //}
        public Model.Vo.Sala.Model_Vo_Sala SalaSelecionada {get; set;}

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
            cmbSelCampo.Items.Clear();
            cmbSelCampo.Items.Add(Academia.Model.Vo.eTipoSala.Model_Vo_eTipoSala.Quadra);
            cmbSelCampo.Items.Add(Academia.Model.Vo.eTipoSala.Model_Vo_eTipoSala.Sauna);
            Pesquisar();
        }

        private void Pesquisar()
        {
        }

        private void txtSelCampo_TextChanged(object sender, EventArgs e)
        {
            Pesquisar();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }


        private void lsSalas_DoubleClick(object sender, EventArgs e)
        {
            if (lsSala.SelectedItems.Count == 0)
                return;

            SalaSelecionada = lsSala.SelectedItems[0].Tag as Model.Vo.Sala.Model_Vo_Sala;

            this.Close();
        }
    }
}
