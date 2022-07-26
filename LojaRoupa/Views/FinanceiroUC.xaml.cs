﻿using System;
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
using LojaRoupa.Views.SubViews;
using LojaRoupa.ViewsModels;
using LojaRoupa.DAOs;
using MySql.Data.MySqlClient;


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

        private void dtgFinanceiro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRelatorio_Click(object sender, RoutedEventArgs e)
        {

            RelatorioCompra tela = new RelatorioCompra();
            tela.Show();


        }   
        private void btnRealizarCompra_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new RealizarCompraUC(_frame);
        }

        private void btnCadastrarPagamento_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new CadastrarPagamento(_frame);
        }

        private void btnRecebimentos_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new ConsultarRecebimentoUC(_frame);
        }
    }
}
