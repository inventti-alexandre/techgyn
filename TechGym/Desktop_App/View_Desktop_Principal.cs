using System.Collections.Generic;
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
    public partial class View_Desktop_Principal : Form
    {
        private DateTime _dataExibida;

        private List<Model.Vo.Sala.Model_Vo_Sala> _salas;
        private List<Model.Vo.Agenda.Model_Vo_Agenda> _reservas;

        private Model.Vo.Sala.Model_Vo_Sala _sauna;
              
        private Academia.Controller.Agendas.Controller_Agendas controller;
        private Academia.Controller.Clientes.Controller_Clientes controllerCliente;
        private Academia.Controller.Salas.Controller_Salas controllerSalas;
        private Academia.Controller.MovimentacaoEstoques.Controller_MovimentacaoEstoques controllerEstoque;
        
        private Model.Vo.Cliente.Model_Vo_Cliente clienteSelecionado;
        private List<Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque> movimentacao;
        
        private ReservasDoHorario gbItemAgenda = new ReservasDoHorario();
        private int giAgendaSelec = 0;
        private int giClienteSelecionado = 0;

        public View_Desktop_Principal()
        {
            InitializeComponent();

            controller = new Academia.Controller.Agendas.Controller_Agendas();
            controllerCliente = new Controller.Clientes.Controller_Clientes();
            controllerEstoque = new Controller.MovimentacaoEstoques.Controller_MovimentacaoEstoques();
            controllerSalas = new Controller.Salas.Controller_Salas();

            _dataExibida = DateTime.Today;
            
            InicializarDados();
            InicializarForm();
            pesquisarAniversarios();



            this.Font = Desktop_App.Properties.Settings.Default.Fonte;
        }

        private void InicializarDados()
        {
            CarregarSalas();
            CarregarReservas();

            InicializarListViewReservas();
            InicializarSauna();
        }        

        private void CarregarReservas()
        {
            _reservas = controller.ListaDeAgendasDoPeriodo(new DateTime(_dataExibida.Year, _dataExibida.Month, _dataExibida.Day, 0, 0, 0),
                                                            new DateTime(_dataExibida.Year, _dataExibida.Month, _dataExibida.Day, 23, 0, 0));

            
        }

        private void CarregarSalas()
        {
            _salas = new Model.Bo.Salas.Model_Bo_Salas().ListaDeSalas();

            for (int i = _salas.Count - 1; i >= 0; i--)
                if (_salas[i].Tipo == Model.Vo.eTipoSala.Model_Vo_eTipoSala.Sauna) _salas.RemoveAt(i);

            _sauna = controllerSalas.BuscarSauna();
        }

        private void InicializarSauna()
        {
            if (_sauna == null) return;

            lvSaunas.SuspendLayout();

            lvSaunas.Items.Clear();

            List<ReservasDoHorario> reservasDoHorario = new List<ReservasDoHorario>();

            foreach (Model.Vo.Agenda.Model_Vo_Agenda reserva in _reservas)
            {
                Model.Vo.Sala.Model_Vo_Sala sala = controllerSalas.GetSala(reserva.IdSala);

                if (sala.Tipo != Model.Vo.eTipoSala.Model_Vo_eTipoSala.Sauna) continue;

                Model.Vo.Cliente.Model_Vo_Cliente cliente = controllerCliente.GetCliente(reserva.IdCliente);

                ListViewItem itemSauna = new ListViewItem(cliente.Nome);
                itemSauna.Tag = reserva;

                ReservasDoHorario resevTemp = ReservasDoHorario.GetReserva(reservasDoHorario, reserva.DataHoraReserva);
                resevTemp.Horario = reserva.DataHoraReserva;
                if ((resevTemp.listReservas == null))
                    resevTemp.listReservas = new List<Model.Vo.Agenda.Model_Vo_Agenda>();
                resevTemp.listReservas.Add(reserva);
                reservasDoHorario.Add(resevTemp); //Lista

               itemSauna.SubItems[0].Tag = ReservasDoHorario.GetReserva(reservasDoHorario, reserva.DataHoraReserva);

                lvSaunas.Items.Add(itemSauna);
            }

            lvSaunas.ResumeLayout();
        }

        private void InicializarForm()
        {
            _dataExibida = DateTime.Today;

            SetarDataExibida();

            lblAniversariantes.Text = string.Format("Aniversariantes de {0}:", MesDoAno(DateTime.Today.Month));

        } 

        private string MesDoAno(int i)
        {
            string mes = "";

            int m = i - 1;

            switch (m)
            {
                case 0: mes = "Janeiro"; break;
                case 1: mes = "Fevereiro"; break;
                case 2: mes = "Março"; break;
                case 3: mes = "Abril"; break;
                case 4: mes = "Maio"; break;
                case 5: mes = "Junho"; break;
                case 6: mes = "Julho"; break;
                case 7: mes = "Agosto"; break;
                case 8: mes = "Setembro"; break;
                case 9: mes = "Outubro"; break;
                case 10: mes = "Novembro"; break;
                case 11: mes = "Dezembro"; break;
                default:
                    break;
            }

            return mes;
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void salasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Academia.View.Desktop.View_Desktop_CadSalas obj = new Academia.View.Desktop.View_Desktop_CadSalas();
            //obj.MdiParent = this;
            obj.ShowDialog();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Academia.View.Desktop.View_Desktop_CadClientes obj = new Academia.View.Desktop.View_Desktop_CadClientes();
            //obj.MdiParent = this;
            obj.ShowDialog();
        }

        private void btnDiaProximo_Click(object sender, EventArgs e)
        {
            _dataExibida = _dataExibida.AddDays(1);


            SetarDataExibida();
        }

        private void btnDiaAnterior_Click(object sender, EventArgs e)
        {
            _dataExibida = _dataExibida.Subtract(new TimeSpan(1, 0, 0, 0));

            SetarDataExibida();
        }

        private void SetarDataExibida()
        {
            mcCalendario.SetDate(_dataExibida);

            lblDiaMostrado.Text = _dataExibida.ToShortDateString();

            InicializarDados();
        }

        private void mcCalendario_DateSelected(object sender, DateRangeEventArgs e)
        {
            _dataExibida = mcCalendario.SelectionStart;

            lblDiaMostrado.Text = _dataExibida.ToShortDateString();
            InicializarDados();
        }

        private void CarregarItensMovimentacaoSelecionada(int piAgenda)
        {

            if ((piAgenda > 0))
                movimentacao = controllerEstoque.MovimentacaoEstoqueAgenda(piAgenda);

            lvProdutosConsumo.SuspendLayout();

            lvProdutosConsumo.Items.Clear();

            if ((movimentacao != null) &&
                (movimentacao.Count > 0))
            {
                Academia.Controller.Produtos.Controller_Produtos controllerProdutos = new Controller.Produtos.Controller_Produtos();


                foreach (Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque movimentacaoEstoque in movimentacao)
                {
                    Model.Vo.Produto.Model_Vo_Produto produto = controllerProdutos.GetProduto(movimentacaoEstoque.IdProduto);

                    ListViewItem itemMovimentacao = new ListViewItem(produto.Descricao);
                    itemMovimentacao.SubItems.Add(new ListViewItem.ListViewSubItem(itemMovimentacao, movimentacaoEstoque.ValorUnitario.ToString()));
                    itemMovimentacao.SubItems.Add(new ListViewItem.ListViewSubItem(itemMovimentacao, movimentacaoEstoque.Quantidade.ToString()));
                    itemMovimentacao.SubItems.Add(new ListViewItem.ListViewSubItem(itemMovimentacao, movimentacaoEstoque.DataHora.ToShortDateString()));

                    lvProdutosConsumo.Items.Add(itemMovimentacao);
                }
            }
            lvProdutosConsumo.ResumeLayout();
                
        }

        private void lvReservas_ItemActivate(object sender, EventArgs e)
        {

        }

        private void lvReservas_MouseDown(object sender, MouseEventArgs e)
        {


        }

        private void lvReservas_ColumnClick(object sender, ColumnClickEventArgs e)
        {
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Academia.View.Desktop.View_Desktop_CadProdutos obj = new Academia.View.Desktop.View_Desktop_CadProdutos();
            //obj.MdiParent = this;
            obj.ShowDialog();
        }

        private void btnAddCliente_Click(object sender, EventArgs e)
        {
            Academia.View.Desktop.View_Desktop_CadClientes obj = new Academia.View.Desktop.View_Desktop_CadClientes();
            //obj.MdiParent = this;
            obj.ShowDialog();
        }

        private void btnAddReserva_Click(object sender, EventArgs e)
        {
            new View_Desktop_CadReservas(_dataExibida).ShowDialog();

            InicializarDados();
        }

        private void contasAReceberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Academia.View.Desktop.View_Desktop_CadContasARecebers obj = new Academia.View.Desktop.View_Desktop_CadContasARecebers();
            //obj.MdiParent = this;
            obj.ShowDialog();
        }

        private void estoquesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Academia.View.Desktop.View_Desktop_CadMovimentacaoEstoques obj = new Academia.View.Desktop.View_Desktop_CadMovimentacaoEstoques();
            //obj.MdiParent = this;
            obj.ShowDialog();
        }

        private void livroCaixaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Academia.View.Desktop.View_Desktop_CadLivroCaixas obj = new Academia.View.Desktop.View_Desktop_CadLivroCaixas();
            //obj.MdiParent = this;
            obj.ShowDialog();
        }

        private void salasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if ( ! Desktop_App.Panel_Relatorio.IsOpen)
                new Desktop_App.Panel_Relatorio(pnlCentro);
        }

        private void extratoDeSalasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Desktop_App.PanelExtratoSalas.IsOpen)
                new Desktop_App.PanelExtratoSalas(pnlCentro, mcCalendario);
        }

        private void btnConsultaCliente_Click(object sender, EventArgs e)
        {
            View.Desktop.View_Desktop_ConClientes concliente = new View.Desktop.View_Desktop_ConClientes();
            concliente.AbertoParaConsCadastro = true;
            concliente.ShowDialog();
        }

        private void mcCalendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            _dataExibida = mcCalendario.SelectionStart;

            lblDiaMostrado.Text = _dataExibida.ToShortDateString();

            InicializarDados();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
                  
           
        }

        private void pesquisarAniversarios()
        {
            Controller.Clientes.Controller_Clientes contClientes = new Controller.Clientes.Controller_Clientes();
            List<Model.Vo.Cliente.Model_Vo_Cliente> listaClientes = contClientes.ListaDeClientes();

            listView2.Items.Clear();

            if (listaClientes != null) {

                for (int i = 0; i < listaClientes.Count; i++)
                {
                    if (DateTime.Today.Month == listaClientes[i].Nascimento.Month)
                    {
                        ListViewItem clienteItem = new ListViewItem(listaClientes[i].Nome);
                        clienteItem.SubItems.Add(new ListViewItem.ListViewSubItem(clienteItem, (listaClientes[i].Nascimento.Day.ToString() + "/" + listaClientes[i].Nascimento.Month.ToString() + "/" + listaClientes[i].Nascimento.Year.ToString())));
                        clienteItem.Tag = listaClientes[i];

                        listView2.Items.Add(clienteItem);
                    }
                }
            }
        }

        private void btnIncProduto_Click(object sender, EventArgs e)
        {            
            if ((gbItemAgenda != null) && (gbItemAgenda.listReservas.Count > 0))
            {
                View_Desktop_CadMovimentacaoEstoques cadMov = new View_Desktop_CadMovimentacaoEstoques();

                Model.Vo.Agenda.Model_Vo_Agenda agenda = gbItemAgenda.listReservas.FirstOrDefault(x => x.IdCliente == giClienteSelecionado);

                giAgendaSelec = 0;
                if ((agenda != null))
                {
                    giAgendaSelec = agenda.Id;
                    cadMov.SetAgenda(agenda);
                    cadMov.ShowDialog();
                }

                CarregarItensMovimentacaoSelecionada(giAgendaSelec);
            }
        }

        private void lvReservas_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void lblMovimentacao_Click(object sender, EventArgs e)
        {

        }

        private void btnFecharConta_Click(object sender, EventArgs e)
        {
            if ((gbItemAgenda != null) && (gbItemAgenda.listReservas.Count > 0))
            {
                View_Desktop_CadContasARecebers cadCtaReceb = new View_Desktop_CadContasARecebers();

                Model.Vo.Agenda.Model_Vo_Agenda agenda = gbItemAgenda.listReservas.FirstOrDefault(x => x.IdCliente == giClienteSelecionado);

                giAgendaSelec = 0;
                if ((agenda != null))
                {
                    giAgendaSelec = agenda.Id;
                    cadCtaReceb.SetAgenda(agenda);
                    cadCtaReceb.ShowDialog();
                }

                CarregarItensMovimentacaoSelecionada(giAgendaSelec);
            }
        }

        private void livroCaixaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Academia.View.Desktop.View_Desktop_ExtratoLivroCaixa1 obj = new Academia.View.Desktop.View_Desktop_ExtratoLivroCaixa1();
            //obj.MdiParent = this;
            obj.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void SelecaoAgendaReservasSauna(MouseEventArgs e, ListView listView)
        {           
            cmbCliente.Items.Clear();
            giClienteSelecionado = 0;
            cmbCliente.Items.Add("Nenhuma reserva selecionada.");

            btnIncProduto.Enabled = false;
            btnFecharConta.Enabled = false;
            movimentacao = new List<Model.Vo.MovimentacaoEstoque.Model_Vo_MovimentacaoEstoque>();

            ListViewHitTestInfo ar = listView.HitTest(e.Location);
            if (ar.SubItem == null)
            {
                new View_Desktop_CadReservas(_dataExibida).ShowDialog();

                InicializarDados();
            }
            else
            {
                gbItemAgenda = ar.SubItem.Tag as ReservasDoHorario;

                if ((gbItemAgenda != null) &&
                    (gbItemAgenda.listReservas != null) &&
                    (gbItemAgenda.listReservas.Count > 0))
                {
                    cmbCliente.Items.Clear();                    
                    for (int i = 0; i < gbItemAgenda.listReservas.Count; i++)
                    {

                        string sNome = controllerCliente.PesquisarCliente(gbItemAgenda.listReservas[i].IdCliente).Nome;

                        if ((ar.SubItem.Text.ToLower().Contains(";")))
                        {
                            if (i == 0)
                                giClienteSelecionado = gbItemAgenda.listReservas[i].IdCliente;
                        }
                        else if ((ar.SubItem.Text.ToLower().Contains(sNome.ToLower())))
                            giClienteSelecionado = gbItemAgenda.listReservas[i].IdCliente;

                        
                        if ((sNome == null) ||
                            (sNome.Trim() == String.Empty))
                            cmbCliente.Items.Add("Cliente sem nome - Nº: " + Convert.ToString(gbItemAgenda.listReservas[i].IdCliente));
                        else
                            cmbCliente.Items.Add(sNome + " - Nº: " + Convert.ToString(gbItemAgenda.listReservas[i].IdCliente));
                    }


                    Model.Vo.Agenda.Model_Vo_Agenda agenda = gbItemAgenda.listReservas.FirstOrDefault(x => x.IdCliente == giClienteSelecionado);

                    giAgendaSelec = 0;
                    if (agenda != null)
                    {
                        giAgendaSelec = agenda.Id;
                        clienteSelecionado = controllerCliente.PesquisarCliente(agenda.IdCliente);
                        cmbCliente.Text = clienteSelecionado.Nome;

                        btnIncProduto.Enabled = true;
                        btnFecharConta.Enabled = true;
                    }
                }
                else
                {
                    new View_Desktop_CadReservas(_dataExibida).ShowDialog();

                    InicializarDados();
                }
            }

            CarregarItensMovimentacaoSelecionada(giAgendaSelec);
        }

        private void lvReservas_MouseUp(object sender, MouseEventArgs e)
        {
            //object o = lvReservas.GetChildAtPoint(e.Location);
            //ListViewItem i = lvReservas.GetItemAt(e.X, e.Y);

            SelecaoAgendaReservasSauna(e, lvReservas);
        }

        

        private void InicializarListViewReservas()
        {
            lvReservas.SuspendLayout();

            lvReservas.Columns.Clear();

            lvReservas.Columns.Add("");

            _salas.ForEach(s => lvReservas.Columns.Add(s.Nome));

            for (int i = 0; i < lvReservas.Columns.Count; i++)
            {
                if ((i > 0))
                {
                    lvReservas.Columns[i].Width = 200;
                }
            }


            foreach (ListViewItem horaItem in lvReservas.Items)
            {
                ListViewItem.ListViewSubItem subItemHora = horaItem.SubItems[0];
                horaItem.SubItems.Clear();

                horaItem.Text = subItemHora.Text;


                for (int i = 0; i < _salas.Count; i++)
                {
                    horaItem.SubItems.Add(new ListViewItem.ListViewSubItem(horaItem, " "));
                }
            }

            if (_reservas == null) return;

            List<IGrouping<int, Model.Vo.Agenda.Model_Vo_Agenda>> reservasPorHorario = _reservas.GroupBy(a => a.DataHoraReserva.Hour).ToList<IGrouping<int, Model.Vo.Agenda.Model_Vo_Agenda>>();
            List<ReservasDoHorario> reservasDoHorario = new List<ReservasDoHorario>();


            foreach (Model.Vo.Agenda.Model_Vo_Agenda reserva in _reservas.OrderBy(x => x.Id).ThenBy(x => x.IdCliente))
            {
                if (controllerSalas.GetSala(reserva.IdSala).Tipo == Model.Vo.eTipoSala.Model_Vo_eTipoSala.Sauna) continue;

                ListViewItem itemReserva = lvReservas.Items[reserva.DataHoraReserva.Hour];

                int indexSala = -1;
                for (int i = 0; i < _salas.Count; i++)
                {
                    if (_salas[i].Id == reserva.IdSala)
                    {
                        indexSala = i;
                        break;
                    }
                }

                if (indexSala == -1) continue;

                Model.Vo.Cliente.Model_Vo_Cliente cliente = controllerCliente.PesquisarCliente(reserva.IdCliente);
                if (cliente == null) continue;

                if ((itemReserva.SubItems[indexSala + 1].Text.Trim() == String.Empty) ||
                    (itemReserva.SubItems[indexSala + 1].Text == null))
                    itemReserva.SubItems[indexSala + 1].Text = cliente.Nome;
                else
                    itemReserva.SubItems[indexSala + 1].Text = itemReserva.SubItems[indexSala + 1].Text + ";" + cliente.Nome;

                ReservasDoHorario resevTemp = ReservasDoHorario.GetReserva(reservasDoHorario, reserva.DataHoraReserva);
                resevTemp.Horario = reserva.DataHoraReserva;
                if ((resevTemp.listReservas == null))
                    resevTemp.listReservas = new List<Model.Vo.Agenda.Model_Vo_Agenda>();
                resevTemp.listReservas.Add(reserva);
                reservasDoHorario.Add(resevTemp); //Lista

                itemReserva.SubItems[indexSala + 1].Tag = ReservasDoHorario.GetReserva(reservasDoHorario, reserva.DataHoraReserva);
            }


            lvReservas.ResumeLayout();
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            giClienteSelecionado = 0;
            var sTexto = cmbCliente.Text.Split('º');
            if ((sTexto != null) && (sTexto.Length > 1))
            {
                string sIdCliente = sTexto[1];
                sIdCliente = sIdCliente.Replace(":", "");
                sIdCliente = sIdCliente.Replace(" ", "");

                int iTemp = 0;
                int.TryParse(sIdCliente, out iTemp);

                if ((iTemp > 0))
                {
                    giClienteSelecionado = iTemp;

                    Model.Vo.Agenda.Model_Vo_Agenda agenda = gbItemAgenda.listReservas.FirstOrDefault(x => x.IdCliente == giClienteSelecionado);

                    giAgendaSelec = 0;
                    if ((agenda != null))
                    {
                        giAgendaSelec = agenda.Id;
                        CarregarItensMovimentacaoSelecionada(giAgendaSelec);
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lvSaunas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvSaunas_MouseUp(object sender, MouseEventArgs e)
        {
            SelecaoAgendaReservasSauna(e, lvSaunas);
        }

        private void gerarMensalidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerarMensalidades gerarForm = new GerarMensalidades();
            gerarForm.ShowDialog();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    public class ReservasDoHorario
    {
        public DateTime Horario { get; set; }
        public List<Model.Vo.Agenda.Model_Vo_Agenda> listReservas { get; set; }

        public static ReservasDoHorario GetReserva(List<ReservasDoHorario> pLista, DateTime pHorario)
        {
            ReservasDoHorario retorno = new ReservasDoHorario();

            if ((pLista != null) &&
                (pLista.Count > 0))
            {
                for (int i = 0; i < pLista.Count; i++)
                {
                    if ((pLista[i].Horario == pHorario))
                    {
                        retorno = pLista[i];
                        break;
                    }
                }
            }

            return retorno;
        }
    }
}
