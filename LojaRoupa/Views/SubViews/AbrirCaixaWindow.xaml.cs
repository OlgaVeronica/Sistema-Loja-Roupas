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
using System.Windows.Shapes;
using LojaRoupa.ViewsModels;
using LojaRoupa.DAOs;

namespace LojaRoupa.Views.SubViews
{
    /// <summary>
    /// Lógica interna para AbrirCaixaWindow.xaml
    /// </summary>
    public partial class AbrirCaixaWindow : Window
    {
        public CaixaModel Caixa = new CaixaModel();

        public double SaldoInicial { get; private set; } = 0.0;

        public AbrirCaixaWindow(CaixaModel caixa)
        {
            InitializeComponent();
            //_caixa = caixa;
            Loaded += AbrirCaixaWindow_Loaded;
        }

        private void AbrirCaixaWindow_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Cadastrar_Click(object sender, RoutedEventArgs e)
        {
            CaixaModel caixa = new CaixaModel();
            //_caixa.SaldoInicial = double.Parse(txtValor.Text);
            SaldoInicial = double.Parse(txtValor.Text);
            caixa.SaldoInicial = SaldoInicial;

            try
            {
                var dao = new CaixaDAO();
                dao.Insert(caixa);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Não foi possível Abrir caixa {ex.Message}", "Erro ao Abrir caixa", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            this.Close();
        }
    }
}
