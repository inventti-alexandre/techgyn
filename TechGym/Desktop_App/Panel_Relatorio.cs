using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Academia.View.Desktop.Principal;

namespace Desktop_App
{
    public partial class Panel_Relatorio : UserControl
    {
        Control[] old;
        Panel mainPanel;
        static bool isOpen = false;

        public static bool IsOpen
        {
            get { return Panel_Relatorio.isOpen; }
        }

        public Panel_Relatorio(Panel panel)
        {
            InitializeComponent();
            this.mainPanel = panel;

            old = new Control[panel.Controls.Count];
            panel.Controls.CopyTo(this.old, 0);

            panel.Controls.Clear();
            panel.Controls.Add(this);

            this.Dock = DockStyle.Fill;
            Panel_Relatorio.isOpen = true;

            // Carregar dados automaticamente
            btMes.Checked = true;
            loadData();
        }

        public void close(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.AddRange(this.old);
            Panel_Relatorio.isOpen = false;
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

            if (btAno.Checked)
            {
            }
            else if (btMes.Checked)
            {
            }
            else if (btAno.Checked)
            {
            }


        }
    }
}
