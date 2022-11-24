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


namespace LojaRoupa.Views.SubViews
{
    /// <summary>
    /// Interação lógica para CadastrarCaixaUC.xam
    /// </summary>
    public partial class CadastrarCaixaUC : UserControl
    {
        public Frame _frame;
        private CaixaModel _caixaModel = new CaixaModel();
        

        public CadastrarCaixaUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            Loaded += CadastrarCaixaUC_Loaded;
        }

        private void CadastrarCaixaUC_Loaded(object sender, RoutedEventArgs e)
        {
            txtSaldoInicial.Text = _caixaModel.SaldoInicial.ToString();
            txtSaldoFinal.Text = _caixaModel.SaldoFinal.ToString();
            txtTotalEntrada.Text = _caixaModel.TotalEntrada.ToString();
            txtTotalSaida.Text = _caixaModel.TotalSaida.ToString();
            txtNumeroCaixa.Text = _caixaModel.Numero.ToString();
            txtStatus.Text = _caixaModel.Status; 
        }

        public void VerificarCaixa()
        {

        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new CaixaUC(_frame);
        }

        private void btnAbrirCaixa_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFecharCaixa_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
