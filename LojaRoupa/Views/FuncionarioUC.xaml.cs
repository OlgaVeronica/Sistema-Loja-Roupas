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
using MySql.Data.MySqlClient;

namespace LojaRoupa.Views
{
    /// <summary>
    /// Interação lógica para FuncionarioUC.xam
    /// </summary>
    public partial class FuncionarioUC : UserControl
    {
        public Frame _frame;

        public FuncionarioUC(Frame frame)
        {

            InitializeComponent();
            _frame = frame;
            Loaded += FuncionarioUC_Loaded;

            
        }

        private void FuncionarioUC_Loaded(object sender, RoutedEventArgs e)
        {
           

            try
            {
                var dao = new FuncionarioDAO();
                dtgFuncionarios.ItemsSource = dao.List();

            } catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new CadastrarFuncionarioUC(_frame);
        }

        private void dtgFuncionarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnEditFunc_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new EditarFuncionarioUC(_frame);
        }
    }
}
