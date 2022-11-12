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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LojaRoupa.DAOs;
using LojaRoupa.Views.SubViews;
using LojaRoupa.ViewsModels;
using MySql.Data.MySqlClient;
using System.Diagnostics.Eventing.Reader;

namespace LojaRoupa.Views
{
    /// <summary>
    /// Interação lógica para FuncionarioUC.xam
    /// </summary>
    public partial class FuncionarioUC : UserControl
    {
        public Frame _frame;
        private List<FuncionarioModel> _productsInGrid;
        public FuncionarioUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            Loaded += FuncionarioUC_Loaded;            
        }

        private void FuncionarioUC_Loaded(object sender, RoutedEventArgs e)
        {
            carregarListagem();
        }

        private void carregarListagem()
        {
            try
            {
                var dao = new FuncionarioDAO();
                _productsInGrid = dao.List();
                dtgFuncionarios.ItemsSource = dao.List();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new CadastrarFuncionarioUC(_frame);
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var funcionario = dtgFuncionarios.SelectedItem as FuncionarioModel;
                var resultado = MessageBox.Show($"Deseja realmente excluir \"{funcionario.Nome}\" dos registros?", "Confirmação de Exclusão",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);


                if (resultado == MessageBoxResult.Yes)
                {
                    var dao = new FuncionarioDAO();
                    dao.Delete(funcionario);
                    MessageBox.Show("Funcionário deletado com sucesso");
                    carregarListagem();
                }
            } catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            var funcionario = dtgFuncionarios.SelectedItem as FuncionarioModel;

            _frame.Content = new CadastrarFuncionarioUC(_frame, funcionario);
        }

        private void dtgFuncionarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnEditFunc_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new EditarFuncionarioUC(_frame);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var txt = txtFilter;
            List<FuncionarioModel> list = _productsInGrid;

            if (!String.IsNullOrWhiteSpace(txt.Text))
            {
                List<FuncionarioModel> listaFiltrada = list.FindAll(item =>
                {
                    return item.Nome.ToLower().StartsWith(txt.Text.ToLower());
                });

                dtgFuncionarios.ItemsSource = listaFiltrada;
            }
            else
            {
                dtgFuncionarios.ItemsSource = _productsInGrid;
            }

        }
    }
}
