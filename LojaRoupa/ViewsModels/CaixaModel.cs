using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupa.ViewsModels
{
    public class CaixaModel
    {
        public int? Id { get; set; }
        public int Numero { get; set; }
        public DateTime? DataCaixa { get; set; }
        public string HoraAbertura { get; set; }
        public string HoraFechamento { get; set; }
        public double SaldoInicial { get; set; }
        public double SaldoFinal { get; set; }
        public double TotalEntrada { get; set; }
        public double TotalSaida { get; set; }
        public string Status { get; set; }
       
    }
}
