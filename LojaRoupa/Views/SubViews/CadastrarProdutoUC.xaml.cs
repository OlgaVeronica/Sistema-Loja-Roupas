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
using LojaRoupa.ViewsModels;
using LojaRoupa.DAOs;
using MySql.Data.MySqlClient;

namespace LojaRoupa.Views.SubViews
{
    /// <summary>
    /// Interaction logic for CadastrarProdutoUC.xaml
    /// </summary>
    public partial class CadastrarProdutoUC : UserControl
    {
        private Frame _frame;
        public CadastrarProdutoUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            ProdutoModel produto = new ProdutoModel();

            produto.Descricao = txtDescricao.Text;
            produto.Tecido = txtTecido.Text;
            produto.Tipo = txtTipo.Text;
            produto.Colecao = txtColecao.Text;
            produto.Tamanho = txtTamanho.Text;
            produto.Estampa = txtEstampa.Text;
            produto.Status = "ativo";

            try
            {
                var dao = new ProdutoDAO();
                dao.Insert(produto);
                MessageBox.Show("Cadastro Realizado!");
            }
            catch (MySqlException error)
            {

                MessageBox.Show(error.Message);
            }

            Clear();
        }

        private void Clear()
        {
            txtDescricao.Clear();
            txtTecido.Clear();
            txtTipo.Clear();
            txtColecao.Clear();
            txtTamanho.Clear();
            txtEstampa.Clear();
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new ProdutoUC(_frame);
        }
    }
}
