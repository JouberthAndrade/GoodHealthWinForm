using GoodHealth.Application;
using GoodHealth.Model.Dto;
using GoodHealth.Model.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GooHealthApp
{
    public partial class FrmUsuarioProdutos : Form
    {
        private static UsuariosApplication usuarioApplication = new UsuariosApplication();
        private static ProdutoApplication produtoApplication = new ProdutoApplication();
        private static EmpresaApplication empresaApplication = new EmpresaApplication();
        private static DiasApplication diasApplictaion = new DiasApplication();

        public FrmUsuarioProdutos()
        {
            InitializeComponent();

            cbEmpresa.DataSource = empresaApplication.GetAll();
            cbEmpresa.DisplayMember = "NOME";
            cbEmpresa.ValueMember = "ID";
        }

        private void FrmUsuarioProdutos_Load(object sender, EventArgs e)
        {
            try
            {
                var listaDias = diasApplictaion.GetAll();
                var listaProdutos = produtoApplication.GetAll();

                if (listaProdutos.Any())
                {
                    BindingSource bindingProdutos = new BindingSource();
                    bindingProdutos.DataSource = listaProdutos;
                    chkListProdutos.DataSource = bindingProdutos.DataSource;
                    chkListProdutos.DisplayMember = "DESCRICAO";
                    chkListProdutos.ValueMember = "ID";
                }

                if (listaDias.Any())
                {
                    DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
                    BindingSource bindinDias = new BindingSource();
                    bindinDias.DataSource = listaDias;

                    cbDias.DataSource = bindinDias.DataSource;
                    cbDias.DisplayMember = "DESCRICAO";
                    cbDias.ValueMember = "ID";
                }

                var idEmpresa = Convert.ToInt32(cbEmpresa.SelectedValue);
                var listaUsuarios = usuarioApplication.GetUsuariosAtivos(idEmpresa);
                if (listaUsuarios.Any())
                {
                    BindingSource bindingUsuario = new BindingSource();
                    bindingUsuario.DataSource = listaUsuarios;
                    cbUsuario.DataSource = bindingUsuario.DataSource;
                    cbUsuario.DisplayMember = "NOME";
                    cbUsuario.ValueMember = "ID";
                }

                BindGrid();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void BindGrid()
        {
            dgvProdutoDia.Rows.Clear();
            dgvProdutoDia.Refresh();

            var Usuario = (Usuarios)cbUsuario.SelectedItem;
            List<UsuarioDiaProduto> listaProdutosUsuario = new List<UsuarioDiaProduto>();
            listaProdutosUsuario = produtoApplication.GetProdutosUsuario(Usuario.ID);
            foreach (var item in listaProdutosUsuario)
            {
                DataGridViewRow row = (DataGridViewRow)dgvProdutoDia.Rows[0].Clone();

                row.Cells[0].Value = item.IdProduto;
                row.Cells[1].Value = item.IdDia;
                row.Cells[2].Value = item.Dia;
                row.Cells[3].Value = item.Produto;
                row.Cells[4].Value = item.DataInicio.ToShortDateString();
                row.Cells[5].Value = item.DataFim.ToShortDateString();
                row.Cells[6].Value = item.Id;
                dgvProdutoDia.Rows.Add(row);
            }
        }

        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {

            

        }

        private void cbEmpresa_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            int fid;
            bool parseOK = Int32.TryParse(comboBox.SelectedValue.ToString(), out fid);

            // var empresa = (Empresa)cbEmpresa.SelectedValue;
            var listaUsuarios = usuarioApplication.GetUsuariosAtivos(fid);
            var usuario = new Usuarios();
            usuario.ID = 0;
            usuario.NOME = "Selecione";

            listaUsuarios.Insert(0, usuario);
            
            BindingSource bindingUsuario = new BindingSource();
            bindingUsuario.DataSource = listaUsuarios;
            cbUsuario.DataSource = bindingUsuario.DataSource;
            cbUsuario.DisplayMember = "NOME";
            cbUsuario.ValueMember = "ID";
            
            
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void Salvar()
        {
            var listaItens = getObjUsuarioProd();
            foreach (var item in listaItens)
                produtoApplication.Salvar(item);
           
            MessageBox.Show("Cadastro realizado com sucesso!");

            Limpar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Salvar();
                BindGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO-" + ex.Message);
            }

        }

        private void Limpar()
        {
            chkListProdutos.ClearSelected();
            txtDataFim.Text = "";
            txtDataFim.Text = "";
            lblID.Text = "0";

            chkListProdutos.Enabled = true;
            cbDias.Enabled = true;
            cbEmpresa.Enabled = true;
            cbUsuario.Enabled = true;

            btnNovo.Visible = false;
            btnAtualizar.Visible = false;
            btnSalvar.Visible = true;

            dgvProdutoDia.Refresh();
        }

        private void cbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void dgvProdutoDia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }   

        private void dgvProdutoDia_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvProdutoDia.SelectedRows)
            {
                int idProduto = Convert.ToInt32(row.Cells[0].Value.ToString());
                int idDia = Convert.ToInt32(row.Cells[1].Value.ToString());
                string dia = row.Cells[2].Value.ToString();
                string produto = row.Cells[3].Value.ToString();
                DateTime dtInicio = Convert.ToDateTime(row.Cells[4].Value.ToString());
                DateTime dtFim = Convert.ToDateTime(row.Cells[5].Value.ToString());

                chkListProdutos.SelectedValue = idProduto;
                chkListProdutos.SetItemChecked(chkListProdutos.SelectedIndex, true);
                txtDataInicio.Text = dtInicio.ToShortDateString();
                txtDataFim.Text = dtFim.ToShortDateString();
                cbDias.SelectedValue = idDia;
                lblID.Text = row.Cells[6].Value.ToString();

                btnNovo.Visible = true;
                btnAtualizar.Visible = true;
                btnSalvar.Visible = false;

                chkListProdutos.Enabled = false;
                cbDias.Enabled = false;
                cbEmpresa.Enabled = false;
                cbUsuario.Enabled = false;
            }
        }
        
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            UsuarioDiaProduto objUsuarioProd = new UsuarioDiaProduto();
            objUsuarioProd = getObjUsuarioProd().FirstOrDefault();
            objUsuarioProd.Id = Convert.ToInt32(lblID.Text);
         
            produtoApplication.Atualizar(objUsuarioProd);
            MessageBox.Show("Atualizacao realizada com sucesso!");

            Limpar();
            BindGrid();
        }

        private List<UsuarioDiaProduto> getObjUsuarioProd()
        {
            List<UsuarioDiaProduto> retorno = new List<UsuarioDiaProduto>();
            

            var user = (Usuarios)cbUsuario.SelectedItem;

            Produtos produtos = new Produtos();
            List<Produtos> listaProdutosTela = new List<Produtos>();
            DateTime dtParse = new DateTime();
            
            var listaProdutos = chkListProdutos.CheckedItems.OfType<Produtos>().ToArray();

            if (chkTodosDias.Checked)
            {
                foreach (DIA_SEMANA item in cbDias.Items)
                {
                    UsuarioDiaProduto usuarioDiaProduto = new UsuarioDiaProduto();
                    usuarioDiaProduto.ListaProdutos = listaProdutos.ToList();
                    usuarioDiaProduto.IdUsuario = user.ID;
                    usuarioDiaProduto.IdDia = Convert.ToInt32(item.ID);
                    DateTime.TryParseExact(txtDataInicio.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtParse);
                    usuarioDiaProduto.DataInicio = dtParse.Year < 2017 ? DateTime.Now : dtParse;

                    DateTime.TryParseExact(txtDataFim.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtParse);
                    usuarioDiaProduto.DataFim = dtParse.Year < 2017 ? DateTime.Now.AddYears(1) : dtParse;

                    retorno.Add(usuarioDiaProduto);
                }
            }
            else
            {
                UsuarioDiaProduto usuarioDiaProduto = new UsuarioDiaProduto();
                usuarioDiaProduto.ListaProdutos = listaProdutos.ToList();
                usuarioDiaProduto.IdUsuario = user.ID;
                usuarioDiaProduto.IdDia = Convert.ToInt32(cbDias.SelectedValue);
                DateTime.TryParseExact(txtDataInicio.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtParse);
                usuarioDiaProduto.DataInicio = dtParse.Year < 2017 ? DateTime.Now : dtParse;

                DateTime.TryParseExact(txtDataFim.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtParse);
                usuarioDiaProduto.DataFim = dtParse.Year < 2017 ? DateTime.Now.AddYears(1) : dtParse;

                retorno.Add(usuarioDiaProduto);
            }

            return retorno;
        }

        private void FrmUsuarioProdutos_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmPrincipal form = new FrmPrincipal();
            form.Show();
            this.Hide();
        }

        private void chkProdutoAtual_CheckedChanged(object sender, EventArgs e)
        {
            var Usuario = (Usuarios)cbUsuario.SelectedItem;
            List<UsuarioDiaProduto> listaProdutosUsuario = new List<UsuarioDiaProduto>();
            
            if (chkProdutoAtual.Checked)
                listaProdutosUsuario = produtoApplication.GetProdutosUsuario(Usuario.ID).Where(x => x.DataInicio <= DateTime.Now && x.DataFim >= DateTime.Now).ToList();
            else
                listaProdutosUsuario = produtoApplication.GetProdutosUsuario(Usuario.ID);


            dgvProdutoDia.Rows.Clear();
            dgvProdutoDia.Refresh();
            foreach (var item in listaProdutosUsuario)
            {
                DataGridViewRow row = (DataGridViewRow)dgvProdutoDia.Rows[0].Clone();

                row.Cells[0].Value = item.IdProduto;
                row.Cells[1].Value = item.IdDia;
                row.Cells[2].Value = item.Dia;
                row.Cells[3].Value = item.Produto;
                row.Cells[4].Value = item.DataInicio.ToShortDateString();
                row.Cells[5].Value = item.DataFim.ToShortDateString();
                row.Cells[6].Value = item.Id;
                dgvProdutoDia.Rows.Add(row);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            FrmPrincipal form = new FrmPrincipal();
            form.Show();
            this.Hide();
        }

        private void chkTodosDias_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodosDias.Checked)
            {
                cbDias.Enabled = false;
            }
            else
            {
                cbDias.Enabled = true;
            }
        }
    }
}
