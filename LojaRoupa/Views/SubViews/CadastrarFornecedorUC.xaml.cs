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
    /// Interação lógica para CadastrarFornecedorUC.xam
    /// </summary>
    public partial class CadastrarFornecedorUC : UserControl
    {
        private Frame _frame;
        public CadastrarFornecedorUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new FornecedorUC(_frame);
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
