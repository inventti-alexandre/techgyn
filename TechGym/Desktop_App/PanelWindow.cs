using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop_App
{
    public partial class PanelWindow : UserControl
    {

        Control[] old;
        Panel mainPanel;
        static bool isOpen = false;

        public static bool IsOpen
        {
            get { return isOpen; }
        }


        public PanelWindow(Panel panel)
        {
            InitializeComponent();
            this.mainPanel = panel;

            old = new Control[panel.Controls.Count];
            panel.Controls.CopyTo(this.old, 0);

            panel.Controls.Clear();
            panel.Controls.Add(this);

            this.Dock = DockStyle.Fill;
            isOpen = true;
        }

        public void close(object sender, EventArgs e)
        {
            this.mainPanel.Controls.Clear();
            this.mainPanel.Controls.AddRange(this.old);
            isOpen = false;
        }

    }
}
