namespace GooHealthApp
{
    partial class Form1
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
            this.btnEnviarEmail = new System.Windows.Forms.Button();
            this.lblValorTotal = new System.Windows.Forms.Label();
            this.cbPeriodos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dgDetalhado = new System.Windows.Forms.DataGridView();
            this.btnEmailIndividual = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalhado)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(435, 33);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Consultar Pagamentos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEnviarEmail
            // 
            this.btnEnviarEmail.BackColor = System.Drawing.Color.Brown;
            this.btnEnviarEmail.Enabled = false;
            this.btnEnviarEmail.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
            this.btnEnviarEmail.FlatAppearance.BorderSize = 2;
            this.btnEnviarEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviarEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviarEmail.ForeColor = System.Drawing.Color.White;
            this.btnEnviarEmail.Location = new System.Drawing.Point(435, 696);
            this.btnEnviarEmail.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnviarEmail.Name = "btnEnviarEmail";
            this.btnEnviarEmail.Size = new System.Drawing.Size(203, 48);
            this.btnEnviarEmail.TabIndex = 2;
            this.btnEnviarEmail.Text = "Enviar Email em Massa";
            this.btnEnviarEmail.UseVisualStyleBackColor = false;
            this.btnEnviarEmail.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.AutoSize = true;
            this.lblValorTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorTotal.Location = new System.Drawing.Point(1404, 675);
            this.lblValorTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(35, 17);
            this.lblValorTotal.TabIndex = 3;
            this.lblValorTotal.Text = "123";
            this.lblValorTotal.Visible = false;
            // 
            // cbPeriodos
            // 
            this.cbPeriodos.FormattingEnabled = true;
            this.cbPeriodos.Location = new System.Drawing.Point(17, 36);
            this.cbPeriodos.Margin = new System.Windows.Forms.Padding(4);
            this.cbPeriodos.Name = "cbPeriodos";
            this.cbPeriodos.Size = new System.Drawing.Size(410, 24);
            this.cbPeriodos.TabIndex = 4;
            this.cbPeriodos.SelectedIndexChanged += new System.EventHandler(this.cbPeriodos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Selecione o período:";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(17, 67);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(412, 677);
            this.treeView1.TabIndex = 6;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // dgDetalhado
            // 
            this.dgDetalhado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetalhado.Location = new System.Drawing.Point(435, 69);
            this.dgDetalhado.Name = "dgDetalhado";
            this.dgDetalhado.RowTemplate.Height = 24;
            this.dgDetalhado.Size = new System.Drawing.Size(971, 620);
            this.dgDetalhado.TabIndex = 7;
            // 
            // btnEmailIndividual
            // 
            this.btnEmailIndividual.BackColor = System.Drawing.Color.ForestGreen;
            this.btnEmailIndividual.Enabled = false;
            this.btnEmailIndividual.FlatAppearance.BorderColor = System.Drawing.Color.LimeGreen;
            this.btnEmailIndividual.FlatAppearance.BorderSize = 2;
            this.btnEmailIndividual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmailIndividual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmailIndividual.ForeColor = System.Drawing.Color.White;
            this.btnEmailIndividual.Location = new System.Drawing.Point(646, 696);
            this.btnEmailIndividual.Margin = new System.Windows.Forms.Padding(4);
            this.btnEmailIndividual.Name = "btnEmailIndividual";
            this.btnEmailIndividual.Size = new System.Drawing.Size(203, 48);
            this.btnEmailIndividual.TabIndex = 8;
            this.btnEmailIndividual.Text = "Enviar Email Individual";
            this.btnEmailIndividual.UseVisualStyleBackColor = false;
            this.btnEmailIndividual.Click += new System.EventHandler(this.btnEmailIndividual_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 757);
            this.Controls.Add(this.btnEmailIndividual);
            this.Controls.Add(this.dgDetalhado);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPeriodos);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.btnEnviarEmail);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDetalhado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnEnviarEmail;
        private System.Windows.Forms.Label lblValorTotal;
        private System.Windows.Forms.ComboBox cbPeriodos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView dgDetalhado;
        private System.Windows.Forms.Button btnEmailIndividual;
    }
}

