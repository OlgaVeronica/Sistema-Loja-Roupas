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

namespace LojaRoupa.Views
{
    /// <summary>
    /// Interação lógica para VendaUC.xam
    /// </summary>
    public partial class VendaUC : UserControl
    {
        public Frame _frame;

        public VendaUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }


        private void btnRealizar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
