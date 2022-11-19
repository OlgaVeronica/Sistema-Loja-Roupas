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
using Microsoft.Win32;

namespace LojaRoupa.Views.SubViews
{
    /// <summary>
    /// Interaction logic for CadastrarMarcaUC.xaml
    /// </summary>
    public partial class CadastrarMarcaUC : UserControl
    {
        private Frame _frame;
        private MarcaModel _marca = new MarcaModel();
        private ImageSource _imageSourceMarca;
        public CadastrarMarcaUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }
        public CadastrarMarcaUC(Frame frame, MarcaModel marca)
        {
            InitializeComponent();
            _frame = frame;
            _marca = marca;
            Loaded += CadastrarMarcaUC_Loaded;
        }

        private void CadastrarMarcaUC_Loaded(object sender, RoutedEventArgs e)
        {
            txtNome.Text = _marca.Nome;
            imgMarca.ImageSource = _marca.Logo != null ? new BitmapImage(new Uri(_marca.Logo)) : imgMarca.ImageSource;
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new MarcaUC(_frame);
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {


            MarcaModel marca = _marca;
            marca.Nome = txtNome.Text;
            marca.Logo = imgMarca.ImageSource.ToString();
            

            try
            {
                var dao = new MarcaDAO();

                if(marca.Id > 0)
                {
                    dao.Update(marca);
                    MessageBox.Show("Update Realizado!");
                }
                else
                {
                    dao.Insert(marca);
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
            txtNome.Clear();
            imgMarca.ImageSource = _imageSourceMarca;
        }

        private void btnEscolherImg_Click(object sender, RoutedEventArgs e)
        {
            _imageSourceMarca = imgMarca.ImageSource;
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files|*.bmp; *.jpg; *.png";
            openDialog.FilterIndex = 1;
            if (openDialog.ShowDialog() == true)
            {
                imgMarca.ImageSource = new BitmapImage(new Uri(openDialog.FileName));
            }
        }
    }
}
