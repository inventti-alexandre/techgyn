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
    public partial class View_Desktop_CadProdutos : Form
    {
        Model.Vo.Produto.Model_Vo_Produto ProdutoLocal;
        Controller.Produtos.Controller_Produtos controlerProdutos = new Controller.Produtos.Controller_Produtos();
        string StatusLocal = "";

        public View_Desktop_CadProdutos()
        {
            InitializeComponent();
        }

        private void CadProdutos_Load(object sender, EventArgs e)
        {
                      
        }

        private void CarregarProduto(Int32 piNumRegistro)
        {
            try
            {
                ProdutoLocal = controlerProdutos.CarregarProduto(piNumRegistro);
                txtId.Text = Convert.ToString(ProdutoLocal.Id);
                txtDescricao.Text = ProdutoLocal.Descricao;
                txtEstoque.Text = Convert.ToString(ProdutoLocal.Estoque);
                txtUnidade.Text = ProdutoLocal.Unidade;
                txtValorDeVenda.Text = Convert.ToString(ProdutoLocal.ValorDeVenda);
                txtObservacao.Text = ProdutoLocal.Observacao;

                TratarInterface();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar Produtos:" + ex.Message);
            }
        }

        private void TratarInterface()
        {
            btnVoltar.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I") && (ProdutoLocal.RegistroNro > 0));
            btnPesquisa.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I") && (ProdutoLocal.RegistroNro > 0));
            btnAvancar.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I") && (ProdutoLocal.RegistroNro < controlerProdutos.getNumRegistros() - 1));
            btnIncluir.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I"));
            btnAlterar.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I") && (controlerProdutos.getNumRegistros() > 0));
            btnSalvar.Enabled = ((StatusLocal == "A") || (StatusLocal == "I"));
            btnCancelar.Enabled = ((StatusLocal == "A") || (StatusLocal == "I"));
            btnExcluir.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I") && (controlerProdutos.getNumRegistros() > 0));            

            if ((StatusLocal == ""))
            {
                txtId.Enabled = false;
                txtDescricao.Enabled = false;
                txtEstoque.Enabled = false;
                txtUnidade.Enabled = false;
                txtValorDeVenda.Enabled = false;
                txtObservacao.Enabled = false;
            }
            else
            {
                txtId.Enabled = false;
                txtDescricao.Enabled = true;
                txtEstoque.Enabled = true;
                txtUnidade.Enabled = true;
                txtValorDeVenda.Enabled = true;
                txtObservacao.Enabled = true;
            }
        }


        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if ((ProdutoLocal.RegistroNro > 0))
                ProdutoLocal.RegistroNro = ProdutoLocal.RegistroNro - 1;
            CarregarProduto(ProdutoLocal.RegistroNro);
        }

        private void btnAvancar_Click(object sender, EventArgs e)
        {
            if ((ProdutoLocal.RegistroNro < controlerProdutos.getNumRegistros() - 1))
                ProdutoLocal.RegistroNro = ProdutoLocal.RegistroNro + 1;
            CarregarProduto(ProdutoLocal.RegistroNro);
        }

        private void PreencherCampos(Model.Vo.Produto.Model_Vo_Produto Produto)
        {
            txtId.Text = Convert.ToString(Produto.Id);
            txtDescricao.Text = Produto.Descricao;
            txtEstoque.Text = Convert.ToString(Produto.Estoque);
            txtUnidade.Text = Produto.Unidade;
            txtValorDeVenda.Text = Convert.ToString(Produto.ValorDeVenda);
            txtObservacao.Text = Produto.Observacao;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            ProdutoLocal = controlerProdutos.DevolveValorInicial();
            ProdutoLocal.RegistroNro = ProdutoLocal.RegistroNro + 1;
            PreencherCampos(ProdutoLocal);
            StatusLocal = "I";
            TratarInterface();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            PreencherCampos(ProdutoLocal);
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
                    ProdutoLocal.Descricao = txtDescricao.Text;                    
                    ProdutoLocal.Unidade = txtUnidade.Text;

                    float fEstoque = 0.0f;
                    float.TryParse(txtEstoque.Text, out fEstoque);
                    ProdutoLocal.Estoque = fEstoque;
                    txtEstoque.Text = Convert.ToString(fEstoque);

                    float fValorDevenda = 0.0f;
                    float.TryParse(txtValorDeVenda.Text, out fValorDevenda);
                    ProdutoLocal.ValorDeVenda = fValorDevenda;
                    txtValorDeVenda.Text = Convert.ToString(fValorDevenda);

                    ProdutoLocal.Observacao = txtObservacao.Text;

                    if ((StatusLocal == "A"))
                        controlerProdutos.Alterar(ProdutoLocal);
                    else
                        controlerProdutos.Incluir(ProdutoLocal);

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
                    CarregarProduto(-1);
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if ((txtId.Text.ToString() != "") &&
                (txtId.Text != null) &&
                (Convert.ToInt32(txtId.Text) > 0))
                controlerProdutos.Excluir(Convert.ToInt32(txtId.Text));
            CarregarProduto(-1);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            StatusLocal = "";
            TratarInterface();
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

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            Academia.View.Desktop.View_Desktop_ConProdutos obj = new Academia.View.Desktop.View_Desktop_ConProdutos();
            //obj.MdiParent = this;
            obj.ShowDialog();

            if ((obj.ProdSelecionado != null))
            {
                ProdutoLocal = obj.ProdSelecionado;

                PreencherCampos(ProdutoLocal);
            }
        }

        private void View_Desktop_CadProdutos_Load(object sender, EventArgs e)
        {
            ProdutoLocal = new Model.Vo.Produto.Model_Vo_Produto();
            CarregarProduto(-1); 
        }
    }
}
