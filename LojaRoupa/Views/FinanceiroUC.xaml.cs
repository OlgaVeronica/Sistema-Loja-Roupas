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
using LojaRoupa.Views;
using LojaRoupa.ViewsModels;
using LojaRoupa.Views.SubViews;

namespace LojaRoupa.Views
{
    /// <summary>
    /// Interação lógica para FinanceiroUC.xam
    /// </summary>
    public partial class FinanceiroUC : UserControl
    {
        public Frame _frame;

        public FinanceiroUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }

        private void btnExibirDesp_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new ExibirDespesasUC(_frame);
        }
    }
}
