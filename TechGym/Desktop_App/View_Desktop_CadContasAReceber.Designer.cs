namespace Academia.View.Desktop 
{
    partial class View_Desktop_CadContasARecebers
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

        
        private System.Windows.Forms.Label label1;
#region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnAvancar = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.txtDataHoraCriacao = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnPesquisarReservaOrigem = new System.Windows.Forms.Button();
            this.btnPesquisarClienteSolicitante = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdClienteSolicitante = new System.Windows.Forms.TextBox();
            this.lblNomeCliente = new System.Windows.Forms.Label();
            this.lblDescricaoProduto = new System.Windows.Forms.Label();
            this.btnPesquisarProduto = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIdProduto = new System.Windows.Forms.TextBox();
            this.txtValorAReceber = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbOrigem = new System.Windows.Forms.ComboBox();
            this.txtIdReserva = new System.Windows.Forms.TextBox();
            this.lblReserva1 = new System.Windows.Forms.Label();
            this.txtDescrição = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chkRecebido = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número: ";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(98, 52);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(131, 20);
            this.txtId.TabIndex = 8;
            this.txtId.TextChanged += new System.EventHandler(this.txtId_TextChanged);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(179, 12);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(75, 23);
            this.btnVoltar.TabIndex = 1;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnAvancar
            // 
            this.btnAvancar.Location = new System.Drawing.Point(253, 12);
            this.btnAvancar.Name = "btnAvancar";
            this.btnAvancar.Size = new System.Drawing.Size(75, 23);
            this.btnAvancar.TabIndex = 2;
            this.btnAvancar.Text = "Avancar";
            this.btnAvancar.UseVisualStyleBackColor = true;
            this.btnAvancar.Click += new System.EventHandler(this.btnAvancar_Click);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Location = new System.Drawing.Point(327, 12);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(75, 23);
            this.btnIncluir.TabIndex = 3;
            this.btnIncluir.Text = "Incluir";
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(401, 12);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(75, 23);
            this.btnAlterar.TabIndex = 4;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Enabled = false;
            this.btnSalvar.Location = new System.Drawing.Point(475, 12);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 5;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(549, 12);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 6;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(623, 12);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Reserva: ";
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.Location = new System.Drawing.Point(98, 12);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisa.TabIndex = 0;
            this.btnPesquisa.Text = "Pesquisar";
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
            // 
            // txtDataHoraCriacao
            // 
            this.txtDataHoraCriacao.Enabled = false;
            this.txtDataHoraCriacao.Location = new System.Drawing.Point(493, 48);
            this.txtDataHoraCriacao.Name = "txtDataHoraCriacao";
            this.txtDataHoraCriacao.Size = new System.Drawing.Size(131, 20);
            this.txtDataHoraCriacao.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(427, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Data/Hora";
            // 
            // btnPesquisarReservaOrigem
            // 
            this.btnPesquisarReservaOrigem.Location = new System.Drawing.Point(233, 76);
            this.btnPesquisarReservaOrigem.Name = "btnPesquisarReservaOrigem";
            this.btnPesquisarReservaOrigem.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisarReservaOrigem.TabIndex = 11;
            this.btnPesquisarReservaOrigem.Text = "Pesquisar";
            this.btnPesquisarReservaOrigem.UseVisualStyleBackColor = true;
            this.btnPesquisarReservaOrigem.Visible = false;
            this.btnPesquisarReservaOrigem.Click += new System.EventHandler(this.btnPesquisarReservaOrigem_Click);
            // 
            // btnPesquisarClienteSolicitante
            // 
            this.btnPesquisarClienteSolicitante.Location = new System.Drawing.Point(233, 105);
            this.btnPesquisarClienteSolicitante.Name = "btnPesquisarClienteSolicitante";
            this.btnPesquisarClienteSolicitante.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisarClienteSolicitante.TabIndex = 13;
            this.btnPesquisarClienteSolicitante.Text = "Pesquisar";
            this.btnPesquisarClienteSolicitante.UseVisualStyleBackColor = true;
            this.btnPesquisarClienteSolicitante.Click += new System.EventHandler(this.btnPesquisarClienteSolicitante_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Cliente: ";
            // 
            // txtIdClienteSolicitante
            // 
            this.txtIdClienteSolicitante.Enabled = false;
            this.txtIdClienteSolicitante.Location = new System.Drawing.Point(98, 107);
            this.txtIdClienteSolicitante.Name = "txtIdClienteSolicitante";
            this.txtIdClienteSolicitante.Size = new System.Drawing.Size(131, 20);
            this.txtIdClienteSolicitante.TabIndex = 12;
            this.txtIdClienteSolicitante.TextChanged += new System.EventHandler(this.txtIdClienteSolicitante_TextChanged);
            // 
            // lblNomeCliente
            // 
            this.lblNomeCliente.AutoSize = true;
            this.lblNomeCliente.Location = new System.Drawing.Point(314, 111);
            this.lblNomeCliente.Name = "lblNomeCliente";
            this.lblNomeCliente.Size = new System.Drawing.Size(41, 13);
            this.lblNomeCliente.TabIndex = 31;
            this.lblNomeCliente.Text = "Nome: ";
            // 
            // lblDescricaoProduto
            // 
            this.lblDescricaoProduto.AutoSize = true;
            this.lblDescricaoProduto.Location = new System.Drawing.Point(314, 140);
            this.lblDescricaoProduto.Name = "lblDescricaoProduto";
            this.lblDescricaoProduto.Size = new System.Drawing.Size(58, 13);
            this.lblDescricaoProduto.TabIndex = 35;
            this.lblDescricaoProduto.Text = "Descrição:";
            // 
            // btnPesquisarProduto
            // 
            this.btnPesquisarProduto.Location = new System.Drawing.Point(233, 134);
            this.btnPesquisarProduto.Name = "btnPesquisarProduto";
            this.btnPesquisarProduto.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisarProduto.TabIndex = 15;
            this.btnPesquisarProduto.Text = "Pesquisar";
            this.btnPesquisarProduto.UseVisualStyleBackColor = true;
            this.btnPesquisarProduto.Click += new System.EventHandler(this.btnPesquisarProduto_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Produto: ";
            // 
            // txtIdProduto
            // 
            this.txtIdProduto.Enabled = false;
            this.txtIdProduto.Location = new System.Drawing.Point(98, 136);
            this.txtIdProduto.Name = "txtIdProduto";
            this.txtIdProduto.Size = new System.Drawing.Size(131, 20);
            this.txtIdProduto.TabIndex = 14;
            this.txtIdProduto.TextChanged += new System.EventHandler(this.txtIdProduto_TextChanged);
            // 
            // txtValorAReceber
            // 
            this.txtValorAReceber.Enabled = false;
            this.txtValorAReceber.Location = new System.Drawing.Point(98, 163);
            this.txtValorAReceber.Name = "txtValorAReceber";
            this.txtValorAReceber.Size = new System.Drawing.Size(131, 20);
            this.txtValorAReceber.TabIndex = 18;
            this.txtValorAReceber.TextChanged += new System.EventHandler(this.txtValorTotal_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "Valor a receber: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(454, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "Origem:";
            // 
            // cmbOrigem
            // 
            this.cmbOrigem.Enabled = false;
            this.cmbOrigem.FormattingEnabled = true;
            this.cmbOrigem.Location = new System.Drawing.Point(503, 163);
            this.cmbOrigem.Name = "cmbOrigem";
            this.cmbOrigem.Size = new System.Drawing.Size(121, 21);
            this.cmbOrigem.TabIndex = 19;
            // 
            // txtIdReserva
            // 
            this.txtIdReserva.Enabled = false;
            this.txtIdReserva.Location = new System.Drawing.Point(98, 78);
            this.txtIdReserva.Name = "txtIdReserva";
            this.txtIdReserva.Size = new System.Drawing.Size(131, 20);
            this.txtIdReserva.TabIndex = 10;
            this.txtIdReserva.TextChanged += new System.EventHandler(this.txtIdReserva_TextChanged);
            // 
            // lblReserva1
            // 
            this.lblReserva1.AutoSize = true;
            this.lblReserva1.Location = new System.Drawing.Point(314, 81);
            this.lblReserva1.Name = "lblReserva1";
            this.lblReserva1.Size = new System.Drawing.Size(41, 13);
            this.lblReserva1.TabIndex = 46;
            this.lblReserva1.Text = "Nome: ";
            // 
            // txtDescrição
            // 
            this.txtDescrição.Enabled = false;
            this.txtDescrição.Location = new System.Drawing.Point(98, 215);
            this.txtDescrição.Multiline = true;
            this.txtDescrição.Name = "txtDescrição";
            this.txtDescrição.Size = new System.Drawing.Size(526, 66);
            this.txtDescrição.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 215);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 48;
            this.label10.Text = "Descrição: ";
            // 
            // chkRecebido
            // 
            this.chkRecebido.AutoSize = true;
            this.chkRecebido.Location = new System.Drawing.Point(98, 190);
            this.chkRecebido.Name = "chkRecebido";
            this.chkRecebido.Size = new System.Drawing.Size(72, 17);
            this.chkRecebido.TabIndex = 20;
            this.chkRecebido.Text = "Recebido";
            this.chkRecebido.UseVisualStyleBackColor = true;
            // 
            // View_Desktop_CadContasARecebers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 318);
            this.Controls.Add(this.chkRecebido);
            this.Controls.Add(this.txtDescrição);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblReserva1);
            this.Controls.Add(this.txtIdReserva);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbOrigem);
            this.Controls.Add(this.txtValorAReceber);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblDescricaoProduto);
            this.Controls.Add(this.btnPesquisarProduto);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtIdProduto);
            this.Controls.Add(this.lblNomeCliente);
            this.Controls.Add(this.btnPesquisarClienteSolicitante);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIdClienteSolicitante);
            this.Controls.Add(this.btnPesquisarReservaOrigem);
            this.Controls.Add(this.txtDataHoraCriacao);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnPesquisa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.btnAvancar);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label1);
            this.Name = "View_Desktop_CadContasARecebers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contas a Receber";
            this.Load += new System.EventHandler(this.View_Desktop_CadContasARecebers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnAvancar;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtIdReservaOrigem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.TextBox txtDataHoraCriacao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnPesquisarReservaOrigem;
        private System.Windows.Forms.Button btnPesquisarClienteSolicitante;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdClienteSolicitante;
        private System.Windows.Forms.Label lblNomeCliente;
        private System.Windows.Forms.Label lblDescricaoProduto;
        private System.Windows.Forms.Button btnPesquisarProduto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtIdProduto;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.TextBox txtValorUnitario;
        private System.Windows.Forms.TextBox txtValorAReceber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblReserva;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbOrigem;
        private System.Windows.Forms.TextBox txtIdReserva;
        private System.Windows.Forms.Label lblReserva1;
        private System.Windows.Forms.TextBox txtDescrição;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkRecebido;
    }
}