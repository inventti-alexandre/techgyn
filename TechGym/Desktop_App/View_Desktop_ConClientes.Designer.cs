namespace Academia.View.Desktop
{
    partial class View_Desktop_ConClientes
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
            this.lsCliente = new System.Windows.Forms.ListView();
            this.c_nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_telefone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExtrato = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSelCampo
            // 
            this.txtSelCampo.Location = new System.Drawing.Point(56, 13);
            this.txtSelCampo.Name = "txtSelCampo";
            this.txtSelCampo.Size = new System.Drawing.Size(482, 20);
            this.txtSelCampo.TabIndex = 1;
            this.txtSelCampo.TextChanged += new System.EventHandler(this.txtSelCampo_TextChanged);
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
            // lsCliente
            // 
            this.lsCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsCliente.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.c_nome,
            this.c_telefone,
            this.c_id});
            this.lsCliente.FullRowSelect = true;
            this.lsCliente.GridLines = true;
            this.lsCliente.Location = new System.Drawing.Point(15, 47);
            this.lsCliente.MultiSelect = false;
            this.lsCliente.Name = "lsCliente";
            this.lsCliente.Size = new System.Drawing.Size(604, 252);
            this.lsCliente.TabIndex = 3;
            this.lsCliente.UseCompatibleStateImageBehavior = false;
            this.lsCliente.View = System.Windows.Forms.View.Details;
            this.lsCliente.SelectedIndexChanged += new System.EventHandler(this.lsCliente_SelectedIndexChanged);
            this.lsCliente.DoubleClick += new System.EventHandler(this.lsCliente_DoubleClick);
            this.lsCliente.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lsCliente_MouseClick);
            this.lsCliente.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsCliente_MouseDoubleClick);
            // 
            // c_nome
            // 
            this.c_nome.Text = "Nome";
            this.c_nome.Width = 405;
            // 
            // c_telefone
            // 
            this.c_telefone.Text = "Telefone";
            this.c_telefone.Width = 132;
            // 
            // c_id
            // 
            this.c_id.Text = "ID";
            this.c_id.Width = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nome:";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(501, 304);
            this.btnOk.Margin = new System.Windows.Forms.Padding(2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(56, 19);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(562, 304);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 19);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnExtrato
            // 
            this.btnExtrato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExtrato.Location = new System.Drawing.Point(441, 304);
            this.btnExtrato.Margin = new System.Windows.Forms.Padding(2);
            this.btnExtrato.Name = "btnExtrato";
            this.btnExtrato.Size = new System.Drawing.Size(56, 19);
            this.btnExtrato.TabIndex = 7;
            this.btnExtrato.Text = "Extrato";
            this.btnExtrato.UseVisualStyleBackColor = true;
            this.btnExtrato.Click += new System.EventHandler(this.btnExtrato_Click);
            // 
            // View_Desktop_ConClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 336);
            this.Controls.Add(this.btnExtrato);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lsCliente);
            this.Controls.Add(this.btnPesquisa);
            this.Controls.Add(this.txtSelCampo);
            this.Name = "View_Desktop_ConClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Clientes";
            this.Load += new System.EventHandler(this.View_Desktop_ConClientes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSelCampo;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.ListView lsCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader c_nome;
        private System.Windows.Forms.ColumnHeader c_telefone;
        private System.Windows.Forms.ColumnHeader c_id;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExtrato;
    }
}