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

namespace LojaRoupa.Views
{
    /// <summary>
    /// Interação lógica para FornecedorUC.xam
    /// </summary>
    public partial class FornecedorUC : UserControl
    {
        public Frame _frame;

        public FornecedorUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
