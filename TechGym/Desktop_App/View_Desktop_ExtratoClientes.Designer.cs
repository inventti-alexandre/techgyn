namespace Academia.View.Desktop
{
    partial class View_Desktop_ExtratoClientes
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
            this.Nome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lsMovimentacaoEstoques = new System.Windows.Forms.ListView();
            this.cldData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnTipoMovimento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnProduto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnQuantidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnValorUnitario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnValorTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // Nome
            // 
            this.Nome.AutoSize = true;
            this.Nome.Location = new System.Drawing.Point(13, 13);
            this.Nome.Name = "Nome";
            this.Nome.Size = new System.Drawing.Size(35, 13);
            this.Nome.TabIndex = 1;
            this.Nome.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Enabled = false;
            this.txtNome.Location = new System.Drawing.Point(54, 8);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(401, 20);
            this.txtNome.TabIndex = 2;
            this.txtNome.TextChanged += new System.EventHandler(this.txtNome_TextChanged);
            // 
            // lsMovimentacaoEstoques
            // 
            this.lsMovimentacaoEstoques.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsMovimentacaoEstoques.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cldData,
            this.clnTipoMovimento,
            this.clnProduto,
            this.clnQuantidade,
            this.clnValorUnitario,
            this.clnValorTotal});
            this.lsMovimentacaoEstoques.Location = new System.Drawing.Point(12, 50);
            this.lsMovimentacaoEstoques.Name = "lsMovimentacaoEstoques";
            this.lsMovimentacaoEstoques.Size = new System.Drawing.Size(545, 252);
            this.lsMovimentacaoEstoques.TabIndex = 4;
            this.lsMovimentacaoEstoques.UseCompatibleStateImageBehavior = false;
            this.lsMovimentacaoEstoques.View = System.Windows.Forms.View.Details;
            // 
            // cldData
            // 
            this.cldData.Text = "Data";
            this.cldData.Width = 88;
            // 
            // clnTipoMovimento
            // 
            this.clnTipoMovimento.Text = "Tipo";
            this.clnTipoMovimento.Width = 92;
            // 
            // clnProduto
            // 
            this.clnProduto.Text = "Produto";
            this.clnProduto.Width = 94;
            // 
            // clnQuantidade
            // 
            this.clnQuantidade.Text = "Quantidade";
            this.clnQuantidade.Width = 87;
            // 
            // clnValorUnitario
            // 
            this.clnValorUnitario.Text = "Valor unitário";
            this.clnValorUnitario.Width = 89;
            // 
            // clnValorTotal
            // 
            this.clnValorTotal.Text = "Valor total";
            this.clnValorTotal.Width = 99;
            // 
            // View_Desktop_ExtratoClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 314);
            this.Controls.Add(this.lsMovimentacaoEstoques);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.Nome);
            this.Name = "View_Desktop_ExtratoClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimentações do Cliente";
            this.Load += new System.EventHandler(this.View_Desktop_ExtratoClientes_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Nome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.ListView lsMovimentacaoEstoques;
        private System.Windows.Forms.ColumnHeader cldData;
        private System.Windows.Forms.ColumnHeader clnTipoMovimento;
        private System.Windows.Forms.ColumnHeader clnProduto;
        private System.Windows.Forms.ColumnHeader clnQuantidade;
        private System.Windows.Forms.ColumnHeader clnValorUnitario;
        private System.Windows.Forms.ColumnHeader clnValorTotal;
    }
}