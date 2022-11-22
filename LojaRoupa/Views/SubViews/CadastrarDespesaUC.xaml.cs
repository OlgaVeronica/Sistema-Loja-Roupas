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

namespace LojaRoupa.Views.SubViews
{
    /// <summary>
    /// Interação lógica para CadastrarDespesaUC.xam
    /// </summary>
    public partial class CadastrarDespesaUC : UserControl
    {
        public Frame _frame;

        public CadastrarDespesaUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            Loaded += CadastrarDespesaUC_Loaded;
        }

        private void CadastrarDespesaUC_Loaded (object sender, RoutedEventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new ExibirDespesasUC(_frame);
        }

        private void btnCadastrarDesp_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
