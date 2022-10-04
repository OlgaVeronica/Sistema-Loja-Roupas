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

namespace LojaRoupa.Views.SubViews
{
    /// <summary>
    /// Interação lógica para RealizarCompraUC.xam
    /// </summary>
    public partial class RealizarCompraUC : UserControl
    {
        public Frame _frame;
        public RealizarCompraUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new FinanceiroUC(_frame);
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
