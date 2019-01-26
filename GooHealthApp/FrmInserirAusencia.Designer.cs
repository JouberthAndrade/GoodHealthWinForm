namespace GooHealthApp
{
    partial class FrmInserirAusencia
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
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbUsuario = new System.Windows.Forms.ComboBox();
            this.dataCaleInicio = new System.Windows.Forms.MonthCalendar();
            this.dataCaleFim = new System.Windows.Forms.MonthCalendar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gvAusencia = new System.Windows.Forms.DataGridView();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvAusencia)).BeginInit();
            this.SuspendLayout();
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.IntegralHeight = false;
            this.cbEmpresa.ItemHeight = 16;
            this.cbEmpresa.Location = new System.Drawing.Point(17, 37);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(219, 24);
            this.cbEmpresa.TabIndex = 15;
            this.cbEmpresa.SelectedIndexChanged += new System.EventHandler(this.cbEmpresa_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(260, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Usuario:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "Empresa:";
            // 
            // cbUsuario
            // 
            this.cbUsuario.FormattingEnabled = true;
            this.cbUsuario.IntegralHeight = false;
            this.cbUsuario.ItemHeight = 16;
            this.cbUsuario.Location = new System.Drawing.Point(265, 37);
            this.cbUsuario.Name = "cbUsuario";
            this.cbUsuario.Size = new System.Drawing.Size(492, 24);
            this.cbUsuario.TabIndex = 12;
            this.cbUsuario.SelectedIndexChanged += new System.EventHandler(this.cbUsuario_SelectedIndexChanged);
            this.cbUsuario.SelectedValueChanged += new System.EventHandler(this.cbUsuario_SelectedValueChanged);
            // 
            // dataCaleInicio
            // 
            this.dataCaleInicio.Location = new System.Drawing.Point(18, 113);
            this.dataCaleInicio.MaxSelectionCount = 1;
            this.dataCaleInicio.Name = "dataCaleInicio";
            this.dataCaleInicio.TabIndex = 16;
            // 
            // dataCaleFim
            // 
            this.dataCaleFim.Location = new System.Drawing.Point(323, 113);
            this.dataCaleFim.MaxSelectionCount = 1;
            this.dataCaleFim.Name = "dataCaleFim";
            this.dataCaleFim.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 25);
            this.label3.TabIndex = 18;
            this.label3.Text = "Início";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(318, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 25);
            this.label4.TabIndex = 19;
            this.label4.Text = "Fim";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(12, 419);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(796, 10);
            this.panel1.TabIndex = 20;
            // 
            // gvAusencia
            // 
            this.gvAusencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAusencia.Location = new System.Drawing.Point(18, 435);
            this.gvAusencia.Name = "gvAusencia";
            this.gvAusencia.RowTemplate.Height = 24;
            this.gvAusencia.Size = new System.Drawing.Size(770, 284);
            this.gvAusencia.TabIndex = 21;
            // 
            // btnIncluir
            // 
            this.btnIncluir.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnIncluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncluir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnIncluir.Location = new System.Drawing.Point(617, 357);
            this.btnIncluir.Margin = new System.Windows.Forms.Padding(4);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(171, 55);
            this.btnIncluir.TabIndex = 22;
            this.btnIncluir.Text = "INCLUIR";
            this.btnIncluir.UseVisualStyleBackColor = false;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 329);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 25);
            this.label5.TabIndex = 23;
            this.label5.Text = "Motivio:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(27, 357);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(565, 56);
            this.txtMotivo.TabIndex = 24;
            // 
            // FrmInserirAusencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 731);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.gvAusencia);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataCaleFim);
            this.Controls.Add(this.dataCaleInicio);
            this.Controls.Add(this.cbEmpresa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbUsuario);
            this.Name = "FrmInserirAusencia";
            this.Text = "FrmInserirAusencia";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmInserirAusencia_FormClosed);
            this.Load += new System.EventHandler(this.FrmInserirAusencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvAusencia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbEmpresa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbUsuario;
        private System.Windows.Forms.MonthCalendar dataCaleInicio;
        private System.Windows.Forms.MonthCalendar dataCaleFim;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gvAusencia;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMotivo;
    }
}