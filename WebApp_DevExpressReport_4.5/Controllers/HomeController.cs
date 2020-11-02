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