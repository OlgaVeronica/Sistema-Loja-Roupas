using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaRoupa.ViewsModels
{
    public class PagamentoModel
    {
        public int Id { get; set; }
        public DateTime? Data { get; set; }
        public double Valor { get; set; }
        public  DateTime? Hora { get; set; }
        public string FormaPagamento { get; set; }
        public string Status { get; set; }

    }
}
