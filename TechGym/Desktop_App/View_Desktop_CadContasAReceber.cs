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
    public partial class View_Desktop_CadContasARecebers : Form
    {
        Model.Vo.ContasAReceber.Model_Vo_ContasAReceber ContasAReceberLocal;
        Controller.ContasARecebers.Controller_ContasARecebers controlerContasARecebers = new Controller.ContasARecebers.Controller_ContasARecebers();
        Controller.Produtos.Controller_Produtos contProdutos = new Controller.Produtos.Controller_Produtos();
        Controller.Clientes.Controller_Clientes contClientes = new Controller.Clientes.Controller_Clientes();

        string StatusLocal = "";

        Boolean gbCargaPorAgenda = false;
        Model.Vo.Agenda.Model_Vo_Agenda AgendaOrigem = new Model.Vo.Agenda.Model_Vo_Agenda();

        public View_Desktop_CadContasARecebers()
        {
            InitializeComponent();
        }


        public void SetAgenda(Model.Vo.Agenda.Model_Vo_Agenda pAgenda)
        {
            AgendaOrigem = pAgenda;
            if ((AgendaOrigem != null))
                gbCargaPorAgenda = true;
            else
                gbCargaPorAgenda = false;
        }
       
       
        private void CarregarContasAReceber(Int32 piNumRegistro)
        {
            try
            {
                if ((gbCargaPorAgenda) && (AgendaOrigem != null))
                    ContasAReceberLocal = controlerContasARecebers.CarregarContasAReceber(piNumRegistro, AgendaOrigem.Id);
                else
                    ContasAReceberLocal = controlerContasARecebers.CarregarContasAReceber(piNumRegistro, 0);

                txtId.Text = Convert.ToString(ContasAReceberLocal.Id);
                txtIdReserva.Text = ContasAReceberLocal.IdReservaOrigem.ToString();
                txtDataHoraCriacao.Text = ContasAReceberLocal.DataHoraCriacao.ToString();
                txtIdProduto.Text = ContasAReceberLocal.IdProduto.ToString();
                txtIdClienteSolicitante.Text = Convert.ToString(ContasAReceberLocal.IdCliente);
                txtValorAReceber.Text = ContasAReceberLocal.ValorAReceber.ToString();
                cmbOrigem.Text = ContasAReceberLocal.Origem.ToString();
                chkRecebido.Checked = ContasAReceberLocal.Recebido;
                txtDescrição.Text = ContasAReceberLocal.Descricao.ToString() ;

                TratarInterface();

                if ((gbCargaPorAgenda))
                {
                    lblAlterar();

                    txtIdReserva.Enabled = false;
                    btnPesquisarReservaOrigem.Enabled = false;
                    txtIdClienteSolicitante.Enabled = false;
                    btnPesquisarClienteSolicitante.Enabled = false;
                    txtIdProduto.Enabled = false;
                    btnPesquisarProduto.Enabled = false;
                    cmbOrigem.Enabled = false;
                    chkRecebido.Checked = true;
                }

                lblReserva1.Text = String.Empty;
                lblNomeCliente.Text = contClientes.GetCliente(ContasAReceberLocal.IdCliente).Nome;
                lblDescricaoProduto.Text = contProdutos.GetProduto(ContasAReceberLocal.IdProduto).Descricao;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar ContasARecebers:" + ex.Message);
            }
        }

        private void TratarInterface()
        {
            btnVoltar.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I") && (ContasAReceberLocal.RegistroNro > 0));
            btnPesquisa.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I") && (ContasAReceberLocal.RegistroNro > 0));
            btnAvancar.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I") && (ContasAReceberLocal.RegistroNro < controlerContasARecebers.getNumRegistros() - 1));
            btnIncluir.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I"));
            btnAlterar.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I") && (controlerContasARecebers.getNumRegistros() > 0));
            btnSalvar.Enabled = ((StatusLocal == "A") || (StatusLocal == "I"));
            btnCancelar.Enabled = ((StatusLocal == "A") || (StatusLocal == "I"));
            btnExcluir.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I") && (controlerContasARecebers.getNumRegistros() > 0));            

            if ((StatusLocal == ""))
            {
                txtId.Enabled = false;
                txtIdReserva.Enabled = false;
                txtDataHoraCriacao.Enabled = false;
                txtIdProduto.Enabled = false;
                txtValorAReceber.Enabled = false;
                cmbOrigem.Enabled = false;
                btnPesquisarClienteSolicitante.Enabled = false;
                btnPesquisarProduto.Enabled = false;
                btnPesquisarReservaOrigem.Enabled = false;
                txtIdClienteSolicitante.Enabled = false;
                txtDescrição.Enabled = false;
                chkRecebido.Enabled = false;
            }
            else
            {
                txtId.Enabled = false;
                txtIdReserva.Enabled = true;
                txtDataHoraCriacao.Enabled = true;
                txtIdProduto.Enabled = true;
                txtValorAReceber.Enabled = true;
                cmbOrigem.Enabled = true;
                btnPesquisarClienteSolicitante.Enabled = true;
                btnPesquisarProduto.Enabled = true;
                btnPesquisarReservaOrigem.Enabled = true;
                txtIdClienteSolicitante.Enabled = true;
                txtDescrição.Enabled = true;
                chkRecebido.Enabled = (StatusLocal != "I");
            }
        }


        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if ((ContasAReceberLocal.RegistroNro > 0))
                ContasAReceberLocal.RegistroNro = ContasAReceberLocal.RegistroNro - 1;
            CarregarContasAReceber(ContasAReceberLocal.RegistroNro);
        }

        private void btnAvancar_Click(object sender, EventArgs e)
        {
            if ((ContasAReceberLocal.RegistroNro < controlerContasARecebers.getNumRegistros() - 1))
                ContasAReceberLocal.RegistroNro = ContasAReceberLocal.RegistroNro + 1;
            CarregarContasAReceber(ContasAReceberLocal.RegistroNro);
        }

        private void PreencherCampos(Model.Vo.ContasAReceber.Model_Vo_ContasAReceber ContasAReceber)
        {
            txtId.Text = Convert.ToString(ContasAReceber.Id);
            txtIdReserva.Text = ContasAReceber.IdReservaOrigem.ToString();
            lblReserva1.Text = String.Empty;
            txtDataHoraCriacao.Text = ContasAReceber.DataHoraCriacao.ToString();
            txtIdProduto.Text = ContasAReceber.IdProduto.ToString();
            lblDescricaoProduto.Text = contProdutos.GetProduto(ContasAReceber.IdProduto).Descricao;
            txtIdClienteSolicitante.Text = Convert.ToString(ContasAReceber.IdCliente);
            lblNomeCliente.Text = contClientes.GetCliente(ContasAReceber.IdCliente).Nome;
            txtValorAReceber.Text = ContasAReceber.ValorAReceber.ToString();
            txtDescrição.Text = ContasAReceber.Descricao.ToString();
            cmbOrigem.Text = ContasAReceber.Origem.ToString();
            chkRecebido.Checked = ContasAReceber.Recebido;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            lclIncluir();
        }

        private void lclIncluir()
        {
            ContasAReceberLocal = controlerContasARecebers.DevolveValorInicial();
            ContasAReceberLocal.RegistroNro = ContasAReceberLocal.RegistroNro + 1;
            PreencherCampos(ContasAReceberLocal);
            StatusLocal = "I";
            TratarInterface();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            lblAlterar();
        }

        private void lblAlterar()
        {
            try
            {
                PreencherCampos(ContasAReceberLocal);
                StatusLocal = "A";
                TratarInterface();
            }
            finally
            {
                
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bool bSalv = false;
            try
            {
                try
                {

                    ContasAReceberLocal.IdReservaOrigem = Convert.ToInt32(txtIdReserva.Text);
                    ContasAReceberLocal.DataHoraCriacao = Convert.ToDateTime(txtDataHoraCriacao.Text);
                    ContasAReceberLocal.IdProduto = Convert.ToInt32(txtIdProduto.Text);
                    ContasAReceberLocal.IdCliente = Convert.ToInt32(txtIdClienteSolicitante.Text);

                    ContasAReceberLocal.Descricao = Convert.ToString(txtDescrição.Text);
                    ContasAReceberLocal.Recebido = chkRecebido.Checked;

                    float fValor = 0.0f;
                                        

                    fValor = 0.0f;
                    float.TryParse(txtValorAReceber.Text, out fValor);
                    ContasAReceberLocal.ValorAReceber = fValor;
                    txtValorAReceber.Text = Convert.ToString(fValor);

                    if ((cmbOrigem.Text.ToString() == Model.Vo.eOrigemContasAReceber.Model_Vo_eOrigemContasAReceber.Consumo.ToString()))
                        ContasAReceberLocal.Origem = Model.Vo.eOrigemContasAReceber.Model_Vo_eOrigemContasAReceber.Consumo;
                    else if ((cmbOrigem.Text.ToString() == Model.Vo.eOrigemContasAReceber.Model_Vo_eOrigemContasAReceber.Mensalidade.ToString()))
                        ContasAReceberLocal.Origem = Model.Vo.eOrigemContasAReceber.Model_Vo_eOrigemContasAReceber.Mensalidade;
                    else if ((cmbOrigem.Text.ToString() == Model.Vo.eOrigemContasAReceber.Model_Vo_eOrigemContasAReceber.VendaBalcao.ToString()))
                        ContasAReceberLocal.Origem = Model.Vo.eOrigemContasAReceber.Model_Vo_eOrigemContasAReceber.VendaBalcao;
                    else
                        ContasAReceberLocal.Origem = Model.Vo.eOrigemContasAReceber.Model_Vo_eOrigemContasAReceber.Outros;

                    if ((StatusLocal == "A"))
                        controlerContasARecebers.Alterar(ContasAReceberLocal);
                    else
                        controlerContasARecebers.Incluir(ContasAReceberLocal);

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
                    CarregarContasAReceber(-1);

                    if ((gbCargaPorAgenda))
                    {
                        this.Close();
                    }
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if ((txtId.Text.ToString() != "") &&
                (txtId.Text != null) &&
                (Convert.ToInt32(txtId.Text) > 0))
                controlerContasARecebers.Excluir(ContasAReceberLocal.Id);
            CarregarContasAReceber(-1);
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
                if ((gbCargaPorAgenda))
                {
                    this.Close();
                }
            }
        }

        private void gridItens_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            Academia.View.Desktop.View_Desktop_ConContasAReceber obj = new Academia.View.Desktop.View_Desktop_ConContasAReceber();
            //obj.MdiParent = this;
            obj.ShowDialog();

            if ((obj.ContasAReceberSelecionado != null))
            {
                ContasAReceberLocal = obj.ContasAReceberSelecionado;

                PreencherCampos(ContasAReceberLocal);
            }
        }        

        private void txtObservacao_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPesquisarClienteSolicitante_Click(object sender, EventArgs e)
        {
            Academia.View.Desktop.View_Desktop_ConClientes obj = new Academia.View.Desktop.View_Desktop_ConClientes();
            //obj.MdiParent = this;
            obj.ShowDialog();

            if ((obj.ClienteSelecionado != null))
            {
                txtIdClienteSolicitante.Text = Convert.ToString(obj.ClienteSelecionado.Id);
                localCarrecarCliente(obj.ClienteSelecionado.Id);
            }
            
        }

        private void btnPesquisarProduto_Click(object sender, EventArgs e)
        {
            Academia.View.Desktop.View_Desktop_ConProdutos obj = new Academia.View.Desktop.View_Desktop_ConProdutos();
            //obj.MdiParent = this;
            obj.ShowDialog();

            if ((obj.ProdSelecionado != null))
            {
                txtIdProduto.Text = Convert.ToString(obj.ProdSelecionado.Id);
                localCarregarProduto(obj.ProdSelecionado.Id);
            }
            
        }

        private void localCarregarProduto(int id) {

            if ((id > 0)) {
                lblDescricaoProduto.Text = Convert.ToString(contProdutos.GetProduto(id).Descricao);
                txtValorAReceber.Text = Convert.ToString(contProdutos.GetProduto(id).ValorDeVenda);
            }
            else {
                lblDescricaoProduto.Text = String.Empty;
                txtValorAReceber.Text = Convert.ToString(0.0f);
            }
        }

        private void localCarrecarCliente(int id)
        {
            if ((id > 0))
            {
                lblNomeCliente.Text = Convert.ToString(contClientes.GetCliente(id).Nome);
            }
            else
                lblNomeCliente.Text = String.Empty;
        }

        private void btnPesquisarReservaOrigem_Click(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }        

        private void txtIdClienteSolicitante_TextChanged(object sender, EventArgs e)
        {
            int i = 0;
            int.TryParse(txtIdClienteSolicitante.Text, out i);

            localCarrecarCliente(i);
        }

        private void txtIdProduto_TextChanged(object sender, EventArgs e)
        {
            int i = 0;
            int.TryParse(txtIdProduto.Text, out i);

            localCarregarProduto(i);
        }

        

        private void txtValorTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIdReserva_TextChanged(object sender, EventArgs e)
        {

        }

        private void View_Desktop_CadContasARecebers_Load(object sender, EventArgs e)
        {
            cmbOrigem.Items.Clear();
            cmbOrigem.Items.Add(Model.Vo.eOrigemContasAReceber.Model_Vo_eOrigemContasAReceber.VendaBalcao);
            cmbOrigem.Items.Add(Model.Vo.eOrigemContasAReceber.Model_Vo_eOrigemContasAReceber.Consumo);
            cmbOrigem.Items.Add(Model.Vo.eOrigemContasAReceber.Model_Vo_eOrigemContasAReceber.Mensalidade);                        
            cmbOrigem.Items.Add(Model.Vo.eOrigemContasAReceber.Model_Vo_eOrigemContasAReceber.Outros);

            ContasAReceberLocal = new Model.Vo.ContasAReceber.Model_Vo_ContasAReceber();

            CarregarContasAReceber(-1);
        }
    }
}
