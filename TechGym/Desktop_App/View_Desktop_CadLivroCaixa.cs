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
    public partial class View_Desktop_CadLivroCaixas : Form
    {
        Model.Vo.LivroCaixa.Model_Vo_LivroCaixa LivroCaixaLocal;
        Controller.LivroCaixas.Controller_LivroCaixas controlerLivroCaixas = new Controller.LivroCaixas.Controller_LivroCaixas();

        string StatusLocal = "";       

        public View_Desktop_CadLivroCaixas()
        {
            InitializeComponent();
        }

        private void CadLivroCaixas_Load(object sender, EventArgs e)
        {
                      
        }        

        private void CarregarLivroCaixa(Int32 piNumRegistro)
        {
            try
            {
                LivroCaixaLocal = controlerLivroCaixas.CarregarLivroCaixa(piNumRegistro);
                txtId.Text = Convert.ToString(LivroCaixaLocal.Id);
                txtIdContasAReceber.Text = Convert.ToString(LivroCaixaLocal.IdContasAReceber);
                txtDataHora.Text = (Convert.ToString(LivroCaixaLocal.DataHora));
                txtDescricao.Text = LivroCaixaLocal.Descricao.ToString();
                txtValor.Text = Convert.ToString(LivroCaixaLocal.Valor);
                cmbTipo.Text = LivroCaixaLocal.TipoDeMovimento.ToString();

                TratarInterface();                

                lblContasAReceber.Text = String.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar LivroCaixas:" + ex.Message);
            }
        }

        private void TratarInterface()
        {
            btnVoltar.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I") && (LivroCaixaLocal.RegistroNro > 0));
            btnPesquisa.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I") && (LivroCaixaLocal.RegistroNro > 0));
            btnAvancar.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I") && (LivroCaixaLocal.RegistroNro < controlerLivroCaixas.getNumRegistros() - 1));
            btnIncluir.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I"));
            btnAlterar.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I") && (controlerLivroCaixas.getNumRegistros() > 0));
            btnSalvar.Enabled = ((StatusLocal == "A") || (StatusLocal == "I"));
            btnCancelar.Enabled = ((StatusLocal == "A") || (StatusLocal == "I"));
            btnExcluir.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I") && (controlerLivroCaixas.getNumRegistros() > 0));            

            if ((StatusLocal == ""))
            {
                txtId.Enabled = false;
                txtIdContasAReceber.Enabled = false;
                txtDataHora.Enabled = false;               
                txtDescricao.Enabled = false;
                txtValor.Enabled = false;               
                cmbTipo.Enabled = false;
                btnPesquisarContasAReceber.Enabled = false;
            }
            else
            {
                txtId.Enabled = false;
                txtIdContasAReceber.Enabled = true;
                txtDataHora.Enabled = true;
                txtDescricao.Enabled = true;
                txtValor.Enabled = true;
                cmbTipo.Enabled = true;
                btnPesquisarContasAReceber.Enabled = true;
            }
        }


        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if ((LivroCaixaLocal.RegistroNro > 0))
                LivroCaixaLocal.RegistroNro = LivroCaixaLocal.RegistroNro - 1;
            CarregarLivroCaixa(LivroCaixaLocal.RegistroNro);
        }

        private void btnAvancar_Click(object sender, EventArgs e)
        {
            if ((LivroCaixaLocal.RegistroNro < controlerLivroCaixas.getNumRegistros() - 1))
                LivroCaixaLocal.RegistroNro = LivroCaixaLocal.RegistroNro + 1;
            CarregarLivroCaixa(LivroCaixaLocal.RegistroNro);
        }

        private void PreencherCampos(Model.Vo.LivroCaixa.Model_Vo_LivroCaixa LivroCaixa)
        {
            txtId.Text = Convert.ToString(LivroCaixa.Id);
            txtIdContasAReceber.Text = Convert.ToString(LivroCaixa.IdContasAReceber);
            lblContasAReceber.Text = String.Empty;
            txtDataHora.Text = Convert.ToString(LivroCaixa.DataHora);
            txtDescricao.Text = Convert.ToString(LivroCaixa.Descricao);
            txtValor.Text = Convert.ToString(LivroCaixa.Valor);
            cmbTipo.Text = LivroCaixa.TipoDeMovimento.ToString();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            lclIncluir();
        }

        private void lclIncluir()
        {
            LivroCaixaLocal = controlerLivroCaixas.DevolveValorInicial();
            LivroCaixaLocal.RegistroNro = LivroCaixaLocal.RegistroNro + 1;
            PreencherCampos(LivroCaixaLocal);
            StatusLocal = "I";
            TratarInterface();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            PreencherCampos(LivroCaixaLocal);
            StatusLocal = "A";
            TratarInterface();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bool bSalv = false;
            try
            {
                try
                {

                    LivroCaixaLocal.IdContasAReceber = Convert.ToInt32(txtIdContasAReceber.Text);
                    LivroCaixaLocal.DataHora = Convert.ToDateTime(txtDataHora.Text);
                    LivroCaixaLocal.Descricao = txtDescricao.Text;
                  

                    float fValor = 0.0f;                                       
                    float.TryParse(txtValor.Text, out fValor);
                    LivroCaixaLocal.Valor = fValor;
                    txtValor.Text = Convert.ToString(fValor);                   

                    if ((cmbTipo.Text.ToString() == Model.Vo.eTipoMovimento.Model_Vo_eTipoMovimento.Entrada.ToString()))
                        LivroCaixaLocal.TipoDeMovimento = Model.Vo.eTipoMovimento.Model_Vo_eTipoMovimento.Entrada;
                    else
                        LivroCaixaLocal.TipoDeMovimento = Model.Vo.eTipoMovimento.Model_Vo_eTipoMovimento.Saida;

                    if ((StatusLocal == "A"))
                        controlerLivroCaixas.Alterar(LivroCaixaLocal);
                    else
                        controlerLivroCaixas.Incluir(LivroCaixaLocal);

                    bSalv = true;
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
                    CarregarLivroCaixa(-1);
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if ((txtId.Text.ToString() != "") &&
                (txtId.Text != null) &&
                (Convert.ToInt32(txtId.Text) > 0))
                controlerLivroCaixas.Excluir(LivroCaixaLocal.Id, 0);
            CarregarLivroCaixa(-1);
        }
        //sadsad
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                StatusLocal = "";
                TratarInterface();

            }
            finally
            {                
            }
        }

        private void gridItens_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            Academia.View.Desktop.View_Desktop_ConLivroCaixa obj = new Academia.View.Desktop.View_Desktop_ConLivroCaixa();
            //obj.MdiParent = this;
            obj.ShowDialog();

            if ((obj.LivroCaixaSelecionado != null))
            {
                LivroCaixaLocal = obj.LivroCaixaSelecionado;

                PreencherCampos(LivroCaixaLocal);
            }
        }

        private void View_Desktop_CadLivroCaixas_Load(object sender, EventArgs e)
        {
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add(Model.Vo.eTipoMovimento.Model_Vo_eTipoMovimento.Entrada);
            cmbTipo.Items.Add(Model.Vo.eTipoMovimento.Model_Vo_eTipoMovimento.Saida);

            LivroCaixaLocal = new Model.Vo.LivroCaixa.Model_Vo_LivroCaixa();

            CarregarLivroCaixa(-1);
        }

        private void btnPesquisarContasAReceber_Click(object sender, EventArgs e)
        {

        }

    }
}
