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
    /// Interação lógica para FuncionarioUC.xam
    /// </summary>
    public partial class FuncionarioUC : UserControl
    {
        public Frame _frame;

        public FuncionarioUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }
    }
}
