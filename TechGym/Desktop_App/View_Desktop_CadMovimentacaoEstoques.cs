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
    public partial class View_Desktop_CadMovimentacaoEstoques : Form
    {
        Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque MovimentacaoEstoqueLocal;
        Controller.MovimentacaoEstoques.Controller_MovimentacaoEstoques controlerMovimentacaoEstoques = new Controller.MovimentacaoEstoques.Controller_MovimentacaoEstoques();
        Controller.Produtos.Controller_Produtos contProdutos = new Controller.Produtos.Controller_Produtos();
        Controller.Clientes.Controller_Clientes contClientes = new Controller.Clientes.Controller_Clientes();

        string StatusLocal = "";

        Boolean gbCargaPorAgenda = false;
        Model.Vo.Agenda.Model_Vo_Agenda AgendaOrigem = new Model.Vo.Agenda.Model_Vo_Agenda();

        public View_Desktop_CadMovimentacaoEstoques()
        {
            InitializeComponent();
        }

        private void CadMovimentacaoEstoques_Load(object sender, EventArgs e)
        {
                      
        }

        public void SetAgenda(Model.Vo.Agenda.Model_Vo_Agenda pAgenda)
        {
            AgendaOrigem = pAgenda;
            if ((AgendaOrigem != null))
                gbCargaPorAgenda = true;
            else
                gbCargaPorAgenda = false;
        }

        private void CarregarMovimentacaoEstoque(Int32 piNumRegistro)
        {
            try
            {
                MovimentacaoEstoqueLocal = controlerMovimentacaoEstoques.CarregarMovimentacaoEstoque(piNumRegistro);
                txtId.Text = Convert.ToString(MovimentacaoEstoqueLocal.Id);
                txtIdReserva.Text = MovimentacaoEstoqueLocal.IdReservaOrigem.ToString();                
                txtDataHora.Text = MovimentacaoEstoqueLocal.DataHora.ToString();
                txtIdProduto.Text = MovimentacaoEstoqueLocal.IdProduto.ToString();                
                txtIdClienteSolicitante.Text = Convert.ToString(MovimentacaoEstoqueLocal.IdClienteSolicitante);                
                txtQuantidade1.Text = MovimentacaoEstoqueLocal.Quantidade.ToString();
                txtValorUnitario1.Text = MovimentacaoEstoqueLocal.ValorUnitario.ToString();
                txtValorTotal.Text = MovimentacaoEstoqueLocal.ValorTotal.ToString();
                cmbTipo.Text = MovimentacaoEstoqueLocal.TipoDeMovimento.ToString();

                TratarInterface();

                if ((gbCargaPorAgenda))
                {

                    lclIncluir();

                    txtId.Text = "0";

                    txtIdReserva.Text = Convert.ToString(AgendaOrigem.Id);
                    txtIdReserva.Enabled = false;

                    txtDataHora.Text = Convert.ToString(AgendaOrigem.DataHoraReserva);
                    txtDataHora.Enabled = false;

                    txtIdProduto.Text = Convert.ToString(0);

                    txtIdClienteSolicitante.Text = Convert.ToString(AgendaOrigem.IdCliente);
                    txtIdClienteSolicitante.Enabled = false;
                    btnPesquisarClienteSolicitante.Enabled = false;

                    txtQuantidade1.Text = Convert.ToString(1);
                    txtValorUnitario1.Text = Convert.ToString(0.0f);

                    cmbTipo.Text = Model.Vo.eTipoMovimento.Model_Vo_eTipoMovimento.Saida.ToString();
                    cmbTipo.Enabled = false;
                }

                lblReserva1.Text = String.Empty;
                lblNomeCliente.Text = contClientes.GetCliente(MovimentacaoEstoqueLocal.IdClienteSolicitante).Nome;
                lblDescricaoProduto.Text = contProdutos.GetProduto(MovimentacaoEstoqueLocal.IdProduto).Descricao;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar MovimentacaoEstoques:" + ex.Message);
            }
        }

        private void TratarInterface()
        {
            btnVoltar.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I") && (MovimentacaoEstoqueLocal.RegistroNro > 0));
            btnPesquisa.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I") && (MovimentacaoEstoqueLocal.RegistroNro > 0));
            btnAvancar.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I") && (MovimentacaoEstoqueLocal.RegistroNro < controlerMovimentacaoEstoques.getNumRegistros() - 1));
            btnIncluir.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I"));
            btnAlterar.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I") && (controlerMovimentacaoEstoques.getNumRegistros() > 0));
            btnSalvar.Enabled = ((StatusLocal == "A") || (StatusLocal == "I"));
            btnCancelar.Enabled = ((StatusLocal == "A") || (StatusLocal == "I"));
            btnExcluir.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I") && (controlerMovimentacaoEstoques.getNumRegistros() > 0));            

            if ((StatusLocal == ""))
            {
                txtId.Enabled = false;
                txtIdReserva.Enabled = false;
                txtDataHora.Enabled = false;
                txtIdProduto.Enabled = false;
                txtQuantidade1.Enabled = false;
                txtValorUnitario1.Enabled = false;
                txtValorTotal.Enabled = false;
                cmbTipo.Enabled = false;
                btnPesquisarClienteSolicitante.Enabled = false;
                btnPesquisarProduto.Enabled = false;
                btnPesquisarReservaOrigem.Enabled = false;
                txtIdClienteSolicitante.Enabled = false;
            }
            else
            {
                txtId.Enabled = false;
                txtIdReserva.Enabled = true;
                txtDataHora.Enabled = true;
                txtIdProduto.Enabled = true;
                txtQuantidade1.Enabled = true;
                txtValorUnitario1.Enabled = true;
                txtValorTotal.Enabled = true;
                cmbTipo.Enabled = true;
                btnPesquisarClienteSolicitante.Enabled = true;
                btnPesquisarProduto.Enabled = true;
                btnPesquisarReservaOrigem.Enabled = true;
                txtIdClienteSolicitante.Enabled = true;
            }
        }


        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if ((MovimentacaoEstoqueLocal.RegistroNro > 0))
                MovimentacaoEstoqueLocal.RegistroNro = MovimentacaoEstoqueLocal.RegistroNro - 1;
            CarregarMovimentacaoEstoque(MovimentacaoEstoqueLocal.RegistroNro);
        }

        private void btnAvancar_Click(object sender, EventArgs e)
        {
            if ((MovimentacaoEstoqueLocal.RegistroNro < controlerMovimentacaoEstoques.getNumRegistros() - 1))
                MovimentacaoEstoqueLocal.RegistroNro = MovimentacaoEstoqueLocal.RegistroNro + 1;
            CarregarMovimentacaoEstoque(MovimentacaoEstoqueLocal.RegistroNro);
        }

        private void PreencherCampos(Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque MovimentacaoEstoque)
        {
            txtId.Text = Convert.ToString(MovimentacaoEstoque.Id);
            txtIdReserva.Text = MovimentacaoEstoque.IdReservaOrigem.ToString();
            lblReserva1.Text = String.Empty;
            txtDataHora.Text = MovimentacaoEstoque.DataHora.ToString();
            txtIdProduto.Text = MovimentacaoEstoque.IdProduto.ToString();
            lblDescricaoProduto.Text = contProdutos.GetProduto(MovimentacaoEstoque.IdProduto).Descricao;
            txtIdClienteSolicitante.Text = Convert.ToString(MovimentacaoEstoque.IdClienteSolicitante);
            lblNomeCliente.Text = contClientes.GetCliente(MovimentacaoEstoque.IdClienteSolicitante).Nome;
            txtQuantidade1.Text = MovimentacaoEstoque.Quantidade.ToString();
            txtValorUnitario1.Text = MovimentacaoEstoque.ValorUnitario.ToString();
            txtValorTotal.Text = MovimentacaoEstoque.ValorTotal.ToString();
            cmbTipo.Text = MovimentacaoEstoque.TipoDeMovimento.ToString();
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            lclIncluir();
        }

        private void lclIncluir()
        {
            MovimentacaoEstoqueLocal = controlerMovimentacaoEstoques.DevolveValorInicial();
            MovimentacaoEstoqueLocal.RegistroNro = MovimentacaoEstoqueLocal.RegistroNro + 1;
            PreencherCampos(MovimentacaoEstoqueLocal);
            StatusLocal = "I";
            TratarInterface();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            PreencherCampos(MovimentacaoEstoqueLocal);
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

                    MovimentacaoEstoqueLocal.IdReservaOrigem = Convert.ToInt32(txtIdReserva.Text);
                    MovimentacaoEstoqueLocal.DataHora = Convert.ToDateTime(txtDataHora.Text);
                    MovimentacaoEstoqueLocal.IdProduto = Convert.ToInt32(txtIdProduto.Text);
                    MovimentacaoEstoqueLocal.IdClienteSolicitante = Convert.ToInt32(txtIdClienteSolicitante.Text);

                    float fValor = 0.0f;
                    
                    float.TryParse(txtQuantidade1.Text, out fValor);
                    MovimentacaoEstoqueLocal.Quantidade = fValor;
                    txtQuantidade1.Text = Convert.ToString(fValor);

                    fValor = 0.0f;
                    float.TryParse(txtValorUnitario1.Text, out fValor);
                    MovimentacaoEstoqueLocal.ValorUnitario = fValor;
                    txtValorUnitario1.Text = Convert.ToString(fValor);

                    fValor = 0.0f;
                    float.TryParse(txtValorTotal.Text, out fValor);
                    MovimentacaoEstoqueLocal.ValorTotal = fValor;
                    txtValorTotal.Text = Convert.ToString(fValor);

                    if ((cmbTipo.Text.ToString() == Model.Vo.eTipoMovimento.Model_Vo_eTipoMovimento.Entrada.ToString()))
                       MovimentacaoEstoqueLocal.TipoDeMovimento = Model.Vo.eTipoMovimento.Model_Vo_eTipoMovimento.Entrada;
                    else
                       MovimentacaoEstoqueLocal.TipoDeMovimento = Model.Vo.eTipoMovimento.Model_Vo_eTipoMovimento.Saida;

                    if ((StatusLocal == "A"))
                        controlerMovimentacaoEstoques.Alterar(MovimentacaoEstoqueLocal);
                    else
                        controlerMovimentacaoEstoques.Incluir(MovimentacaoEstoqueLocal);

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
                    CarregarMovimentacaoEstoque(-1);
                }

                if ((gbCargaPorAgenda) && (bSalv))
                {
                    this.Close();
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if ((txtId.Text.ToString() != "") &&
                (txtId.Text != null) &&
                (Convert.ToInt32(txtId.Text) > 0))
                controlerMovimentacaoEstoques.Excluir(MovimentacaoEstoqueLocal);
            CarregarMovimentacaoEstoque(-1);
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
            Academia.View.Desktop.View_Desktop_ConMovimentacaoEstoques obj = new Academia.View.Desktop.View_Desktop_ConMovimentacaoEstoques();
            //obj.MdiParent = this;
            obj.ShowDialog();

            if ((obj.MovEstoqueSelecionado != null))
            {
                MovimentacaoEstoqueLocal = obj.MovEstoqueSelecionado;

                PreencherCampos(MovimentacaoEstoqueLocal);
            }
        }

        private void View_Desktop_CadMovimentacaoEstoques_Load(object sender, EventArgs e)
        {
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add(Model.Vo.eTipoMovimento.Model_Vo_eTipoMovimento.Entrada);
            cmbTipo.Items.Add(Model.Vo.eTipoMovimento.Model_Vo_eTipoMovimento.Saida);

            MovimentacaoEstoqueLocal = new Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque();

            CarregarMovimentacaoEstoque(-1);
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
                txtValorUnitario1.Text = Convert.ToString(contProdutos.GetProduto(id).ValorDeVenda);
            }
            else {
                lblDescricaoProduto.Text = String.Empty;
                txtValorUnitario1.Text = Convert.ToString(0.0f);
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

        private void CalcularValorTotal()
        {
            if ((txtQuantidade1.Enabled) && (txtValorUnitario1.Enabled))
            {
                float fQuantidade = 0.0f;
                float fValor = 0.0f;

                float.TryParse(txtQuantidade1.Text, out fQuantidade);
                float.TryParse(txtValorUnitario1.Text, out fValor);

                txtValorTotal.Text = Convert.ToString(fQuantidade * fValor);
            }
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

        private void txtValorUnitario1_TextChanged(object sender, EventArgs e)
        {
            CalcularValorTotal();
        }

        private void txtQuantidade1_TextChanged(object sender, EventArgs e)
        {
            CalcularValorTotal();
        }

        private void txtValorTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIdReserva_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
