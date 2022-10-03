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
            var source = new[]
            {
                new {Descricao = "Venda short", Vencimento = "05/10/2022", Valor = "R$ 200,00", Status = "Pago"},
                new {Descricao = "Venda Camiseta", Vencimento = "02/10/2022", Valor = "R$ 1.000,00", Status = "Pago"},
                new {Descricao = "Venda short", Vencimento = "10/10/2022", Valor = "R$ 350,00", Status = "a receber"},
                new {Descricao = "Venda short", Vencimento = "05/10/2022", Valor = "R$ 200,00", Status = "Pago"},
                new {Descricao = "Venda Camiseta", Vencimento = "02/10/2022", Valor = "R$ 1.000,00", Status = "a receber"},
                new {Descricao = "Venda moletom", Vencimento = "10/10/2022", Valor = "R$ 350,00", Status = "a receber"},
                new {Descricao = "Venda short", Vencimento = "05/10/2022", Valor = "R$ 200,00", Status = "Pago"},
                new {Descricao = "Venda Camiseta", Vencimento = "02/10/2022", Valor = "R$ 1.000,00", Status = "Pago"},
                new {Descricao = "Venda Camiseta", Vencimento = "10/10/2022", Valor = "R$ 350,00", Status = "a receber"},
                new {Descricao = "Venda moletom", Vencimento = "05/10/2022", Valor = "R$ 200,00", Status = "a receber"},
                new {Descricao = "Venda Camiseta", Vencimento = "02/10/2022", Valor = "R$ 1.000,00", Status = "Pago"},
                new {Descricao = "Venda moletom", Vencimento = "10/10/2022", Valor = "R$ 350,00", Status = "a receber"},
            };
            dtgExibirReceb.ItemsSource = source;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new CaixaUC(_frame);
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
    }
}