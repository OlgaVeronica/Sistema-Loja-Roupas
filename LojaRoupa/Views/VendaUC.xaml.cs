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
using LojaRoupa.ViewsModels;
using LojaRoupa.DAOs;
using MySql.Data.MySqlClient;

namespace LojaRoupa.Views
{
    /// <summary>
    /// Interação lógica para VendaUC.xam
    /// </summary>
    public partial class VendaUC : UserControl
    {
        private Frame _frame;
        private VendaModel _venda = new VendaModel();
        public  List<ProdutoModel> productsInGrid = new List<ProdutoModel>();

        public VendaUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;

            dtpData.IsEnabled = false;
            dtpData.SelectedDate = DateTime.Now;

            carregarListagemFuncionario();
            carregarListagemCliente();
            carregarListagemProdutos()
;        }

        private void carregarListagemFuncionario()
        {
            try
            {
                var dao = new FuncionarioDAO();
                cbFuncionario.ItemsSource = dao.List();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void carregarListagemCliente()
        {
            try
            {
                var dao = new ClienteDAO();
                cbCliente.ItemsSource = dao.List();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void carregarListagemProdutos()
        {
            try
            {
                var dao = new ProdutoDAO();
                cbProdutos.ItemsSource = dao.List();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRealizar_Click(object sender, RoutedEventArgs e)
        {
            VendaModel venda = new VendaModel();
            venda.Funcionario = cbFuncionario.SelectedItem as FuncionarioModel;
            venda.Cliente = cbCliente.SelectedItem as ClienteModel;
            venda.Produto = cbProdutos.ItemsSource as ProdutoModel[];
            venda.Data = dtpData.SelectedDate;
            venda.Valor = float.Parse(txtValor.Text);

            var dao = new VendaDAO();
            dao.Insert(venda);
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {

        }

        
        private void btAdicionar_Click(object sender, RoutedEventArgs e)
        {
            productsInGrid.Add(cbProdutos.SelectedItem as ProdutoModel);
            dtgProdutos.ItemsSource = productsInGrid;

        }
    }
}
