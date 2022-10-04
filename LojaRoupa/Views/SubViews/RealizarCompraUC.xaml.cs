using LojaRoupa.DAOs;
using LojaRoupa.ViewsModels;
using MySql.Data.MySqlClient;
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
    /// Interação lógica para RealizarCompraUC.xam
    /// </summary>
    public partial class RealizarCompraUC : UserControl
    {
        public Frame _frame;
        private CompraModel _compra = new CompraModel();
        public RealizarCompraUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            Loaded += RealizarCompraUC_Loaded;
        }
        public RealizarCompraUC(Frame frame, CompraModel compra)
        {
            InitializeComponent();
            _frame = frame;
            _compra = compra;
            Loaded += RealizarCompraUC_Loaded;

        }
        private void RealizarCompraUC_Loaded(object sender, RoutedEventArgs e)
        {
            txtData.Text = _compra.Data;
            txtHora.Text = _compra.Hora;
            txtValor.Text = _compra.Valor;
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new FinanceiroUC(_frame);
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            CompraModel compra = _compra;
            compra.Data = txtData.Text;
            compra.Valor = txtValor.Text;
            compra.Hora = txtHora.Text;
            compra.Status = "Ativo";

            try
            {
                var dao = new CompraDAO();
                if (compra.Id > 0)
                {
                    dao.Update(compra);
                    MessageBox.Show("Update Realizado!");

                }
                else
                {
                    dao.Insert(compra);
                    MessageBox.Show("Cadastro Realizado!");

                }
            }
            catch (MySqlException error)
            {

                MessageBox.Show(error.Message);
            }

            Clear();
        }
        private void Clear()
        {
            txtData.Clear();
            txtHora.Clear();
            txtValor.Clear();
        }
    }
}
