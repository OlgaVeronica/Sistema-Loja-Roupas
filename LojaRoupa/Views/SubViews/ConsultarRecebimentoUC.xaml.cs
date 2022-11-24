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
namespace LojaRoupa.Views.SubViews
{
    /// <summary>
    /// Interação lógica para ConsultarRecebimentoUC.xam
    /// </summary>
    public partial class ConsultarRecebimentoUC : UserControl
    {
        public Frame _frame;
        private List<RecebimentoModel> _recebimentosInGrid;
        public ConsultarRecebimentoUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            Loaded += ConsultarRecebimentoUC_loaded;
        }

        private void ConsultarRecebimentoUC_loaded(object sender, RoutedEventArgs e)
        {
            AtualizarLista();
            cbFilters.SelectedIndex = 0;
        }

        private void AtualizarLista()
        {
            try
            {
                var dao = new RecebimentoDAO();
                _recebimentosInGrid = dao.List();
                dtgExibirReceb.ItemsSource = _recebimentosInGrid;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao recuperar Listagem {ex.Message}");
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new FinanceiroUC(_frame);
        }

        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            FiltrarDespesa();
        }

        private void FiltrarDespesa()
        {
            //dt.ItemsSource = string.Format("[{0}] LIKE '%{1}%'", "Descrição", txtPesquisarDesp.Text);
        }

        private void Button_Alter_Click(object sender, RoutedEventArgs e)
        {
            var thing = dtgExibirReceb.SelectedItem;
        }

        private void Button_Recipt_Click(object sender, RoutedEventArgs e)
        {
            var thing = dtgExibirReceb.SelectedItem;
        }

        

        private void btnReceber_Click(object sender, RoutedEventArgs e)
        {
            ReceberRecebimentoWindow tela = new ReceberRecebimentoWindow(dtgExibirReceb.SelectedItem as RecebimentoModel);
            tela.ShowDialog();
            AtualizarLista();

        }

        private void txtPesquisarReceb_TextChanged(object sender, TextChangedEventArgs e)
        {
            var txt = txtPesquisarReceb;
            string filter = cbFilters.Text;
            string rdChecked = rdAbertos.IsChecked == true? "Aberto" : "";
            rdChecked = rdRecebidos.IsChecked != true ? rdChecked : "Recebido";


            List<RecebimentoModel> list = _recebimentosInGrid;

            if (!String.IsNullOrWhiteSpace(txt.Text))
            {

                List<RecebimentoModel> listaFiltrada = list.FindAll(item =>
                { 
                    if(filter == "Data")
                    {
                        return item.DataAbertura.ToLower().Contains(txt.Text.ToLower()) && item.StatusReceb.ToLower().Contains(rdChecked.ToLower());

                    }
                    else if(filter == "Id")
                    {
                        return item.Id.ToString().Contains(txt.Text.ToLower()) && item.StatusReceb.ToLower().Contains(rdChecked.ToLower());

                    }
                    else if(filter == "Caixa")
                    {
                        return item.Caixa.Numero.ToString().Contains(txt.Text.ToLower()) && item.StatusReceb.ToLower().Contains(rdChecked.ToLower());
                    }
                    else
                    {
                        return item.Venda.Id.ToString().Contains(txt.Text.ToLower()) && item.StatusReceb.ToLower().Contains(rdChecked.ToLower());

                    }
                });

                dtgExibirReceb.ItemsSource = listaFiltrada;
            }
            else
            {
                dtgExibirReceb.ItemsSource = _recebimentosInGrid;
            }
        }

        private void cbFilters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void rdAbertos_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rdRecebidos_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rdTodos_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}