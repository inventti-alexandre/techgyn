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
    public partial class GerarMensalidades : Form
    {
        public GerarMensalidades()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    DateTime dtVencimento = DateTime.MinValue;
                    DateTime.TryParse(mskDataDeVencimento.Text, out dtVencimento);
                    if ((dtVencimento == null) ||
                        (dtVencimento == DateTime.MinValue))
                        throw new Exception("Data informada inválida.");
                    else
                    {

                        Controller.Clientes.Controller_Clientes contClientes = new Controller.Clientes.Controller_Clientes();
                        Controller.ContasARecebers.Controller_ContasARecebers contContReceb = new Controller.ContasARecebers.Controller_ContasARecebers();
                        Model.Vo.ContasAReceber.Model_Vo_ContasAReceber modelContaReceb = new Model.Vo.ContasAReceber.Model_Vo_ContasAReceber();
                        List<Model.Vo.Cliente.Model_Vo_Cliente> listaClientes = contClientes.ListaDeClientes();

                        if ((listaClientes != null) &&
                            (listaClientes.Count > 0))
                        {
                            for (int i = 0; i < listaClientes.Count; i++)
                            {
                                if ((listaClientes[i].ValorMensalidade > 0.0f))
                                {
                                    modelContaReceb = new Model.Vo.ContasAReceber.Model_Vo_ContasAReceber();
                                    modelContaReceb.DataHoraCriacao = dtVencimento;
                                    modelContaReceb.Descricao = "Controle de mensalidades";
                                    modelContaReceb.IdCliente = listaClientes[i].Id;
                                    modelContaReceb.Origem = Model.Vo.eOrigemContasAReceber.Model_Vo_eOrigemContasAReceber.Mensalidade;
                                    modelContaReceb.Recebido = false;
                                    modelContaReceb.ValorAReceber = listaClientes[i].ValorMensalidade;

                                    contContReceb.Incluir(modelContaReceb);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
            finally
            {
                MessageBox.Show("Concluído!");
            }
        }

        private void GerarMensalidades_Load(object sender, EventArgs e)
        {
            mskDataDeVencimento.Text = Convert.ToString(DateTime.Now.Date);

        }
    }
}
