using GoodHealth.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace GoodHealth.Util
{
    
    public class Mail
    {
        public string MailSmtpHost { get; set; }
        public int MailSmtpPort { get; set; }
        public string MailSmtpUsername { get; set; }
        public string MailSmtpPassword { get; set; }
        public string MailFrom { get; set; }

        private const string styleMail = @"<style>
                        body {
                            padding: $base-spacing-unit;
                            font-family: 'Source Sans Pro', sans-serif;
                            margin: 0;
                        }

                        h1, h2, h3, h4, h5, h6, label {
                            margin: 0;
                            font-family: 'Times New Roman', Times, serif;
                            font-size: 12px;
                        }

                        .container {
                            max-width: 1000px;
                            margin-right: auto;
                            margin-left: auto;
                            display: flex;
                            justify-content: center;
                            align-items: center;
                            min-height: 100vh;
                        }
                        .table2 {
                            width: 60%;
                            border: 1px solid $color-form-highlight;
                        }

                        .table {
                            width: 50%;
                            border: 1px solid $color-form-highlight;
                        }

                        .table-header {
                            display: flex;
                            width: 100%;
                            background: #000;
                            padding: ($half-spacing-unit * 1.5) 0;
                        }

                        .table-row {
                            display: flex;
                            width: 100%;
                            padding: ($half-spacing-unit * 1.5) 0;
                            &:nth-of-type(odd)

                        {
                            background: $color-form-highlight;
                        }

                        }

                        .table-data, .header__item {
                            flex: 2 2 50%;
                            text-align: center;
                            font-size: 12px;
                        }

                        .header__item {
                            text-transform: uppercase;
                        }

                        .filter__link {
                            color: white;
                            text-decoration: none;
                            position: relative;
                            display: inline-block;
                            padding-left: $base-spacing-unit;
                            padding-right: $base-spacing-unit;
                            &::after

                        {
                            content: '';
                            position: absolute;
                            right: -($half-spacing-unit * 1.5);
                            color: white;
                            font-size: $half-spacing-unit;
                            top: 50%;
                            transform: translateY(-50%);
                        }

                        &.desc::after {
                            content: '(desc)';
                        }

                        &.asc::after {
                            content: '(asc)';
                        }
                        }
                    </style>";

        public bool SendEmail(string to, string subject, string body)
        {
            MailMessage mail = new MailMessage(MailFrom, to, subject, body);
            var alternameView = AlternateView.CreateAlternateViewFromString(body, new ContentType("text/html"));
            mail.AlternateViews.Add(alternameView);

            var smtpClient = new SmtpClient(MailSmtpHost, MailSmtpPort);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(MailSmtpUsername, MailSmtpPassword);
            try
            {
                smtpClient.Send(mail);
            }
            catch (Exception e)
            {
                //Log error here
                return false;
            }

            return true;
        }

        public bool SendEmail(PagamentoDetalhadoDTO objPagamento, string subject, string body)
        {
            MailMessage Email = new MailMessage();
            Attachment anexo = GetAnexo(objPagamento);

            Email.From = new MailAddress(MailFrom, "GoodHealth"); // Remetente
            Email.Subject = subject; // Assunto do e-mail
            Email.Body = body; // Conteudo do e-mail
            Email.To.Add(objPagamento.EMAIL);

            Email.Attachments.Add(anexo);
            Email.IsBodyHtml = true;
            //  MailMessage mail = new MailMessage(MailFrom, objPagamento.EMAIL, subject, body);

            var alternameView = AlternateView.CreateAlternateViewFromString(body, new ContentType("text/html"));
            Email.AlternateViews.Add(alternameView);

            var smtpClient = new SmtpClient(MailSmtpHost, MailSmtpPort);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(MailSmtpUsername, MailSmtpPassword);
            try
            {
                smtpClient.Send(Email);
            }
            catch (Exception e)
            {
                //Log error here
                return false;
            }

            return true;
        }

        private Attachment GetAnexo(PagamentoDetalhadoDTO objPagamento)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.IO.StreamWriter writer = new System.IO.StreamWriter(ms);

            writer.Write(string.Format("Olá {0} ", objPagamento.NOME));
            writer.Write(writer.NewLine);
            writer.Write("Segue seu datalhamento do mês.");
            writer.Write(writer.NewLine);
            foreach (var item in objPagamento.Datas)
            {
                writer.Write(writer.NewLine);
                writer.WriteLine(string.Format("Data {0} - {1}", item.DATA_FECHAMENTO.ToShortDateString(), item.DATA_FECHAMENTO.ToString("dddd")));
                decimal totalDia = 0;
                foreach (var produto in item.Produtos)
                {
                    writer.WriteLine(string.Format("Produto {0} | Valor R$ {1}", produto.DESCRICAO_PRODUTO, produto.VALOR_PRODUTO.ToString()));
                    totalDia += produto.VALOR_PRODUTO;
                }
                writer.WriteLine(string.Format("Total: R$ {0}", totalDia));
                writer.WriteLine("#######################################################");
            }
            writer.WriteLine(string.Format("TOTAL A PAGAR: R$ {0}", objPagamento.Datas.Sum(x => x.Produtos.Sum(y => y.VALOR_PRODUTO))));
            writer.Flush();
            ms.Position = 0;

            Attachment anexo = new Attachment(ms, "FechamentoDetalhado.txt", "text/*");
            return anexo;
        }

        public string RetornarHtlmEmail(PagamentoDetalhadoDTO item, PeriodoDTO perido, int qtdAusencias)
        {
            string head = string.Format(@"<label>Olá {0}, boa noite!</label><br />
                    <label>Estamos enviando o valor do seu período de {1} {2}.</label><br />
                    <label>Caso já tenha realizado o pagamento, favor desconsiderar este e-mail.</label><br /><br />
                    <label>Caso ainda não tenha enviado o comprovante, pedimos que nos encaminhe respondendo este e-mail ou se preferir através do Whatsapp 31 99998-1128.</label><br />
                    <label>* Em anexo segue seu fechamento detalhado.</label>                
                    <br /><br />
                    
                    <div><table class='table'>
                            <thead>
                                <tr class='table-header' style='background-color:cadetblue'>
                                    <th class='header__item'>Quantidade de dias período</th>
                                    <th class='header__item'>Quantidade de dias ausentes</th>
                                    <th class='header__item'>Valor total</th>
                                </tr>
                            </thead>", item.NOME, perido.NOME, string.Format("[{0} a {1}]", perido.DATA_INICIO.ToShortDateString(), perido.DATA_FIM.ToShortDateString()) );
            string body = string.Format(@"<tbody>
                                            <tr class='table-row' style='background-color:gainsboro'>
                                                <td class='table-data'>{0}</td>
                                                <td class='table-data'>{1}</td>
                                                <td class='table-data'>R$ {2}</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <hr />
                    </div>", item.Datas.Count, qtdAusencias, item.Datas.Sum(x => x.Produtos.Sum(y => y.VALOR_PRODUTO)));
            string foot = @"<br />
                    <h3>Formas de pagamento</h3>
                    <div>
                        <table class='table2'>
                        <thead>
                            <tr class='table-header' style='background-color:lightsteelblue'>
                                <th class='header__item'>Banco</th>
                                <th class='header__item'>Agência</th>
                                <th class='header__item'>Conta</th>
                                <th class='header__item'>CPF</th>
                                <th class='header__item'>Nome</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr class='table-row' style='background-color:orange'>
                                <td class='table-data'><b>Itaú</b></td>
                                <td class='table-data'>6590</td>
                                <td class='table-data'>16076-5</td>
                                <td class='table-data'>070.264.626-10</td>
                                <td class='table-data'>Jouberth Givan Andrade</td>
                            </tr>
                            <tr class='table-row' style='background-color:yellow'>
                                <td class='table-data'><b>Banco do Brasil</b></td>
                                <td class='table-data'>3610-2</td>
                                <td class='table-data'>49761-4</td>
                                <td class='table-data'>102.402.566-70</td>
                                <td class='table-data'>Ana Paula Barbosa Pinheiro</td>
                            </tr>
                            <tr class='table-row' style='background-color:cornflowerblue'>
                                <td class='table-data'><b>Mercantil do Brasil(389)</b></td>
                                <td class='table-data'>0216-7</td>
                                <td class='table-data'>01014166-3</td>
                                <td class='table-data'>712.740.226-49</td>
                                <td class='table-data'>Marcos de Souza Oliveira</td>
                            </tr>
                        </tbody>
                    </table>
                    <hr />
                    </div>
                    <br /><br />
                    <label> <u>Agradecemos sua compreensão.</u></label>
                    <br /><br />
                    <label>Muito obrigada! ☺</label>
                    <br /><br />
                    <h4>Atenciosamente,</h4>
                    <h4>Equipe Good Health</h4>";

            return styleMail + head + body + foot;
        }

        public string RetornaEmailComunicado()
        {
            string email = @"<style>
	                    body {
		                    padding: $base-spacing-unit;
		                    font-family: 'Source Sans Pro', sans-serif;
		                    margin: 0;
	                    }

	                    h1, h2, h3, h4, h5, h6, label {
		                    margin: 0;
		                    font-family: 'Times New Roman', Times, serif;
		                    font-size: 12px;
	                    }

	                    .container {
		                    max-width: 1000px;
		                    margin-right: auto;
		                    margin-left: auto;
		                    display: flex;
		                    justify-content: center;
		                    align-items: center;
		                    min-height: 100vh;
	                    }
	                    .table2 {
		                    width: 60%;
		                    border: 1px solid $color-form-highlight;
	                    }

	                    .table {
		                    width: 50%;
		                    border: 1px solid $color-form-highlight;
	                    }

	                    .table-header {
		                    display: flex;
		                    width: 100%;
		                    background: #000;
		                    padding: ($half-spacing-unit * 1.5) 0;
	                    }

	                    .table-row {
		                    display: flex;
		                    width: 100%;
		                    padding: ($half-spacing-unit * 1.5) 0;
		                    &:nth-of-type(odd)

	                    {
		                    background: $color-form-highlight;
	                    }

	                    }

	                    .table-data, .header__item {
		                    flex: 2 2 50%;
		                    text-align: center;
		                    font-size: 12px;
	                    }

	                    .header__item {
		                    text-transform: uppercase;
	                    }

	                    .filter__link {
		                    color: white;
		                    text-decoration: none;
		                    position: relative;
		                    display: inline-block;
		                    padding-left: $base-spacing-unit;
		                    padding-right: $base-spacing-unit;
		                    &::after

		                    {
			                    content: '';
			                    position: absolute;
			                    right: -($half-spacing-unit * 1.5);
			                    color: white;
			                    font-size: $half-spacing-unit;
			                    top: 50%;
			                    transform: translateY(-50%);
		                    }

		                    &.desc::after {
			                    content: '(desc)';
		                    }

		                    &.asc::after {
			                    content: '(asc)';
		                    }
	                    }
                    </style>


                    <h2>Boa noite, Cliente Good Health!</h2><br />
                    <label>Infelizmente ainda não conseguimos abastecer nosso estoque, nossos fornecedores ainda não possuem os produtos e para nao afetar nossa qualidade, não iremos realizar a entrega dos kits também amanhã quarta-feira 30/05/2018.</label><br /><br />
                    <label>Pedimos sua compreensão. Caso conseguirmos abastecer nosso estoque, voltaremos com as entregas na sexta-feira.</label> <br />
                    <label>Muito obrigado.</label> <br />
                    <br />
                    <h4>Atenciosamente,</h4>
                    <h4>Equipe Good Health</h4>";

            return email;
        }
    }
}
