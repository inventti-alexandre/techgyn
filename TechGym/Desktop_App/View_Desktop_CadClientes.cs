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
    public partial class View_Desktop_CadClientes : Form
    {
        Model.Vo.Cliente.Model_Vo_Cliente clienteLocal;
        Controller.Clientes.Controller_Clientes controlerClientes = new Controller.Clientes.Controller_Clientes();
        string StatusLocal = "";

        public Model.Vo.Cliente.Model_Vo_Cliente ClienteSelecionadoPorConsulta { get; set; }
        public Boolean AbertoPorConsulta { get; set; }

        public View_Desktop_CadClientes()
        {
            InitializeComponent();
        }

        private void InicializarJanela()
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if ((clienteLocal.RegistroNro > 0))
                clienteLocal.RegistroNro = clienteLocal.RegistroNro - 1;
            CarregarCliente(clienteLocal.RegistroNro);
        }

        private void btnAvancar_Click(object sender, EventArgs e)
        {
            if ((clienteLocal.RegistroNro < controlerClientes.getNumRegistros() - 1))
                clienteLocal.RegistroNro = clienteLocal.RegistroNro + 1;
            CarregarCliente(clienteLocal.RegistroNro);
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            clienteLocal = controlerClientes.DevolveValorInicial();
            clienteLocal.RegistroNro = clienteLocal.RegistroNro + 1;
            PreencherCampos(clienteLocal);
            StatusLocal = "I";
            TratarInterface();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            PreencherCampos(clienteLocal);
            StatusLocal = "A";
            TratarInterface();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Boolean bSalv = false;
            try
            {
                try
                {
                    clienteLocal.Nome = txtNome.Text;
                    clienteLocal.Cpf = txtCpf.Text;
                    clienteLocal.Bairro = txtBairro.Text;
                    clienteLocal.CEP = txtCep.Text;
                    clienteLocal.Cidade = txtCidade.Text;
                    clienteLocal.Complemento = txtComplemento.Text;
                    clienteLocal.Email = txtEmail.Text;
                    clienteLocal.Numero = txtNumero.Text;
                    clienteLocal.Rg = txtRG.Text;
                    clienteLocal.Rua = txtEndereco.Text;
                    clienteLocal.Telefone = txtTelefone.Text;
                    clienteLocal.UF = txtEstado.Text;

                    DateTime dtNascimento = DateTime.MinValue;
                    DateTime.TryParse(txtNascimento.Text, out dtNascimento);
                    clienteLocal.Nascimento = dtNascimento;

                    float fMensalidade = 0.0f;
                    float.TryParse(txtValorMensalidade.Text, out fMensalidade);
                    clienteLocal.ValorMensalidade = fMensalidade;
                    txtValorMensalidade.Text = Convert.ToString(fMensalidade);

                    clienteLocal.Ativo = chkAtivo.Checked;
                    clienteLocal.Observacao = txtObservacao.Text;

                    if ((StatusLocal == "A"))
                        controlerClientes.Alterar(clienteLocal);
                    else if ((StatusLocal == "I"))
                    {
                        controlerClientes.Incluir(clienteLocal);
                    }
                   
                    bSalv = true;
                }
                catch (Exception ex) {
                    bSalv = false;
                    MessageBox.Show(ex.Message);
                }
            }
            finally
            {
                if ((bSalv == true))
                {
                    StatusLocal = "";
                    CarregarCliente(-1);
                }

                if ((AbertoPorConsulta))
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
                controlerClientes.Excluir(Convert.ToInt32(txtId.Text));

            CarregarCliente(-1);

            if ((AbertoPorConsulta))
            {
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            StatusLocal = "";
            TratarInterface();

            CarregarCliente(-1);

            if ((AbertoPorConsulta))
            {
                this.Close();
            }
        }

        private void PreencherCampos(Model.Vo.Cliente.Model_Vo_Cliente voCliente)
        {
            txtId.Text = Convert.ToString(voCliente.Id);
            txtNome.Text = voCliente.Nome;
            txtCpf.Text = voCliente.Cpf;
            txtBairro.Text = voCliente.Bairro;
            txtCep.Text = voCliente.CEP;
            txtCidade.Text = voCliente.Cidade;
            txtComplemento.Text = voCliente.Complemento;
            txtEmail.Text = voCliente.Email;
            txtNumero.Text = voCliente.Numero;
            txtRG.Text = voCliente.Rg;
            txtEndereco.Text = voCliente.Rua;
            txtTelefone.Text = voCliente.Telefone;
            txtEstado.Text = voCliente.UF;
            txtNascimento.Text = voCliente.Nascimento.ToShortDateString();
            txtValorMensalidade.Text = Convert.ToString(voCliente.ValorMensalidade);
            chkAtivo.Checked = voCliente.Ativo;
            txtObservacao.Text = voCliente.Observacao;
        }

        private void TratarInterface()
        {
            btnIncluir.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I") && (AbertoPorConsulta == false));
            btnAlterar.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I") && (controlerClientes.getNumRegistros() > 0));
            btnSalvar.Enabled = ((StatusLocal == "A") || (StatusLocal == "I"));
            btnCancelar.Enabled = ((StatusLocal == "A") || (StatusLocal == "I"));
            btnExcluir.Enabled = (!(StatusLocal == "A") && !(StatusLocal == "I") && (controlerClientes.getNumRegistros() > 0));
            
            
             if ((StatusLocal == ""))
            {
                txtId.Enabled = false;
                txtNome.Enabled = false;
                txtCpf.Enabled = false;
                txtBairro.Enabled = false;
                txtCep.Enabled = false;
                txtCidade.Enabled = false;
                txtComplemento.Enabled = false;
                txtEmail.Enabled = false;
                txtNumero.Enabled = false;
                txtRG.Enabled = false;
                txtEndereco.Enabled = false;
                txtTelefone.Enabled = false;
                txtEstado.Enabled = false;
                txtNascimento.Enabled = false;
                txtValorMensalidade.Enabled = false;
                chkAtivo.Enabled = false;
                txtObservacao.Enabled = false;
            }
            else
            {
                txtId.Enabled = false;
                txtNome.Enabled = true;
                txtCpf.Enabled = true;
                txtBairro.Enabled = true;
                txtCep.Enabled = true;
                txtCidade.Enabled = true;
                txtComplemento.Enabled = true;
                txtEmail.Enabled = true;
                txtNumero.Enabled = true;
                txtRG.Enabled = true;
                txtEndereco.Enabled = true;
                txtTelefone.Enabled = true;
                txtEstado.Enabled = true;
                txtNascimento.Enabled = true;
                txtValorMensalidade.Enabled = true;
                chkAtivo.Enabled = true;
                txtObservacao.Enabled = true;
            }            
        }

        private void CarregarCliente(Int32 piNumRegistro)
        {
            try
            {
                clienteLocal = controlerClientes.CarregarCliente(piNumRegistro);

                txtId.Text = Convert.ToString(clienteLocal.Id);
                txtNome.Text = clienteLocal.Nome;
                txtCpf.Text = clienteLocal.Cpf;
                txtBairro.Text = clienteLocal.Bairro;
                txtCep.Text = clienteLocal.CEP;
                txtCidade.Text = clienteLocal.Cidade;
                txtComplemento.Text = clienteLocal.Complemento;
                txtEmail.Text = clienteLocal.Email;
                txtNumero.Text = clienteLocal.Numero;
                txtRG.Text = clienteLocal.Rg;
                txtEndereco.Text = clienteLocal.Rua;
                txtTelefone.Text = clienteLocal.Telefone;
                txtEstado.Text = clienteLocal.UF;
                txtNascimento.Text = Convert.ToString(clienteLocal.Nascimento);
                txtValorMensalidade.Text = Convert.ToString(clienteLocal.ValorMensalidade);
                chkAtivo.Checked = clienteLocal.Ativo;
                txtObservacao.Text = clienteLocal.Observacao;

                TratarInterface();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar cliente:" + ex.Message);
            }
        }

        private void View_Desktop_CadClientes_Load(object sender, EventArgs e)
        {
            clienteLocal = new Model.Vo.Cliente.Model_Vo_Cliente();
            CarregarCliente(-1);

            if ((AbertoPorConsulta) &&
                (ClienteSelecionadoPorConsulta != null))
            {
                clienteLocal = ClienteSelecionadoPorConsulta;
                PreencherCampos(ClienteSelecionadoPorConsulta);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Academia.View.Desktop.View_Desktop_ConClientes obj = new View_Desktop_ConClientes();
            //obj.MdiParent = this;
            obj.ShowDialog();            

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

      
    }
}
