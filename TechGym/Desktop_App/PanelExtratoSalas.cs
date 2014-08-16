using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Academia.Controller.Salas;
using Academia.Controller.Extratos;

namespace Desktop_App
{
    public partial class PanelExtratoSalas : UserControl
    {

        Control[] old;
        Panel mainPanel;
        MonthCalendar calendar=null;
        List<Academia.Model.Vo.Sala.Model_Vo_Sala> _salas = new List<Academia.Model.Vo.Sala.Model_Vo_Sala>();

        static bool isOpen = false;

        public static bool IsOpen
        {
            get { return isOpen; }
        }

        public PanelExtratoSalas(Panel panel, MonthCalendar calendar)
        {
            InitializeComponent();
            this.mainPanel = panel;
            this.calendar = calendar;
            calendar.DateSelected += calendar_DateSelected;

            old = new Control[panel.Controls.Count];
            panel.Controls.CopyTo(this.old, 0);

            panel.Controls.Clear();
            panel.Controls.Add(this);

            this.Dock = DockStyle.Fill;
            isOpen = true;

            // Carrega lista de salas
            _salas = new Academia.Model.Bo.Salas.Model_Bo_Salas().ListaDeSalas();
            // Carregar dados automaticamente
            btMes.Checked = true;
            this.loadTabs();

        }

        void calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            loadData();
        }

        public void loadTabs()
        {
            TabPage page;
            ListView list;

            // Monta guias e planilhas para apresentar os dados.
            _salas.ForEach(delegate(Academia.Model.Vo.Sala.Model_Vo_Sala s)
            {

                // criar e preencher preencher listview com os valores        
                list = new ListView();
                list.Columns.Add("Data", 100);
                list.Columns.Add("Origem", 250);
                list.Columns.Add("Valor", 150);
                list.Columns.Add("Situação", 75);
                list.Dock = DockStyle.Fill;
                list.GridLines = true;
                list.View = View.Details;

                page = new TabPage(s.ToString()); // "Squash 1");
                tabSalas.TabPages.Add(page);
                page.Controls.Add(list);


            });

            // Carregar dados nas planilhas (listview)
            loadData(); 

        }

        public void close(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.AddRange(this.old);
            calendar.DateSelected -= calendar_DateSelected;
            isOpen = false;
        }

        private void definePeriodo(object sender, EventArgs e)
        {
            // ajusdas botoes para carregar dados
            ToolStripButton bt = (ToolStripButton)sender;
            btDia.Checked = btMes.Checked = btAno.Checked = false;
            bt.Checked = true;
            loadData();

        }

        private void loadData()
        {

            DateTime x = calendar.SelectionStart;
            String dataDeBusca = x.Year + "-"; // o ano sempre vai estar presente na data
            DataTable table;
            DataRow row;
            ListView list;
            ListViewItem item;
            Decimal pago = 0;
            Decimal pendente = 0;
            String[] rowPago = new String[4] { "Total Pago","", "", "" };
            String[] rowPendente = new String[4] { "Total Pendente","", "", "" };

            if (btMes.Checked || btDia.Checked)
            {
                // coloca o mes na data
                if (x.Month > 9) dataDeBusca += x.Month + "-";
                else dataDeBusca += "0" + x.Month + "-";

                if (btDia.Checked)
                {
                    if (x.Day > 9) dataDeBusca += x.Day + " ";
                    else  dataDeBusca += "0" + x.Day + " ";
                }
            }

            for (int i = tabSalas.TabPages.Count; i > 0; )
            {
                pago = 0;
                pendente = 0;
                i--;
                list = (ListView)tabSalas.TabPages[i].Controls[0];
                list.Items.Clear();
                table = Controller_Extratos.getExtratoSala(tabSalas.TabPages[i].Text, dataDeBusca);
                table.BeginLoadData();
                if (table != null) for (int r = table.Rows.Count; r > 0; )
                {
                    r--;
                    row=table.Rows[r];
                    // agenda.datahorareserva, cliente.nome, contasareceber.valorareceber, contasareceber.recebido
                    item = new ListViewItem(row[0].ToString().Substring(1,10));
                    item.SubItems.Add(row[1].ToString());
                    item.SubItems.Add(row[2].ToString());
                    //item.SubItems.Add(row[3].ToString());
                    if ((bool)row[3])
                    {
                        item.SubItems.Add("Pago");
                        pago += (Decimal)row[2];
                    }
                    else
                    {
                        item.SubItems.Add("-");
                        pendente += (Decimal)row[2];
                    }

                    list.Items.Add(item);
                }
                table.EndLoadData();

                list.Items.Add(new ListViewItem());

                rowPago[2] = pago.ToString();
                item = new ListViewItem(rowPago);
                list.Items.Add(item);

                rowPendente[2] = pendente.ToString();
                item = new ListViewItem(rowPendente);
                list.Items.Add(item);

            }

        }

    }
}
