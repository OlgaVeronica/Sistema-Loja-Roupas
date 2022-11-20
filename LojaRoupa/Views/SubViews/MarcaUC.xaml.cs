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
    /// Interaction logic for MarcaUC.xaml
    /// </summary>
    public partial class MarcaUC : UserControl
    {
        private Frame _frame;
        public MarcaUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            carregarListagem();
        }
       



        private void carregarListagem()
        {
            try
            {
                var dao = new MarcaDAO();
                dtgMarca.ItemsSource = dao.List();

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
                _frame.Content = new CadastrarMarcaUC(_frame);
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new ProdutoUC(_frame);
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {
            MarcaModel marca = dtgMarca.SelectedItem as MarcaModel;
            try
            {
                var dao = new MarcaDAO();
                var resposta = MessageBox.Show("Deseja mesmo deletar esse registro?", "Confirmação", MessageBoxButton.YesNo);

                if(resposta == MessageBoxResult.Yes)
                {
                    dao.Delete(marca);
                    carregarListagem();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            MarcaModel marca = dtgMarca.SelectedItem as MarcaModel;
            _frame.Content = new CadastrarMarcaUC(_frame, marca);

        }
    }
}
