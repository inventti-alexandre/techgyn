using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Academia.View.Desktop.Principal
{
    public partial class View_Desktop_CadReservas : Form
    {
        DateTime _dataReserva;

        List<Academia.Model.Vo.Sala.Model_Vo_Sala> _salas = new List<Model.Vo.Sala.Model_Vo_Sala>();

        Model.Vo.Cliente.Model_Vo_Cliente _clienteReserva;

        Academia.Controller.Agendas.Controller_Agendas controller;

        public View_Desktop_CadReservas(DateTime data)
        {
            InitializeComponent();

            controller = new Controller.Agendas.Controller_Agendas();

            _dataReserva = data;

            AtualizarControles(true);

            dtpData.Value = _dataReserva;

            InicializarSalas();

            InicializarComboHorarios();
        }

        private void InicializarSalas()
        {
            _salas = new Academia.Model.Bo.Salas.Model_Bo_Salas().ListaDeSalas();

            _salas.ForEach(delegate(Academia.Model.Vo.Sala.Model_Vo_Sala s)
            {
                cbSalas.Items.Add(s);
            });
        }

        private void InicializarComboHorarios()
        {
            string[] horarios = BuscarHorariosDisponiveis(_dataReserva);
            if (horarios == null) return;

            cbHorario.Items.Clear();
            cbHorario.Items.AddRange(horarios);
        }

        private string[] BuscarHorariosDisponiveis(DateTime data)
        {
            string[] horarios = null;

            int[] hor = new int[24];
            for (int i = 0; i < 24; i++) hor[i] = i;

           //List<Model.Vo.Agenda.Model_Vo_Agenda> horariosDoPeriodo = controller.ListaDeAgendasDoPeriodo(new DateTime(data.Year, data.Month, data.Day, 0, 0, 0), new DateTime( data.Year, data.Month, data.Day, 23, 59, 59));                      
            
            cbHorario.Items.Clear();

            

            if (cbSalas.SelectedItem == null) return new string[1]{""};

            Model.Vo.Sala.Model_Vo_Sala sala = cbSalas.SelectedItem as Model.Vo.Sala.Model_Vo_Sala;

            /*
            List<int> horariosLocados = (from h in horariosDoPeriodo
                                         where h.IdSala == sala.Id
                                         select h.DataHoraReserva.Hour).ToList<int>();
            */

            for (int i = 0; i < 24; i++)
            {
                //if (horariosLocados.Contains(i)) continue;

                cbHorario.Items.Add(string.Format("{0}:00", hor[i]));
            }
            //TODO: AQUI FAZ-SE UMA PESQUISA PELOS REGISTROS DE RESERVAS CADASTRADAS PARA A DATA QUE É PASSADA POR PARAMETRO 
            //NO CONSTRUTOR. FAZEMOS ISSO PRA COLOCAR NO COMBO DE HORARIOS SOMENTE OS HORARIOS DISPONIVEIS PARA AQUELA DATA

            return horarios;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bool bSav = true;
            try
            {
                try
                {
                    //TODO: AQUI SALVA AS INFORMAÇÕES DE RESERVA NO BANCO DE DADOS
                    Model.Vo.Agenda.Model_Vo_Agenda agenda = new Model.Vo.Agenda.Model_Vo_Agenda();
                    agenda.DataHoraReserva = new DateTime(_dataReserva.Year, _dataReserva.Month, _dataReserva.Day, int.Parse(cbHorario.Text.Split(new char[] { ':' })[0]), 0, 0);
                    agenda.IdCliente = _clienteReserva.Id;
                    agenda.IdSala = (cbSalas.SelectedItem as Model.Vo.Sala.Model_Vo_Sala).Id;

                    controller.Incluir(agenda);

                    LimparCampos();

                    AtualizarControles(false);
                }
                catch (Exception ex)
                {
                    bSav = false;
                    MessageBox.Show(ex.Message);
                }
            }
            finally
            {
                if ((bSav))
                    this.Close();
            }
        }

        private void AtualizarControles(bool enable)
        {
            tbCliente.Enabled = enable;
            cbHorario.Enabled = enable;
            cbSalas.Enabled = enable;
            btnPesquisaCliente.Enabled = enable;
            btnSalvar.Enabled = enable;
            button1.Enabled = !enable;
            dtpData.Enabled = enable;
        }

        private void LimparCampos()
        {
            cbSalas.Text = string.Empty;
            tbCliente.Text = string.Empty;
            cbHorario.Text = string.Empty;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPesquisaCliente_Click(object sender, EventArgs e)
        {
            //TODO: AQUI FAZ PESQUISA POR CLIENTES CADASTRADOS

            View_Desktop_ConClientes consulta = new View_Desktop_ConClientes();
            consulta.ShowDialog();

            _clienteReserva = consulta.ClienteSelecionado;

            if (_clienteReserva == null) return;

            tbCliente.Text = _clienteReserva.Nome;
        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            this.LimparCampos();
        }

        private void dtpData_ValueChanged(object sender, EventArgs e)
        {
            _dataReserva = dtpData.Value;

            BuscarHorariosDisponiveis(_dataReserva);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AtualizarControles(true);
        }

        private void cbSalas_SelectedIndexChanged(object sender, EventArgs e)
        {
            InicializarComboHorarios();
        }

        private void View_Desktop_CadReservas_Load(object sender, EventArgs e)
        {

        }
    }
}
