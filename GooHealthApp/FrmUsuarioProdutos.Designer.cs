namespace GooHealthApp
{
    partial class FrmUsuarioProdutos
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
            this.cbUsuario = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDias = new System.Windows.Forms.ComboBox();
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.dgvProdutoDia = new System.Windows.Forms.DataGridView();
            this.IDProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDDia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataFim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.chkListProdutos = new System.Windows.Forms.CheckedListBox();
            this.lblDataInicio = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDataInicio = new System.Windows.Forms.MaskedTextBox();
            this.txtDataFim = new System.Windows.Forms.MaskedTextBox();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.lblID = new System.Windows.Forms.Label();
            this.chkProdutoAtual = new System.Windows.Forms.CheckBox();
            this.chkTodosDias = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutoDia)).BeginInit();
            this.SuspendLayout();
            // 
            // cbUsuario
            // 
            this.cbUsuario.FormattingEnabled = true;
            this.cbUsuario.IntegralHeight = false;
            this.cbUsuario.ItemHeight = 16;
            this.cbUsuario.Location = new System.Drawing.Point(377, 37);
            this.cbUsuario.Name = "cbUsuario";
            this.cbUsuario.Size = new System.Drawing.Size(546, 24);
            this.cbUsuario.TabIndex = 1;
            this.cbUsuario.SelectedIndexChanged += new System.EventHandler(this.cbUsuario_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Empresa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(372, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Dia da semana";
            // 
            // cbDias
            // 
            this.cbDias.FormattingEnabled = true;
            this.cbDias.IntegralHeight = false;
            this.cbDias.ItemHeight = 16;
            this.cbDias.Location = new System.Drawing.Point(12, 106);
            this.cbDias.Name = "cbDias";
            this.cbDias.Size = new System.Drawing.Size(313, 24);
            this.cbDias.TabIndex = 10;
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.IntegralHeight = false;
            this.cbEmpresa.ItemHeight = 16;
            this.cbEmpresa.Location = new System.Drawing.Point(12, 37);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(313, 24);
            this.cbEmpresa.TabIndex = 11;
            this.cbEmpresa.SelectedIndexChanged += new System.EventHandler(this.cbEmpresa_SelectedIndexChanged);
            this.cbEmpresa.SelectedValueChanged += new System.EventHandler(this.cbEmpresa_SelectedValueChanged);
            // 
            // dgvProdutoDia
            // 
            this.dgvProdutoDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutoDia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDProduto,
            this.IDDia,
            this.Dia,
            this.Produto,
            this.DataInicio,
            this.DataFim,
            this.ID});
            this.dgvProdutoDia.Location = new System.Drawing.Point(12, 371);
            this.dgvProdutoDia.Name = "dgvProdutoDia";
            this.dgvProdutoDia.RowTemplate.Height = 24;
            this.dgvProdutoDia.Size = new System.Drawing.Size(911, 308);
            this.dgvProdutoDia.TabIndex = 12;
            this.dgvProdutoDia.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutoDia_CellDoubleClick);
            this.dgvProdutoDia.SelectionChanged += new System.EventHandler(this.dgvProdutoDia_SelectionChanged);
            // 
            // IDProduto
            // 
            this.IDProduto.HeaderText = "IDProduto";
            this.IDProduto.Name = "IDProduto";
            // 
            // IDDia
            // 
            this.IDDia.HeaderText = "IDDia";
            this.IDDia.Name = "IDDia";
            // 
            // Dia
            // 
            this.Dia.HeaderText = "Dia";
            this.Dia.Name = "Dia";
            // 
            // Produto
            // 
            this.Produto.HeaderText = "Produto";
            this.Produto.Name = "Produto";
            // 
            // DataInicio
            // 
            this.DataInicio.HeaderText = "Data Inicio";
            this.DataInicio.Name = "DataInicio";
            this.DataInicio.Width = 150;
            // 
            // DataFim
            // 
            this.DataFim.HeaderText = "Data Fim";
            this.DataFim.Name = "DataFim";
            this.DataFim.Width = 150;
            // 
            // ID
            // 
            this.ID.HeaderText = "Id";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSalvar.Location = new System.Drawing.Point(695, 283);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(227, 55);
            this.btnSalvar.TabIndex = 14;
            this.btnSalvar.Text = "SALVAR";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(12, 686);
            this.btnVoltar.Margin = new System.Windows.Forms.Padding(4);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(227, 55);
            this.btnVoltar.TabIndex = 15;
            this.btnVoltar.Text = "VOLTAR";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNovo.Location = new System.Drawing.Point(696, 686);
            this.btnNovo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(227, 55);
            this.btnNovo.TabIndex = 16;
            this.btnNovo.Text = "NOVO";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Visible = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // chkListProdutos
            // 
            this.chkListProdutos.BackColor = System.Drawing.SystemColors.Menu;
            this.chkListProdutos.FormattingEnabled = true;
            this.chkListProdutos.Location = new System.Drawing.Point(14, 165);
            this.chkListProdutos.Name = "chkListProdutos";
            this.chkListProdutos.Size = new System.Drawing.Size(311, 157);
            this.chkListProdutos.TabIndex = 17;
            // 
            // lblDataInicio
            // 
            this.lblDataInicio.AutoSize = true;
            this.lblDataInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataInicio.Location = new System.Drawing.Point(326, 166);
            this.lblDataInicio.Name = "lblDataInicio";
            this.lblDataInicio.Size = new System.Drawing.Size(109, 25);
            this.lblDataInicio.TabIndex = 19;
            this.lblDataInicio.Text = "Data Inicio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(327, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 25);
            this.label4.TabIndex = 20;
            this.label4.Text = "Data Fim:";
            // 
            // txtDataInicio
            // 
            this.txtDataInicio.Location = new System.Drawing.Point(331, 194);
            this.txtDataInicio.Mask = "00/00/0000";
            this.txtDataInicio.Name = "txtDataInicio";
            this.txtDataInicio.Size = new System.Drawing.Size(158, 22);
            this.txtDataInicio.TabIndex = 22;
            this.txtDataInicio.ValidatingType = typeof(System.DateTime);
            // 
            // txtDataFim
            // 
            this.txtDataFim.Location = new System.Drawing.Point(331, 248);
            this.txtDataFim.Mask = "00/00/0000";
            this.txtDataFim.Name = "txtDataFim";
            this.txtDataFim.Size = new System.Drawing.Size(158, 22);
            this.txtDataFim.TabIndex = 23;
            this.txtDataFim.ValidatingType = typeof(System.DateTime);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAtualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAtualizar.Location = new System.Drawing.Point(696, 232);
            this.btnAtualizar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(227, 55);
            this.btnAtualizar.TabIndex = 24;
            this.btnAtualizar.Text = "ATUALIZAR";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Visible = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // lblID
            // 
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(423, 713);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(28, 28);
            this.lblID.TabIndex = 25;
            this.lblID.Text = "0";
            this.lblID.Visible = false;
            // 
            // chkProdutoAtual
            // 
            this.chkProdutoAtual.AutoSize = true;
            this.chkProdutoAtual.Location = new System.Drawing.Point(12, 344);
            this.chkProdutoAtual.Name = "chkProdutoAtual";
            this.chkProdutoAtual.Size = new System.Drawing.Size(81, 21);
            this.chkProdutoAtual.TabIndex = 26;
            this.chkProdutoAtual.Text = "Kit atual";
            this.chkProdutoAtual.UseVisualStyleBackColor = true;
            this.chkProdutoAtual.CheckedChanged += new System.EventHandler(this.chkProdutoAtual_CheckedChanged);
            // 
            // chkTodosDias
            // 
            this.chkTodosDias.AutoSize = true;
            this.chkTodosDias.Location = new System.Drawing.Point(332, 108);
            this.chkTodosDias.Name = "chkTodosDias";
            this.chkTodosDias.Size = new System.Drawing.Size(119, 21);
            this.chkTodosDias.TabIndex = 27;
            this.chkTodosDias.Text = "Todos os dias";
            this.chkTodosDias.UseVisualStyleBackColor = true;
            this.chkTodosDias.CheckedChanged += new System.EventHandler(this.chkTodosDias_CheckedChanged);
            // 
            // FrmUsuarioProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 754);
            this.Controls.Add(this.chkTodosDias);
            this.Controls.Add(this.chkProdutoAtual);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.txtDataFim);
            this.Controls.Add(this.txtDataInicio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblDataInicio);
            this.Controls.Add(this.chkListProdutos);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.dgvProdutoDia);
            this.Controls.Add(this.cbEmpresa);
            this.Controls.Add(this.cbDias);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbUsuario);
            this.Name = "FrmUsuarioProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmUsuarioProdutos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmUsuarioProdutos_FormClosed);
            this.Load += new System.EventHandler(this.FrmUsuarioProdutos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutoDia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbDias;
        private System.Windows.Forms.ComboBox cbEmpresa;
        private System.Windows.Forms.DataGridView dgvProdutoDia;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.CheckedListBox chkListProdutos;
        private System.Windows.Forms.Label lblDataInicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtDataInicio;
        private System.Windows.Forms.MaskedTextBox txtDataFim;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDDia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataFim;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.CheckBox chkProdutoAtual;
        private System.Windows.Forms.CheckBox chkTodosDias;
    }
}