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
using System.Windows.Shapes;
using LojaRoupa.ViewsModels;
using LojaRoupa.DAOs;

namespace LojaRoupa.Views.SubViews
{
    /// <summary>
    /// Interaction logic for PagarPagamento.xaml
    /// </summary>
    public partial class PagarPagamento : Window
    {
        PagamentoModel _pagamento;
        public PagarPagamento(PagamentoModel pagamento)
        {
            InitializeComponent();
            _pagamento = pagamento;
            Loaded += PagarPagamento_Loaded;

            BtnPagar.IsEnabled = pagamento.Status == "Aberto";

        }

        private void PagarPagamento_Loaded(object sender, RoutedEventArgs e)
        {
            txtData.Text = _pagamento.Data;
            txtStatus.Text = _pagamento.Status;
            txtValor.Text = _pagamento.Valor.ToString();
            txtFormaPag.Text = _pagamento.FormaPagamento;
            txtCompra.Text = _pagamento.Compra.Id.ToString();

            List<CaixaModel> lista = new List<CaixaModel>();
            try
            {
                var dao = new CaixaDAO();
                lista = dao.List("Abertos");
            }
            catch
            {
                cbNumCaixa.Text = "Não Há caixas abertos no momento";
            }
            cbNumCaixa.ItemsSource = lista;
            cbNumCaixa.SelectedIndex = 0;

            EnableOrDisableButton();
        }

        private void EnableOrDisableButton()
        {
            BtnPagar.IsEnabled = cbNumCaixa.SelectedIndex != -1;
        }

        private void BtnPagar_Click(object sender, RoutedEventArgs e)
        {
            PagamentoModel pagamento = new PagamentoModel
            {
                Id = _pagamento.Id,
                Status = "Pago",
                Hora = DateTime.Now.ToString("HH:mm:ss"),
                Valor = _pagamento.Valor,
                Data = DateTime.Now.ToString("yyyy-MM-dd")
            };
            pagamento.Caixa = cbNumCaixa.SelectedItem as CaixaModel;

            try
            {
                var dao = new PagamentoDAO();
                dao.Update(pagamento);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }
        }

        private void cbNumCaixa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EnableOrDisableButton();
        }
    }
}
