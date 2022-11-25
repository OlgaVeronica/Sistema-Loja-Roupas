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
using LojaRoupa.DAOs;
using LojaRoupa.ViewsModels;
using MySql.Data.MySqlClient;

namespace LojaRoupa.Views.SubViews
{
    /// <summary>
    /// Interação lógica para CadastrarPagamento.xam
    /// </summary>
    public partial class CadastrarPagamento : UserControl
    {
        public Frame _frame;
        private List<PagamentoModel> _pagamentosInGrid;

        public CadastrarPagamento(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            Loaded += CadastrarPagamento_Loaded;
        }

        private void CadastrarPagamento_Loaded(object sender, RoutedEventArgs e)
        {
            AtualizarLista();
            cbFilters.SelectedIndex = 0;
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new FinanceiroUC(_frame); 
        }

        private void Button_Alter_Click(object sender, RoutedEventArgs e)
        {
            var thing = dtgExibirPag.SelectedItem;
        }

        private void Button_Recipt_Click(object sender, RoutedEventArgs e)
        {
            var thing = dtgExibirPag.SelectedItem;
        }

        private void btnPagar_Click(object sender, RoutedEventArgs e)
        {
            PagarPagamento tela = new PagarPagamento(dtgExibirPag.SelectedItem as PagamentoModel);
            tela.ShowDialog();
            AtualizarLista();
        }

        private void AtualizarLista()
        {
            try
            {
                var dao = new PagamentoDAO();
                _pagamentosInGrid = dao.List();
                dtgExibirPag.ItemsSource = _pagamentosInGrid;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao recuperar Listagem {ex.Message}");
            }
        }

        private void txtPesquisarReceb_TextChanged(object sender, TextChangedEventArgs e)
        {
            AtualizarFiltro();
        }

        private void AtualizarFiltro()
        {
            var txt = txtPesquisarPag;
            string filter = cbFilters.Text;
            string rdChecked = rdAbertos.IsChecked == true ? "Aberto" : "";
            rdChecked = rdPagos.IsChecked != true ? rdChecked : "Pago";


            List<PagamentoModel> list = _pagamentosInGrid;

            if (!String.IsNullOrWhiteSpace(txt.Text))
            {

                List<PagamentoModel> listaFiltrada = list.FindAll(item =>
                {
                    if (filter == "Data")
                    {
                        return item.Data.ToLower().Contains(txt.Text.ToLower()) && item.Status.ToLower().Contains(rdChecked.ToLower());

                    }
                    else if (filter == "Id")
                    {
                        return item.Id.ToString().Contains(txt.Text.ToLower()) && item.Status.ToLower().Contains(rdChecked.ToLower());

                    }
                    else if (filter == "Caixa")
                    {
                        return item.Caixa.Numero.ToString().Contains(txt.Text.ToLower()) && item.Status.ToLower().Contains(rdChecked.ToLower());
                    }
                    else
                    {
                        return item.Compra.Id.ToString().Contains(txt.Text.ToLower()) && item.Status.ToLower().Contains(rdChecked.ToLower());

                    }
                });

                dtgExibirPag.ItemsSource = listaFiltrada;
            }
            else
            {
                dtgExibirPag.ItemsSource = _pagamentosInGrid;
            }
        }

        private void cbFilters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AtualizarFiltro();
        }

        private void rdAbertos_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void rdPagos_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void rdTodos_Checked(object sender, RoutedEventArgs e)
        {
        }
    }
}
