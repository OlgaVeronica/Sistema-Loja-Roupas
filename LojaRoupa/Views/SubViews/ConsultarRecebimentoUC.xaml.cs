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
        public ConsultarRecebimentoUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            Loaded += ConsultarRecebimentoUC_loaded;
        }

        private void ConsultarRecebimentoUC_loaded(object sender, RoutedEventArgs e)
        {
            AtualizarLista();
        }

        private void AtualizarLista()
        {
            try
            {
                var dao = new RecebimentoDAO();

                dtgExibirReceb.ItemsSource = dao.List();

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
        }
    }
}