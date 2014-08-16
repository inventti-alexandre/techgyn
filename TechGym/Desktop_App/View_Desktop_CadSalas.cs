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
    public partial class View_Desktop_CadSalas : Form
    {
        Model.Vo.Sala.Model_Vo_Sala salaLocal;
        Controller.Salas.Controller_Salas controlerSalas = new Controller.Salas.Controller_Salas();
        Controller.Produtos.Controller_Produtos controlerProdutos = new Controller.Produtos.Controller_Produtos();

        string StatusLocal = "";

        public View_Desktop_CadSalas()
        {
            InitializeComponent();
        }

        private void CadSalas_Load(object sender, EventArgs e)
        {

                       
        }

        private void CarregarSala(Int32 piNumRegistro)
        {
            try
            {
                salaLocal = controlerSalas.CarregarSala(piNumRegistro);
                txtId.Text = Convert.ToString(salaLocal.Id);
                txtDescricao.Text = salaLocal.Nome;
                txtCapacidade.Text = Convert.ToString(salaLocal.Capacidade);
                cmbTipo.Text = Convert.ToString(salaLocal.Tipo);

                TratarInterface();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar salas:" + ex.Message);
            }
        }

        private void TratarInterface()
        {
            btnVoltar.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I") && (salaLocal.RegistroNro > 0));
            btnAvancar.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I") && (salaLocal.RegistroNro < controlerSalas.getNumRegistros() - 1));
            btnIncluir.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I"));
            btnAlterar.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I") && (controlerSalas.getNumRegistros() > 0));
            btnSalvar.Enabled = ((StatusLocal == "A") || (StatusLocal == "I"));
            btnCancelar.Enabled = ((StatusLocal == "A") || (StatusLocal == "I"));
            btnExcluir.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I") && (controlerSalas.getNumRegistros() > 0));            

            if ((StatusLocal == ""))
            {
                txtId.Enabled = false;
                txtDescricao.Enabled = false;
                txtCapacidade.Enabled = false;
                cmbTipo.Enabled = false;
                txtIdProduto.Enabled = false;
                btnProduto.Enabled = false;
            }
            else
            {
                txtId.Enabled = false;
                txtDescricao.Enabled = true;
                txtCapacidade.Enabled = true;
                cmbTipo.Enabled = true;
                txtIdProduto.Enabled = true;
                btnProduto.Enabled = true;
            }
        }


        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if ((salaLocal.RegistroNro > 0))
                salaLocal.RegistroNro = salaLocal.RegistroNro - 1;
            CarregarSala(salaLocal.RegistroNro);
        }

        private void btnAvancar_Click(object sender, EventArgs e)
        {
            if ((salaLocal.RegistroNro < controlerSalas.getNumRegistros() - 1))
                salaLocal.RegistroNro = salaLocal.RegistroNro + 1;
            CarregarSala(salaLocal.RegistroNro);
        }

        private void PreencherCampos(Model.Vo.Sala.Model_Vo_Sala sala) {
            txtId.Text = Convert.ToString(sala.Id);
            txtDescricao.Text = Convert.ToString(sala.Nome);
            txtCapacidade.Text = Convert.ToString(sala.Capacidade);
            cmbTipo.Text = Convert.ToString(sala.Tipo);
            txtIdProduto.Text = Convert.ToString(sala.IdProduto);
            lblDesProduto.Text = Convert.ToString(controlerProdutos.GetProduto(sala.IdProduto).Descricao);
            
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            salaLocal = controlerSalas.DevolveValorInicial();
            salaLocal.RegistroNro = salaLocal.RegistroNro + 1;
            PreencherCampos(salaLocal);
            StatusLocal = "I";
            TratarInterface();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            PreencherCampos(salaLocal);
            StatusLocal = "A";
            TratarInterface();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Boolean bSalv = true;
            try
            {
                try
                {
                    salaLocal.Nome = txtDescricao.Text;
                    salaLocal.Capacidade = Convert.ToInt32(txtCapacidade.Text);
                    salaLocal.IdProduto = Convert.ToInt32(txtIdProduto.Text);

                    if ((cmbTipo.Text == Model.Vo.eTipoSala.Model_Vo_eTipoSala.Quadra.ToString()))
                        salaLocal.Tipo = Model.Vo.eTipoSala.Model_Vo_eTipoSala.Quadra;
                    else
                        salaLocal.Tipo = Model.Vo.eTipoSala.Model_Vo_eTipoSala.Sauna;

                    if ((StatusLocal == "A"))
                        controlerSalas.Alterar(salaLocal);
                    else
                        controlerSalas.Incluir(salaLocal);
                }
                catch (Exception ex)
                {
                    bSalv = false;
                    MessageBox.Show(ex.Message);
                }
            }
            finally
            {
                if ((bSalv == true))
                {
                    StatusLocal = "";
                    CarregarSala(-1);
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if ((txtId.Text.ToString() != "") &&
                (txtId.Text != null) &&
                (Convert.ToInt32(txtId.Text) > 0))
                controlerSalas.Excluir(Convert.ToInt32(txtId.Text));
            CarregarSala(-1);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            StatusLocal = "";
            CarregarSala(-1);
        }

        private void gridItens_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCapacidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void View_Desktop_CadSalas_Load(object sender, EventArgs e)
        {
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add(Model.Vo.eTipoSala.Model_Vo_eTipoSala.Quadra);
            cmbTipo.Items.Add(Model.Vo.eTipoSala.Model_Vo_eTipoSala.Sauna);

            salaLocal = new Model.Vo.Sala.Model_Vo_Sala();
            CarregarSala(-1);
           
        }

        private void btnProduto_Click(object sender, EventArgs e)
        {
            Academia.View.Desktop.View_Desktop_ConProdutos obj = new Academia.View.Desktop.View_Desktop_ConProdutos();
            //obj.MdiParent = this;
            obj.ShowDialog();

            if ((obj.ProdSelecionado != null))
            {
                txtIdProduto.Text = Convert.ToString(obj.ProdSelecionado.Id);
                lblDesProduto.Text = Convert.ToString(controlerProdutos.GetProduto(obj.ProdSelecionado.Id).Descricao);
            }
        }

        private void txtIdProduto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
