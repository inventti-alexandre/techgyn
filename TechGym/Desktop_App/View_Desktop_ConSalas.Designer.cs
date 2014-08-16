namespace Academia.View.Desktop
{
    partial class View_Desktop_ConSalas
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSelCampo = new System.Windows.Forms.TextBox();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.cmbSelCampo = new System.Windows.Forms.ComboBox();
            this.lsSala = new System.Windows.Forms.ListView();
            this.clnNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnTipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // txtSelCampo
            // 
            this.txtSelCampo.Location = new System.Drawing.Point(164, 13);
            this.txtSelCampo.Name = "txtSelCampo";
            this.txtSelCampo.Size = new System.Drawing.Size(374, 20);
            this.txtSelCampo.TabIndex = 1;
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.Location = new System.Drawing.Point(544, 10);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisa.TabIndex = 2;
            this.btnPesquisa.Text = "Pesquisar";
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // cmbSelCampo
            // 
            this.cmbSelCampo.FormattingEnabled = true;
            this.cmbSelCampo.Location = new System.Drawing.Point(12, 12);
            this.cmbSelCampo.Name = "cmbSelCampo";
            this.cmbSelCampo.Size = new System.Drawing.Size(146, 21);
            this.cmbSelCampo.TabIndex = 0;
            // 
            // lsSala
            // 
            this.lsSala.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsSala.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnNome,
            this.clnTipo});
            this.lsSala.Location = new System.Drawing.Point(12, 39);
            this.lsSala.Name = "lsSala";
            this.lsSala.Size = new System.Drawing.Size(607, 252);
            this.lsSala.TabIndex = 3;
            this.lsSala.UseCompatibleStateImageBehavior = false;
            this.lsSala.View = System.Windows.Forms.View.Details;
            this.lsSala.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // clnNome
            // 
            this.clnNome.Text = "Nome";
            this.clnNome.Width = 491;
            // 
            // clnTipo
            // 
            this.clnTipo.Text = "Tipo";
            this.clnTipo.Width = 103;
            // 
            // View_Desktop_ConSalas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 303);
            this.Controls.Add(this.lsSala);
            this.Controls.Add(this.btnPesquisa);
            this.Controls.Add(this.txtSelCampo);
            this.Controls.Add(this.cmbSelCampo);
            this.Name = "View_Desktop_ConSalas";
            this.Text = "Consulta de salas";
            this.Load += new System.EventHandler(this.View_Desktop_ConSalas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSelCampo;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.ComboBox cmbSelCampo;
        private System.Windows.Forms.ListView lsSala;
        private System.Windows.Forms.ColumnHeader clnNome;
        private System.Windows.Forms.ColumnHeader clnTipo;
    }
}