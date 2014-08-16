namespace INSTALLER
{
    partial class Instalador
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkCriarBancoDeDados = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tPort = new System.Windows.Forms.TextBox();
            this.tHost = new System.Windows.Forms.TextBox();
            this.listLog = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tSenha = new System.Windows.Forms.TextBox();
            this.tUser = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 118);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(259, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Preparar Banco de Dados";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(313, 124);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Teste não executado.";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabControl1.Location = new System.Drawing.Point(325, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(579, 383);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(571, 354);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TechGym";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(4, 23);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(559, 272);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Esta aplicação ira fazer a preparação do banco de dados permitindo o uso do softw" +
    "are sobre o banco de dados Postgre.";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkCriarBancoDeDados);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.tPort);
            this.tabPage2.Controls.Add(this.tHost);
            this.tabPage2.Controls.Add(this.listLog);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.tSenha);
            this.tabPage2.Controls.Add(this.tUser);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(571, 354);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Banco de Dados";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // chkCriarBancoDeDados
            // 
            this.chkCriarBancoDeDados.AutoSize = true;
            this.chkCriarBancoDeDados.Location = new System.Drawing.Point(87, 68);
            this.chkCriarBancoDeDados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkCriarBancoDeDados.Name = "chkCriarBancoDeDados";
            this.chkCriarBancoDeDados.Size = new System.Drawing.Size(166, 21);
            this.chkCriarBancoDeDados.TabIndex = 11;
            this.chkCriarBancoDeDados.Text = "Criar banco de dados";
            this.chkCriarBancoDeDados.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(293, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Porta";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 11);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Host";
            // 
            // tPort
            // 
            this.tPort.Location = new System.Drawing.Point(359, 7);
            this.tPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tPort.Name = "tPort";
            this.tPort.ReadOnly = true;
            this.tPort.Size = new System.Drawing.Size(64, 22);
            this.tPort.TabIndex = 8;
            this.tPort.Text = "5432";
            // 
            // tHost
            // 
            this.tHost.Location = new System.Drawing.Point(87, 7);
            this.tHost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tHost.Name = "tHost";
            this.tHost.ReadOnly = true;
            this.tHost.Size = new System.Drawing.Size(197, 22);
            this.tHost.TabIndex = 7;
            this.tHost.Text = "localhost";
            // 
            // listLog
            // 
            this.listLog.FormattingEnabled = true;
            this.listLog.ItemHeight = 16;
            this.listLog.Items.AddRange(new object[] {
            "Status de preparação do banco"});
            this.listLog.Location = new System.Drawing.Point(25, 154);
            this.listLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listLog.Name = "listLog";
            this.listLog.Size = new System.Drawing.Size(459, 164);
            this.listLog.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Senha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Usuario";
            // 
            // tSenha
            // 
            this.tSenha.Location = new System.Drawing.Point(359, 34);
            this.tSenha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tSenha.Name = "tSenha";
            this.tSenha.PasswordChar = '*';
            this.tSenha.Size = new System.Drawing.Size(127, 22);
            this.tSenha.TabIndex = 3;
            this.tSenha.Text = "123456";
            this.tSenha.TextChanged += new System.EventHandler(this.tSenha_TextChanged);
            // 
            // tUser
            // 
            this.tUser.Location = new System.Drawing.Point(87, 34);
            this.tUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tUser.Name = "tUser";
            this.tUser.Size = new System.Drawing.Size(127, 22);
            this.tUser.TabIndex = 2;
            this.tUser.Text = "postgres";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::INSTALLER.Properties.Resources.LogoTechGym;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(317, 383);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Instalador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 383);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Instalador";
            this.Text = "TechGym Install";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tSenha;
        private System.Windows.Forms.TextBox tUser;
        private System.Windows.Forms.ListBox listLog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tPort;
        private System.Windows.Forms.TextBox tHost;
        private System.Windows.Forms.CheckBox chkCriarBancoDeDados;
    }
}

