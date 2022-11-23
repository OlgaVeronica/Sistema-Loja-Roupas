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
using System.Windows.Shapes;
using LojaRoupa.ViewsModels;

namespace LojaRoupa.Views.SubViews
{
    /// <summary>
    /// Lógica interna para ReceberRecebimentoWindow.xaml
    /// </summary>
    public partial class ReceberRecebimentoWindow : Window
    {
        RecebimentoModel _recebimento;
        public ReceberRecebimentoWindow(RecebimentoModel recebimento)
        {
            InitializeComponent();
            _recebimento = recebimento;
            Loaded += ReceberRecebimentoWindow_Loaded;
        }

        private void ReceberRecebimentoWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}