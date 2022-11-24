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
using LojaRoupa.DAOs;
using LojaRoupa.ViewsModels;
using MySql.Data.MySqlClient;

namespace LojaRoupa.Views.SubViews
{
    /// <summary>
    /// Interação lógica para CadastrarPagamento.xam
    /// </summary>
    public partial class CadastrarPagamento : UserControl
    {
        public Frame _frame;
        private List<PagamentoModel> _productsInGrid;
        PagamentoModel _pagamento;

        public CadastrarPagamento(Frame frame)
        {
            InitializeComponent();
            Loaded += CadastrarPagamento_Loaded;
        }

        private void CadastrarPagamento_Loaded(object sender, RoutedEventArgs e)
        {
            carregarListagem();
        }
            //VERIFICAÇÃO DE NLO OU VAZIO DE PAGAMENTO

            /*if (
                String.IsNullOrWhiteSpace(txtNomeLoja.Text) ||
                String.IsNullOrWhiteSpace(txtCnpjLoja.Text) ||
                String.IsNullOrWhiteSpace(txtRuaLoja.Text) ||
                String.IsNullOrWhiteSpace(txtBairroLoja.Text) ||
                String.IsNullOrWhiteSpace(txtCidadeLoja.Text) ||
                String.IsNullOrWhiteSpace(txtNumeroLoja.Text) ||
                String.IsNullOrWhiteSpace(txtEstadoLoja.Text)

               )
            {
                MessageBox.Show("Existem campos em branco que precisam ser preenchidos!");
            }
            else
            {
                //aaaaaaaaaaaaa
            }*/
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {

        }
        
        private void btnPagar_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new FinanceiroUC(_frame); 
        }

        private void btnPagar_Click(object sender, RoutedEventArgs e)
        {
            PagamentoModel pagamento = new PagamentoModel
            {
                Id = _pagamento.Id,
                Status = "Pago"     
            };

            try
            {
                var dao = new PagamentoDAO();
                dao.Update(pagamento);
            }
            catch
            {

            }
        }

        private void carregarListagem()
        {
            try
            {
                var dao = new PagamentoDAO();
                _productsInGrid = dao.List();
                dtgExibirPag.ItemsSource = _productsInGrid;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
