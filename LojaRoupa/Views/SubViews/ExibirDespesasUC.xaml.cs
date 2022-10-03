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
    /// Interação lógica para ExibirDespesasUC.xam
    /// </summary>
    public partial class ExibirDespesasUC : UserControl
    {
        public Frame _frame;

        public ExibirDespesasUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            Loaded += ExibirDespesasUC_loaded;
        }

        private void ExibirDespesasUC_loaded(object sender, RoutedEventArgs e)
        {
            var despesas = new[]
            {
                new {Descrição = "Conta de Água", Vencimento = "05/10/2022", Valor = "R$ 200,00"},
                new {Descrição = "Conta de Energia", Vencimento = "02/10/2022", Valor = "R$ 1.000,00"},
                new {Descrição = "Conta de Internet", Vencimento = "10/10/2022", Valor = "R$ 350,00"},
            };

            dtgExibirDesp.ItemsSource = despesas;
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new FinanceiroUC(_frame);
        }

        private void dtgExibirDesp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

    }
}
