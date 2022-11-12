using LojaRoupa.Views.SubViews;
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
using System.Diagnostics.Eventing.Reader;

namespace LojaRoupa.Views
{
    /// <summary>
    /// Interação lógica para FornecedorUC.xam
    /// </summary>
    public partial class FornecedorUC : UserControl
    {
        public Frame _frame;
        private List<FornecedorModel> _productsInGrid;
        public FornecedorUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            Loaded += FornecedorUC_Loaded;
        }
        private void FornecedorUC_Loaded(object sender, RoutedEventArgs e)
        {
            carregarListagem();
        }
        private void carregarListagem()
        {
            try
            {
                var dao = new FornecedorDAO();
                _productsInGrid = dao.List();
                dtgFornecedor.ItemsSource = dao.List();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var fornecedor = dtgFornecedor.SelectedItem as FornecedorModel;
                var resultado = MessageBox.Show($"Deseja realmente excluir \"{fornecedor.NomeFantasia}\" dos registros?", "Confirmação de Exclusão",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);


                if (resultado == MessageBoxResult.Yes)
                {
                    var dao = new FornecedorDAO();
                    dao.Delete(fornecedor);
                    MessageBox.Show("Fornecedor deletado com sucesso");
                    carregarListagem();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            var fornecedor = dtgFornecedor.SelectedItem as FornecedorModel;

            _frame.Content = new CadastrarFornecedorUC(_frame, fornecedor);
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new CadastrarFornecedorUC(_frame);
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var txt = txtFilter;
            List<FornecedorModel> list = _productsInGrid;

            if (!String.IsNullOrWhiteSpace(txt.Text))
            {

                List<FornecedorModel> listaFiltrada = list.FindAll(item =>
                {
                    return item.NomeFantasia.ToLower().StartsWith(txt.Text.ToLower());
                });

                dtgFornecedor.ItemsSource = listaFiltrada;
            }
            else
            {
                dtgFornecedor.ItemsSource = _productsInGrid;
            }

        }
    }
}
