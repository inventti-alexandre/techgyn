namespace Academia.View.Desktop
{
    partial class View_Desktop_ExtratoLivroCaixa1
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
            this.lsLivroCaixa = new System.Windows.Forms.ListView();
            this.cldData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnTipoMovimento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnValor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnDescricao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mskDataInicial = new System.Windows.Forms.MaskedTextBox();
            this.mskDataFinal = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEntradas = new System.Windows.Forms.MaskedTextBox();
            this.txtSaidas = new System.Windows.Forms.MaskedTextBox();
            this.txtTotal = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
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
            // lsLivroCaixa
            // 
            this.lsLivroCaixa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsLivroCaixa.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cldData,
            this.clnTipoMovimento,
            this.clnValor,
            this.clnDescricao});
            this.lsLivroCaixa.Location = new System.Drawing.Point(15, 39);
            this.lsLivroCaixa.Name = "lsLivroCaixa";
            this.lsLivroCaixa.Size = new System.Drawing.Size(702, 252);
            this.lsLivroCaixa.TabIndex = 3;
            this.lsLivroCaixa.UseCompatibleStateImageBehavior = false;
            this.lsLivroCaixa.View = System.Windows.Forms.View.Details;
            this.lsLivroCaixa.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.lsLivroCaixa.DoubleClick += new System.EventHandler(this.lsLivroCaixa_DoubleClick);
            this.lsLivroCaixa.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsLivroCaixa_MouseDoubleClick);
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
            // clnValor
            // 
            this.clnValor.Text = "Valor";
            this.clnValor.Width = 89;
            // 
            // clnDescricao
            // 
            this.clnDescricao.Text = "Descrição";
            this.clnDescricao.Width = 405;
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
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Entradas:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(244, 310);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Saídas:";
            // 
            // txtEntradas
            // 
            this.txtEntradas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtEntradas.Enabled = false;
            this.txtEntradas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntradas.Location = new System.Drawing.Point(80, 307);
            this.txtEntradas.Name = "txtEntradas";
            this.txtEntradas.Size = new System.Drawing.Size(148, 22);
            this.txtEntradas.TabIndex = 8;
            this.txtEntradas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSaidas
            // 
            this.txtSaidas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSaidas.Enabled = false;
            this.txtSaidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaidas.Location = new System.Drawing.Point(304, 307);
            this.txtSaidas.Name = "txtSaidas";
            this.txtSaidas.Size = new System.Drawing.Size(155, 22);
            this.txtSaidas.TabIndex = 9;
            this.txtSaidas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(562, 307);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(155, 22);
            this.txtTotal.TabIndex = 11;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(514, 310);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Total:";
            // 
            // View_Desktop_ExtratoLivroCaixa1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 336);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSaidas);
            this.Controls.Add(this.txtEntradas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mskDataFinal);
            this.Controls.Add(this.mskDataInicial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lsLivroCaixa);
            this.Controls.Add(this.btnPesquisa);
            this.Name = "View_Desktop_ExtratoLivroCaixa1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extrato de Livro Caixa";
            this.Load += new System.EventHandler(this.View_Desktop_ExtratoLivroCaixa1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPesquisa;
        private System.Windows.Forms.ColumnHeader clnTipoMovimento;
        private System.Windows.Forms.ListView lsLivroCaixa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mskDataInicial;
        private System.Windows.Forms.MaskedTextBox mskDataFinal;
        private System.Windows.Forms.ColumnHeader cldData;
        private System.Windows.Forms.ColumnHeader clnValor;
        private System.Windows.Forms.ColumnHeader clnDescricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtEntradas;
        private System.Windows.Forms.MaskedTextBox txtSaidas;
        private System.Windows.Forms.MaskedTextBox txtTotal;
        private System.Windows.Forms.Label label5;
    }
}