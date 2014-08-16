namespace Academia.View.Desktop
{
    partial class View_Desktop_ConProdutos
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
            this.lsProdutos = new System.Windows.Forms.ListView();
            this.clnDescricao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnEstoque = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnValorDeVenda = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // txtSelCampo
            // 
            this.txtSelCampo.Location = new System.Drawing.Point(12, 10);
            this.txtSelCampo.Name = "txtSelCampo";
            this.txtSelCampo.Size = new System.Drawing.Size(526, 20);
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
            // lsProdutos
            // 
            this.lsProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsProdutos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnDescricao,
            this.clnId,
            this.clnEstoque,
            this.clnValorDeVenda});
            this.lsProdutos.Location = new System.Drawing.Point(12, 39);
            this.lsProdutos.Name = "lsProdutos";
            this.lsProdutos.Size = new System.Drawing.Size(607, 252);
            this.lsProdutos.TabIndex = 3;
            this.lsProdutos.UseCompatibleStateImageBehavior = false;
            this.lsProdutos.View = System.Windows.Forms.View.Details;
            this.lsProdutos.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.lsProdutos.DoubleClick += new System.EventHandler(this.lsProdutos_DoubleClick);
            this.lsProdutos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsProdutos_MouseDoubleClick);
            // 
            // clnDescricao
            // 
            this.clnDescricao.Text = "Descrição";
            this.clnDescricao.Width = 319;
            // 
            // clnId
            // 
            this.clnId.Text = "Id";
            // 
            // clnEstoque
            // 
            this.clnEstoque.Text = "Estoque";
            this.clnEstoque.Width = 103;
            // 
            // clnValorDeVenda
            // 
            this.clnValorDeVenda.Text = "Valor de Venda";
            this.clnValorDeVenda.Width = 115;
            // 
            // View_Desktop_ConProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 303);
            this.Controls.Add(this.lsProdutos);
            this.Controls.Add(this.btnPesquisa);
            this.Controls.Add(this.txtSelCampo);
            this.Name = "View_Desktop_ConProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Produtos";
            this.Load += new System.EventHandler(this.View_Desktop_ConProdutos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSelCampo;
        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.ListView lsProdutos;
        private System.Windows.Forms.ColumnHeader clnDescricao;
        private System.Windows.Forms.ColumnHeader clnEstoque;
        private System.Windows.Forms.ColumnHeader clnId;
        private System.Windows.Forms.ColumnHeader clnValorDeVenda;
    }
}