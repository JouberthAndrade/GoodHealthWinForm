using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GooHealthApp
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmCadastroUsuario form = new FrmCadastroUsuario();
            form.Show();
            this.Hide();
        }

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmUsuarioProdutos form = new FrmUsuarioProdutos();
            form.Show();
            this.Hide();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnInserirAusencia_Click(object sender, EventArgs e)
        {
            FrmInserirAusencia form = new FrmInserirAusencia();
            form.Show();
            this.Hide();
        }
    }
}
