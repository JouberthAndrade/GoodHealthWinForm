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
    public partial class FrmInserirAusencia : Form
    {

        private static UsuariosApplication usuarioApplication = new UsuariosApplication();
        private static EmpresaApplication empresaApplication = new EmpresaApplication();

        public FrmInserirAusencia()
        {
            InitializeComponent();


            cbEmpresa.DataSource = empresaApplication.GetAll();
            cbEmpresa.DisplayMember = "NOME";
            cbEmpresa.ValueMember = "ID";
        }

        private void FrmInserirAusencia_Load(object sender, EventArgs e)
        {

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

        }

        private void cbUsuario_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridAusencia();
        }

        private void BindGridAusencia()
        {
            var Usuario = (Usuarios)cbUsuario.SelectedItem;

            List<UsuarioAusenciaDTO> ausenciaDTOs = new List<UsuarioAusenciaDTO>();

            ausenciaDTOs = usuarioApplication.GetAusencias(Usuario.ID);
            if (ausenciaDTOs != null)
            {
                BindingSource bindingSource1 = new BindingSource();
                bindingSource1.DataSource = ausenciaDTOs;
                gvAusencia.DataSource = bindingSource1;
            }
            else
            {
                gvAusencia.DataSource = null;
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dataInicio = Convert.ToDateTime(dataCaleInicio.SelectionRange.Start.ToString());
                DateTime dataFim = Convert.ToDateTime(dataCaleFim.SelectionRange.Start.ToString());

                if (dataInicio > dataFim)
                    MessageBox.Show("Data início não pode ser maior que Data Fim");
                else
                {
                    var Usuario = (Usuarios)cbUsuario.SelectedItem;
                    UsuarioAusenciaDTO usuarioAusencia = new UsuarioAusenciaDTO();
                    usuarioAusencia.DataInicio = dataInicio;
                    usuarioAusencia.DataFim = dataFim;
                    usuarioAusencia.Id = Usuario.ID;
                    usuarioAusencia.Motivo = txtMotivo.Text;

                    usuarioApplication.InserirAusencia(usuarioAusencia);
                    BindGridAusencia();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }
        }

        private void cbEmpresa_SelectedIndexChanged(object sender, EventArgs e)
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

        private void FrmInserirAusencia_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmPrincipal form = new FrmPrincipal();
            form.Show();
            this.Hide();
        }
    }
}
