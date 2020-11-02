using DevExpress.XtraPrinting;
using System.Collections;
using System.Web.Mvc;
using WebApp_DevExpressReport_4._5.Models;

namespace WebApp_DevExpressReport_4._5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Report()
        {
            // DevExpress.Net.17.2.7 é compativel como .Net Framework 4.5
            //
            // DevExpress.XtraReports.UI.XtraReport -> Dependencias:
            //   Library/DevExpress.Charts.v17.2.Core.dll
            //   Library/DevExpress.Data.v17.2.dll
            //   Library/DevExpress.DataAccess.v17.2.dll
            //   Library/DevExpress.Office.v17.2.Core.dll
            //   Library/DevExpress.Pdf.v17.2.Core.dll
            //   Library/DevExpress.PivotGrid.v17.2.Core.dll
            //   Library/DevExpress.Printing.v17.2.Core.dll
            //   Library/DevExpress.RichEdit.v17.2.Core.dll
            //   Library/DevExpress.RichEdit.v17.2.Export.dll
            //   Library/DevExpress.Sparkline.v17.2.Core.dll
            //   Library/DevExpress.Web.ASPxThemes.v17.2.dll
            //   Library/DevExpress.Web.Mvc5.v17.2.dll
            //   Library/DevExpress.Web.Resources.v17.2.dll
            //   Library/DevExpress.Web.v17.2.dll
            //   Library/DevExpress.Xpo.v17.2.dll
            //   Library/DevExpress.XtraCharts.v17.2.dll
            //   Library/DevExpress.XtraCharts.v17.2.Web.dll
            //   Library/DevExpress.XtraGauges.v17.2.Core.dll
            //   Library/DevExpress.XtraReports.v17.2.dll
            //   Library/DevExpress.XtraReports.v17.2.Web.dll

            // Criando o objeto XtraReport, que representa o relatório.
            DevExpress.XtraReports.UI.XtraReport report = new DevExpress.XtraReports.UI.XtraReport();

            // Arquivo repx que contém o layout do relatório.
            var reportPath = Server.MapPath("~/Reports/XtraReport.repx");

            // Criando um business object com os dados para o relatório.
            var listDataSource = new ArrayList();

            for (int i = 0; i < 200; i++)
            {
                var index = i + 1;

                listDataSource.Add(new ReportProduto
                {
                    ID = index,
                    Descricao = $"Produto {index.ToString("D2")}",
                    Marca = $"Marca {index.ToString("D2")}",
                    Foto = $"Foto {index.ToString("D2")}"
                });
            }

            // Informando para o DataSource do relatório qual será os dados.
            report.DataSource = listDataSource;

            // Configurado o arquivo repx como arquivo de layout.
            report.LoadLayout(reportPath);

            // Passando o XtraReports configurado para a View.
            ViewData["Report1"] = report;

            return View();
        }

        public ActionResult Pdf()
        {
            // Criando o objeto XtraReport, que representa o relatório.
            DevExpress.XtraReports.UI.XtraReport report = new DevExpress.XtraReports.UI.XtraReport();

            // Arquivo repx que contém o layout do relatório.
            string reportPath = Server.MapPath("~/Reports/XtraReport.repx");

            // Criando um business object com os dados para o relatório.
            ArrayList listDataSource = new ArrayList();

            for (int i = 0; i < 200; i++)
            {
                var index = i + 1;

                listDataSource.Add(new ReportProduto
                {
                    ID = index,
                    Descricao = $"Produto {index.ToString("D2")}",
                    Marca = $"Marca {index.ToString("D2")}",
                    Foto = $"Foto {index.ToString("D2")}"
                });
            }

            // Informando para o DataSource do relatório qual será os dados.
            report.DataSource = listDataSource;

            // Configurado o arquivo repx como arquivo de layout.
            report.LoadLayout(reportPath);

            // Informando onde será gerado o arquivo pdf.
            var pdfExportFile = Server.MapPath("~/Files/Pdf/XtraReport.pdf");

            // Configurando as opções de exportação do pdf.
            PdfExportOptions options = new PdfExportOptions();
            options.PdfACompatibility = PdfACompatibility.PdfA1b;

            // Exportando o arquivo pdf.
            report.ExportToPdf(pdfExportFile, options);

            return View();
        }
    }
}