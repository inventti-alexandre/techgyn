namespace Desktop_App
{
    partial class PanelExtratoSalas
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelExtratoSalas));
            this.tabSalas = new System.Windows.Forms.TabControl();
            this.btClose = new System.Windows.Forms.ToolStripButton();
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.btDia = new System.Windows.Forms.ToolStripButton();
            this.btMes = new System.Windows.Forms.ToolStripButton();
            this.btAno = new System.Windows.Forms.ToolStripButton();
            this.toolBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSalas
            // 
            this.tabSalas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSalas.Location = new System.Drawing.Point(0, 25);
            this.tabSalas.Name = "tabSalas";
            this.tabSalas.SelectedIndex = 0;
            this.tabSalas.Size = new System.Drawing.Size(530, 325);
            this.tabSalas.TabIndex = 5;
            // 
            // btClose
            // 
            this.btClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btClose.Image = global::Desktop_App.Properties.Resources.Xion;
            this.btClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(23, 22);
            this.btClose.Text = "Fechar";
            this.btClose.Click += new System.EventHandler(this.close);
            // 
            // toolBar
            // 
            this.toolBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btClose,
            this.btDia,
            this.btMes,
            this.btAno});
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(530, 25);
            this.toolBar.TabIndex = 4;
            this.toolBar.Text = "toolStrip1";
            // 
            // btDia
            // 
            this.btDia.CheckOnClick = true;
            this.btDia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btDia.Image = ((System.Drawing.Image)(resources.GetObject("btDia.Image")));
            this.btDia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btDia.Name = "btDia";
            this.btDia.Size = new System.Drawing.Size(28, 22);
            this.btDia.Text = "Dia";
            this.btDia.Click += new System.EventHandler(this.definePeriodo);
            // 
            // btMes
            // 
            this.btMes.CheckOnClick = true;
            this.btMes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btMes.Image = ((System.Drawing.Image)(resources.GetObject("btMes.Image")));
            this.btMes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btMes.Name = "btMes";
            this.btMes.Size = new System.Drawing.Size(33, 22);
            this.btMes.Text = "Mês";
            this.btMes.Click += new System.EventHandler(this.definePeriodo);
            // 
            // btAno
            // 
            this.btAno.CheckOnClick = true;
            this.btAno.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btAno.Image = ((System.Drawing.Image)(resources.GetObject("btAno.Image")));
            this.btAno.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btAno.Name = "btAno";
            this.btAno.Size = new System.Drawing.Size(33, 22);
            this.btAno.Text = "Ano";
            this.btAno.Click += new System.EventHandler(this.definePeriodo);
            // 
            // PanelExtratoSalas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabSalas);
            this.Controls.Add(this.toolBar);
            this.Name = "PanelExtratoSalas";
            this.Size = new System.Drawing.Size(530, 350);
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabSalas;
        private System.Windows.Forms.ToolStripButton btClose;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripButton btDia;
        private System.Windows.Forms.ToolStripButton btMes;
        private System.Windows.Forms.ToolStripButton btAno;
    }
}
