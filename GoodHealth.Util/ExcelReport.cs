using GoodHealth.Model.Dto;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GoodHealth.Model.Enum.Enums;

namespace GoodHealth.Util
{
    public class ExcelReport
    {
        private string FileName { get; set; }
        private List<PagamentoDetalhadoDTO> ListFechamento { get; set; }

        public ExcelReport(string fileName, List<PagamentoDetalhadoDTO> lista)
        {
            this.FileName = fileName;
            this.ListFechamento = lista;
        }

        public void Create()
        {
            MemoryStream ms = new MemoryStream();
            if (ListFechamento.Any())
            {
                var newFile = new FileInfo(FileName);
                if (newFile.Exists)
                    newFile.Delete();

                using (var package = new ExcelPackage(newFile))
                {
                    var worksh = package.Workbook.Worksheets.Add("Fechamento");
                    DateTime dataInicio = ListFechamento.Min(x => x.Datas.Min(d => d.DATA_FECHAMENTO));
                    DateTime dataFim = ListFechamento.Max(x => x.Datas.Max(d => d.DATA_FECHAMENTO));
                    ConfigureHeader(worksh, dataInicio, dataFim);
                    SetValues(worksh, ListFechamento);

                    package.Save();
                    GoogleDrive googleDrive = new GoogleDrive();
                    googleDrive.Upload(newFile.FullName);
                }
            }
        }

        private void SetValues(ExcelWorksheet worksh, List<PagamentoDetalhadoDTO> lista)
        {
            var countSheet = 3;
            for (int x = 0; x < lista.Count; x++)
            {
                var indexSheet = x + countSheet;
                var valorTotal = lista[x].Datas.Sum(y => y.Produtos.Sum(p => p.VALOR_PRODUTO));

                worksh.Cells[indexSheet, 1].Value = lista[x].ID_USUARIO;
                worksh.Cells[indexSheet, 2].Value = lista[x].NOME;
                worksh.Cells[indexSheet, 3].Value = lista[x].EMPRESA;
                worksh.Cells[indexSheet, 4].Value = getTotalDias(eProdutos.SaladaFrutas, lista[x].Datas);
                worksh.Cells[indexSheet, 5].Value = getTotalDias(eProdutos.SaladaFrutasAdicional, lista[x].Datas);
                worksh.Cells[indexSheet, 6].Value = getTotalDias(eProdutos.SucoDetox, lista[x].Datas);
                worksh.Cells[indexSheet, 7].Value = getTotalDias(eProdutos.FrutaPicada, lista[x].Datas);
                worksh.Cells[indexSheet, 8].Value = getTotalDias(eProdutos.FrutaInteira, lista[x].Datas);
                worksh.Cells[indexSheet, 9].Style.Numberformat.Format = "R$ ###,###,##0.00";
                worksh.Cells[indexSheet, 9].Value = valorTotal;

            }
            worksh.Cells[string.Format("A{0}", lista.Count + countSheet)].Value = "Valor Total Fechamento";
            worksh.Cells[string.Format("A{0}:F{0}", lista.Count + countSheet)].Merge = true;
            worksh.Cells[string.Format("A{0}:F{0}", lista.Count + countSheet)].Style.Font.Bold = true;
            worksh.Cells[string.Format("A{0}:F{0}", lista.Count + countSheet)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            worksh.Cells[string.Format("G{0}", lista.Count + countSheet)].Value = lista.Sum(x => x.Datas.Sum(d => d.Produtos.Sum(p => p.VALOR_PRODUTO)));
            worksh.Cells[string.Format("G{0}", lista.Count + countSheet)].Style.Numberformat.Format = "R$ ###,###,##0.00";
        }

        private void ConfigureHeader(ExcelWorksheet worksh, DateTime inicio, DateTime fim)
        {
            worksh.Cells["A1:G1"].Value = string.Format("Fechamento do período {0} à {1}", inicio.ToShortDateString(), fim.ToShortDateString());
            worksh.Cells["A1:G1"].Merge = true;
            worksh.Cells["A1:G1"].Style.Font.Bold = true;
            worksh.Cells["A1:G1"].Style.Font.Color.SetColor(Color.DarkBlue);
            worksh.Cells["A1:G1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            for (int i = 1; i <= 7; i++)
                worksh.Column(i).Width = 15;

            var column = 1;
            worksh.Cells[2, column].Value = "ID";
            worksh.Cells[2, column + 1].Value = "Nome";
            worksh.Cells[2, column + 2].Value = "Empresa";
            worksh.Cells[2, column + 3].Value = "Salada de Frutas";
            worksh.Cells[2, column + 4].Value = "Salada de Frutas Adicional";
            worksh.Cells[2, column + 5].Value = "Suco";
            worksh.Cells[2, column + 6].Value = "Fruta picada";
            worksh.Cells[2, column + 7].Value = "Fruta inteira";
            worksh.Cells[2, column + 8].Value = "Valor Total";
            worksh.Cells[2, column + 9].Value = "PAGO";
        }

        private int getTotalDias(eProdutos tipoProduto, List<DataFechamentoDetalhadoDTO> datas)
        {
            int dias = 0;
            for (int i = 0; i < datas.Count; i++)
            {
                if (datas[i].Produtos.Where(x=> x.TIPO == tipoProduto).FirstOrDefault() != null)
                    dias += datas[i].Produtos.Count(x => x.TIPO == tipoProduto);
            }
            return dias;
        }
    }
}
