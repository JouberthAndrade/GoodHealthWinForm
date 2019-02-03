using GoodHealth.Application;
using GoodHealth.Model.Dto;
using GoodHealth.Util;
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
    public partial class Form1 : Form
    {
        private static UsuariosApplication usuarioAPP = new UsuariosApplication();
        private static PagamentoApplication pagamentoApplication = new PagamentoApplication();
        private static PeriodoPagamentoApplication _periodoPagamentoApplication = new PeriodoPagamentoApplication();
        private static Mail _mail = new Mail();

        private List<PagamentoDetalhadoDTO> listaDetalhado = new List<PagamentoDetalhadoDTO>();
        private int idUsuarioTela = 0;

        public Form1()
        {
            InitializeComponent();
            _mail.MailSmtpHost = "smtp.googlemail.com";
            _mail.MailSmtpPort = 587;
            _mail.MailSmtpUsername = "goodhealthkits@gmail.com";
            _mail.MailSmtpPassword = "Teste099";
            _mail.MailFrom = "goodhealthkits@gmail.com";

            cbPeriodos.DataSource = usuarioAPP.GetPeriodos();
            cbPeriodos.DisplayMember = "NOME";
            cbPeriodos.ValueMember = "ID";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var execFechamento = _periodoPagamentoApplication.ExecutaFechamento();
            if (true)
            {
                int idPeriodo = Convert.ToInt32(cbPeriodos.SelectedValue);

                var lista = usuarioAPP.GetPagamentos(idPeriodo);
                lblValorTotal.Text = string.Format("VALOR TOTAL: {0}", lista.Sum(x => x.VALOR).ToString());
                lblValorTotal.Visible = true;
                btnEnviarEmail.Enabled = true;
                btnEmailIndividual.Enabled = true;

                PopulaTreeView();
            }
            else
            {
                MessageBox.Show("Erro ao executar procedure para atualizar fechamento");
            }
            
        }

        private void PopulaTreeView()
        {
            treeView1.Nodes.Clear();
            int idPeriodo = Convert.ToInt32(cbPeriodos.SelectedValue);

            listaDetalhado = pagamentoApplication.GetPagamentosDetalhado(idPeriodo);

            foreach (var item in listaDetalhado)
            {
                var rootNode = string.Format("{0} / {1} - [TOTAL: R$ {2} ]", item.NOME, item.EMPRESA, item.Datas.Sum(x => x.Produtos.Sum(y => y.VALOR_PRODUTO)));
                
                List<TreeNode> treeNodesList = new List<TreeNode>();
                List<TreeNode> treeProdNodesList = new List<TreeNode>();
                //foreach (var datas in item.Datas)
                //{
                //    var dataNode = string.Format("DATA: {0} / DIA: {1} ", datas.DATA_FECHAMENTO, datas.DATA_FECHAMENTO.ToString("dddd"));

                //    TreeNode dataNodeUser = new TreeNode(dataNode);
                //    treeNodesList.Add(dataNodeUser);
                //    decimal totalDia = 0;
                //    foreach (var produto in datas.Produtos)
                //    {
                //        var prodNode = string.Format("PRODUTO: {0} / VALOR: R$ {1} ", produto.DESCRICAO_PRODUTO, produto.VALOR_PRODUTO);

                //        TreeNode prodNodeUser = new TreeNode(prodNode);

                //        treeNodesList.Add(prodNodeUser);

                //        totalDia += produto.VALOR_PRODUTO;
                //    }

                //    TreeNode dateNodeUser = new TreeNode(dataNode, treeProdNodesList.ToArray());

                //}

                // TreeNode rootNodeUser = new TreeNode(rootNode);

                treeView1.Nodes.Add(item.ID_USUARIO.ToString(), rootNode);
                
            }
        }
        private void btnEmailIndividual_Click(object sender, EventArgs e)
        {
            EnviarEmailIndividual();
        }

        private void EnviarEmailIndividual()
        {
            var confirmResult = MessageBox.Show("Tem certeza que deseja enviar os emails?",
                                     "ConfirmMMM",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                var periodo = _periodoPagamentoApplication.GetPeriodo(Convert.ToInt32(cbPeriodos.SelectedValue));

                var assunto = string.Format("Pagamento {0}", cbPeriodos.Text);

                if (idUsuarioTela > 0)
                {
                    var itemFechamento = listaDetalhado.Where(x => x.ID_USUARIO == Convert.ToInt32(idUsuarioTela)).FirstOrDefault();
                   
                    var retornoMail = false;
                    var qtdAusencia = usuarioAPP.GetAusencias(itemFechamento.ID_USUARIO, periodo.ID).Count;
                    string mailcorpo = _mail.RetornarHtlmEmail(itemFechamento, periodo, qtdAusencia);

                    if (!string.IsNullOrEmpty(itemFechamento.EMAIL))
                        retornoMail = _mail.SendEmail(itemFechamento, assunto, mailcorpo);

                    if (retornoMail)
                        MessageBox.Show("Email enviado com sucesso!");
                }

            }
            else
            {
                // If 'No', do something here.
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
          await EnviarEmailAsync();
        }
        private async Task EnviarEmailAsync()
        {
            var qtd = 0;
            var qtdnao = 0;
            var confirmResult = MessageBox.Show("Tem certeza que deseja enviar os emails?",
                                     "ConfirmMMM",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                var periodo = _periodoPagamentoApplication.GetPeriodo(Convert.ToInt32(cbPeriodos.SelectedValue));
                
                var assunto = string.Format("Pagamento {0}/2019", cbPeriodos.Text);

                if (listaDetalhado.Any())
                {
                    foreach (var item in listaDetalhado)
                    {
                        var retornoMail = false;
                        var qtdAusencia = usuarioAPP.GetAusencias(item.ID_USUARIO, periodo.ID).Count;
                        string mailcorpo = _mail.RetornarHtlmEmail(item, periodo, qtdAusencia);

                        if (!string.IsNullOrEmpty(item.EMAIL))
                            retornoMail = _mail.SendEmail(item, assunto, mailcorpo);

                        if (retornoMail)
                            qtd++;
                        else
                            qtdnao++;

                    }
                    if (qtd > 0 || qtdnao > 0)
                    {
                        await EnviarEmailAdministradores();
                        MessageBox.Show(string.Format("Emails enviados: {0} | Não enviados: {1}", qtd, qtdnao));
                    }
                }

            }
            else
            {
                // If 'No', do something here.
            }
        }

        private async Task EnviarEmailAdministradores()
        {
            _mail.SendMailAdms(listaDetalhado);
        }

        private void cbPeriodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Voltar();
        }

        private void Voltar()
        {
            FrmPrincipal form = new FrmPrincipal();
            form.Show();
            this.Hide();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            PopulaGridDetalhe(e.Node.Name);
        }

        private void PopulaGridDetalhe(string idUsuario)
        {
            idUsuarioTela = Convert.ToInt32(idUsuario);
            var itemFechamento = listaDetalhado.Where(x => x.ID_USUARIO == Convert.ToInt32(idUsuario)).FirstOrDefault();
            if (itemFechamento == null)
               MessageBox.Show("Erro ao selecionar usuario");
            else
            {
                dgDetalhado.Columns.Clear();
                dgDetalhado.Rows.Clear();
                dgDetalhado.Refresh();
                

                dgDetalhado.Columns.Add("Data", "");
                dgDetalhado.Columns[0].Width = 200;
                dgDetalhado.Columns.Add("Dia", "");
                dgDetalhado.Columns[1].Width = 200;

                foreach (var item in itemFechamento.Datas)
                {
                    var index = dgDetalhado.Rows.Add();
                    dgDetalhado.Rows[index].Cells[0].Value = item.DATA_FECHAMENTO;
                    dgDetalhado.Rows[index].Cells[1].Value = item.DATA_FECHAMENTO.ToString("dddd");
                    
                    using (Font font = new Font(
                       dgDetalhado.DefaultCellStyle.Font.FontFamily, 12, FontStyle.Bold))
                    {
                        dgDetalhado.Rows[index].DefaultCellStyle.Font = font;
                    }
                    foreach (var produto in item.Produtos)
                    {

                        var index3 = dgDetalhado.Rows.Add();
                        dgDetalhado.Rows[index3].Cells[0].Value = produto.DESCRICAO_PRODUTO;
                        dgDetalhado.Rows[index3].Cells[1].Value = produto.VALOR_PRODUTO;
                        dgDetalhado.Rows[index3].DefaultCellStyle.BackColor = Color.LightGray;

                    }
                }
                var indexTotal = dgDetalhado.Rows.Add();
                dgDetalhado.Rows[indexTotal].Cells[0].Value = "TOTAL PAGAR:";
                dgDetalhado.Rows[indexTotal].Cells[1].Value = itemFechamento.Datas.Sum(x => x.Produtos.Sum(y => y.VALOR_PRODUTO));
                dgDetalhado.Rows[indexTotal].DefaultCellStyle.BackColor = Color.DarkSeaGreen;


            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnEnviaEmailAdm_Click(object sender, EventArgs e)
        {
            _mail.SendMailAdms(listaDetalhado);
        }
    }
}
