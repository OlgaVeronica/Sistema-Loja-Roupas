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

        public class Despesas
        {
        string Descricao {get;set;}
        string Tipo { get; set; }
        string Vencimento {get; set; }
        string Valor{get; set; }
        string Status {get; set; }
        }
        private void ExibirDespesasUC_loaded(object sender, RoutedEventArgs e)
        {
            var despesas = new[]
            {
                new {Descricao = "Conta de Água", Tipo = "Conta", Vencimento = "05/10/2022", Valor = "R$ 200,00", Status = "Pago"},
                new {Descricao = "Conta de Energia", Tipo = "Conta", Vencimento = "02/10/2022", Valor = "R$ 1.000,00", Status = "Pago"},
                new {Descricao = "Conta de Internet", Tipo = "Conta", Vencimento = "10/10/2022", Valor = "R$ 350,00", Status = "Pago"},
            };

            dtgExibirDesp.ItemsSource = despesas;
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new FinanceiroUC(_frame);
        }
        private void Button_Alter_Click(object sender, RoutedEventArgs e)
        {
            var thing = dtgExibirDesp.SelectedItem;

        }

        private void dtgExibirDesp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }

        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            FiltrarDespesa();
        }

        private void FiltrarDespesa()
        {
              dtgExibirDesp.ItemsSource = string.Format("[{0}] LIKE '%{1}%'", "Descrição", txtPesquisarDesp.Text);
        }

        private void btnCadastrarDesp_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new CadastrarDespesaUC(_frame);
        }
    }
}
