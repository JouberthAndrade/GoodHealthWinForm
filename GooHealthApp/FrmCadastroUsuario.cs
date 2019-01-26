using GoodHealth.Application;
using GoodHealth.Model.Dto;
using GoodHealth.Model.Entidades;
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
    public partial class FrmCadastroUsuario : Form
    {
        private static UsuariosApplication usuarioApplication = new UsuariosApplication();
        private static ProdutoApplication produtoApplication = new ProdutoApplication();
        private static EmpresaApplication empresaApplication = new EmpresaApplication();
        private static DiasApplication diasApplictaion = new DiasApplication();
        
        public FrmCadastroUsuario()
        {
            InitializeComponent();
        }

        private void FrmCadastroUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                var listaEmpresas = empresaApplication.GetAll();
                var listaDias = diasApplictaion.GetAll();
                
                if (listaEmpresas.Any())
                {
                    BindingSource bindingEmpresa = new BindingSource();
                    bindingEmpresa.DataSource = listaEmpresas;
                    cbEmpresa.DataSource = bindingEmpresa.DataSource;
                    cbEmpresa.DisplayMember = "NOME";
                    cbEmpresa.ValueMember = "ID";
                }
                if (listaDias.Any())
                {
                    DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
                    BindingSource bindinDias = new BindingSource();
                    bindinDias.DataSource = listaDias;

                    col.DataPropertyName = "2";
                    col.Name = "DiaSemana";
                    col.DataSource = bindinDias.DataSource;
                    col.DisplayMember = "DESCRICAO";
                    col.ValueMember = "ID";
                    
                }
            }
            catch (Exception ex)
            { 
                throw new Exception(ex.Message);
            }
            
        }

        private void FrmCadastroUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Voltar();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Voltar();
        }

        private void Voltar()
        {
            FrmPrincipal form = new FrmPrincipal();
            form.Show();
            this.Hide();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNome.Text) || string.IsNullOrEmpty(txtEmail.Text))
                {
                    MessageBox.Show("Preencha todos os campos!");
                    return;
                }

                UsuarioCadastroDTO usuarioDto = new UsuarioCadastroDTO();
                usuarioDto.Usuario = new Usuarios();
                usuarioDto.Empresa = new Empresa();
                
                usuarioDto.Usuario.NOME = txtNome.Text;
                usuarioDto.Usuario.EMAIL = txtEmail.Text;
                usuarioDto.Usuario.TELEFONE = txtTelefone.Text;
                usuarioDto.Empresa.ID = Convert.ToInt32(cbEmpresa.SelectedValue);
                
                usuarioApplication.Salvar(usuarioDto);

                MessageBox.Show("Cadastro realizado com sucesso!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO-" + ex.Message);
                //throw;
            }
            
        }
    }
}
