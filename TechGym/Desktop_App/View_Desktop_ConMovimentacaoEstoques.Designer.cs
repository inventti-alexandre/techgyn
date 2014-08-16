namespace Academia.View.Desktop
{
    partial class View_Desktop_ConMovimentacaoEstoques
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
            this.btnPesquisa = new System.Windows.Forms.Button();
            this.lsMovimentacaoEstoques = new System.Windows.Forms.ListView();
            this.cldData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnTipoMovimento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnProduto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnQuantidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnValorUnitario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnValorTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mskDataInicial = new System.Windows.Forms.MaskedTextBox();
            this.mskDataFinal = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // btnPesquisa
            // 
            this.btnPesquisa.Location = new System.Drawing.Point(630, 10);
            this.btnPesquisa.Name = "btnPesquisa";
            this.btnPesquisa.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisa.TabIndex = 2;
            this.btnPesquisa.Text = "Pesquisar";
            this.btnPesquisa.UseVisualStyleBackColor = true;
            this.btnPesquisa.Click += new System.EventHandler(this.btnPesquisa_Click);
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
            this.lsMovimentacaoEstoques.Location = new System.Drawing.Point(15, 39);
            this.lsMovimentacaoEstoques.Name = "lsMovimentacaoEstoques";
            this.lsMovimentacaoEstoques.Size = new System.Drawing.Size(702, 252);
            this.lsMovimentacaoEstoques.TabIndex = 3;
            this.lsMovimentacaoEstoques.UseCompatibleStateImageBehavior = false;
            this.lsMovimentacaoEstoques.View = System.Windows.Forms.View.Details;
            this.lsMovimentacaoEstoques.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.lsMovimentacaoEstoques.DoubleClick += new System.EventHandler(this.lsMovimentacaoEstoques_DoubleClick);
            this.lsMovimentacaoEstoques.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsMovimentacaoEstoques_MouseDoubleClick);
            // 
            // cldData
            // 
            this.cldData.Text = "Data";
            this.cldData.Width = 88;
            // 
            // clnTipoMovimento
            // 
            this.clnTipoMovimento.Text = "Tipo";
            this.clnTipoMovimento.Width = 101;
            // 
            // clnProduto
            // 
            this.clnProduto.Text = "Produto";
            this.clnProduto.Width = 219;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Data inicial:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(255, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Data inicial:";
            // 
            // mskDataInicial
            // 
            this.mskDataInicial.Location = new System.Drawing.Point(80, 12);
            this.mskDataInicial.Mask = "00/00/0000";
            this.mskDataInicial.Name = "mskDataInicial";
            this.mskDataInicial.Size = new System.Drawing.Size(96, 20);
            this.mskDataInicial.TabIndex = 0;
            this.mskDataInicial.ValidatingType = typeof(System.DateTime);
            // 
            // mskDataFinal
            // 
            this.mskDataFinal.Location = new System.Drawing.Point(323, 12);
            this.mskDataFinal.Mask = "00/00/0000";
            this.mskDataFinal.Name = "mskDataFinal";
            this.mskDataFinal.Size = new System.Drawing.Size(96, 20);
            this.mskDataFinal.TabIndex = 1;
            // 
            // View_Desktop_ConMovimentacaoEstoques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 301);
            this.Controls.Add(this.mskDataFinal);
            this.Controls.Add(this.mskDataInicial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lsMovimentacaoEstoques);
            this.Controls.Add(this.btnPesquisa);
            this.Name = "View_Desktop_ConMovimentacaoEstoques";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Movimentação de Estoques";
            this.Load += new System.EventHandler(this.View_Desktop_ConMovimentacaoEstoques_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.ColumnHeader clnTipoMovimento;
        private System.Windows.Forms.ColumnHeader clnQuantidade;
        private System.Windows.Forms.ListView lsMovimentacaoEstoques;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mskDataInicial;
        private System.Windows.Forms.MaskedTextBox mskDataFinal;
        private System.Windows.Forms.ColumnHeader cldData;
        private System.Windows.Forms.ColumnHeader clnValorUnitario;
        private System.Windows.Forms.ColumnHeader clnValorTotal;
        private System.Windows.Forms.ColumnHeader clnProduto;
    }
}