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

namespace LojaRoupa.Views.SubViews
{
    /// <summary>
    /// Interaction logic for CadastrarMarcaUC.xaml
    /// </summary>
    public partial class CadastrarMarcaUC : UserControl
    {
        private Frame _frame;
        private MarcaModel _marca = new MarcaModel();
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
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new MarcaUC(_frame);
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {


            MarcaModel marca = _marca;
            marca.Nome = txtNome.Text;
            marca.Logo = txtLogo.Text;

            

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
            txtLogo.Clear();
        }
    }
}
