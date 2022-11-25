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
    }
}
