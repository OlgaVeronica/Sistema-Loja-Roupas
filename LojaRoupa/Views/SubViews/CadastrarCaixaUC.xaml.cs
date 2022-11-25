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
    /// Interação lógica para CadastrarCaixaUC.xam
    /// </summary>
    public partial class CadastrarCaixaUC : UserControl
    {
        public Frame _frame;
        private CaixaModel _caixaModel = new CaixaModel();
        

        public CadastrarCaixaUC(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
            Loaded += CadastrarCaixaUC_Loaded;
            
        }

        private void CadastrarCaixaUC_Loaded(object sender, RoutedEventArgs e)
        {
            //txtSaldoIni.Text = _caixaModel.SaldoInicial.ToString();
            //txtSaldoFinal.Text = _caixaModel.SaldoFinal.ToString();
            //txtTotalEntrada.Text = _caixaModel.TotalEntrada.ToString();
            //txtTotalSaida.Text = _caixaModel.TotalSaida.ToString();
            //txtNumeroCaixa.Text = _caixaModel.Numero.ToString();
            //txtStatus.Text = _caixaModel.Status; 
            EnableAndDisableButtons();

            if (TodayHasCaixa())
            {
                AtualizarCaixa();
            }

        }

        private void EnableAndDisableButtons()
        {
            btnAbrirCaixa.IsEnabled = !TodayHasCaixa();
            btnFecharCaixa.IsEnabled = TodayHasCaixa();
        }

        private bool TodayHasCaixa()
        {
            var lista = new List<CaixaModel>();
            try
            {
                var dao = new CaixaDAO();
                lista = dao.List();
                foreach (var item in lista)
                {
                    if (item.DataCaixa == DateTime.Now.Date)
                    {
                        if (item.Status == "Aberto")
                        {
                            return true;

                        }
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao consultar caixas {ex.Message}");
                return true;
            }

            
        }



        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            _frame.Content = new CaixaUC(_frame);
        }

        private void btnAbrirCaixa_Click(object sender, RoutedEventArgs e)
        {
            CaixaModel caixa = new CaixaModel();
            AbrirCaixaWindow tela = new AbrirCaixaWindow(caixa);
            tela.ShowDialog();

            AtualizarCaixa();




        }
        private void AtualizarCaixa()
        {

            try
            {
                var dao = new CaixaDAO();
                CaixaModel caixa = dao.UltimoCaixa();

                if (caixa == null) return;

                MessageBox.Show(caixa.Id.ToString());
                txtNumeroCaixa.Text = caixa.Numero.ToString();
                txtSaldoFinal.Text = caixa.SaldoFinal.ToString("0.00");
                txtSaldoIni.Text = caixa.SaldoInicial.ToString("0.00");
                txtStatus.Text = caixa.Status;
                txtTotalEntrada.Text = caixa.TotalEntrada.ToString("0.00");
                txtTotalSaida.Text = caixa.TotalSaida.ToString("0.00");
                dtpData.SelectedDate = caixa.DataCaixa;

                EnableAndDisableButtons();
            }
            catch
            {
                MessageBox.Show("Erro ao consultar Caixas", "Erro na listagem");
            }
        }

        private void btnFecharCaixa_Click(object sender, RoutedEventArgs e)
        {
            int numero = int.Parse(txtNumeroCaixa.Text);



            try
            {
                var dao = new CaixaDAO();
                dao.fecharCaixa(numero);
            }
            catch
            {
                MessageBox.Show("Não foi possível fechar o caixa");
            }
            finally
            {
                AtualizarCaixa();
            }
        }
    }
}
