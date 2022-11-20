using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LojaRoupa.Views;
using LojaRoupa.Views.SubViews;
using LojaRoupa.ViewsModels;
using LojaRoupa.DAOs;
using MySql.Data.MySqlClient;
//using iTextSharp;
//using iTextSharp.text;
//using iTextSharp.text.pdf;

namespace LojaRoupa.Views
{
    /// <summary>
    /// Interação lógica para FinanceiroUC.xam
    /// </summary>
    public partial class FinanceiroUC : UserControl
    {
        public Frame _frame;

        public FinanceiroUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }

        private void btnExibirDesp_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new ExibirDespesasUC(_frame);
        }

        private void btnExibirReceb_Click(object sender, RoutedEventArgs e)
        {
           _frame.Content = new ConsultarRecebimentoUC(_frame);

        }

        private void dtgFinanceiro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRelatorio_Click(object sender, RoutedEventArgs e)
        {   /*
            //Criar objeto PDFViewer
            PdfViewer viewer = new PdfViewer();
            //Abrir arquivo PDF de entrada
            viewer.BindPdf(dataDir + "Test.pdf");
            //Imprimir documento PDF
            viewer.PrintDocument();
            //Fechar arquivo PDF
            viewer.Close();*/

            //string arquivo = PdfViewer

            /*FileStream arquivoPDF = new FileStream(arquivoPDF, FileMode.Create);
            Document doc = new Document(PageSize.A4);
            PdfWriter escritorPDF = PdfWriter.GetInstance(doc, arquivoPDF);

            string dados = "";

            Paragraph paragrafo = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14/*, (int)System.Drawing.FontStyle.Bold));
            paragrafo.Alignment = Element.ALIGN_CENTER;
            paragrafo.Add("RELATÓRIO\n");

            paragrafo.Font = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12/*, (int)System.Drawing.FontStyle.Bold);
            paragrafo.Alignment = Element.ALIGN_CENTER;
            paragrafo.Add("variáveis");

            string texto = "variáveis2variáveis2variáveis";
            paragrafo.Font = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 12/*, (int)System.Drawing.FontStyle.Bold);
            paragrafo.Alignment = Element.ALIGN_LEFT;
            paragrafo.Add(texto + "\n");

            doc.Open();
            doc.Add(paragrafo);
            doc.Close();*/
        }   
        private void btnRealizarCompra_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new RealizarCompraUC(_frame);
        }
    }
}
